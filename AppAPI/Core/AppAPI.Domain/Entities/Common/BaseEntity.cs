using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        //this class is a class of common properties of all entities
        //that will be possesed by each of our entities
        //other entities will be inherited from this class
        public Guid Id { get; set; } //I think its safer more fantastic to use guids .swh
        public DateTime CreateDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }

    }
}
