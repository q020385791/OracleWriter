using Oracle.ManagedDataAccess.Client;
using System;

namespace OracleWriter
{
    class Program
    {
        //using Oracle.ManagedDataAccess.Client
        public static OracleConnection db = new OracleConnection();
        static void Main(string[] args)
        {
            string sql = "";
           db.Close();
            db.ConnectionString = "";
           db.Open();

            using (OracleTransaction trans = db.BeginTransaction())
            {
                OracleCommand command = db.CreateCommand();
                command.Transaction = trans;
                command.CommandText = sql;
                try
                {
                    int ChangedCount = command.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                }
            }

                db.Close();
        }

        
    }
}
