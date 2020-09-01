using System;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.DataTransferObjects
{
    public class FoodDto
    {
        public Guid? Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public int Kcal { get; set; }

        public float Protein { get; set; }

        public float Carbohydrates { get; set; }

        public float Fat { get; set; }

        public bool IsVegetarian { get; set; }
    }
}