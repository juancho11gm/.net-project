using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioRepositorio
    {
        public List<UsuarioModelo> GetUsuarios()
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var listado = contexto.AspNetUsers.Select(c => new UsuarioModelo
                {
                    Id = c.Id,
                    Email = c.Email,
                }).ToList();

                return listado;
            }
        }

        public UsuarioModelo GetUsuario(string id)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var usuario = contexto.AspNetUsers.Find(id);
                UsuarioModelo cm = new UsuarioModelo
                {
                    Id = usuario.Id,
                    Email = usuario.Email
                };
                return cm;
            }
        }

        public void EliminarUsuario(string id)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var usuario = contexto.AspNetUsers.Remove(contexto.AspNetUsers.Find(id));
                contexto.SaveChanges();

            }
        }

        public void EditarUsuario(UsuarioModelo usuario)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var us = contexto.AspNetUsers.Find(usuario.Id);
                us.Email = usuario.Email;
                var entidad = new AspNetUsers
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                };
                contexto.Entry(us).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void AgregarAdministrador(string id)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                AspNetUserRoles au = new AspNetUserRoles
                {
                    UserId = id,
                    RoleId = "1"
                };
                
                contexto.AspNetUserRoles.Add(au);
                contexto.SaveChanges();

            }
        }

        public void AgregarUsuario(UsuarioModelo usuario)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                AspNetUserRoles au = new AspNetUserRoles
                {
                    UserId = usuario.Id,
                    RoleId = "2"
                };

                contexto.AspNetUserRoles.Add(au);
                contexto.SaveChanges();

            }
        }
    }
}
