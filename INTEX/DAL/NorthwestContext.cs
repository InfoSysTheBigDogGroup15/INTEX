using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace INTEX.DAL
{
    public class NorthwestContext : DbContext
    {
        public NorthwestContext() : base("NorthwestContext")
        {

        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Compound> Component { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Test_Record> Test_Record { get; set; }
        public DbSet<Test_Tube> Test_Tube { get; set; }
        public DbSet<Assay> Assay { get; set; }
        public DbSet<Authorization> Authorization { get; set; }
        public DbSet<Billing> Billing { get; set; }
    }
}
