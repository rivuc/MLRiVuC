using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLML
{
    public class OperacionesBL
    {
        public List<string> GetTransacciones()
        {
            return (from u in Operacione.All()
                    orderby u.Operacion descending
                    select u.Operacion).ToList();
        }

        public List<string> GetTransaccionesAddExtraItem(string item)
        {
            List<string> listaOps = new List<string>();
            listaOps = GetTransacciones();
            listaOps.Insert(0, item);
            return listaOps;
        }
    }
}
