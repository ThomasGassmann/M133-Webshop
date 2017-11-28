namespace TaobaoExpress
{
    using AutoMapper;
    using Microsoft.Practices.Unity;
    using System;
    using System.Linq;
    using System.Web.UI;
    using TaobaoExpress.Model.Core;
    using TaobaoExpress.Model.Dto;
    using TaobaoExpress.Services.Core;

    public partial class _Default : Page
    {
        [Dependency]
        public IModelService<Product> ProductService { get; set; }

        public ProductDto[] Products { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var fetchedProducts = this.ProductService
                .Query()
                .ToList()
                .Select(x => Mapper.Map<Product, ProductDto>(x));
            this.Products = fetchedProducts.ToArray();
        }
    }
}