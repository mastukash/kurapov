using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurapov.DAL.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Guid HeaderId { get; set; }
        public Guid BodyId { get; set; }
        public DateTime? CreatedDateTime { get; set; } 
        public DateTime? ModifiedDateTime { get; set; } 

        public virtual Header Header { get; set; }
        public virtual Body Body { get; set; }
    }
}
