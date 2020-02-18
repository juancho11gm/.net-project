using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
   public class DepartamentoRepositorio
    {

        public List<DepartamentoModelo> GetListadoDepartamentos()
        {
            using (var contexto = new JaverianaNETEntities())
            {
                  var listado = contexto.Departamentos.Select(c => new DepartamentoModelo
                {
                    Id = c.Id,
                    NombreDepartamento = c.NombreDepartamento,
                    PaisId = c.PaisId,
                }).ToList();

                return listado;
            }
        }

        public void CrearDepartamento(DepartamentoModelo departamento)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var entidad = new Departamentos
                {
                    Id = departamento.Id,
                    NombreDepartamento = departamento.NombreDepartamento,
                    PaisId = departamento.PaisId
                };

                contexto.Departamentos.Add(entidad);
                contexto.SaveChanges();

            }
        }

        public DepartamentoModelo GetDepartamento(int? id)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var departamento = contexto.Departamentos.Find(id);


                DepartamentoModelo cm = new DepartamentoModelo
                {
                    Id = departamento.Id,
                    NombreDepartamento = departamento.NombreDepartamento,
                    PaisId = departamento.PaisId,
                    Ciudades = new List<CiudadModelo>()
                };

                foreach (var item in departamento.Ciudades)
                {
                    CiudadModelo c = new CiudadModelo();
                    c.Id = item.Id;
                    c.NombreCiudad = item.NombreCiudad;
                    c.DepartamentoId = item.DepartamentoId;
                    cm.Ciudades.Add(c);

                }
                return cm;
            }

        }


        public void EditarDepartamento(DepartamentoModelo departamento)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var entidad = new Departamentos
                {
                    Id = departamento.Id,
                    NombreDepartamento = departamento.NombreDepartamento,
                    PaisId = departamento.PaisId
                };
                contexto.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void EliminarDepartamento(int? id)
        {
            using (var contexto = new JaverianaNETEntities())
            {

                contexto.Departamentos.Remove(contexto.Departamentos.Find(id));
                contexto.SaveChanges();
            }
        }

    }
}
