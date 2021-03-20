using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OzonePrime.Models
{
    public partial class OzoneprimeContext : IdentityDbContext<User, Role, int>
    {
        public OzoneprimeContext(DbContextOptions<OzoneprimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmsUser> FilmsUsers { get; set; }
        public virtual DbSet<UsersRole> UsersRole { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Ignore<IdentityUserClaim<int>>();
            modelBuilder.Ignore<IdentityUserRole<int>>();
            modelBuilder.Ignore<IdentityUserLogin<int>>();
            modelBuilder.Ignore< IdentityRoleClaim<int>>();
            modelBuilder.Ignore<IdentityUserToken<int>>();
            
            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("directors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("last_name");                
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
