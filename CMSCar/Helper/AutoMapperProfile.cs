using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models.Contact;
using CMSCar.Areas.CPanel.Models.SpecialOffers;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserVM>().ForMember(x => x.CreatedAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<UserDTO, ApplicationUser>().ReverseMap();
            CreateMap<CarType, CarTypeVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<CarTypeDTO, CarType>().ReverseMap();
            CreateMap<SubCarType, SubCarTypeVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<SubCarTypeDTO, SubCarType>();
            CreateMap<SubCarTypeUpdateDTO, SubCarType>().ReverseMap();
            CreateMap<Offer, OfferVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<OfferDTO, Offer>().ReverseMap();
            CreateMap<CallUs, CallUsVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<City, CityVM>().ForMember(x => x.CreateAt, p =>
           p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<Branch, BranchVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<BranchDTO, Branch>();
            CreateMap<BranchUpdateDTO, Branch>().ReverseMap();
            CreateMap <Car, CarVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
        }
    }
}
