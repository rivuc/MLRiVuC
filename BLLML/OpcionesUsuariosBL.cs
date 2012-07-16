using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLML
{
    public class OpcionesUsuariosBL
    {
        private UsuariosBL _oUsuriosBL {get; set;}
        protected UsuariosBL oUsuariosBL 
        {
            get
            {
                if (_oUsuriosBL==null)
                    _oUsuriosBL=new UsuariosBL();
                return _oUsuriosBL;
            }
        }

        private TransaccionesBL _TransaccionesBL { get; set; }
        protected TransaccionesBL oTransaccionesBL
        {
            get
            {
                if (_TransaccionesBL == null)
                    _TransaccionesBL = new TransaccionesBL();
                return _TransaccionesBL;
            }
        }


        public Boolean EliminarUsuario(string seudonimo)
        {
            if (oTransaccionesBL.ExisteTransaccionBySeudonimo(seudonimo))
            {
                MessageBox.Show("No se puede eliminar usuario." + Convert.ToChar(13) + "Para borrarlo debe eliminar las transacciones relacionadas a este usuario", "Eliminar");
                return false;
            }
            else
            {
                DialogResult respDialog;
                respDialog = MessageBox.Show("Esta seguro de eliminar al usuario: " + seudonimo + "?", "Confirmar", MessageBoxButtons.YesNo);
                if (respDialog == DialogResult.Yes)
                {
                    Boolean result;
                    result = oUsuariosBL.DeleteUsuariobySeudonimo(seudonimo);
                    return result;
                }
                else
                    return false;
            }
        }

        public void ExecuteBusqueda(DataGridView grv, string Tipo, string Wordtofind)
        {
            if (Tipo.ToUpper() == "SEUDONIMO")
                grv.DataSource = oUsuariosBL.GetUsuariosBySeudonimo(Wordtofind);
            if (Tipo.ToUpper() == "MAIL")
                grv.DataSource = oUsuariosBL.GetUsuariosByMail(Wordtofind);
            if (Tipo.ToUpper() == "PAIS")
                grv.DataSource = oUsuariosBL.GetUsuariosByPais(Wordtofind);
            if (Tipo.ToUpper() == "ESTADO")
                grv.DataSource = oUsuariosBL.GetUsuariosByEstado(Wordtofind);
            if (Tipo.ToUpper() == "NOMBRE")
                grv.DataSource = oUsuariosBL.GetUsuariosByNombre(Wordtofind);
            if (Tipo.ToUpper() == "VER TODO")
                grv.DataSource = oUsuariosBL.GetUsuariosAllData();
        }

        public void FuncBusquedas(Control CtrToValidate, ErrorProvider errorprov, string TextError,
            ComboBox cb, DataGridView grv, ref string updSelected, ref string updtxtBusqueda, 
            string[] NameHeaders)
        {
            Boolean FormValido = true; //Empezamos suponiendo que el formulario es valido
            if (cb.SelectedItem.ToString() != "Ver todo")
                FormValido = Functions.ValidarControl(errorprov, CtrToValidate, TextError);
            if (FormValido)
            {
                ExecuteBusqueda(grv, cb.SelectedItem.ToString().ToUpper(), CtrToValidate.Text);
                if (grv.Rows.Count > 0)
                {
                    grv.Columns[0].Visible = false;
                    grv.ClearSelection();
                    updSelected = cb.SelectedItem.ToString();
                    updtxtBusqueda = CtrToValidate.Text;
                    Functions.SetHeaderColumnsName(grv, NameHeaders, 1);
                }
            }
        }
    }
}
