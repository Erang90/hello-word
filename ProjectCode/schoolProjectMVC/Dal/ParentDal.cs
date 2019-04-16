using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using schoolProjectMVC.Models;

namespace schoolProjectMVC.Dal
{
    public class ParentDal: DbContext
    {

        public ParentDal() : base("SchoolDBConnectionString")
        {
            Database.SetInitializer<ParentDal>(new CreateDatabaseIfNotExists<ParentDal>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parent>().ToTable("tblParent");
        }
        public DbSet<Parent> parents { get; set; }
    }
}