using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.Data.Entities
{
	public class Reader
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[MaxLength(10)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(10)]
		public string LastName { get; set; }
		[MaxLength(10)]
		public string Patronymic { get; set; }
		public virtual ICollection<Book> Books { get; set; }

		public override string ToString()
		{
			return string.Format("{0} {1}.{2}", LastName, FirstName[0], Patronymic[0]);
		}
	}
}
