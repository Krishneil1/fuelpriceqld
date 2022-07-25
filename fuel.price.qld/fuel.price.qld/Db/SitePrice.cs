using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Fuel.Price.Qld.Db
{
    [Table("SitePrices", Schema = "fpq")]
    public partial class SitePrice
    {
        [Key]
        public int PriceId { get; set; }
        public int SiteId { get; set; }
        public int FuelId { get; set; }
        public string CollectionMethod { get; set; }
        public DateTime TransactionDateUtc { get; set; }
        public double Price { get; set; }
        public string Hash { get; set; }
    }
}
