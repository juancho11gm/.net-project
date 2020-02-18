using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class CiudadModelo
    {
        public int Id { get; set; }
        public string NombreCiudad { get; set; }
        public Nullable<int> DepartamentoId { get; set; }

    }
}
