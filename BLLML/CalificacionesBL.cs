using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLML
{
    public class CalificacionesBL
    {
        public List<string> GetCalificaciones()
        {
            return (from u in Calificacione.All()
                    select u.Calificacion).ToList();
        }
    }
}
