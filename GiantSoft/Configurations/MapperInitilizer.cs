using AutoMapper;
using GiantSoft.Data;
using GiantSoft.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Configurations
{
    /// <summary>
    /// Inherits from Profile(automapper). we have constructor. In constructor
    /// we have to define all the Mappings. Domain class Brand is going to map 
    /// to BrandDTO, CreateBrandDTO, UpdateBrandDTO and from them back to Brand domain object
    /// </summary>
    public class MapperInitilizer: Profile
    {
        public MapperInitilizer()
        {
            //this basically says that Brand class has direct correlation to BrandDTO fields. and they go in either direction
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            CreateMap<Brand, UpdateBrandDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<ApiUser, UserDTO>().ReverseMap();

            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<Feedback, CreateFeedbackDTO>().ReverseMap();
            CreateMap<Feedback, UpdateFeedbackDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<Journal, JournalDTO>().ReverseMap();
            CreateMap<Journal, CreateJournalDTO>().ReverseMap();
            CreateMap<Journal, UpdateJournalDTO>().ReverseMap();

            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<Image, CreateImageDTO>().ReverseMap();
            CreateMap<Image, UpdateImageDTO>().ReverseMap();

            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Payment, CreatePaymentDTO>().ReverseMap();
            CreateMap<Payment, UpdatePaymentDTO>().ReverseMap();

            CreateMap<Whishlist, WhishlistDTO>().ReverseMap();
            CreateMap<Whishlist, CreateWhishlistDTO>().ReverseMap();
            CreateMap<Whishlist, UpdateWhishlistDTO>().ReverseMap();

            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap();
        }

    }
}
