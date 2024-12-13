using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ASPCoreMVCDapper.Data_Access_Layer.Repository
{
   public class GenericRepository<T> : IRepository<T> where T : class
   {
      private readonly IConfiguration _configuration;
      private readonly string connectionString;
      public string InsertQuery { get; set; }
      public string UpdateQuery { get; set; }
      public string GetByIDQuery { get; set; }
      public string DeleteQuery { get; set; }
      public string GetAllQuery { get; set; }
      public List<SqlParameter> InsertParams { get; set; }
      public List<SqlParameter> UpdateParams { get; set; }

      public GenericRepository(IConfiguration configuration)
      {
         _configuration = configuration;
         connectionString = _configuration.GetConnectionString("ASPCoreRepoDB");

         InsertQuery = string.Empty;
         UpdateQuery = string.Empty;
         GetByIDQuery = string.Empty;
         DeleteQuery = string.Empty;
         GetAllQuery = string.Empty;
         InsertParams = new List<SqlParameter>();
         UpdateParams = new List<SqlParameter>();
      }

      public int Add()
      {
         int affectedRows = 0;

         try
         {
            var args = new DynamicParameters(new { });
            InsertParams.ForEach(p => args.Add(p.ParameterName, p.Value));

            using (var connection = new SqlConnection(this.connectionString))
            {
               affectedRows = connection.Execute(InsertQuery, args);
            }
         }
         catch (Exception ex)
         {
            return affectedRows;
         }

         return affectedRows;
      }

      public int Update()
      {
         int affectedRows = 0;

         try
         {
            var args = new DynamicParameters(new { });
            UpdateParams.ForEach(p => args.Add(p.ParameterName, p.Value));

            using (var connection = new SqlConnection(this.connectionString))
            {
               affectedRows = connection.Execute(UpdateQuery, args);
            }
         }
         catch (Exception ex)
         {
            return affectedRows;
         }

         return affectedRows;
      }

      public int Delete(int ID)
      {
         int affectedRows = 0;

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               affectedRows = connection.Execute(DeleteQuery, new { ID = ID });
            }
         }
         catch (Exception ex)
         {
            return affectedRows;
         }

         return affectedRows;
      }

      public T FindByID(int ID)
      {
         T result;

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               result = connection.Query<T>(GetByIDQuery, new { ID = ID }).FirstOrDefault();
            }
         }
         catch (Exception ex)
         {
            return null;
         }

         return result;
      }

      public IEnumerable<T> GetAll()
      {
         List<T> lstRecords = new List<T>();

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               lstRecords = connection.Query<T>(GetAllQuery).ToList();
            }
         }
         catch (Exception ex)
         {
            return null;
         }

         return lstRecords;
      }
   }
}