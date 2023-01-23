using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data.Entities;

namespace ProjectLibrary.Data
{
	internal class LibraryContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Shelf> Shelves { get; set; }
		public DbSet<Reader> Readers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseLazyLoadingProxies()
				.UseSqlServer(DBConfiguration.GetConnectionString());
		}
	}
}
