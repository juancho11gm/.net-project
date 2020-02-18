using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PaisModelo
    {
        public int Id { get; set; }
        public string NombrePais { get; set; }
        public List<DepartamentoModelo> Departamentos { get; set; }

    }
}
