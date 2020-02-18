using Modelos;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PaisLogica
    {
        public List<PaisModelo> GetListadoPaises()
        {
            PaisRepositorio repositorio = new PaisRepositorio();
            return repositorio.GetListadoPaises();
        }

        public void CrearPais(PaisModelo pais)
        {
            PaisRepositorio repositorio = new PaisRepositorio();
            repositorio.CrearPais(pais);
        }

        public PaisModelo GetPais(int? id)
        {
            PaisRepositorio repositorio = new PaisRepositorio();
            return repositorio.GetPais(id);
        }

        public PaisModelo EditarPais(int? id)
        {
            PaisRepositorio repositorio = new PaisRepositorio();
            return repositorio.GetPais(id);
        }

        public void EditarPais(PaisModelo pais)
        {
            PaisRepositorio repositorio = new PaisRepositorio();
            repositorio.EditarPais(pais);
        }

        public void EliminarPais(int? id)
        {
            PaisRepositorio repositorio = new PaisRepositorio();
            repositorio.EliminarPais(id);
        }

    }
}
