using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL_MAPEO_DAO
{
    public class BeanColumnas
    {
        public string Id { get; set; }
        public bool EsLlavePrimaria { get; set; }
        public string NombreColumna { get; set; }
        public string TipoDato { get; set; }
        public string estado { get; set; }
        public double tamanio { get; set; }
        public double Decimales { get; set; }
        public bool EsColumnaEstado { get; set; }
        public bool EsColumnaIdentidad { get; set; }
    }
}
