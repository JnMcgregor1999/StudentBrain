using Dapper;
using Microsoft.Data.SqlClient;
using StudentBrain.Common;
using System.Data;

namespace StudentBrain.DataAccess
{
    public class User_Repository : IRepository<User>, IDisposable
    {

        #region Region [Variables]
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        private string ConnectionString { get; set; }
        #endregion


        #region Region [Constructor]
        public User_Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Region [Methods]

        public async Task<IEnumerable<User>> List(User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<User>(
                    "PA_USER_GET",
                    param: new
                    {
                        P_PK_USER = model.Pk_User,
                        P_NAME = model.Name,
                        P_PASSWORD = model.Password,
                        P_USER_CREATED = model.User_Created,
                        P_DATE_CREATED = model.Date_Created,
                        P_USER_UPDATED = model.User_Updated,
                        P_DATE_UPDATED = model.Date_Updated,
                        P_ACTIVE = model.Active,
                    },
                    commandType: CommandType.StoredProcedure);
                return await Task.FromResult<IEnumerable<User>>(result.ToList());
            }
        }

        public async Task<User> Get(User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<User>(
                    "PA_USER_GET",
                    param: new
                    {
                        P_PK_USER = model.Pk_User,
                        P_NAME = model.Name,
                        P_PASSWORD = model.Password,
                        P_USER_CREATED = model.User_Created,
                        P_DATE_CREATED = model.Date_Created,
                        P_USER_UPDATED = model.User_Updated,
                        P_DATE_UPDATED = model.Date_Updated,
                        P_ACTIVE = model.Active,
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return await Task.FromResult<User>(result);
            }
        }


        public async Task Save(User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<User>(
                    "PA_USER_SAVE",
                    param: new
                    {
                        P_PK_USER = model.Pk_User,
                        P_NAME = model.Name,
                        P_PASSWORD = model.Password,
                        P_USER_CREATED = model.User_Created,
                        P_DATE_CREATED = model.Date_Created,
                        P_USER_UPDATED = model.User_Updated,
                        P_DATE_UPDATED = model.Date_Updated,
                        P_ACTIVE = model.Active,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<User>(
                    "PA_USER_SAVE",
                    param: new
                    {
                        P_PK_USER = model.Pk_User,
                        P_NAME = model.Name,
                        P_PASSWORD = model.Password,
                        P_USER_CREATED = model.User_Created,
                        P_DATE_CREATED = model.Date_Created,
                        P_USER_UPDATED = model.User_Updated,
                        P_DATE_UPDATED = model.Date_Updated,
                        P_ACTIVE = 0,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Region [Dispose]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~User_Repository()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        #endregion

    }
}
