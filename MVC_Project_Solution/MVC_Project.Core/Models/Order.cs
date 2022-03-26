using MVC_Project.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public string DateTime { get; set; }
        [Column(TypeName = "money")]

        public decimal? Price { get; set; }
        [ForeignKey("AppUser")]
        public string Customer_Id { get; set; }

        [ForeignKey("Payment")]
        public int? Payment_Id { get; set; }
        public bool? Accepted { get; set; }
        public Payment Payment { get; set; }
        public AppUser AppUser { get; set; }



    }
}
