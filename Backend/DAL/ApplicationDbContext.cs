using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt): base(opt) 
        {
            
            Database.EnsureCreated();
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
              .Property(p => p.PickupDate)
              .HasConversion
              (
                  src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                  dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
              );


            modelBuilder.Entity<Order>().Property(p=>p.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Order>().HasData(
                new Order { 
                    Id =1,
                    SenderСity="Москва",
                    SenderAddres= "ул. Профсоюзная, 104/47",
                    RecipientCity="Кирово-Чепецк",
                    RecipientAddres= "ул. Сергея Ожегова, д. 3",
                    WeightCargo = 10,
                    PickupDate= DateTime.SpecifyKind(new DateTime(2023, 10, 5), DateTimeKind.Utc),
                },

                new Order
                {
                    Id = 2,
                    SenderСity = "Санкт-Петербург",
                    SenderAddres = "Кузнецовская ул., 10а",
                    RecipientCity = "Москва",
                    RecipientAddres = "ул. Профсоюзная, 104/47",
                    WeightCargo = 15,
                    PickupDate = DateTime.SpecifyKind(new DateTime(2023, 1, 23), DateTimeKind.Utc),
                },

                new Order
                {
                    Id = 3,
                    SenderСity = "Кирово-Чепецк",
                    SenderAddres = "ул. Сергея Ожегова, д. 3",
                    RecipientCity = "Москва",
                    RecipientAddres = "ул. Профсоюзная, 104/47",
                    WeightCargo = 45,
                    PickupDate = DateTime.SpecifyKind(new DateTime(2023, 12, 30), DateTimeKind.Utc),
                },
                new Order
                {
                    Id = 4,
                    SenderСity = "Санкт-Петербург",
                    SenderAddres = "Благодатная ул., 10, стр. 1",
                    RecipientCity = "Кирово-Чепецк",
                    RecipientAddres = "ул. Братьев Васнецовых",
                    WeightCargo = 23,
                    PickupDate = DateTime.SpecifyKind(new DateTime(2023, 7, 29), DateTimeKind.Utc),
                },
                new Order
                {
                    Id = 5,
                    SenderСity = "Санкт-Петербург",
                    SenderAddres = "Старообрядческая ул., дом 24",
                    RecipientCity = "Санкт-Петербург",
                    RecipientAddres = "Митрофаньевское ш., 2",
                    WeightCargo = 32,
                    PickupDate = DateTime.SpecifyKind(new DateTime(2023, 1, 1), DateTimeKind.Utc),
                }

        );
            base.OnModelCreating(modelBuilder);
        }
    }
}
