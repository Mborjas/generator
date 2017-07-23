using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL_MAPEO_DAO
{
    public interface IColumnasDAO
    {
        List<BeanColumnas> ListarColumnas(string p_NombreTabla);
        List<BeanLlavePrimaria> ListarLlavesPrimarias(string p_NombreTabla);
    }
}
