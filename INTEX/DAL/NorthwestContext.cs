using INTEX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INTEX.DAL
{
    public class NorthwestContext : DbContext
    {
        public NorthwestContext() : base("NorthwestContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test_Record> Test_Records { get; set; }
        public DbSet<Test_Tube> Test_Tubes { get; set; }
        public DbSet<Assay> Assays { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Billing> Billings { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.Compound> Compounds { get; set; }
    }
}
