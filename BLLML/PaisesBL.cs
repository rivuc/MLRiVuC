using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLML
{
    public class PaisesBL
    {
        public List<string> GetEstadosByPais(string pais)
        {
            return (from u in Estado.All()
                    where u.Pais == pais
                    select u.State).ToList();
        }

        public List<string> GetPaises()
        {
            return (from u in Paise.All()
                    select u.Pais).ToList();
        }
    }
}
