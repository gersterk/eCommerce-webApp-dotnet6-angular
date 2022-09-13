using AppAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity 
    {
        DbSet<T> Table { get; }  //in the DbSets we get but do not set anything
    }


    //self comment : my talks :D 
    

    /// Repository Pattern contradicts with SOLID principles... Query and Command methods are all in the same class...
    /// So Single Responsibility principle is bypassed
    /// and this is why I will seperate the repos of Db into two
    /// IReadRepository and IWriteRepository 

}
