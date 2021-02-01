using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Models
{
    public class Order
    {
        //Ignore the OrderId in case the client send it on the request
        [IgnoreDataMember]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Products are required")]
        public List<Product> Products { get; set; }

        [IgnoreDataMember]
        public string Status {get; set; }
        
        //IsReady would be used by the kitchen to notify this API that the
        //order is finished and then notify the system responsible to inform
        //the customers about their orders. 
        //We could use an annotation to block
        //this info to prevent the client to send it on the post request, but this
        //way the kitchen's system would not be able to update this field back too
        public bool IsReady { get; set;}
    }
}