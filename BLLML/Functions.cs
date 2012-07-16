using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BLML
{
    public class Functions
    {
        public static bool ValidarControl(ErrorProvider Provider, Control ctrl, string ErrorMensaje)
        {
            string error = null;
            if (string.IsNullOrEmpty(ctrl.Text.Trim()))
            {
                error = ErrorMensaje;
            }
            Provider.SetError(ctrl, error);

            //Si el error es nulo es que no hubo error y devolvemos true
            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        public static bool ValidarControlWithText(ErrorProvider Provider, Control ctrl, string TexttoValidate, string ErrorMensaje)
        {
            string error = null;
            if (string.IsNullOrEmpty(ctrl.Text.Trim()) || ctrl.Text.Equals(TexttoValidate))
            {
                error = ErrorMensaje;
            }
            Provider.SetError(ctrl, error);

            //Si el error es nulo es que no hubo error y devolvemos true
            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        public static bool ValidacionEspecialTel(ErrorProvider Provider, Control ctrlCasa, Control ctrlCel, string ErrorMensaje)
        {
            string error = null;
            string Patron = "[()_-]";
            string telCasa = Regex.Replace(ctrlCasa.Text, Patron, string.Empty).Trim();
            string telCel = Regex.Replace(ctrlCel.Text, Patron, string.Empty).Trim();
            if (string.IsNullOrEmpty(telCasa) & (string.IsNullOrEmpty(telCel)))
            {
                error = ErrorMensaje;
            }

            Provider.SetError(ctrlCasa, error);
            Provider.SetError(ctrlCel, error);

            //Si el error es nulo es que no hubo error y devolvemos true
            if (string.IsNullOrEmpty(error) | (string.IsNullOrEmpty(error)))
                return true;
            else
                return false;
        }


        public static Boolean ValidarMail(string mail)
        {
            string modelo = @"^([\w\d\-\.]+)@{1}(([\w\d\-]{1,67})| ([\w\d\-]+\.[\w\d\-]{1,67}))\.(([a-zA-Z\d]{2,4})(\.[a-zA-Z\d]{2})?)$";
            Regex reg = new Regex(modelo);
            if (reg.IsMatch(mail))
                return true;
            else
                return false;
        }


        public static bool ValidarControlMail(ErrorProvider Provider, Control ctrl, string ErrorMensaje)
        {
            string error = null;
            if (string.IsNullOrEmpty(ctrl.Text) || ValidarMail(ctrl.Text)==false)
            {
                error = ErrorMensaje;
            }
            Provider.SetError(ctrl, error);

            //Si el error es nulo es que no hubo error y devolvemos true
            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        //obtiene el valor de una celda
        public static string GetCellfromDatagrid(DataGridView grid, string Celda)
        {
            try
            {
                int CurrentRow = Convert.ToInt32(grid.CurrentRow.Index);
                string Valor = grid.Rows[CurrentRow].Cells[Celda].Value.ToString();
                return Valor;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static void InitialSelectCb(ComboBox cb, string Seleccion)
        {
            cb.SelectedIndex=cb.FindStringExact(Seleccion);
        }

        public static void SetHeaderColumnsName(DataGridView grv, string[] NombreColums, int initialCol)
        {
            for (int i = 0; i < NombreColums.Length; i++)
			{
                grv.Columns[i+initialCol].HeaderText = NombreColums[i];
			}
        }

        public static void FormatDataGrid(DataGridView grv)
        {
            DataGridViewCellStyle style = grv.ColumnHeadersDefaultCellStyle;
            style.WrapMode = DataGridViewTriState.False;//Para que ocupe solo una lina
            grv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //Para que el texto de la cabecera se vea completo 
            grv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells; //Para que el alto de las filas se ajuste su contenido 
            grv.DefaultCellStyle.WrapMode = DataGridViewTriState.True; //para que se el contenido de la celda se ajuste al alto y ancho
            grv.RowHeadersVisible = false; //Para no mostrar la cabecera las filas
            grv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; //para evitar modificar el alto de las filas
            grv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void ConfigForm1(Form frm)
        {
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public static void CheckCellMouseDown(DataGridView grv, DataGridViewCellMouseEventArgs e)
        {
            //si es el boton derechi y es una fila de contenido del datagridview
            if (e.Button == MouseButtons.Right && e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                grv.CurrentCell = grv[e.ColumnIndex, e.RowIndex];
            }
            else
                //Si se dio click en la cabecera y la seleccion de la fila actual no es nulo se selecciona la primera fila
                if (e.RowIndex < 0 && grv.CurrentCell != null)
                {
                    grv.CurrentCell = grv[e.ColumnIndex, 0];
                }
        }
    }
}
