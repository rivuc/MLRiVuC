using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLML
{
    public class MensajeriasBL
    {
        public List<string> GetMensajerias()
        {
            return (from u in Mensajeria.All()
                    select u.MensajeriaName).ToList();
        }
    }
}
