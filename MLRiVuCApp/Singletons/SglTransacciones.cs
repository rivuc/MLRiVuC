using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public sealed class SglTransacciones
    {
        private static object syncRoot = new object();
        private static volatile SglTransacciones instance;
        private Transacciones frm=null;
        public Form ParentForm;

        private SglTransacciones()
        {
            frm = new Transacciones();
        }

        public static SglTransacciones Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SglTransacciones();
                    }
                }

                return instance;
            }
        }


        public void MostrarForm()
        {
            if (frm == null)
            {
                frm = new Transacciones();
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
