namespace TaobaoExpress
{
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using TaobaoExpress.DataAccess.Context;
    using TaobaoExpress.Model.Core;
    using TaobaoExpress.Services.Core;
    using TaobaoExpress.Services.Product;

    public class ObjectFactory
    {
        private static bool notYetInitialized = true;

        public static IServiceLocator Instance
        {
            get
            {
                if (ObjectFactory.notYetInitialized)
                {
                    var locator = new UnityServiceLocator(ObjectFactory.ConfigureUnityContainer());
                    ServiceLocator.SetLocatorProvider(() => locator);
                    ObjectFactory.notYetInitialized = false;
                }

                return ServiceLocator.Current;
            }
        }

        public static IUnityContainer ConfigureUnityContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<TaobaoExpressContext>();
            unityContainer.RegisterType<IModelService<Product>, ModelService<Product>>();
            unityContainer.RegisterType<IModelService<Picture>, ModelService<Picture>>();
            unityContainer.RegisterType<IProductCreationService, ProductCreationService>();
            return unityContainer;
        }
    }
}