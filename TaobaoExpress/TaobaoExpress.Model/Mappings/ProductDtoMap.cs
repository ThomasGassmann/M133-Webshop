namespace TaobaoExpress.Model.Mappings
{
    using AutoMapper;
    using TaobaoExpress.Model.Core;
    using TaobaoExpress.Model.Dto;

    public class ProductDtoMap : Profile
    {
        public ProductDtoMap()
        {
            this.CreateMap<Product, ProductDto>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Created, x => x.MapFrom(y => y.Created))
                .ForMember(x => x.ImageData, x => x.MapFrom(y => y.Picture.Data))
                .ForMember(x => x.MarkdownDescription, x => x.MapFrom(y => y.MarkdownDescription))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.Title, x => x.MapFrom(y => y.Title));
        }
    }
}
