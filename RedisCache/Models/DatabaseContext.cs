using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RedisCache.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<CountryMaster> Countries { get; set; }
        public DbSet<StateMaster> States { get; set; }
    }
}