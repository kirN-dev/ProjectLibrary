using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.Data.Entities
{
	public class Reader
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string Patronymic { get; set; }
		public virtual ICollection<Book> Books { get; set; }
	}
}
