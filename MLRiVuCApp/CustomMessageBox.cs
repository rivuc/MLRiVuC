using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLRiVuCApp
{
    public partial class CustomMessageBox : Form
    {
        string[] Resp;

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public CustomMessageBox(string[] pResp, string Mensaje, string TituloFrm,
            string TextBtn1, string TextBtn2, string TextBtn3)
        {
            InitializeComponent();
            Resp = pResp;
            lblMensaje.Text = Mensaje;
            this.Text = TituloFrm;
            btnOpc1.Text = TextBtn1;
            btnOpc2.Text = TextBtn2;
            btnOpc3.Text = TextBtn3;
        }

        private void frmCustomMsgBx_Load(object sender, EventArgs e)
        {

        }

        private void btnOpc1_Click(object sender, EventArgs e)
        {
            Resp[0] = "1";
            this.Close();
        }

        private void btnOpc2_Click(object sender, EventArgs e)
        {
            Resp[0] = "2";
            this.Close();
        }

        private void btnOpc3_Click(object sender, EventArgs e)
        {
            Resp[0] = "3";
            this.Close();
        }







    }
}
