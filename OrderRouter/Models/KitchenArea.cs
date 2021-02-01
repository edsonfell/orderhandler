using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class KitchenArea
    {
        [Key]
        [Required(ErrorMessage = "This field is required")]
        public int KitchenAreaId;

        [Required(ErrorMessage = "This field is required")]
        [MinLength(1, ErrorMessage = "This field should be between 1 and 100")]
        [MaxLength(1, ErrorMessage = "This field should be between 1 and 100")]
        public string KitchenAreaName;
    }
}