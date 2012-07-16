using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public sealed class SglOpcionesUsuarios
    {
        private static object syncRoot = new object();
        private static volatile SglOpcionesUsuarios instance;
        private OpcionesUsuarios frm=null;
        public Form ParentForm;

        private SglOpcionesUsuarios()
        {
            frm = new OpcionesUsuarios();
        }

        public static SglOpcionesUsuarios Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SglOpcionesUsuarios();
                    }
                }

                return instance;
            }
        }


        public void MostrarForm()
        {
            if (frm == null)
            {
                frm = new OpcionesUsuarios();
            }
            frm.BringToFront();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }

        public void Dispose1()
        {
            frm = null;
        }

        public void MDIContenedor(Form MDIfrm)
        {
            frm.MdiParent = MDIfrm;
        }
    }


}
