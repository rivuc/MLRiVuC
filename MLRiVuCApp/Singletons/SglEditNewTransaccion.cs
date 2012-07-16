using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public sealed class SglEditNewTransaccion
    {
        private static object syncRoot = new object();
        private static volatile SglEditNewTransaccion instance;
        private EditNewTransaccion frm=null;
        public Form ParentForm;

        private SglEditNewTransaccion()
        {
            frm = new EditNewTransaccion();
        }

        public static SglEditNewTransaccion Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SglEditNewTransaccion();
                    }
                }

                return instance;
            }
        }


        public void MostrarForm()
        {
            if (frm == null)
            {
                frm = new EditNewTransaccion();
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
