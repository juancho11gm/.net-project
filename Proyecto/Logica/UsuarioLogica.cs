using Modelos;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UsuarioLogica
    {
        public List<UsuarioModelo> GetUsuarios()
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            return repositorio.GetUsuarios();
        }

        public UsuarioModelo GetUsuario(string id)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            return repositorio.GetUsuario(id);
        }

        public void EliminarUsuario(string id)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            repositorio.EliminarUsuario(id);
        }

        public UsuarioModelo EditarUsuario(string id)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            return repositorio.GetUsuario(id);
        }

        public void EditarUsuario(UsuarioModelo usuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            repositorio.EditarUsuario(usuario);
        }

        public void AgregarUsuario(UsuarioModelo usuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            repositorio.AgregarUsuario(usuario);
        }

        public void AgregarAdministrador(string id)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            repositorio.AgregarAdministrador(id);
        }

    }
}
