using Modelos;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CiudadLogica
    {
        public List<CiudadModelo> GetListadoCiudades()
        {
            ProyectoRepositorio repositorio = new ProyectoRepositorio();
            return repositorio.GetListadoCiudades();
        }

        public void CrearCiudad(CiudadModelo ciudad)
        {
            ProyectoRepositorio repositorio = new ProyectoRepositorio();
            repositorio.CrearCiudad(ciudad);
        }

        public CiudadModelo GetCiudad(int? id)
        {
            ProyectoRepositorio repositorio = new ProyectoRepositorio();
            return repositorio.GetCiudad(id);
        }

        public CiudadModelo EditarCiudad(int? id)
        {
            ProyectoRepositorio repositorio = new ProyectoRepositorio();
            return repositorio.GetCiudad(id);
        }

        public void EditarCiudad(CiudadModelo ciudad)
        {
            ProyectoRepositorio repositorio = new ProyectoRepositorio();
            repositorio.EditarCiudad(ciudad);
        }

        public void EliminarCiudad(int? id)
        {
            ProyectoRepositorio repositorio = new ProyectoRepositorio();
            repositorio.EliminarCiudad(id);
        }
    }
}
