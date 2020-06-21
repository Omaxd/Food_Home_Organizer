using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }

        public int Kcal { get; set; }

        public float Protein { get; set; }

        public float Carbohydrates { get; set; }

        public float Fat { get; set; }

        public bool IsVegetarian { get; set; }

    }
}
