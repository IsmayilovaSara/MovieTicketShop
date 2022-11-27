using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstract;
using Services.Config;



AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<AppDbContext>(opt =>
			opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"),
			x => x.MigrationsAssembly("DataAccess")
		  )
	  );

var mapperConfig = new MapperConfiguration(mc =>
	mc.AddProfile(new MapperProfile())
);

builder.Services.AddSingleton(mapperConfig.CreateMapper());


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(opt =>
	{
		opt.LoginPath = "/Login/SignIn";
		opt.Cookie.HttpOnly = true;
		opt.Cookie.Name = "AuthCookie";
		opt.Cookie.MaxAge = TimeSpan.FromHours(1);		
	});


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.Run();
