using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DLL_MAPEO_DAO
{
    public class SqlServerTablaDAO :ITablaDAO
    {

        public List<BeanTabla> ListarTablas()
        {
            SqlDataReader reader;
            SqlConnection cnx = SqlHelper.Conectar();
            String sql = "select '(Seleccione)' as NombreTabla " +
                        " union all " +
                        " select Name as NombreTabla " +
                        " from sysobjects where xtype='U' "+ 
                        " order by NombreTabla";

            BeanTabla objEntidad;
            List<BeanTabla> ListadoBeanTabla = new List<BeanTabla>();
            try
            {
                //SqlParameter[] arParms = new SqlParameter[1];
                //arParms[0] = new SqlParameter("@VCodVend", SqlDbType.Char);
                //arParms[0].Value = P_CodigoVendedor;

                reader = SqlHelper.ExecuteReader(cnx, CommandType.Text, sql);
                while (reader.Read())
                {
                    objEntidad = new BeanTabla();
                    objEntidad.Id = Convert.ToString(reader["NombreTabla"].Equals(System.DBNull.Value) ? "" : reader["NombreTabla"]);
                    objEntidad.Nombre = Convert.ToString(reader["NombreTabla"].Equals(System.DBNull.Value) ? "" : reader["NombreTabla"]);
                    objEntidad.estado = "A";
                    ListadoBeanTabla.Add(objEntidad);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }
            return ListadoBeanTabla;

        }
    }
}
