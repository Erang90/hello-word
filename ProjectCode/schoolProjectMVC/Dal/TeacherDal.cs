using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using schoolProjectMVC.Models;

namespace schoolProjectMVC.Dal
{
    public class TeacherDal: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teacher>().ToTable("tblTeacher");
        }
        public DbSet<Teacher> Teachers { get; set; }
    }
}