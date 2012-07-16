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

namespace MLRiVuCApp
{
    public partial class Transacciones : Form
    {
        OperacionesBL OperacionesBL = new OperacionesBL();
        UsuariosBL oUsuariosBL = new UsuariosBL();
        MensajeriasBL oMensajeriaBL = new MensajeriasBL();
        CalificacionesBL oCalificacionesBL = new CalificacionesBL();
        BusquedasBL oBusquedasBL = new BusquedasBL();
        TransaccionesBL oTransaccionesBL = new TransaccionesBL();
        string updSelectedItemVenta, updtxtBusquedaVenta;
        string updSelectedItemCompra, updtxtBusquedaCompra;
        Boolean LoadData = false;
        string TipoBusquedaInicial = ConfigurationSettings.AppSettings["InitialSelFrmBusqTran"];

        private string[] ColumnasCompraVenta
        {
            get
            {
                return new string[]
                {
                    "Id",
                    "Fecha de Registro",
                    "Seudonimo",
                    "Operacion",
                    "Fecha Transaccion",
                    "Descripcion",
                    "Estatus",
                    "Calif Recibida",
                    "Calif Otorgada",
                    "Mensajeria",
                    "Numero de Guia",
                    "Cantidad",
                    "Precio",
                    "Envio",
                    "Total",
                };
            }
        }

        public Transacciones()
        {
            InitializeComponent();
        }

        public Transacciones(string Seudonimo)
        {
            InitializeComponent();
            txtBusquedaVenta.Text = Seudonimo;
            txtBusquedaCompras.Text = Seudonimo;
            LoadData = true;

        }

        private void Transacciones_Load(object sender, EventArgs e)
        {
            cbBusquedaVentas.DataSource = oBusquedasBL.GetBusquedasforTrans();
            cbBusquedaCompras.DataSource = oBusquedasBL.GetBusquedasforTrans();
            cbBusquedaVentas.SelectedIndex = cbBusquedaVentas.FindStringExact(TipoBusquedaInicial);
            cbBusquedaCompras.SelectedIndex = cbBusquedaCompras.FindStringExact(TipoBusquedaInicial);
            Functions.FormatDataGrid(grvVentas);
            Functions.FormatDataGrid(grvCompras);
            if (LoadData) //si van cargar los datos de un usuario se ejecuta
            {
                List<string> listaTrans = new List<string>();
                listaTrans = OperacionesBL.GetTransacciones();
                oTransaccionesBL.FuncBusquedas(txtBusquedaVenta, errorProvider1, "Busqueda requerido", cbBusquedaVentas,
                    grvVentas, ref updSelectedItemVenta, ref updtxtBusquedaVenta, ColumnasCompraVenta, listaTrans[0]);
                oTransaccionesBL.FuncBusquedas(txtBusquedaCompras, errorProvider1, "Busqueda requerido", cbBusquedaCompras,
                    grvCompras, ref updSelectedItemCompra, ref updtxtBusquedaCompra, ColumnasCompraVenta, listaTrans[1]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //oTransaccionesBL.FuncBusquedas(txtBusquedaVenta, errorProvider1, "Busqueda requerido", cbBusquedaVentas, 
            //    grvVentas, ref updSelectedItemVenta, ref updtxtBusquedaVenta, ColumnasCompraVenta, GetTypeOp());
            SelectExecuteBusqueda();
        }


        private void btnBuscarCompras_Click(object sender, EventArgs e)
        {
            //oTransaccionesBL.FuncBusquedas(txtBusquedaCompras, errorProvider1, "Busqueda requerido", cbBusquedaCompras,
            //    grvCompras, ref updSelectedItemCompra, ref updtxtBusquedaCompra, ColumnasCompraVenta, GetTypeOp());
            SelectExecuteBusqueda();
        }

        
        private void btnNueva_Click(object sender, EventArgs e)
        {
            SglEditNewTransaccion.Instance.MostrarForm();
            SglEditNewTransaccion.Instance.MDIContenedor(this.MdiParent);
        }


        private string GetTypeOp()
        {
            switch (tbTransacciones.SelectedIndex)
            {
                case 0:
                    return OperacionesBL.GetTransacciones()[0];
                case 1:
                    return OperacionesBL.GetTransacciones()[1];
                default:
                    return null;
            }
        }

        private DataGridView GetDataGrid()
        {
            switch (tbTransacciones.SelectedIndex)
            {
                case 0:
                    return grvVentas;
                case 1:
                    return grvCompras;
                default:
                    return null;
            }
        }

        private void SelectExecuteBusqueda()
        {
            switch (tbTransacciones.SelectedIndex)
            {
                case 0:
                    oTransaccionesBL.FuncBusquedas(txtBusquedaVenta, errorProvider1, "Busqueda requerido", cbBusquedaVentas,
                        grvVentas, ref updSelectedItemVenta, ref updtxtBusquedaVenta, ColumnasCompraVenta, GetTypeOp());
                    break;
                case 1:
                    oTransaccionesBL.FuncBusquedas(txtBusquedaCompras, errorProvider1, "Busqueda requerido", cbBusquedaCompras,
                    grvCompras, ref updSelectedItemCompra, ref updtxtBusquedaCompra, ColumnasCompraVenta, GetTypeOp());
                    break;
            }
        }


        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string TipoOp = GetTypeOp();
            DataGridView grvSelec = GetDataGrid();
            if (grvSelec != null)
            {
                int Id_Tran = Convert.ToInt32(Functions.GetCellfromDatagrid(grvSelec, "Id_Tran"));
                EditNewTransaccion frmEditNewTran = new EditNewTransaccion(Id_Tran, TipoOp);
                frmEditNewTran.MdiParent = this.MdiParent;
                frmEditNewTran.Show();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string TipoOp = GetTypeOp();
            DataGridView grvSelec = GetDataGrid();
            string updtxtBusqueda = string.Empty;
            string updSelectedItem = string.Empty;
            if (grvSelec != null)
            {
                int Id_Tran = Convert.ToInt32(Functions.GetCellfromDatagrid(grvSelec, "Id_Tran"));
                oTransaccionesBL.DeleteTransaccion(Id_Tran);
                if (grvSelec==grvVentas)
                {
                    updtxtBusqueda = updtxtBusquedaVenta;
                    updSelectedItem = updSelectedItemVenta;
                }
                if (grvSelec == grvCompras)
                {
                    updtxtBusqueda = updtxtBusquedaCompra;
                    updSelectedItem = updSelectedItemCompra;
                }
                oTransaccionesBL.ExecuteBusqueda(grvSelec, updSelectedItem, updtxtBusqueda, TipoOp);
                grvSelec.ClearSelection();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Transacciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SglTransacciones.Instance.ParentForm != null)
            {
                SglTransacciones.Instance.ParentForm.Show();
            }
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SglEditNewTransaccion.Instance.MostrarForm();
        }

        private void grvVentas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Functions.CheckCellMouseDown(grvVentas, e);
        }

        private void grvCompras_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Functions.CheckCellMouseDown(grvCompras, e);
        }

        private void menVentas_Opening(object sender, CancelEventArgs e)
        {
            DataGridView grv = GetDataGrid();
            if (grv.CurrentRow == null)
            {
                e.Cancel = true;
            }
        }

        private void btnBuscarVentaCompra_Click(object sender, EventArgs e)
        {
            SelectExecuteBusqueda();
        }


    }
}
