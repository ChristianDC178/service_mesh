using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ServiceMesh.Accounts.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceMesh.Accounts.Repositories
{
    public class ServiceContext : DbContext
    {

        public ServiceContext()  : base()
        {
        }

        
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string serverName = "DESKTOP-O9NSGB7"; 

            optionsBuilder.UseSqlServer(@$"Data Source={serverName}; Initial Catalog=ServiceMesh; Integrated Security=true;");
        }


        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());


            //model.Conventions.Remove<Conventions.PluralizingTableNameConvention>();
            //model.Conventions.Remove<Conventions.PrimaryKeyNameForeignKeyDiscoveryConvention>();
            //model.Conventions.Remove<Conventions.ForeignKeyAssociationMultiplicityConvention>();

        }



    }
  
  
}