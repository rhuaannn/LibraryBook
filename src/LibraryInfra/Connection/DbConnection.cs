using LibraryDomain.Entities;
using LibraryDomain.ValueObject; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryInfra.Connection
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=010203;Database=LibraryApi;");
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento entre Book e User
            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do ValueObject Name
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Name, name =>
                {
                    name.Property(n => n.FullName)
                        .HasMaxLength(100)
                        .IsRequired();
                });

            // Configuração do ValueObject Email
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Address)
                        .HasColumnName("Email_Address")
                        .HasMaxLength(255)
                        .IsRequired();
                });

            // Configuração do ValueObject Password
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Password, password =>
                {
                    password.Property(p => p.HashedPassword)
                        .HasMaxLength(64)
                        .IsRequired();
                });
        }

    }
}