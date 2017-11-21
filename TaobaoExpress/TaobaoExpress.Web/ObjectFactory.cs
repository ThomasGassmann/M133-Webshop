namespace TaobaoExpress
{
    using CommonServiceLocator;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.UI;
    using TaobaoExpress.DataAccess.Context;
    using TaobaoExpress.Model.Core;
    using TaobaoExpress.Services.Core;
    using Unity;
    using Unity.ServiceLocation;

    public class ObjectFactory : PageHandlerFactory
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

        public override IHttpHandler GetHandler(HttpContext cxt,
            string type, string vPath, string path)
        {
            var page = base.GetHandler(cxt, type, vPath, path);

            if (page != null)
            {
                ObjectFactory.InjectDependencies(page);
            }

            return page;
        }

        private static object GetInstance(Type type)
        {
            return ServiceLocator.Current.GetInstance(type);
        }

        private static void InjectDependencies(object page)
        {
            Type pageType = page.GetType().BaseType;

            var ctor = GetInjectableCtor(pageType);

            if (ctor != null)
            {
                var arguments =
                    (from parameter in ctor.GetParameters()
                    select GetInstance(parameter.ParameterType))
                    .ToArray();

                ctor.Invoke(page, arguments);
            }
        }

        private static ConstructorInfo GetInjectableCtor(Type type)
        {
            var overloadedPublicConstructors = (
                from constructor in type.GetConstructors()
                where constructor.GetParameters().Length > 0
                select constructor).ToArray();

            if (overloadedPublicConstructors.Length == 0)
            {
                return null;
            }

            if (overloadedPublicConstructors.Length == 1)
            {
                return overloadedPublicConstructors[0];
            }

            throw new Exception(string.Format(
                "The type {0} has multiple public " +
                "ctors and can't be initialized.", type));
        }

        private static IUnityContainer ConfigureUnityContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<TaobaoExpressContext>();
            unityContainer.RegisterType<IModelService<Product>, ModelService<Product>>();
            unityContainer.RegisterType<IModelService<Picture>, ModelService<Picture>>();
            return unityContainer;
        }
    }
}