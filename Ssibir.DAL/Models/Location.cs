using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssibir.DAL.Models
{
    public class Location : BaseEntity
    {
        public String Name { get; set; }

        public String Address { get; set; }

        public String GoogleMapLink { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }

        public Guid? DirectionId { get; set; }
        public virtual Direction Direction { get; set; }
    }
}
