using KickSharing.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KickSharing.DataAccess
{
    public class AppDBContext : DbContext
    {
        public DbSet<Price> Prices { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<User> Users { get; set; }


        public AppDBContext()
        {
            Database.EnsureCreated();
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=base.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Price
            builder.Entity<Price>().HasData(new Price() { MinutePrice = 5 });
            #endregion

            #region User
            builder.Entity<User>().HasData(new User()
            {
                DateBirth = DateTime.Parse("11.03.2003"),
                Name = "Admin",
                Role = Role.Admin,
                IsBlocked = false,
                Email = "dmitry_yalchik@mail.ru",
                IsEmailVerified = true,
                Phone = "78005553535",
                IsPhoneVerified = true
            });
            #endregion

            #region Scooter
            builder.Entity<Scooter>().HasData(new Scooter()
            {
                Identifier = "AA0001",
                ChargePercent = 100,
            });
            #endregion

            #region IsRequired
            builder.Entity<Price>().Property(p => p.MinutePrice).IsRequired();

            builder.Entity<Rent>().Property(p => p.ScooterId).IsRequired();
            builder.Entity<Rent>().Property(p => p.PriceId).IsRequired();
            builder.Entity<Rent>().Property(p => p.UserId).IsRequired();
            builder.Entity<Rent>().Property(p => p.StartDateTime).IsRequired();
            builder.Entity<Rent>().Property(p => p.StartLatitude).IsRequired();
            builder.Entity<Rent>().Property(p => p.StartLongitude).IsRequired();

            builder.Entity<Scooter>().Property(p => p.Identifier).IsRequired();
            builder.Entity<Scooter>().Property(p => p.ChargePercent).IsRequired();

            builder.Entity<User>().Property(p => p.Name).IsRequired();
            builder.Entity<User>().Property(p => p.Role).IsRequired();
            builder.Entity<User>().Property(p => p.DateBirth).IsRequired();
            #endregion

            builder.Entity<User>().Property(p => p.Role).HasDefaultValue(Role.User);

            #region IsUnique
            builder.Entity<User>().HasIndex(p => p.Email).IsUnique();
            builder.Entity<User>().HasIndex(p => p.Phone).IsUnique();

            builder.Entity<Scooter>().HasIndex(p => p.Identifier).IsUnique();
            #endregion

            //builder.Entity<User>().HasMany<Transport>().WithOne();
            //builder.Entity<User>().Property(p => p.DateBirth).ValueGeneratedOnAdd();
        }
    }
}
