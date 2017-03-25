namespace LostAndFound.Web.Migrations
{
    using Data.Entities;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LostAndFound.Web.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LostAndFound.Web.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Item Types
            TypeOfItem atm = new TypeOfItem { Name = "ATM/Debit Card", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(atm);
            TypeOfItem bag = new TypeOfItem { Name = "Bags/Backpacks", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(bag);
            TypeOfItem bike = new TypeOfItem { Name = "Bicycle Items", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(bike);
            TypeOfItem binoculars = new TypeOfItem { Name = "Binoculars", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(binoculars);
            TypeOfItem blankets = new TypeOfItem { Name = "Blankets", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(blankets);
            TypeOfItem book = new TypeOfItem { Name = "Book", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(book);
            TypeOfItem briefcase = new TypeOfItem { Name = "Briefcase", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(briefcase);
            TypeOfItem cd = new TypeOfItem { Name = "CD/CD Cases", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(cd);
            TypeOfItem calculator = new TypeOfItem { Name = "Calculator", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(calculator);
            TypeOfItem cameras = new TypeOfItem { Name = "Cameras", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(cameras);
            TypeOfItem casette = new TypeOfItem { Name = "Casette Tape", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(casette);
            TypeOfItem casettePlayer = new TypeOfItem { Name = "Casette Player", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(casettePlayer);
            TypeOfItem cellPhone = new TypeOfItem { Name = "Cellphone", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(cellPhone);
            TypeOfItem cellphoneCharger = new TypeOfItem { Name = "Cellphone Charger/Adapter", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(cellphoneCharger);
            TypeOfItem childrenCloth = new TypeOfItem { Name = "Childrens Clothes", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(childrenCloth);
            TypeOfItem clothing = new TypeOfItem { Name = "Cloathing", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(clothing);
            TypeOfItem coat = new TypeOfItem { Name = "Coat/Jacket", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(coat);
            TypeOfItem computerPower = new TypeOfItem { Name = "Computer Power Cord/Adapter", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(computerPower);
            TypeOfItem cc = new TypeOfItem { Name = "Credit card", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(cc);
            TypeOfItem dentures = new TypeOfItem { Name = "Dentures", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(dentures);
            TypeOfItem electronics = new TypeOfItem { Name = "Electronics", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(electronics);
            TypeOfItem eyeGlasses = new TypeOfItem { Name = "Eyeglasses", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(eyeGlasses);
            TypeOfItem foldingChair = new TypeOfItem { Name = "Folding Chair", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(foldingChair);
            TypeOfItem gloves = new TypeOfItem { Name = "Gloves/Mittens", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(gloves);
            TypeOfItem hats = new TypeOfItem { Name = "Hats", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(hats);
            TypeOfItem headhpones = new TypeOfItem { Name = "Head Phones", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(headhpones);
            TypeOfItem id = new TypeOfItem { Name = "ID", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(id);
            TypeOfItem jewelry = new TypeOfItem { Name = "Jewelry", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(jewelry);
            TypeOfItem keys = new TypeOfItem { Name = "Keys", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(keys);
            TypeOfItem laptop = new TypeOfItem { Name = "Laptop Computer", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(laptop);
            TypeOfItem luggage = new TypeOfItem { Name = "Luggage", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(luggage);
            TypeOfItem mp3 = new TypeOfItem { Name = "MP3/Video Player", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(mp3);
            TypeOfItem musical = new TypeOfItem { Name = "Musical Instrument", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(musical);
            TypeOfItem notebooks = new TypeOfItem { Name = "Notebooks", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(notebooks);
            TypeOfItem pda = new TypeOfItem { Name = "PDA", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(pda);
            TypeOfItem passport = new TypeOfItem { Name = "Passport", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(passport);
            TypeOfItem purses = new TypeOfItem { Name = "Purses/Handbags", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(purses);
            TypeOfItem radio = new TypeOfItem { Name = "Radio", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(radio);
            TypeOfItem scarves = new TypeOfItem { Name = "Scarves", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(scarves);
            TypeOfItem shirt = new TypeOfItem { Name = "Shirt", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(shirt);
            TypeOfItem shoes = new TypeOfItem { Name = "Shoes", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(shoes);
            TypeOfItem skateboard = new TypeOfItem { Name = "Skateboard", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(skateboard);
            TypeOfItem sportsequipment = new TypeOfItem { Name = "Sports Equipment", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(sportsequipment);
            TypeOfItem sunglasses = new TypeOfItem { Name = "Sunglasses", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(sunglasses);
            TypeOfItem sweater = new TypeOfItem { Name = "Sweater", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(sweater);
            TypeOfItem sweatshirt = new TypeOfItem { Name = "Sweatshirt", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(sweatshirt);
            TypeOfItem textbook = new TypeOfItem { Name = "Text Book", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(textbook);
            TypeOfItem tools = new TypeOfItem { Name = "Tools", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(tools);
            TypeOfItem toys = new TypeOfItem { Name = "Toys/Children", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(toys);
            TypeOfItem tripod = new TypeOfItem { Name = "Tripod (Camera)", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(tripod);
            TypeOfItem usb = new TypeOfItem { Name = "USB Drive", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(usb);
            TypeOfItem umbrella = new TypeOfItem { Name = "Umbrella", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(umbrella);
            TypeOfItem videotape = new TypeOfItem { Name = "Video Tape", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(videotape);
            TypeOfItem wallets = new TypeOfItem { Name = "Wallet", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(wallets);
            TypeOfItem watches = new TypeOfItem { Name = "Watches", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(watches);
            TypeOfItem waterBottle = new TypeOfItem { Name = "Water Bottle", TypeOfItemId = Guid.NewGuid() };
            context.TypeOfItems.Add(waterBottle);

            context.SaveChanges();
            #endregion

            #region users & roles

            AppRole adminRole = new AppRole();
            adminRole.Id = Guid.NewGuid();
            adminRole.Name = "Administrator";
            context.Roles.Add(adminRole);
            
            AppUser sysAdmin = new AppUser();
            sysAdmin.Id = Guid.NewGuid();
            sysAdmin.FirstName = "System";
            sysAdmin.LastName = "Admin";
            sysAdmin.IsActive = true;
            sysAdmin.JoinDate = DateTime.UtcNow;
            sysAdmin.LockoutEnabled = false;
            sysAdmin.PasswordHash = new PasswordHasher().HashPassword("P@ssword1");
            sysAdmin.SecurityStamp = Guid.NewGuid().ToString();
            sysAdmin.EmailConfirmed = true;
            sysAdmin.Email = "lostandfoundapp@devign34.com";
            context.Users.Add(sysAdmin);

            AppUserRole adminUserRole = new AppUserRole();
            adminUserRole.RoleId = adminRole.Id;
            adminUserRole.UserId = sysAdmin.Id;

            adminRole.Users.Add(adminUserRole);
            context.SaveChanges();


            #endregion

            #region locations
            Location locA = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow,  Name = "Building A" ,LocationId = Guid.NewGuid()};
            Location locB = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow, Name = "Building B", LocationId = Guid.NewGuid() };
            Location locC = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow, Name = "Building C", LocationId = Guid.NewGuid() };
            Location locD = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow, Name = "Building D", LocationId = Guid.NewGuid() };
            Location locE = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow, Name = "Building E", LocationId = Guid.NewGuid() };
            Location locF = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow, Name = "Building F", LocationId = Guid.NewGuid() };
            Location locG = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow, Name = "Building G", LocationId = Guid.NewGuid() };
            Location locH = new Location() { Active = true, DateCreatedUTC = DateTime.UtcNow, Name = "Building H", LocationId = Guid.NewGuid() };
            context.Locations.Add(locA);
            context.Locations.Add(locB);
            context.Locations.Add(locC);
            context.Locations.Add(locD);
            context.Locations.Add(locE);
            context.Locations.Add(locF);
            context.Locations.Add(locG);
            context.Locations.Add(locH);
            #endregion
        }
    }
}
