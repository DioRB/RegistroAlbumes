using Microsoft.EntityFrameworkCore;
using RegistroAlbumes.Models;
namespace RegistroAlbumes.Data
{
	public class AppDBContext : DbContext
	{
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Album> Albumes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Album>(tb =>
			{
				tb.HasKey(col => col.IdAlbum);

				tb.Property(col => col.IdAlbum)
				.UseIdentityColumn()
				.ValueGeneratedOnAdd();

				tb.Property(col => col.Nombre);
				tb.Property(col => col.Autor).HasMaxLength(50);

				tb.Property(col => col.Puntuacion).HasColumnType("decimal(3,1)");
			});

			modelBuilder.Entity<Album>().ToTable("Albumes");
		}
	}
}
