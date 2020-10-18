using System;
using System.Collections.Generic;
using System.Text;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models.Contact;
using CMSCar.Areas.CPanel.Models.Home;
using CMSCar.Areas.CPanel.Models.PurchaseOrders;
using CMSCar.Areas.CPanel.Models.Questions;
using CMSCar.Areas.CPanel.Models.Services;
using CMSCar.Areas.CPanel.Models.Settings;
using CMSCar.Areas.CPanel.Models.SpecialOffers;
using CMSCar.Areas.CPanel.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMSCar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OfferCar>().HasKey(x => new { x.CarId, x.OfferId });
        }
        #region Cars
        public DbSet<Car> Car { get; set; }
        public DbSet<CarImage> CarImage { get; set; }
        public DbSet<CarType> CarType { get; set; }
        public DbSet<ColorCar> ColorCar { get; set; }
        public DbSet<ColorImage> ColorImage { get; set; }
        public DbSet<FeatureCar> FeatureCar { get; set; }
        public DbSet<SpecificationCar> SpecificationCar { get; set; }
        public DbSet<SubCarType> SubCarType { get; set; }
        public DbSet<SubFeatureCar> SubFeatureCar { get; set; }
        public DbSet<SubSpecificationCar> SubSpecificationCar { get; set; }
        #endregion
        #region Contact
        public DbSet<Branch> Branch { get; set; }
        public DbSet<CallUs> CallUs { get; set; }
        public DbSet<City> City { get; set; }
        #endregion
        #region PurchaseOrders
        public DbSet<CarOrderCash> CarOrderCash { get; set; }
        public DbSet<CarOrderFinance> CarOrderFinance { get; set; }
        public DbSet<CompanyFinance> CompanyFinance { get; set; }
        public DbSet<CompanyCash> CompanyCash { get; set; }
        public DbSet<IndividualCash> IndividualCash { get; set; }
        public DbSet<IndividualFinance> IndividualFinance { get; set; }
        public DbSet<ServiceOrder> ServiceOrder { get; set; }
        #endregion
        #region Questions
        public DbSet<Question> Question { get; set; }
        #endregion
        #region Services
        public DbSet<Service> Service { get; set; }
        #endregion
        #region Settings
        public DbSet<Information> Information { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<WhoWeAre> WhoWeAre { get; set; }
        #endregion
        #region SpecialOffers
        public DbSet<Offer> Offer { get; set; }
        public DbSet<OfferCar> OfferCar { get; set; }
        #endregion
        #region Home
        public DbSet<FininceSide> FininceSide { get; set; }
        #endregion

    }
}
