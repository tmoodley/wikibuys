﻿using PagedList;
using seoWebApplication.Models;
using seoWebApplication.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace seoWebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        private StoreService _StoreService = new StoreService();
        private ProductService _productService = new ProductService();
        private CategoriesService _categoriesService = new CategoriesService();
        protected IPagedList<mProducts> GetPagedDepartments(int? page, string name)
        {
            try
            {
                // return a 404 if user browses to before the first page
                if (page.HasValue && page < 1)
                    return null;

                Departments department = new DepartmentService().GetDepartmentsByName(name);


                if (department != null)
                {
                    IList<mProducts> products = _productService.GetProductsByDepartmentGuid(department.Id);
                    // page the list
                    const int pageSize = 20;
                    var listPaged = products.ToPagedList(page ?? 1, pageSize);

                    // return a 404 if user browses to pages beyond last page. special case first page if no items exist
                    if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                        return null;


                    return listPaged;
                }
                else
                {
                    return null;
                }



            }
            catch
            {
                return null;
            }

        }
        protected IPagedList<mProducts> GetPagedSubcategory(int? page, string name)
        {
            try
            {
                // return a 404 if user browses to before the first page
                if (page.HasValue && page < 1)
                    return null;

                Subcategories category = new SubcategoriesService().GetCategories(name);
                
                if (category != null)
                {
                    IList<mProducts> products = _productService.GetProductsByCategoryGuid(category.Id);
                    // page the list
                    const int pageSize = 20;
                    var listPaged = products.ToPagedList(page ?? 1, pageSize);

                    // return a 404 if user browses to pages beyond last page. special case first page if no items exist
                    if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                        return null;


                    return listPaged;
                }
                else
                {
                    return null;
                }



            }
            catch
            {
                return null;
            }

        }
        protected IPagedList<mProducts> GetPagedCategory(int? page, string name)
        {
            try
            {
                // return a 404 if user browses to before the first page
                if (page.HasValue && page < 1)
                    return null;

                Categories category = new CategoriesService().GetCategoryByName(name);


                if (category != null)
                {
                    IList<mProducts> products = _productService.GetProductsByCategoryGuid(category.Id);
                    // page the list
                    const int pageSize = 20;
                    var listPaged = products.ToPagedList(page ?? 1, pageSize);

                    // return a 404 if user browses to pages beyond last page. special case first page if no items exist
                    if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                        return null;


                    return listPaged;
                }
                else
                {
                    return null;
                }



            }
            catch
            {
                return null;
            }

        }
        protected IPagedList<mProducts> GetPagedBrands(int? page, string name)
        {
            try
            {
                // return a 404 if user browses to before the first page
                if (page.HasValue && page < 1)
                    return null;

                Brands brand = new BrandsService().GetBrandByName(name);
                if (brand != null)
                {
                    List<mProducts> products = _productService.GetProductsByBrand(brand.Id);
                    // page the list
                    const int pageSize = 20;
                    var listPaged = products.ToPagedList(page ?? 1, pageSize);

                    // return a 404 if user browses to pages beyond last page. special case first page if no items exist
                    if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                        return null;


                    return listPaged;
                }
                else {
                    return null;
                }
                

               
            }
            catch {
                return null;
            }
           
        }

        protected IPagedList<mProducts> GetPagedNames(int? page, string name)
        {
            // return a 404 if user browses to before the first page
            if (page.HasValue && page < 1)
                return null;

            var storeId = _StoreService.Getstores(name).Id;
            List<mProducts> products = _productService.GetProductsByStore(storeId);

            // page the list
            const int pageSize = 20;
            var listPaged = products.ToPagedList(page ?? 1, pageSize);

            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }

        protected IPagedList<mProducts> GetPagedSearch(int? page, string name)
        {
            // return a 404 if user browses to before the first page
            if (page.HasValue && page < 1)
                return null;
             
            List<mProducts> products = _productService.GetProductsBySearch(name);

            // page the list
            const int pageSize = 20;
            var listPaged = products.ToPagedList(page ?? 1, pageSize);

            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }

        protected IPagedList<mProducts> GetPromoPage(int? page)
        {
            // return a 404 if user browses to before the first page
            if (page.HasValue && page < 1)
                return null;

            IList<mProducts> products = _productService.GetProductsOnFrontPromo();
            var orderList = products.OrderByDescending(x => x.LikesCount).OrderByDescending(x => x.InsertDate);
            // page the list
            const int pageSize = 18;
            var listPaged = orderList.ToPagedList(page ?? 1, pageSize);

            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }

        protected IPagedList<mProducts> GetPagedUser(int? page, string id)
        {
            // return a 404 if user browses to before the first page
            if (page.HasValue && page < 1)
                return null;
             
            IList<mProducts> products = _productService.GetProductsByUserId(id);

            // page the list
            const int pageSize = 20;
            var listPaged = products.ToPagedList(page ?? 1, pageSize);

            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }

        // in this case we return IEnumerable<string>, but in most
        // - DB situations you'll want to return IQueryable<string>
        protected IEnumerable<string> GetStuffFromDatabase()
        {
            var sampleData = new StreamReader(Server.MapPath("~/App_Data/Names.txt")).ReadToEnd();
            return sampleData.Split('\n');
        }
    }
}