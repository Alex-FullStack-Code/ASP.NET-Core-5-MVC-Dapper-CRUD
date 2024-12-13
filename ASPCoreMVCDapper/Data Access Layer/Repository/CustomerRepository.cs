using ASPCoreMVCDapper.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ASPCoreMVCDapper.Data_Access_Layer.Repository
{
   public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
   {
      public CustomerRepository(IConfiguration _configuration) : base(_configuration)
      {
         SetQueries();
      }

      private void SetQueries()
      {
         GetAllQuery = "SELECT* From Customer;";
         GetByIDQuery = "SELECT * FROM Customer WHERE CustomerID=@ID";
         DeleteQuery = "DELETE FROM Customer WHERE CustomerID = @ID";
         InsertQuery = "INSERT INTO Customer(CompanyName,Address,City,State,IntroDate,CreditLimit)"
                          + " Values(@CompanyName,@Address,@City,@State,@IntroDate,@CreditLimit)";
         UpdateQuery = " UPDATE Customer SET CompanyName = @CompanyName,Address = @Address, "
                         + " City = @City,State = @State,IntroDate = @IntroDate,CreditLimit = @CreditLimit"
                         + " WHERE CustomerID = @CustomerID";
      }

      public void SetInsertParams(Customer customer)
      {
         InsertParams = new List<SqlParameter>()
         {
            new SqlParameter("@CompanyName", customer.CompanyName),
            new SqlParameter("@Address",customer.Address),
            new SqlParameter("@City",customer.City),
            new SqlParameter("@State",customer.State),
            new SqlParameter("@IntroDate",customer.IntroDate),
            new SqlParameter("@CreditLimit",customer.CreditLimit)
         };
      }

      public void SetUpdateParams(Customer customer)
      {
         UpdateParams = new List<SqlParameter>()
         {
            new SqlParameter("@CustomerID",customer.CustomerID),
            new SqlParameter("@CompanyName",customer.CompanyName),
            new SqlParameter("@Address",customer.Address),
            new SqlParameter("@City",customer.City),
            new SqlParameter("@State",customer.State),
            new SqlParameter("@IntroDate",customer.IntroDate),
            new SqlParameter("@CreditLimit",customer.CreditLimit)
         };
      }
   }
}
