using Modelos;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DepartamentoLogica
    {

        public List<DepartamentoModelo> GetListadoDepartamentos()
        {
            DepartamentoRepositorio repositorio = new DepartamentoRepositorio();
            return repositorio.GetListadoDepartamentos();
        }

        public void CrearDepartamento(DepartamentoModelo departamento)
        {
            DepartamentoRepositorio repositorio = new DepartamentoRepositorio();
            repositorio.CrearDepartamento(departamento);
        }

        public DepartamentoModelo GetDepartamento(int? id)
        {
            DepartamentoRepositorio repositorio = new DepartamentoRepositorio();
            return repositorio.GetDepartamento(id);
        }

        public DepartamentoModelo EditarDepartamento(int? id)
        {
            DepartamentoRepositorio repositorio = new DepartamentoRepositorio();
            return repositorio.GetDepartamento(id);
        }

        public void EditarDepartamento(DepartamentoModelo departamento)
        {
            DepartamentoRepositorio repositorio = new DepartamentoRepositorio();
            repositorio.EditarDepartamento(departamento);
        }

        public void EliminarDepartamento(int? id)
        {
            DepartamentoRepositorio repositorio = new DepartamentoRepositorio();
            repositorio.EliminarDepartamento(id);
        }

    }
}
