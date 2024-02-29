using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string? Borrower { get; set; }
		public string? Lender { get; set; }
        [DisplayName("Item name")]//wont show wo space
		public string ItemName { get; set; }

	}
}
