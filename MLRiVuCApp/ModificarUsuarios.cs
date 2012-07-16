using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLML;
using DAL;

namespace MLRiVuCApp
{
    public partial class ModificarUsuarios : Form
    {
        PaisesBL oPaises = new PaisesBL();
        Usuario oUsuario;
        UsuariosBL oUsuarioBL = new UsuariosBL();

        public ModificarUsuarios(string pSeudonimo)
        {
            InitializeComponent();
            oUsuario = oUsuarioBL.GetUsuarioBySeudonimo(pSeudonimo);
        }

        private void ModificarUsuarios_Load(object sender, EventArgs e)
        {
            cbPais.DataSource = oPaises.GetPaises();
            cbEstado.DataSource = oPaises.GetEstadosByPais(oUsuario.Pais);
            LoadUser();
        }

        private void LoadUser()
        {
            txtSeudonimo.Text=oUsuario.Seudonimo;
            txtMail.Text=oUsuario.Mail;
            txtNombre.Text= oUsuario.Nombre;
            txtApePaterno.Text=oUsuario.ApPaterno;
            txtApeMaterno.Text=oUsuario.ApMaterno;
            txtDireccion.Text = oUsuario.Direccion;
            txtCodigoPostal.Text=oUsuario.CP;
            txtColonia.Text=oUsuario.Colonia;
            txtTelCasa.Text=oUsuario.Tel_Casa;
            txtTelCel.Text=oUsuario.Tel_Cel;
            cbPais.SelectedIndex = cbPais.FindStringExact(oUsuario.Pais);
            cbEstado.SelectedIndex = cbEstado.FindStringExact(oUsuario.Estado);
            txtCiudad.Text = oUsuario.Ciudad;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean FormValido = true; //Empezamos suponiendo que el formulario es valido

            //Comparamos cada control con el valor de FormValido si todo es valido el valor final de FormValido es true
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtNombre, "Nombre es requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtApePaterno, "Apellido Paterno Requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtDireccion, "Direccion requerida");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtCodigoPostal, "Codigo postal requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtColonia, "Colonida requerida");
            //En telefono solo hay que proporcionar o el de casa o el celular
            FormValido = FormValido & Functions.ValidacionEspecialTel(errorProvider1, txtTelCasa, txtTelCel, "Telefono de casa o celular requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, cbPais, "Pais requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, cbEstado, "Estado requerido");
            FormValido = FormValido & Functions.ValidarControl(errorProvider1, txtCiudad, "Ciudad requerida");

            if (FormValido)
            {
                DialogResult respDialog;
                respDialog = MessageBox.Show("Desea actualizar los datos?", "Aviso", MessageBoxButtons.YesNo);
                if (respDialog == DialogResult.Yes)
                {
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
                    Boolean result=oUsuarioBL.UpdateUsuario(oUsuario);
                    if (!result)
                        MessageBox.Show("Error. No se pudieron actualizar los datos");
                    this.Close();
                }

            }

            
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEstado.DataSource = oPaises.GetEstadosByPais(cbPais.SelectedItem.ToString());
        }


    }
}
