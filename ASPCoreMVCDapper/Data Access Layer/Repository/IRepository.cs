using System.Collections.Generic;

namespace ASPCoreMVCDapper.Data_Access_Layer.Repository
{
   public interface IRepository<T> where T : class
   {
      T FindByID(int ID);
      IEnumerable<T> GetAll();
      int Add();
      int Update();
      int Delete(int ID);
   }
}
