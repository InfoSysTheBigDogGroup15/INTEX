using INTEX.Models;
using System;
using System.Collections.Generic;
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
        public DbSet<Assay> Assays { get; set; }
        public DbSet<UserAuth> UserAuths { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test_Record> Test_Record { get; set; }
        public DbSet<Test_Tube> Test_Tube { get; set; }
    }
}
