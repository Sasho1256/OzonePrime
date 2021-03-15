using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OzonePrime.Models
{
    public partial class ozoneprimeContext : IdentityDbContext<User, Role, int>
    {
        public ozoneprimeContext()
        {
        }

        public ozoneprimeContext(DbContextOptions<ozoneprimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmsCast> FilmsCasts { get; set; }
        public virtual DbSet<FilmsGenre> FilmsGenres { get; set; }
        public virtual DbSet<FilmsUser> FilmsUsers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=localhost;Database=ozoneprime;Uid=Val;Pwd=QkaParola123");
                //optionsBuilder.UseMySQL("Server=localhost;Database=ozoneprime;Uid=Sasho1256;Pwd=7l#GhM)XXd<rAm(4");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Ignore<IdentityUserClaim<int>>();
            modelBuilder.Ignore<IdentityUserRole<int>>();
            modelBuilder.Ignore<IdentityUserLogin<int>>();
            modelBuilder.Ignore< IdentityRoleClaim<int>>();
            modelBuilder.Ignore<IdentityUserToken<int>>();
            
            modelBuilder.Entity<Cast>(entity =>
            {
                entity.ToTable("cast");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("films");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExpirationDays)
                    .HasColumnName("expiration_days")
                    .HasDefaultValueSql("'15'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10,0)")
                    .HasColumnName("price");

                entity.Property(e => e.YearRelease).HasColumnName("year_release");
            });

            modelBuilder.Entity<FilmsCast>(entity =>
            {
                entity.HasKey(c => new { c.FilmId, c.CastId });

                entity.ToTable("films_cast");

                entity.HasIndex(e => e.CastId, "cast_id");

                entity.HasIndex(e => e.FilmId, "film_id");

                entity.Property(e => e.CastId).HasColumnName("cast_id");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.HasOne(d => d.Cast)
                    .WithMany()
                    .HasForeignKey(d => d.CastId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_cast_ibfk_2");

                entity.HasOne(d => d.Film)
                    .WithMany()
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_cast_ibfk_1");
            });

            modelBuilder.Entity<FilmsGenre>(entity =>
            {
                entity.HasKey(c => new { c.FilmId, c.GenreId });

                entity.ToTable("films_genres");

                entity.HasIndex(e => e.FilmId, "film_id");

                entity.HasIndex(e => e.GenreId, "genre_id");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.HasOne(d => d.Film)
                    .WithMany()
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_genres_ibfk_1");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_genres_ibfk_2");
            });

            modelBuilder.Entity<FilmsUser>(entity =>
            {
                entity.HasKey(c => new { c.FilmId, c.UserId });

                entity.ToTable("films_users");

                entity.HasIndex(e => e.FilmId, "film_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Film)
                    .WithMany()
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_users_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("films_users_ibfk_2");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("password");                
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasKey(c => new { c.UserId, c.RoleId });

                entity.ToTable("users_roles");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_roles_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_roles_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
