namespace TaobaoExpress
{
    using System;
    using System.Web.UI;
    using TaobaoExpress.Model.Core;
    using TaobaoExpress.Services.Core;

    public partial class _Default : Page
    {
        private IModelService<Product> modelService;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.modelService = ObjectFactory.Instance.GetInstance<IModelService<Product>>();
        }
    }
}