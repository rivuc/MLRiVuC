using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using DAL;

namespace BLML
{
    public class ReportesBL
    {
        private string CadConex=@"Data Source=C:\Documents and Settings\francisco\Mis documentos\SQL Lite\MLRiVuC.s3db;";

        private ReportesDAL _ReportesDAL {get; set;}
        protected ReportesDAL ReportesDAL
        {
            get
            {
                if (_ReportesDAL == null)
                    _ReportesDAL = new ReportesDAL();
                return _ReportesDAL;
            }
        }
        

        public DataSet GetReportDest_Remit(string Destinatario, string Remite)
        {
            StringBuilder sb = new StringBuilder();
            string Query;

            sb.Append("SELECT ");
            sb.Append("A.Nombre || ' ' || A.ApPaterno || ' ' ||  A.ApMaterno as 'A.NombreCompleto', A.Direccion, A.CP, A.Colonia,  ");
            sb.Append("CASE A.Tel_Casa ");
            sb.Append("   WHEN '(   )   -' THEN A.Tel_Cel ");
            sb.Append("   Else ");
            sb.Append("        A.Tel_Casa  ");
            sb.Append("END AS 'A.Telefono', ");
            sb.Append("A.Pais, A.Estado, A.Ciudad, ");
            sb.Append("B.Nombre || ' ' || B.ApPaterno || ' ' ||  B.ApMaterno as 'B.NombreCompleto', B.Direccion 'B.Direccion', B.CP  ");
            sb.Append("'B.CP', B.Colonia 'B.Colonia',  ");
            sb.Append("CASE B.Tel_Casa ");
            sb.Append("   WHEN '(   )   -' THEN B.Tel_Cel ");
            sb.Append("   Else ");
            sb.Append("        B.Tel_Casa  ");
            sb.Append("END AS 'B.Telefono', ");
            sb.Append("B.Pais 'B.Pais', B.Estado 'B.Estado', B.Ciudad 'B.Ciudad' ");
            sb.Append("FROM    usuarios A, usuarios B ");
            sb.Append("WHERE A.SEUDONIMO={0} ");
            sb.Append("AND B.SEUDONIMO={1} ");

            Destinatario = "'" + Destinatario + "'";
            Remite = "'" + Remite + "'";
            Query = string.Format(sb.ToString(), Destinatario, Remite);
            return ReportesDAL.GetReportDest_Remit(Query);
        }
    }
}
