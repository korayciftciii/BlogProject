using AutoMapper;
using Entities.Models;
using Entities.DataTransferObject;

namespace webApi.Infrastructure.AutoMapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDtoForUpdate,Category>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDtoForInsertion, Category>();
            CreateMap<BlogDtoForUpdate,Blog>().ReverseMap();
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDtoForInsertion, Blog>();
            CreateMap<SubscribeMail, SubscribeMailDto>();
            CreateMap<SubscribeMailDtoForInsertion, SubscribeMail>();
            //CreateMap<SubscribeMailDtoForUpdate, SubscribeMail>().ReverseMap();
        }
    }
}
