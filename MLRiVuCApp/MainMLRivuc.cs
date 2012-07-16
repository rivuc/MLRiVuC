using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DAL;
using BLML;
using MLRiVuCApp;

namespace MLRiVuCApp
{
    public partial class MainMLRivuc : Form
    {
        MenuPrincipalBL oMenuPrincipalML = new MenuPrincipalBL();

        public MainMLRivuc()
        {
            InitializeComponent();
            Functions.ConfigForm1(this);
            picLogo.BackColor = Color.Transparent;
        }

        private void MainMLRivuc_Load(object sender, EventArgs e)
        {
            string ExtraItem=ConfigurationSettings.AppSettings["Seleccione"];
            cbMenu.DataSource = oMenuPrincipalML.GetOpcionesMenuExtraItem(ExtraItem);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaUsuarios frmAlta = new AltaUsuarios();
            frmAlta.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        [STAThread]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int num = cbMenu.SelectedIndex;
            switch (num)
            {
                case 1:
                    SglAltaUsuarios.Instance.MostrarForm();
                    SglAltaUsuarios.Instance.ParentForm = this;
                    SglAltaUsuarios.Instance.MDIContenedor(this.MdiParent);
                    break;
                case 2:
                    SglEditNewTransaccion.Instance.MostrarForm();
                    SglEditNewTransaccion.Instance.ParentForm = this;
                    SglEditNewTransaccion.Instance.MDIContenedor(this.MdiParent);
                    break;
                case 3:
                    SglOpcionesUsuarios.Instance.MostrarForm();
                    SglOpcionesUsuarios.Instance.ParentForm = this;
                    SglOpcionesUsuarios.Instance.MDIContenedor(this.MdiParent);
                    break;
                case 4:
                    SglTransacciones.Instance.MostrarForm();
                    SglTransacciones.Instance.ParentForm = this;
                    SglTransacciones.Instance.MDIContenedor(this.MdiParent);
                    break;
                case 5:
                    SglReportes.Instance.MostrarForm();
                    SglReportes.Instance.ParentForm = this;
                    SglReportes.Instance.MDIContenedor(this.MdiParent);
                    break;
                case 6:
                    Application.Exit();
                    break;
            }
        }



    }
}
