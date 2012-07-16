using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public sealed class SglAltaUsuarios
    {
        private static object syncRoot = new object();
        private static volatile SglAltaUsuarios instance;
        private AltaUsuarios frmAltaUsuarios=null;
        public Form ParentForm;

        private SglAltaUsuarios()
        {
            frmAltaUsuarios = new AltaUsuarios();
        }

        public static SglAltaUsuarios Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SglAltaUsuarios();
                    }
                }

                return instance;
            }
        }


        public void MostrarForm()
        {
            if (frmAltaUsuarios == null)
            {
                frmAltaUsuarios = new AltaUsuarios();
            }
            frmAltaUsuarios.BringToFront();
            frmAltaUsuarios.Show();
            frmAltaUsuarios.WindowState = FormWindowState.Normal;
        }

        public void Dispose1()
        {
            frmAltaUsuarios = null;
        }

        public void MDIContenedor(Form MDIfrm)
        {
            if (frmAltaUsuarios != null)
                frmAltaUsuarios.MdiParent = MDIfrm;
        }
    }


}
