using AutoMapper;
using TravelProject.Dto.AboutUsDtos;
using TravelProject.Dto.AdminDtos;
using TravelProject.Dto.BlogDtos;
using TravelProject.Dto.CommentDtos;
using TravelProject.Dto.ContactDtos;
using TravelProject.Dto.HomePageDtos;
using TravelProject.Entity.Entities;

namespace TravelProject.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Blog, ResultBlogDto>().ReverseMap();
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();

            CreateMap<AboutUs, ResultAboutUsDto>().ReverseMap();
            CreateMap<AboutUs, CreateAboutUsDto>().ReverseMap();
            CreateMap<AboutUs, UpdateAboutUsDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            CreateMap<HomePage, ResultHomePageDto>().ReverseMap();
            CreateMap<HomePage, CreateHomePageDto>().ReverseMap();
            CreateMap<HomePage, UpdateHomePageDto>().ReverseMap();

            CreateMap<Admin, ResultAdminDto>();


        }
    }
}