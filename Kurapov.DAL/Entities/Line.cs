using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurapov.DAL.Entities
{
    public class Line
    {
        [Browsable(false)]
        public Guid Id { get; set; }
        public DateTime? DATE { get; set; }
        public TimeSpan? TIME { get; set; }
        public int? DOY { get; set; }
        public decimal? BRWD { get; set; }
        public decimal? BRWH { get; set; }
        public decimal? BRWZ { get; set; }
        public decimal? BRWF { get; set; }
        [Browsable(false)]
        public Guid? BodyId { get; set; }

        [Browsable(false)]
        public virtual Body Body { get; set; }
    }
}
