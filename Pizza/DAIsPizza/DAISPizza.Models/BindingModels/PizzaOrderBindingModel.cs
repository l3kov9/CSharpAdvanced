using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAISPizza.Models.BindingModels
{
    public class PizzaOrderBindingModel
    {
        [Required]
        public int PizzaId { get; set; }

        [Required]
        public int DoughTypeId { get; set; }

        [Required]
        public int SizeId { get; set; }

        public ICollection<int> Ingredients { get; set; }
    }
}
