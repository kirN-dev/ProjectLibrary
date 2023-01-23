using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.Data.Entities
{
	public class Shelf
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Book> Books { get; set; }
	}
}
