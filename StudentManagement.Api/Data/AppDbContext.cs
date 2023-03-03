using Microsoft.EntityFrameworkCore;
using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // config class
            modelBuilder.Entity<Class>().ToTable("classes").HasKey(x => x.Id);
            modelBuilder.Entity<Class>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Class>().Property(x => x.ClassName)
                .HasColumnName("class_name")
                .HasMaxLength(255);
            modelBuilder.Entity<Class>().Property(x => x.CreatedDate).HasColumnName("create_date");
            modelBuilder.Entity<Class>().Property(x => x.ModifiedDate).HasColumnName("modified_date");

            // config country
            modelBuilder.Entity<Country>().ToTable("countries").HasKey(x => x.Id);
            modelBuilder.Entity<Country>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Country>().Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255);
            modelBuilder.Entity<Country>().Property(x => x.CreatedDate).HasColumnName("create_date");
            modelBuilder.Entity<Country>().Property(x => x.ModifiedDate).HasColumnName("modified_date");

            // config student
            modelBuilder.Entity<Student>().ToTable("students").HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Student>().Property(x => x.ClassId).HasColumnName("class_id");
            modelBuilder.Entity<Student>().Property(x => x.CountryId).HasColumnName("country_id");
            modelBuilder.Entity<Student>().Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255);
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Class)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>().Property(x => x.CreatedDate).HasColumnName("create_date");
            modelBuilder.Entity<Student>().Property(x => x.ModifiedDate).HasColumnName("modified_date");

            // seed class
            modelBuilder.Entity<Class>().HasData(new Class { Id = 1, ClassName = "First Class", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 2, ClassName = "Second Class", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 3, ClassName = "Third Class", CreatedDate = DateTime.Now });

            // seed country
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Bangladesh", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Germany", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Netherlands", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "USA", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Japan", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 6, Name = "China", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 7, Name = "UK", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 8, Name = "France", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 9, Name = "Brazil", CreatedDate = DateTime.Now });

            // seed student
            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, ClassId = 1, CountryId = 1, Name = "Emtious", DateOfBirth = new DateTime(1994, 5, 16), CreatedDate = DateTime.Now });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 2, ClassId = 2, CountryId = 1, Name = "Riad", DateOfBirth = new DateTime(1992, 7, 8), CreatedDate = DateTime.Now });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 3, ClassId = 1, CountryId = 1, Name = "Nabi", DateOfBirth = new DateTime(1992, 7, 8), CreatedDate = DateTime.Now });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 4, ClassId = 1, CountryId = 1, Name = "Nira", DateOfBirth = new DateTime(1992, 7, 8), CreatedDate = DateTime.Now });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 5, ClassId = 1, CountryId = 1, Name = "Nawaz", DateOfBirth = new DateTime(1992, 7, 8), CreatedDate = DateTime.Now });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 6, ClassId = 2, CountryId = 1, Name = "Tanzir", DateOfBirth = new DateTime(1992, 7, 8), CreatedDate = DateTime.Now });
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
