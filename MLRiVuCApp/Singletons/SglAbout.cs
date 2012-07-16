using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public sealed class SglAbout
    {
        private static object syncRoot = new object();
        private static volatile SglAbout instance;
        private AboutBox1 frm=null;
        public Form ParentForm;

        private SglAbout()
        {
            frm = new AboutBox1();
        }

        public static SglAbout Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SglAbout();
                    }
                }

                return instance;
            }
        }


        public void MostrarForm()
        {
            if (frm == null)
            {
                frm = new AboutBox1();
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
