using DTO;
using Helper.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstract;
using System.Diagnostics;

namespace Presentation.Controllers
{
    [Authorize(Roles = RoleKeywords.AdminRole)]
    public class AdminProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;


        public AdminProductController(IProductService productService,IUserService userService)
        {
            this.productService = productService;
            this.userService = userService;
        }


        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers(int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null)
        {
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;
            //to save search text in input


            var res = userService.GetFilter(page, pageSize, order, search);

            var allProductsCount = res.Count();
            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }
            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }


            ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
            ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;


            var pagedRs = new PagedResponseDTO<UserDTO>(page, pageSize, res);
            return View(pagedRs);
        }

        [HttpGet("User/Get/{id}")]
        public IActionResult Get(int id, string message = null, bool isSuccess = true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                    ViewBag.Success = message;
                else
                    ViewBag.Error = message;
            }


            var res = userService.Get(id);

            if (res == null)
            {
                ViewBag.Error = "Not Found!";
                return View();
            }
            return View(res);
        }


        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            userService.Delete(id);
            return RedirectToAction("Index");
        }







        [HttpGet("{id}")]
        public IActionResult Update(int id)
        {
            var res = productService.Get(id);
            return View(res);
        }        


        [HttpPost]
        public IActionResult UpdateDTO(ProductDTO product)
        {
           
            var res = productService.Update(product);

            return View("Update", res);
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Add(ProductDTO product)
        {
            
            productService.Create(product);

            return View();
        }




        [HttpGet]
        public IActionResult GetAll(int page = 1, int pageSize = 4, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null, bool changeSort = false)
        {
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;


            int allProductsCount;
            var res = productService.GetFilter(out allProductsCount, page, pageSize, order, search);

            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }
            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }

            if (changeSort)
            {
                ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
                ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;
            }
            else
            {
                ViewBag.NameSort = order;
                ViewBag.PriceSort = order;
            }

            var pagedRs = new PagedResponseDTO<ProductDTO>(page, pageSize, res);

            return View(pagedRs);
        }

    }
}
