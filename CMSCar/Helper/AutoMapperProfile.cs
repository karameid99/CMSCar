using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.DTOs.SubFS;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models.Contact;
using CMSCar.Areas.CPanel.Models.FundingBodies;
using CMSCar.Areas.CPanel.Models.Home;
using CMSCar.Areas.CPanel.Models.PurchaseOrders;
using CMSCar.Areas.CPanel.Models.Questions;
using CMSCar.Areas.CPanel.Models.Services;
using CMSCar.Areas.CPanel.Models.Sliders;
using CMSCar.Areas.CPanel.Models.SpecialOffers;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Models.ViewModels;
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
            CreateMap<Offer, CMSCar.Areas.CPanel.ViewModels.OfferVM>().ForMember(x => x.CreateAt, p =>
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
            CreateMap<CarDTO, Car>().ReverseMap();
            CreateMap <ColorCarDTO, ColorCar>().ReverseMap();
            CreateMap <ColorCarDTOEdit, ColorCar>().ReverseMap();
            CreateMap <ColorCar, ColorCarUpdateDTO>().ReverseMap();
            CreateMap<Car, CarVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<IndividualCash, IndividualCashVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<CompanyCash, CashCompanyVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<IndividualFinance, IndividualFinanceVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<CompanyFinance, CompanyFinanceVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));

            CreateMap<ServiceOrder, ServiceOrderVM>().ForMember(x => x.CreatedAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy"))).ForMember(x => x.ServiceName, p =>
            p.MapFrom(m => m.Service.NameAr));

            CreateMap<Question, QuestionVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<QuestionDTO, Question>().ReverseMap();

            CreateMap<Service, ServiceVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<ServiceDTO, Service>().ReverseMap();

            CreateMap<WhyUs, WhyUsVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<WhyUsDTO, WhyUs>().ReverseMap();

            CreateMap<FininceSide, FininceSideVM>().ForMember(x => x.CreateAt, p =>
            p.MapFrom(m => m.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<FininceSideDTO, FininceSide>().ReverseMap();

            CreateMap<Car, CarShowVM>();
            CreateMap<FeteureCreateDTO, FeatureCar>();
            CreateMap<FeteureUpdateDTO, FeatureCar>().ReverseMap();
            CreateMap<SpecificationUpdateDTO, SpecificationCar>().ReverseMap();
            CreateMap<SpecificationCreateDTO, SpecificationCar>();

            CreateMap<SubSpecificationCarDTO, SubSpecificationCar>();
            CreateMap<SubSpecificationCarUpdateDTO, SubSpecificationCar>().ReverseMap();

            CreateMap<SubFeatureCarDTO, SubFeatureCar>();
            CreateMap<SubFeatureCarUpdateDTO, SubFeatureCar>().ReverseMap();

            CreateMap<SliderDTO, Slider>().ReverseMap();
            CreateMap<Car, CarDetalesVM>().ReverseMap();

        }
    }
}
