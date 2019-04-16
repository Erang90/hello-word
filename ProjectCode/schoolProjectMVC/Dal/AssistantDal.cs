using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using schoolProjectMVC.Models;

namespace schoolProjectMVC.Dal
{
    public class AssistantDal:DbContext
    {

        public AssistantDal() : base("SchoolDBConnectionString")
        {
            Database.SetInitializer<AssistantDal>(new CreateDatabaseIfNotExists<AssistantDal>());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Assistant>().ToTable("tblAssistant");
        }
        public DbSet<Assistant> Assistants { get; set; }
    }
}