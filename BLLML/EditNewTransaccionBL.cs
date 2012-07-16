using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace BLML
{
    public class EditNewTransaccionBL
    {
        public void LoadControlsContents(ComboBox cbTipoOp, ComboBox cbSeudonimo, ComboBox cbMensajeria,
            ComboBox cbCalifRecib, ComboBox cbCalifOtorg)
        {
            try
            {
                string Seleccione = System.Configuration.ConfigurationSettings.AppSettings["NewTransOperacion"];
                OperacionesBL oOperacionesBL = new OperacionesBL();
                UsuariosBL oUsuariosBL = new UsuariosBL();
                MensajeriasBL oMensajeriasBL = new MensajeriasBL();
                CalificacionesBL oCalificacionesBL = new CalificacionesBL();

                cbTipoOp.DataSource = oOperacionesBL.GetTransaccionesAddExtraItem(Seleccione);
                cbSeudonimo.DataSource = oUsuariosBL.GetUsuarios();
                cbMensajeria.DataSource = oMensajeriasBL.GetMensajerias();
                cbCalifRecib.DataSource = oCalificacionesBL.GetCalificaciones();
                cbCalifOtorg.DataSource = oCalificacionesBL.GetCalificaciones();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void InitialSelection(Label lblEstatus, string initlblEstatus, ComboBox cbTipoOp, string initTipoOp, 
            ComboBox cbSeudonimo, string initSeudonimo, ComboBox cbMensajeria, string initMensajeria, 
            ComboBox cbCalifRecib, string initCalifRecib, ComboBox cbCalifOtorg, string initCalifOtorg)
        {
            try
            {
                lblEstatus.Text = initlblEstatus;
                cbTipoOp.SelectedIndex = cbTipoOp.FindStringExact(initTipoOp);
                cbSeudonimo.SelectedIndex = cbSeudonimo.FindStringExact(initSeudonimo);
                cbMensajeria.SelectedIndex = cbMensajeria.FindStringExact(initMensajeria);
                cbCalifRecib.SelectedIndex = cbCalifRecib.FindStringExact(initCalifRecib);
                cbCalifOtorg.SelectedIndex = cbCalifRecib.FindStringExact(initCalifOtorg);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public string CheckEstatus(ComboBox cbCalifRecib, ComboBox cbCalifOtorg)
        {
            try
            {
                if (cbCalifRecib.DataSource != null && cbCalifOtorg.DataSource != null)
                {
                    string CheckCalificacion = System.Configuration.ConfigurationSettings.AppSettings["CheckCalificacion"];
                    if ((cbCalifRecib.SelectedItem.ToString() == CheckCalificacion)
                        || (cbCalifOtorg.SelectedItem.ToString() == CheckCalificacion))
                    {
                        return System.Configuration.ConfigurationSettings.AppSettings["BeginStatus"];
                    }
                    else
                        return System.Configuration.ConfigurationSettings.AppSettings["EndStatus"];
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EnabledControls(Control ctr, bool Value)
        {
            ctr.Enabled = Value;
        }

        public void CheckEnabledControls(string Estatus, Button BtnGuardar)
        {
            if (Estatus == System.Configuration.ConfigurationSettings.AppSettings["EndStatus"])
                EnabledControls(BtnGuardar, false);
        }

    }
}
