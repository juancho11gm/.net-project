using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DepartamentoModelo
    {
        public int Id { get; set; }
        public string NombreDepartamento { get; set; }
        public Nullable<int> PaisId { get; set; }

        public List<CiudadModelo> Ciudades { get; set; }

    }
}
