using ASPCoreMVCDapper.Data_Access_Layer.Repository;

namespace ASPCoreMVCDapper.Data_Access_Layer.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
   {
      public ICustomerRepository CustomerRepository { get; private set; }

      public UnitOfWork(ICustomerRepository customerRepository)
      {
         CustomerRepository = customerRepository;
      }
   }
}
