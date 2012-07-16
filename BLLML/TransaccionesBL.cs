using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace BLML
{
    public class TransaccionesBL
    {

        public Boolean AddTransaccion(Transaccione pTransaccion)
        {
            try
            {
                UsuariosBL BLUsuarios=new UsuariosBL();
                if (BLUsuarios.ExistUser(pTransaccion.Seudonimo))
                {
                    pTransaccion.Dsc = pTransaccion.Dsc.Trim();
                    pTransaccion.FchAlta = DateTime.Now.ToString("yyyy-MM-dd");
                    pTransaccion.Save();
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Transacción no valida. El usuario seleccionado no existe");
                    return false;
                }
                    
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean UpdateTransaccion(Transaccione pTransaccion)
        {
            try
            {
                pTransaccion.Dsc = pTransaccion.Dsc.Trim();
                pTransaccion.Update();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ExisteTransaccionBySeudonimo(string Seudonimo)
        {
            try
            {
                int Count;
                Count = (from u in Transaccione.All()
                         where u.Seudonimo == Seudonimo
                         select u).Count();
                if (Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Transaccione GetTransById(int Id, string TipoOp)
        {
            return (from u in Transaccione.All()
                    where u.Id_Tran==Id & u.Tipo_Op == TipoOp
                    select u).SingleOrDefault();
        }

        public Transaccione GetTransById(int Id)
        {
            return (from u in Transaccione.All()
                    where u.Id_Tran == Id
                    select u).SingleOrDefault();
        }

        public List<Transaccione> GetTransByAllDataOp(string TipOp)
        {
            return (from u in Transaccione.All()
                    where u.Tipo_Op == TipOp
                    select u).ToList();
        }

        public List<Transaccione> GetTransBySeudonimoOp(string Seudonimo, string TipOp)
        {
            return (from u in Transaccione.All()
                    where u.Seudonimo.Contains(Seudonimo) & u.Tipo_Op==TipOp
                    select u).ToList();
        }

        public List<Transaccione> GetTransByEstatusOp(string Estatus, string TipoOp)
        {
            return (from u in Transaccione.All()
                    where u.Estatus.Contains(Estatus) & u.Tipo_Op == TipoOp
                    select u).ToList();
        }

        public List<Transaccione> GetTransByFechaOp(string Fecha, string TipoOp)
        {
            return (from u in Transaccione.All()
                    where u.FchCompraVenta.Contains(Fecha) & u.Tipo_Op == TipoOp
                    select u).ToList();
        }

        public List<Transaccione> GetTransByMensajeriaOp(string Mensajeria, string TipoOp)
        {
            return (from u in Transaccione.All()
                    where u.Mensajeria.Contains(Mensajeria) & u.Tipo_Op == TipoOp
                    select u).ToList();
        }

        public List<Transaccione> GetTransByNombreOp(string Nombre, string TipoOp)
        {
            return (from u in Transaccione.All()
                    join a in Usuario.All()
                    on u.Seudonimo equals a.Seudonimo
                    where (a.Nombre.Contains(Nombre) | a.ApPaterno.Contains(Nombre) | a.ApMaterno.Contains(Nombre))
                    & u.Tipo_Op == TipoOp
                    select u).ToList();
        }

        public Boolean DeleteTransaccion(int Id_Tran)
        {
            try
            {
                Transaccione oTrans = GetTransById(Id_Tran);
                oTrans.Delete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ExecuteBusqueda(DataGridView grv, string TipoBusq, string Wordtofind, string TipoOp)
        {
            if (TipoBusq.ToUpper() == "SEUDONIMO")
                grv.DataSource = GetTransBySeudonimoOp(Wordtofind, TipoOp);
            if (TipoBusq.ToUpper() == "ESTATUS")
                grv.DataSource = GetTransByEstatusOp(Wordtofind, TipoOp);
            if (TipoBusq.ToUpper() == "FECHA")
                grv.DataSource = GetTransByFechaOp(Wordtofind, TipoOp);
            if (TipoBusq.ToUpper() == "MENSAJERIA")
                grv.DataSource = GetTransByMensajeriaOp(Wordtofind, TipoOp);
            if (TipoBusq.ToUpper() == "NOMBRE")
                grv.DataSource = GetTransByNombreOp(Wordtofind, TipoOp);
            if (TipoBusq.ToUpper() == "VER TODO")
                grv.DataSource = GetTransByAllDataOp(TipoOp);
        }

        public void FuncBusquedas(Control CtrToValidate, ErrorProvider oError, string TextError,
            ComboBox cb, DataGridView grv, ref string updSelected, ref string updtxtBusqueda, 
            string[] NameHeaders, string Type_Op)
        {
            Boolean FormValido = true; //Empezamos suponiendo que el formulario es valido
            if (cb.SelectedItem.ToString()!="Ver todo")
                FormValido = Functions.ValidarControl(oError, CtrToValidate, "Busqueda requerido");
            if (FormValido)
            {
                ExecuteBusqueda(grv, cb.SelectedItem.ToString().ToUpper(), CtrToValidate.Text, Type_Op);
                Functions.SetHeaderColumnsName(grv, NameHeaders, 1);
                if (grv.Rows.Count > 0)
                {
                    grv.Columns[0].Visible = false;
                    //grv.Columns[1].Visible = false; //Oculta la columna Id
                    grv.Columns[2].Visible = false; //oculta la columna Fecha Transaccion
                    grv.ClearSelection();
                    updSelected = cb.SelectedItem.ToString();
                    updtxtBusqueda = CtrToValidate.Text;
                }
            }
        }

    }
}
