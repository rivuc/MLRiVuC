using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLML
{
    public class BusquedasBL
    {
        public List<string> GetBusquedasforUsers()
        {
            return (from u in Busqueda.All()
                    where u.Categoria == "USUARIOS" | u.Categoria == "TODOS"
                    orderby u.Tipo
                    select u.Tipo).ToList();
        }

        public List<string> GetBusquedasforTrans()
        {
            return (from u in Busqueda.All()
                    where u.Categoria == "TRANSACCIONES" | u.Categoria == "TODOS"
                    orderby u.Tipo
                    select u.Tipo).ToList();
        }
    }
}
