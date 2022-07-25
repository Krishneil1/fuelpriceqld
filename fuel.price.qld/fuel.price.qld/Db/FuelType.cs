using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Fuel.Price.Qld.Db
{
    [Table("FuelTypes", Schema = "fpq")]
    public partial class FuelType
    {
        [Key]
        public int FuelId { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
    }
}
