using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				.UseSqlServer(@"Server=localhost\sqlexpress;Database=LibraryDB;Trusted_Connection=True;");
		}
	}
}
