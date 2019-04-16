using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using schoolProjectMVC.Models;

namespace schoolProjectMVC.Dal
{
    public class StudentDal : DbContext
    {
        //internal object objStudent;

        public StudentDal() : base("SchoolDBConnectionString")
        {
            Database.SetInitializer<StudentDal>(new CreateDatabaseIfNotExists<StudentDal>());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("tblStudent");
        }
        public DbSet<Student> students { get; set; }
    }
}