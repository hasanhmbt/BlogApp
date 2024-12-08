using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<DownloadFiles> DownloadFiles { get; set; } = null!;
    public DbSet<Article> Articles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Alice",
                LastName = "Johnson",
                JobTitle = "Senior Developer",
                Specialty = "Full Stack Development",
                ScientificFacts = "Published 5 papers on cloud computing.",
                Email = "alice.johnson@example.com",
                ProfileImageUrl = "/images/users/alice.jpg",
                CreatedAt = new DateTime(2023, 1, 15)
            } 
        );

        // Seed data for Subjects
        modelBuilder.Entity<Subject>().HasData(
            new Subject
            {
                Id = 1,
                Name = "Mathematics",
                Hours = 60,
                Credits = 4,
                MaterialsLink = "/materials/mathematics.pdf",
                CreatedAt = new DateTime(2023, 3, 10)
            }
        );

        // Seed data for DownloadFiles
        modelBuilder.Entity<DownloadFiles>().HasData(
            new DownloadFiles
            {
                Id = 1,
                Name = "Introduction to Programming.pdf",
                FilePath = "/files/IntroProgramming.pdf",
                FileType = "pdf",
                UploadDate = new DateTime(2023, 4, 5),
                CreatedAt = new DateTime(2023, 4, 5)
            },
            new DownloadFiles
            {
                Id = 2,
                Name = "DataStructures.docx",
                FilePath = "/files/DataStructures.docx",
                FileType = "docx",
                UploadDate = new DateTime(2023, 4, 10),
                CreatedAt = new DateTime(2023, 4, 10)
            }
          
        );

        // Seed data for Articles
        modelBuilder.Entity<Article>().HasData(
            new Article
            {
                Id = 1,
                Title = "Getting Started with ASP.NET Core",
                Description = "<p>ASP.NET Core is a cross-platform, high-performance framework for building modern web applications...</p>",
                PublicationDate = new DateTime(2023, 5, 1),
                FilePath = "/images/articles/aspnetcore.jpg",
                CreatedAt = new DateTime(2023, 5, 1)
            },
            new Article
            {
                Id = 2,
                Title = "Understanding Entity Framework Core",
                Description = "<p>Entity Framework Core (EF Core) is a modern object-database mapper for .NET...</p>",
                PublicationDate = new DateTime(2023, 5, 10),
                FilePath = "/images/articles/efcore.jpg",
                CreatedAt = new DateTime(2023, 5, 10)
            }
          
        );
    }
}
