using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class ReportesDAL
    {
        private string CadConex = ConfigurationManager.ConnectionStrings["MLSQLite"].ToString();
        
        public DataSet GetReportDest_Remit(string Query)
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = new SQLiteConnection(CadConex))
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(Query, conn))
                da.Fill(ds);
            return ds;
        }
    }
}
