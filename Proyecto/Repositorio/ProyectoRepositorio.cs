using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ProyectoRepositorio
    {
        public List<CiudadModelo> GetListadoCiudades()
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var listado = contexto.Ciudades.Select(c => new CiudadModelo
                {
                    Id = c.Id,
                    NombreCiudad = c.NombreCiudad,
                    DepartamentoId = c.DepartamentoId
                }).ToList();

                return listado;
            }
        }

        public void CrearCiudad(CiudadModelo ciudad)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var entidad = new Ciudades
                {
                    Id = ciudad.Id,
                    NombreCiudad = ciudad.NombreCiudad,
                    DepartamentoId = ciudad.DepartamentoId
                };

                contexto.Ciudades.Add(entidad);
                contexto.SaveChanges();

            }
        }

        public CiudadModelo GetCiudad(int? id)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var ciudad = contexto.Ciudades.Find(id);
                CiudadModelo cm = new CiudadModelo
                {
                    Id = ciudad.Id,
                    NombreCiudad = ciudad.NombreCiudad,
                    DepartamentoId = ciudad.DepartamentoId
                };
                return cm;
            }

        }

        public void EditarCiudad(CiudadModelo ciudad)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var entidad = new Ciudades
                {
                    Id = ciudad.Id,
                    NombreCiudad = ciudad.NombreCiudad,
                    DepartamentoId = ciudad.DepartamentoId
                };
                contexto.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void EliminarCiudad(int? id)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                
                contexto.Ciudades.Remove(contexto.Ciudades.Find(id));
                contexto.SaveChanges();
            }
        }




    }
}
