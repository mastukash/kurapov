using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurapov.DAL.Entities
{
    public class Header
    {
        public Guid Id { get; set; }
        public string Format { get; set; }
        public string SourceOfData { get; set; }
        public string StationName { get; set; }
        public string IAGACODE { get; set; }
        public decimal? GeodeticLatitude { get; set; }
        public decimal? GeodeticLongitude { get; set; }
        public decimal? Elevation { get; set; }
        public string Reported { get; set; }
        public string SensorOrientation { get; set; }
        public string DigitalSampling { get; set; }
        public string DataIntervalType { get; set; }
        public string DataType { get; set; }
        public Guid? DocumentId { get; set; }

        public virtual Document Document { get; set; }
    }
}
