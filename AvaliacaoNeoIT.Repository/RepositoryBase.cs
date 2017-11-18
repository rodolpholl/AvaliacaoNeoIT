using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AvaliacaoNeoIT.Repository
{
    public class RepositoryBase<T>: IDisposable where T: class
    {
        protected SqlConnection _Connection;
        protected SqlCommand _Command;
        
        public string ConnectionString { get; set; }

        public RepositoryBase()
        {
            InitializeConnection();
        }

        public RepositoryBase(string pConnectionString)
        {
            this.ConnectionString = pConnectionString;
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            _Connection = new SqlConnection(ConnectionString);
            _Command = new SqlCommand("", _Connection);
        }

        

        protected void OpenConnection()
        {
            if (_Connection.State == ConnectionState.Closed)
                _Connection.Open();
        }

        protected void CloseConnection()
        {
            if (_Connection.State == ConnectionState.Open)
                _Connection.Close();
        }

        protected static IList<T> DataReaderToList<T>(IDataReader dr)
        {
            IList<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }


        public void Dispose()
        {
            if (_Connection.State == ConnectionState.Open)
                CloseConnection();
            _Connection.Dispose();
        }
    }
}
