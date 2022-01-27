using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperianChange.Models
{
    public class ChangeModel
    {
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount Given")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountGiven { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductPrice { get; set; }

        public string ChangeGiven { get; set; }
    }
}
