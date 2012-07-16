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
using System.Configuration;

namespace MLRiVuCApp
{
    public partial class OpcionesUsuarios : Form
    {
        BusquedasBL oBusquedasBL = new BusquedasBL();
        UsuariosBL oUsuariosBL = new UsuariosBL();
        OpcionesUsuariosBL OpcUsersBL = new OpcionesUsuariosBL();
        ModificarUsuarios frmModificar = null;
        string updSelectedItem;
        string updtxtBusqueda;
        string TipoBusquedaInicial = ConfigurationSettings.AppSettings["InitialSelFrmBusq"];

        private string[] ColumnasUsuarios
        {
            get
            {
                return new string[]
                {
                    "Seudonimo",
                    "Mail",
                    "Nombre",
                    "Apellido Paterno",
                    "Apellido Materno",
                    "Direccion",
                    "C.P.",
                    "Colonia",
                    "Tel. Casa",
                    "Tel. Celular",
                    "Pais",
                    "Estado",
                    "Ciudad",
                    "Fecha Registro"
                };
            }
        }

        public OpcionesUsuarios()
        {
            InitializeComponent();
        }

        private void OpcionesUsuarios_Load(object sender, EventArgs e)
        {
            cbBusqueda.DataSource = oBusquedasBL.GetBusquedasforUsers();
            Functions.FormatDataGrid(grvUsuarios);
            Functions.InitialSelectCb(cbBusqueda, TipoBusquedaInicial);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpcUsersBL.FuncBusquedas(txtBusqueda, errorProvider1, "Busqueda requerido", cbBusqueda,
                grvUsuarios, ref updSelectedItem, ref updtxtBusqueda, ColumnasUsuarios);
            grvUsuarios.ClearSelection();
        }

        private void mnAbrir_Click(object sender, EventArgs e)
        {
            string Seudonimo;
            Seudonimo=BLML.Functions.GetCellfromDatagrid(grvUsuarios, "Seudonimo");
            Transacciones frmTransacciones = new Transacciones(Seudonimo);
            frmTransacciones.MdiParent = this.MdiParent;
            frmTransacciones.Show();
        }

        private void mnModificar_Click(object sender, EventArgs e)
        {  
            string seudonimo=BLML.Functions.GetCellfromDatagrid(grvUsuarios, "Seudonimo");
            frmModificar = new ModificarUsuarios(seudonimo);
            frmModificar.MdiParent = this.MdiParent;
            frmModificar.Show();
        }

        private void mnEliminar_Click(object sender, EventArgs e)
        {
            string seudonimo = BLML.Functions.GetCellfromDatagrid(grvUsuarios, "Seudonimo");
            if (OpcUsersBL.EliminarUsuario(seudonimo))
            {
                OpcUsersBL.ExecuteBusqueda(grvUsuarios, updSelectedItem, updtxtBusqueda);
                grvUsuarios.ClearSelection();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpcionesUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            SglOpcionesUsuarios.Instance.ParentForm.Show();
        }

        private void agregarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SglAltaUsuarios.Instance.MostrarForm();
        }

        private void grvUsuarios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Functions.CheckCellMouseDown(grvUsuarios, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (grvUsuarios.CurrentRow == null)
            {
                e.Cancel = true;
            }
        }

    }
}
