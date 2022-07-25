using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Fuel.Price.Qld.Db
{
    [Table("Brands", Schema = "fpq")]
    public partial class Brand
    {
        public string Name { get; set; }
        [Key]
        public int BrandId { get; set; }
        public string Hash { get; set; }
    }
}
