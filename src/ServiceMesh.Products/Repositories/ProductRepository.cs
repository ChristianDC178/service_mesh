using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ServiceMesh.Products.Entities;
using System.Data.SqlClient;


namespace ServiceMesh.Products.Repositories
{
    public class ProductRepository
    {

        public List<Product> GetProducts()
        {

            var connection = new SqlConnection(@"Data Source=.\SQLExpress; Initial Catalog=ServiceMesh; Integrated Security=true;");

            var products = connection
                        .Query<Product>("select * from dbo.Products")
                        .ToList();

            return products;

        }

    }
}
