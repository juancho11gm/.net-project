using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class PaisRepositorio
    {
        public List<PaisModelo> GetListadoPaises()
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var listado = contexto.Paises.Select(c => new PaisModelo
                {
                    Id = c.Id,
                    NombrePais = c.NombrePais,
                }).ToList();

                return listado;
            }
        }

        public void CrearPais(PaisModelo pais)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var entidad = new Paises
                {
                    Id = pais.Id,
                    NombrePais = pais.NombrePais,
                };

                contexto.Paises.Add(entidad);
                contexto.SaveChanges();

            }
        }

        public PaisModelo GetPais(int? id)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var pais = contexto.Paises.Find(id);
                PaisModelo cm = new PaisModelo
                {
                    Id = pais.Id,
                    NombrePais = pais.NombrePais,
                    Departamentos = new List<DepartamentoModelo>()

                };

                foreach (var item in pais.Departamentos)
                {
                    DepartamentoModelo c = new DepartamentoModelo();
                    c.Id = item.Id;
                    c.NombreDepartamento = item.NombreDepartamento;
                    c.PaisId = item.PaisId;
                    cm.Departamentos.Add(c);

                }

                return cm;
            }

        }

        public void EditarPais(PaisModelo pais)
        {
            using (var contexto = new JaverianaNETEntities())
            {
                var entidad = new Paises
                {
                    Id = pais.Id,
                    NombrePais = pais.NombrePais,
                };
                contexto.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void EliminarPais(int? id)
        {
            using (var contexto = new JaverianaNETEntities())
            {

                contexto.Paises.Remove(contexto.Paises.Find(id));
                contexto.SaveChanges();
            }
        }

    }
}
