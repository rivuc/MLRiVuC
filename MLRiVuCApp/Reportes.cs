using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using BLML;
using Microsoft.Reporting.WinForms;

namespace MLRiVuCApp
{
    public partial class Reportes : Form
    {
        UsuariosBL oUsuariosBL = new UsuariosBL();
        ReportesBL oReportesBL = new ReportesBL();
        private string DfaultRemite = System.Configuration.ConfigurationSettings.AppSettings["DefaultRemite"];

        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mLRiVuCDataSet.Usuarios' table. You can move, or remove it, as needed.
            cbDestinatario.DataSource = oUsuariosBL.GetUsuariosSeudonimoFullName();
            cbRemite.DataSource = oUsuariosBL.GetUsuariosSeudonimoFullName();
            cbDestinatario.SelectedIndex = -1;
            cbDestinatario.Text= "--Seleccione--";
            cbRemite.SelectedIndex = cbRemite.FindString(DfaultRemite);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean Existe;
                string Destinatario = cbDestinatario.Text.Split(' ')[0];
                string Remite = cbRemite.Text.Split(' ')[0];
                Existe = (oUsuariosBL.ExistUser(Destinatario) && (oUsuariosBL.ExistUser(Remite)));
                if (Existe)
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "MLRiVuCApp.RptEnvio.rdlc";
                    DataSet ds = oReportesBL.GetReportDest_Remit(Destinatario, Remite);
                    ReportDataSource dsReport = new ReportDataSource(reportViewer1.LocalReport.DataSources[0].Name, ds.Tables[0]);
                    reportViewer1.LocalReport.DataSources.RemoveAt(0);
                    reportViewer1.LocalReport.DataSources.Add(dsReport);
                    reportViewer1.ZoomPercent = 70;
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Usuario seleccionado no existe");
                }


            }
            catch (Exception ex)
            {
                lblMensajes.Text = ex.Message;
            }

        }

    }
}
