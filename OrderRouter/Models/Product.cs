using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Models
{
    public class Product
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ProductId field must have at least 1 number")]
        public int ProductId { get; set; }

        [IgnoreDataMember]
        public int? OrderId { get; set; }

        //Ignore the OrderId in case the client send it on the request
        [IgnoreDataMember]
        public bool IsReady { get; set; }
    
        [Required(ErrorMessage = "KitchenArea are required")]
        [Range(1, int.MaxValue, ErrorMessage = "KitchenAreaId field must have at least 1 number")]
        public int KitchenAreaId { get; set; }
    }
}