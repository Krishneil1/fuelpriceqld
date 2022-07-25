using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Fuel.Price.Qld.Db
{
    [Table("FullSiteDetails", Schema = "fpq")]
    public partial class FullSiteDetail
    {
        [Key]
        public int SiteId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int PostCode { get; set; }
        public int GeoRegionId { get; set; }
        public int GeoRegionParentId { get; set; }
        public int GeoRegionParentId3 { get; set; }
        public int GeoRegionParentId4 { get; set; }
        public int GeoRegionParentId5 { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Modified { get; set; }
        public string Hash { get; set; }
    }
}
