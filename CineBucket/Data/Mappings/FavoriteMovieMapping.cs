using CineBucket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CineBucket.Data.Mappings;

public class FavoriteMovieMapping : IEntityTypeConfiguration<FavoriteMovie>
{
    public void Configure(EntityTypeBuilder<FavoriteMovie> builder)
    {
        builder.ToTable("FavoriteMovies");  

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TmdbId)
            .IsRequired(true);

        
        builder.Property(x => x.Title)
            .IsRequired(true)  
            .HasColumnType("VARCHAR")  
            .HasMaxLength(60);  

        
        builder.Property(x => x.OriginalTitle)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(65);

        
        builder.Property(x => x.PosterPath)
            .IsRequired(false)  
            .HasColumnType("VARCHAR")
            .HasMaxLength(500);  

        
        builder.Property(x => x.ReleaseDate)
            .IsRequired(false);  

        
        builder.Property(x => x.Runtime)
            .IsRequired(false);

        
        builder.Property(x => x.Status)
            .IsRequired(false)  
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);  

        
        builder.Property(x => x.Priority)
            .IsRequired(true)  
            .HasColumnType("SMALLINT");

        
        builder.Property(x => x.AddedAt)
            .IsRequired(true)  
            .HasColumnType("TIMESTAMP");  

        
    }
}