using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace DISPLAY__ADD__EDIT_AND_DELETE_FROM_DATABASE.Models
{
    internal class Conn
    {
        public static void DbComm(string command)
        {
                OdbcConnection DbConn = new OdbcConnection("DSN=capstoneassignment");
                DbConn.Open();
                OdbcCommand DbComm = DbConn.CreateCommand();
                DbComm.CommandText = command;
                OdbcDataReader DbReader = DbComm.ExecuteReader();
                DbConn.Close();
        }


        public static DataTable DbTable(string query)
        {
            OdbcConnection DbConn = new OdbcConnection("DSN=capstoneassignment");
            DbConn.Open();
            OdbcCommand DbComm = DbConn.CreateCommand();
            DbComm.CommandText = query;
            OdbcDataReader DbReader = DbComm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(DbReader);
            DbConn.Close();
            return dt;
        }
    }
}
