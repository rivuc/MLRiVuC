using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLML
{
    public class UsuariosBL
    {
        public List<string> GetUsuarios()
        {
            return (from u in Usuario.All()
                    select u.Seudonimo).ToList();
        }

        public List<string> GetUsuariosSeudonimoFullName()
        {
            return (from u in Usuario.All()
                    select (u.Seudonimo+ " - "+u.Nombre + " " + u.ApPaterno)).ToList();
        }

        public Usuario GetUsuarioBySeudonimo(string Seudonimo)
        {
            Seudonimo = Seudonimo.Trim();
            return (from u in Usuario.All()
                    where u.Seudonimo == Seudonimo
                    select u).SingleOrDefault();
        }

        public List<Usuario> GetUsuariosAllData()
        {
            return (from u in Usuario.All()
                    select u).ToList();
        }

        public List<Usuario> GetUsuariosBySeudonimo(string Seudonimo)
        {
            Seudonimo = Seudonimo.Trim();
            return (from u in Usuario.All()
                    where u.Seudonimo.Contains(Seudonimo)
                    select u).ToList();
        }

        public List<Usuario> GetUsuariosByMail(string Mail)
        {
            Mail = Mail.Trim();
            return (from u in Usuario.All()
                    where u.Mail.Contains(Mail)
                    select u).ToList();
        }

        public List<Usuario> GetUsuariosByPais(string Pais)
        {
            Pais = Pais.Trim();
            return (from u in Usuario.All()
                    where u.Pais.Contains(Pais)
                    select u).ToList();
        }

        public List<Usuario> GetUsuariosByEstado(string Estado)
        {
            Estado = Estado.Trim();
            return (from u in Usuario.All()
                    where u.Estado.Contains(Estado)
                    select u).ToList();
        }

        public List<Usuario> GetUsuariosByNombre(string Nombre)
        {
            Nombre = Nombre.Trim();
            return (from u in Usuario.All()
                    where (u.Nombre.Contains(Nombre) | u.ApPaterno.Contains(Nombre) | u.ApMaterno.Contains(Nombre))
                    select u).ToList();
        }

        public Boolean ExistUser(string Seudonimo)
        {
            int Count;
            Count = (from u in Usuario.All()
                     where u.Seudonimo == Seudonimo
                     select u).Count();
            if (Count > 0)
                return true;
            else
                return false;
        }

        public Boolean AddUsuario(Usuario pUsuario)
        {
            try
            {
                pUsuario.Nombre = pUsuario.Nombre.Trim();
                pUsuario.ApPaterno = pUsuario.ApPaterno.Trim();
                pUsuario.ApMaterno = pUsuario.ApMaterno.Trim();
                pUsuario.Ciudad = pUsuario.Ciudad.Trim();
                pUsuario.Pais = pUsuario.Pais.Trim();
                pUsuario.CP = pUsuario.CP.Trim();
                pUsuario.Colonia = pUsuario.Colonia.Trim();
                pUsuario.Direccion = pUsuario.Direccion.Trim();
                pUsuario.Seudonimo = pUsuario.Seudonimo.Trim();
                pUsuario.Tel_Casa = pUsuario.Tel_Casa.Trim();
                pUsuario.Tel_Cel = pUsuario.Tel_Cel.Trim();
                pUsuario.Mail = pUsuario.Mail.Trim();
                pUsuario.Estado = pUsuario.Estado.Trim();
                pUsuario.FchAlta = DateTime.Now.ToString("yyyy-MM-dd");
                pUsuario.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean UpdateUsuario(Usuario pUsuario)
        {
            try
            {
                pUsuario.Nombre = pUsuario.Nombre.Trim();
                pUsuario.ApPaterno = pUsuario.ApPaterno.Trim();
                pUsuario.ApMaterno = pUsuario.ApMaterno.Trim();
                pUsuario.CP = pUsuario.CP.Trim();
                pUsuario.Colonia = pUsuario.Colonia.Trim();
                pUsuario.Direccion = pUsuario.Direccion.Trim();
                pUsuario.Seudonimo = pUsuario.Seudonimo.Trim();
                pUsuario.Tel_Casa = pUsuario.Tel_Casa.Trim();
                pUsuario.Tel_Cel = pUsuario.Tel_Cel.Trim();
                pUsuario.Mail = pUsuario.Mail.Trim();
                pUsuario.Pais = pUsuario.Pais.Trim();
                pUsuario.Estado = pUsuario.Estado.Trim();
                pUsuario.Ciudad = pUsuario.Ciudad.Trim();
                pUsuario.Update();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean DeleteUsuariobySeudonimo(string Seudonimo)
        {
            try
            {
                Seudonimo=Seudonimo.Trim();
                Usuario oUsuario = (from u in Usuario.All()
                                    where u.Seudonimo == Seudonimo
                                    select u).SingleOrDefault();
                oUsuario.Delete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
