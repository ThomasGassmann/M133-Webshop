namespace TaobaoExpress.Services.Product
{
    using System.Drawing;

    public interface IProductCreationService
    {
        long CreateProduct(string title, string markdown, double price, Image picture);
    }
}
