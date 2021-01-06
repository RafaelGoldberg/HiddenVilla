using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomAmenityDTO
    {


        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Amenity name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Amenity Time is required")]
        public string Timing { get; set; }
        [Required(ErrorMessage = "Please enter Icon Style")]
        [Display(Name = "Icon Style")]
        public string IconStyle { get; set; }
    }
}
