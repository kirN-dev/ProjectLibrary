using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.Data.Entities
{
	public class Shelf
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[MaxLength(10)]
		public string Title { get; set; }
		[MaxLength(50)]
		public string Description { get; set; }
		public virtual ICollection<Book> Books { get; set; }

		public override string ToString()
		{
			return Title;
		}
	}
}
