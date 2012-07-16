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

namespace MLRiVuCApp
{
    public partial class EditNewTransaccion : Form
    {
        OperacionesBL OperacionesBL = new OperacionesBL();
        UsuariosBL oUsuariosBL = new UsuariosBL();
        MensajeriasBL oMensajeriaBL = new MensajeriasBL();
        CalificacionesBL oCalificacionesBL = new CalificacionesBL();
        TransaccionesBL oTransaccionesBL = new TransaccionesBL();
        Transaccione oTrans;
        EditNewTransaccionBL oEditNew = new EditNewTransaccionBL();
        string SeleccionInicialCalif = System.Configuration.ConfigurationSettings.AppSettings["NewTransCalif"];
        string EstatusNuevo = System.Configuration.ConfigurationSettings.AppSettings["NewTransEstatus"];
        string OperacionNuevo = System.Configuration.ConfigurationSettings.AppSettings["NewTransOperacion"];
        string MensajeriaNuevo = System.Configuration.ConfigurationSettings.AppSettings["NewTransMensajeria"];
        string SeudonimoNuevo = System.Configuration.ConfigurationSettings.AppSettings["Seleccione"];
        Boolean NuevoReg = true; //Verificar si va ser un nuevo registro o es una actualizacion
        string[] Resp = new string[] { string.Empty };//Respuesta al Dialog

        public EditNewTransaccion()
        {
            InitializeComponent();
            oEditNew.LoadControlsContents(cbTipoOp, cbSeudonimo, cbMensajeria, cbCalifRecib, cbCalifOtorg);
            oEditNew.InitialSelection(lblEstatus, EstatusNuevo, cbTipoOp, OperacionNuevo, cbSeudonimo, SeudonimoNuevo,
                cbMensajeria, MensajeriaNuevo, cbCalifRecib, SeleccionInicialCalif, cbCalifOtorg, SeleccionInicialCalif);
            cbSeudonimo.Text = SeudonimoNuevo;
            oTrans = new Transaccione();
        }

        public EditNewTransaccion(int Id_Tran, string Type_Op)
        {
            InitializeComponent();
            oTrans = oTransaccionesBL.GetTransById(Id_Tran, Type_Op);
            oEditNew.LoadControlsContents(cbTipoOp, cbSeudonimo, cbMensajeria, cbCalifRecib, cbCalifOtorg);
            oEditNew.InitialSelection(lblEstatus, oTrans.Estatus, cbTipoOp, oTrans.Tipo_Op, cbSeudonimo, oTrans.Seudonimo,
                cbMensajeria, oTrans.Mensajeria, cbCalifRecib, oTrans.Calif_Recib, cbCalifOtorg, oTrans.Calif_Otorg);
            dtpFecha.Text = oTrans.FchCompraVenta;
            txtDescripcion.Text = oTrans.Dsc;
            txtNumdeGuia.Text = oTrans.NumGuia;
            nudCantidad.Value = (decimal)oTrans.Cantidad;
            nudPrecio.Value = (decimal)oTrans.Precio;
            nudEnvio.Value = (decimal)oTrans.PrecioEnvio;
            txtTotal.Text = oTrans.Total.ToString();
            NuevoReg = false;
        }


        private void EditNewTransaccion_Load(object sender, EventArgs e)
        {
            oEditNew.CheckEnabledControls(lblEstatus.Text, btnGuardar);
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            MontoTotal();
        }

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {
            MontoTotal();
        }

        private void nudEnvio_ValueChanged(object sender, EventArgs e)
        {
            MontoTotal();
        }

        private void MontoTotal()
        {
            txtTotal.Text = ((nudCantidad.Value * nudPrecio.Value) + nudEnvio.Value).ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean FormValido = true; //Empezamos suponiendo que el formulario es valido

            //Comparamos cada control con el valor de FormValido si todo es valido el valor final de FormValido es true
            FormValido = FormValido & Functions.ValidarControlWithText(errorProvider1, cbTipoOp, OperacionNuevo, "Seleccione una operacion");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, cbSeudonimo, "Seleccione un seudonimo");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, dtpFecha, "Fecha es requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, cbMensajeria, "Seleccione una mensajeria");

            if (FormValido)
            {
                MontoTotal();
                DialogoGuardar();
                if ((Resp[0] == "1") || (Resp[0] == "2"))
                {
                    Boolean Result;
                    oTrans.Tipo_Op = cbTipoOp.SelectedItem.ToString();
                    oTrans.Estatus = lblEstatus.Text;
                    oTrans.Seudonimo = cbSeudonimo.Text;
                    oTrans.FchCompraVenta = dtpFecha.Value.ToString("yyyy-MM-dd");
                    oTrans.Dsc = txtDescripcion.Text;
                    oTrans.Calif_Recib = cbCalifRecib.SelectedItem.ToString();
                    oTrans.Calif_Otorg = cbCalifOtorg.SelectedItem.ToString();
                    oTrans.Mensajeria = cbMensajeria.SelectedItem.ToString();
                    oTrans.Cantidad = Convert.ToDouble(nudCantidad.Value);
                    oTrans.Precio = Convert.ToDouble(nudPrecio.Value);
                    oTrans.Total = Convert.ToDouble(txtTotal.Text);
                    oTrans.NumGuia = txtNumdeGuia.Text;
                    oTrans.PrecioEnvio = Convert.ToDouble(nudEnvio.Value);
                    if (NuevoReg)
                        Result = oTransaccionesBL.AddTransaccion(oTrans);
                    else
                        Result = oTransaccionesBL.UpdateTransaccion(oTrans);
                    if (Result == false)
                    {
                        MessageBox.Show("No se guardo el registro");
                    }
                    else
                        this.Close();
                    if ((Resp[0] == "2"))
                    {
                        EditNewTransaccion frmNew = new EditNewTransaccion();
                        frmNew.Show();
                        frmNew.MdiParent = this.MdiParent;
                    }
                }

            }
        }

        private void cbCalifRecib_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEstatus.Text = oEditNew.CheckEstatus(cbCalifRecib, cbCalifOtorg);
            MontoTotal();
        }

        private void cbCalifOtorg_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEstatus.Text = oEditNew.CheckEstatus(cbCalifRecib, cbCalifOtorg);
            MontoTotal();
        }

        private void DialogoGuardar()
        {
            string TituloFrm = "Guardar Datos";
            string MsgConfirmar = "Desea guardar estos datos?";
            string MsgAdvertencia = "El estatus actual es finalizado, si guarda este registro no podra volver a ser modificado";
            string MsgFinal;
            if (lblEstatus.Text == "Finalizado")
                MsgFinal = MsgAdvertencia + "\n" + MsgConfirmar;
            else
                MsgFinal = MsgConfirmar;
            string TextGuardar="Guardar";
            string TextGuardarAgregar="Guardar y agregar nuevo";
            string TextCancelar="Cancelar";
            CustomMessageBox frmCustomMsgBox = new CustomMessageBox(Resp, MsgFinal, TituloFrm, TextGuardar, TextGuardarAgregar, TextCancelar);
            frmCustomMsgBox.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditNewTransaccion_FormClosing(object sender, FormClosingEventArgs e)
        {
        }




    }
}
