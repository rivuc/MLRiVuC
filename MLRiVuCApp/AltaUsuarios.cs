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
    public partial class AltaUsuarios : Form
    {
        PaisesBL oPaises = new PaisesBL();
        Usuario oUsuario = new Usuario();
        UsuariosBL oUsuarioBL = new UsuariosBL();

        public AltaUsuarios()
        {
            InitializeComponent();
        }

        public AltaUsuarios(Form ParentForm)
        {
            InitializeComponent();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Boolean FormValido = true; //Empezamos suponiendo que el formulario es valido

            //Comparamos cada control con el valor de FormValido si todo es valido el valor final de FormValido es true
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtSeudonimo, "Escriba un seudonimo");
            FormValido = FormValido & Functions.ValidarControlMail(errorProvider1, txtMail, "Escriba un mail");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtNombre, "Nombre es requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtApePaterno, "Apellido Paterno Requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtDireccion, "Direccion requerida");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtCodigoPostal, "Codigo postal requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtColonia, "Colonida requerida");
            //En telefono solo hay que proporcionar o el de casa o el celular
            FormValido = FormValido & Functions.ValidacionEspecialTel(errorProvider1, txtTelCasa, txtTelCel, "Telefono de casa o celular requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, cbPais, "Pais requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtCiudad, "Ciudad requerida");

            if (FormValido)
            {
                string[] respDialog=new string[]{string.Empty};
                DialogoGuardar(respDialog);
                if (respDialog[0] == "1" || respDialog[0] == "2")
                {
                    Boolean Result; //Almacenara el resultado de guardar el registro
                    oUsuario.Seudonimo = txtSeudonimo.Text;
                    oUsuario.Mail = txtMail.Text;
                    oUsuario.Nombre = txtNombre.Text;
                    oUsuario.ApPaterno = txtApePaterno.Text;
                    oUsuario.ApMaterno = txtApeMaterno.Text;
                    oUsuario.Direccion = txtDireccion.Text;
                    oUsuario.CP = txtCodigoPostal.Text;
                    oUsuario.Colonia = txtColonia.Text;
                    oUsuario.Tel_Casa = txtTelCasa.Text;
                    oUsuario.Tel_Cel = txtTelCel.Text;
                    oUsuario.Pais = cbPais.SelectedItem.ToString();
                    oUsuario.Estado = cbEstado.SelectedItem.ToString();
                    oUsuario.Ciudad = txtCiudad.Text;
                    Result = oUsuarioBL.AddUsuario(oUsuario);
                    if (Result ==false)
                        MessageBox.Show("Error. Verifique los datos no se guardo el registro");
                    else
                        this.Close();
                    if (respDialog[0] == "2")
                    {
                        AltaUsuarios frnNew = new AltaUsuarios();
                        frnNew.Show();
                        frnNew.MdiParent = this.MdiParent;
                    }
                }
                
            }


        }

        private void AltaUsuarios_Load(object sender, EventArgs e)
        {
            string Pais="Mexico";
            cbPais.DataSource = oPaises.GetPaises();
            cbPais.SelectedIndex = cbPais.FindStringExact(Pais);
            cbEstado.DataSource = oPaises.GetEstadosByPais(Pais);
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox tmpCbPais=(ComboBox)sender;
            cbEstado.DataSource = oPaises.GetEstadosByPais(tmpCbPais.SelectedValue.ToString());
        }

        private void AltaUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SglAltaUsuarios.Instance.ParentForm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogoGuardar(string[] Resp)
        {
            string TituloFrm = "Guardar Datos";
            string MsgConfirmar = "Desea guardar estos datos?";
            string TextGuardar = "Guardar";
            string TextGuardarAgregar = "Guardar y agregar nuevo";
            string TextCancelar = "Cancelar";
            CustomMessageBox frmCustomMsgBox = new CustomMessageBox(Resp, MsgConfirmar, TituloFrm, TextGuardar, TextGuardarAgregar, TextCancelar);
            frmCustomMsgBox.ShowDialog();
        }


    }
}
