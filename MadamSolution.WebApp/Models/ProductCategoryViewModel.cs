using MadamSolution.ViewModels.Catalog.Categories;
using MadamSolution.ViewModels.Catalog.Products;
using MadamSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadamSolution.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVm> Products { get; set; }
    }
}