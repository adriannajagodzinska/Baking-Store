using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OIprojekt.Models
{
    public class Measurement
    {
        public int MeasurementID { get; set; }
        // [Required]
        public string MeasurementName { get; set; }
    }
}