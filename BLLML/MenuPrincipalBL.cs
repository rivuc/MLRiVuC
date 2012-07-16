using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLML
{
    public class MenuPrincipalBL
    {
        public List<string> GetOpcionesMenu()
        {
            return (from u in MenuPrincipal.All()
                    orderby u.Id_Menu
                    select u.Opciontxt).ToList();
        }

        public List<string> GetOpcionesMenuExtraItem(string item)
        {
            List<string> lista = new List<string>();
            lista = GetOpcionesMenu();
            lista.Insert(0, item);
            return lista;
        }

    }
}
