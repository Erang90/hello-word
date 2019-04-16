using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace schoolProjectMVC.Dal
{
    public class Dal : DbContext
    {
        
        public System.Data.Entity.DbSet<schoolProjectMVC.Models.Teacher> Teacher { get; set; }
        public System.Data.Entity.DbSet<schoolProjectMVC.Models.Assistant> Assistant { get; set; }
        //public System.Data.Entity.DbSet<schoolProjectMVC.Models.Parent> Parent { get; set; }
    }
}