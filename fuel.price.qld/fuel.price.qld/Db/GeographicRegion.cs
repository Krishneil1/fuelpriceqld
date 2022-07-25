using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Fuel.Price.Qld.Db
{
    [Table("GeographicRegions", Schema = "fpq")]
    public partial class GeographicRegion
    {
        [Key]
        public int GeographicRegionId { get; set; }
        public int GeoRegionLevel { get; set; }
        public int GeoRegionId { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public string GeoRegionParentId { get; set; }
        public string Hash { get; set; }
    }
}
