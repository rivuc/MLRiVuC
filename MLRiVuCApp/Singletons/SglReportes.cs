using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public sealed class SglReportes
    {
        private static object syncRoot = new object();
        private static volatile SglReportes instance;
        private Reportes frm=null;
        public Form ParentForm;

        private SglReportes()
        {
            frm = new Reportes();
        }

        public static SglReportes Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SglReportes();
                    }
                }

                return instance;
            }
        }


        public void MostrarForm()
        {
            if (frm == null)
            {
                frm = new Reportes();
            }
            frm.BringToFront();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }

        public void Dispose1()
        {
            if (frm != null)
            {
                frm = null;
            }
        }

        public void MDIContenedor(Form MDIfrm)
        {
            if (frm != null)
                frm.MdiParent = MDIfrm;
        }
    }


}
