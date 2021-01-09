using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurapov.DAL.Entities
{
    public class Body
    {
        public Guid Id { get; set; }
        public Guid? DocumentId { get; set; }
        

        public virtual Document Document { get; set; }
        public virtual ICollection<Line> Lines { get; set; }
    }
}
