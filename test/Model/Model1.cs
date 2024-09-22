using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace test.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=HotelModel")
        {
        }
        private static Model1 _instanse;

        public static Model1 GetContext()
        {
            if (_instanse == null)
            {
                _instanse = new Model1();
            }
            return _instanse;
        }

        public virtual DbSet<AdditionalEquipment> AdditionalEquipment { get; set; }
        public virtual DbSet<FoodOrders> FoodOrders { get; set; }
        public virtual DbSet<Guests> Guests { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<RoomEquipment> RoomEquipment { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<RoomTypes> RoomTypes { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceOrders> ServiceOrders { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<WorkSchedules> WorkSchedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalEquipment>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AdditionalEquipment>()
                .HasMany(e => e.RoomEquipment)
                .WithOptional(e => e.AdditionalEquipment)
                .HasForeignKey(e => e.EquipmentID);

            modelBuilder.Entity<Guests>()
                .HasMany(e => e.FoodOrders)
                .WithOptional(e => e.Guests)
                .HasForeignKey(e => e.GuestID);

            modelBuilder.Entity<Guests>()
                .HasMany(e => e.Reservations)
                .WithOptional(e => e.Guests)
                .HasForeignKey(e => e.GuestID);

            modelBuilder.Entity<Guests>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.Guests)
                .HasForeignKey(e => e.GuestID);

            modelBuilder.Entity<Guests>()
                .HasMany(e => e.ServiceOrders)
                .WithOptional(e => e.Guests)
                .HasForeignKey(e => e.GuestID);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Positions>()
                .HasMany(e => e.Staff)
                .WithOptional(e => e.Positions)
                .HasForeignKey(e => e.PositionID);

            modelBuilder.Entity<Restaurants>()
                .HasMany(e => e.Menu)
                .WithOptional(e => e.Restaurants)
                .HasForeignKey(e => e.RestaurantID);

            modelBuilder.Entity<Rooms>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rooms>()
                .HasMany(e => e.Reservations)
                .WithOptional(e => e.Rooms)
                .HasForeignKey(e => e.RoomID);

            modelBuilder.Entity<Rooms>()
                .HasMany(e => e.RoomEquipment)
                .WithOptional(e => e.Rooms)
                .HasForeignKey(e => e.RoomID);

            modelBuilder.Entity<RoomTypes>()
                .HasMany(e => e.Rooms)
                .WithOptional(e => e.RoomTypes)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<Service>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Statuses>()
                .HasMany(e => e.FoodOrders)
                .WithOptional(e => e.Statuses)
                .HasForeignKey(e => e.StatusID);

            modelBuilder.Entity<Statuses>()
                .HasMany(e => e.Reservations)
                .WithOptional(e => e.Statuses)
                .HasForeignKey(e => e.StatusID);

            modelBuilder.Entity<Statuses>()
                .HasMany(e => e.ServiceOrders)
                .WithOptional(e => e.Statuses)
                .HasForeignKey(e => e.StatusID);
        }
    }
}
