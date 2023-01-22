using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data.Entities
{
	
	public class Book
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Author { get; set; }
		[Required]
		public string ISBN { get; set; }
		public string Annotation { get; set; }
		public virtual Shelf Shelf { get; set; }
		public virtual ICollection<Reader> Readers { get; set; }

	}
}
