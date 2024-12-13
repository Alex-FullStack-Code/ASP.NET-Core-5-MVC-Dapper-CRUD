using ASPCoreMVCDapper.Models;

namespace ASPCoreMVCDapper.Data_Access_Layer.Repository
{
   public interface ICustomerRepository : IRepository<Customer>
   {
      public void SetInsertParams(Customer customer);
      public void SetUpdateParams(Customer customer);
   }
}
