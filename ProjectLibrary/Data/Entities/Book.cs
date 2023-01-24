using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.Data.Entities
{
	
	public class Book
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[MaxLength(10)]
		public string Title { get; set; }
		[Required]

		[MaxLength(25)]
		public string Author { get; set; }
		[Required]

		[MaxLength(10)]
		public string ISBN { get; set; }
		[MaxLength(50)]
		public string Annotation { get; set; }
		[Required]
		public virtual Shelf Shelf { get; set; }
		public virtual ICollection<Reader> Readers { get; set; }

		public override string ToString()
		{
			return Title;
		}
	}
}
