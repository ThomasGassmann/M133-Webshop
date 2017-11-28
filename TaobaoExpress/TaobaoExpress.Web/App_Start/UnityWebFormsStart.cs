[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(TaobaoExpress.App_Start.UnityWebFormsStart), "PostStart")]
namespace TaobaoExpress.App_Start
{
    using AutoMapper;
    using System.Web;
    using TaobaoExpress.Model.Mappings;
    using Unity.WebForms;

    internal static class UnityWebFormsStart
	{
		internal static void PostStart()
		{
            Mapper.Initialize(x => x.AddProfile<ProductDtoMap>());
            var container = ObjectFactory.ConfigureUnityContainer();
			HttpContext.Current.Application.SetContainer(container);
		}
	}
}