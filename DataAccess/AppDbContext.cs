using DataAccess.Entities;
using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 
           

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


              

            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   Id = 1,
                   Name = "Admin",
                   CreateDate = DateTime.Now,
                   CreateUserId = 1,
                   UpdateUserId = null,
                   UpdateDate = null
               });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 2,
                    Name = "User",
                    CreateDate = DateTime.Now,
                    CreateUserId = 1,
                    UpdateUserId = null,
                    UpdateDate = null
                }
                );
            var salt = Crypto.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
              new User
              {
                  Id = 1,
                  Username = "admin",
                  Salt = salt,
                  PasswordHash = Crypto.GenerateSHA256Hash("admin2004", salt),
                  RoleId = 1,
                  CreateDate = DateTime.Now,
                  CreateUserId = 1,
                  UpdateUserId=null,
                  UpdateDate = null
                  
              }
              );





            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Ant-Man",
                   Price = 7.50,
                   ImgPath = "~/image/AntMan.jpg",
                   IMDbRating = 7.3,
                   Note = "Description",
                   CreateDate = DateTime.Now,
                   CreateUserId = 1
               });



            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 2,
                   Name = "Don't Look Up",
                   Price = 8.00,
                   ImgPath = "~/image/Don'tLookUp.jpg",
                   IMDbRating = 7.2,
                   Note = "Description",
                   CreateDate = DateTime.Now,
                   CreateUserId = 1
               });


            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 3,
                   Name = "Dunkirk",
                   Price = 10.00,
                   ImgPath = "~/image/Dunkirk.jpg",
                   IMDbRating = 7.8,
                   Note = "Description",
                   CreateDate = DateTime.Now,
                   CreateUserId = 1
               });


            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 4,
                   Name = "Enola Holmes",
                   Price = 6.00,
                   ImgPath = "~/image/EnolaHolmes.jpg",
                   IMDbRating = 6.6,
                   Note = "Description",
                   CreateDate = DateTime.Now,
                   CreateUserId = 1
               });


            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 5,
                  Name = "Flatliners",
                  Price = 6.00,
                  ImgPath = "~/image/FlatLiners.jpg",
                  IMDbRating = 6.5,
                  Note = "Description",
                  CreateDate = DateTime.Now,
                  CreateUserId = 1
              });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 6,
                Name = "Interstellar",
                Price = 10.00,
                ImgPath = "~/image/Interstellar.jpg",
                IMDbRating = 8.6,
                Note = "Description",
                CreateDate = DateTime.Now,
                CreateUserId = 1
            });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 7,
                Name = "Joker",
                Price = 5.00,
                ImgPath = "~/image/Joker.jpg",
                IMDbRating = 8.4,
                Note = "Description",
                CreateDate = DateTime.Now,
                CreateUserId = 1
            });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 8,
                Name = "The Incredibles",
                Price = 4.50,
                ImgPath = "~/image/TheIncredibles.jpg",
                IMDbRating = 8.0,
                Note = "Description",
                CreateDate = DateTime.Now,
                CreateUserId = 1
            });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 9,
                Name = "The Platform",
                Price = 8.50,
                ImgPath = "~/image/ThePlatform.jpg",
                IMDbRating = 7.0,
                Note = "Description",
                CreateDate = DateTime.Now,
                CreateUserId = 1
            });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 10,
                Name = "Thor: Love and Thunder",
                Price = 6.00,
                ImgPath = "~/image/ThorLoveandThunder.jpg",
                IMDbRating = 6.5,
                Note = "Description",
                CreateDate = DateTime.Now,
                CreateUserId = 1
            });


        }
    }
}
