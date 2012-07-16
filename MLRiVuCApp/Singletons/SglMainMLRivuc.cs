using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public sealed class SglMainMLRivuc
    {
        private static object syncRoot = new object();
        private static volatile SglMainMLRivuc instance;
        private MainMLRivuc frm=null;

        private SglMainMLRivuc()
        {
            frm = new MainMLRivuc();
        }

        public static SglMainMLRivuc Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SglMainMLRivuc();
                    }
                }

                return instance;
            }
        }


        public void MostrarForm()
        {
            if (frm == null)
            {
                frm = new MainMLRivuc();
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
