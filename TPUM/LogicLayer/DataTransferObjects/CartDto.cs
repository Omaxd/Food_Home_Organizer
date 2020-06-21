using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.DataTransferObjects
{
    public class CartDto
    {
        [Required]
        public UserDto User { get; set; }

        public IEnumerable<FoodDto> Foods { get; set; }
    }
}