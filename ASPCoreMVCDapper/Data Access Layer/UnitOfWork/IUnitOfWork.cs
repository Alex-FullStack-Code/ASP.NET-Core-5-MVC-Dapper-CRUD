using ASPCoreMVCDapper.Data_Access_Layer.Repository;

namespace ASPCoreMVCDapper.Data_Access_Layer.UnitOfWork
{
   public interface IUnitOfWork
   {
      ICustomerRepository CustomerRepository { get; }
   }
}
