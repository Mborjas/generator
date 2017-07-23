using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace DLL_MAPEO_DAO
{
    public class SqlServerColumnasDAO : IColumnasDAO
    {
        public List<BeanColumnas> ListarColumnas(string p_NombreTabla)
        {
            SqlDataReader reader;
            SqlConnection cnx = SqlHelper.Conectar();
            String sql = "sp_columns";

            BeanColumnas objEntidad;
            List<BeanColumnas> ListadoBeanColumnas = new List<BeanColumnas>();
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@table_name", SqlDbType.NVarChar);
                arParms[0].Value = p_NombreTabla;

                reader = SqlHelper.ExecuteReader(cnx, CommandType.StoredProcedure, sql, arParms);
                int i = 0;
                while (reader.Read())
                {
                    objEntidad = new BeanColumnas();
                    objEntidad.Id = Convert.ToString(reader["COLUMN_NAME"].Equals(System.DBNull.Value) ? "" : reader["COLUMN_NAME"]);
                    if(i==0)
                    {
                        objEntidad.EsLlavePrimaria=false;
                    }
                    else
                    {
                        objEntidad.EsLlavePrimaria=false;
                    }
                    i += 1;
                    objEntidad.NombreColumna = Convert.ToString(reader["COLUMN_NAME"].Equals(System.DBNull.Value) ? "" : reader["COLUMN_NAME"]);
                    objEntidad.TipoDato = Convert.ToString(reader["TYPE_NAME"].Equals(System.DBNull.Value) ? "" : reader["TYPE_NAME"]);
                    objEntidad.tamanio = Convert.ToDouble(reader["precision"].Equals(System.DBNull.Value) ? 0.0 : reader["precision"]);
                    objEntidad.Decimales = Convert.ToDouble(reader["scale"].Equals(System.DBNull.Value) ? 0.0 : reader["scale"]);
                    if ((reader["COLUMN_NAME"]).ToString().Trim().Equals("Estado"))
                    {
                        objEntidad.EsColumnaEstado = true;
                    }
                    else
                    {
                        objEntidad.EsColumnaEstado = false;
                    }
                    if ((reader["TYPE_NAME"]).ToString().Trim().Equals("int identity"))
                    {
                        objEntidad.EsColumnaIdentidad = true;
                    }
                    else
                    {
                        objEntidad.EsColumnaIdentidad = false;
                    }
                    objEntidad.estado = "A";
                    ListadoBeanColumnas.Add(objEntidad);
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
            return ListadoBeanColumnas;

        }



        public List<BeanLlavePrimaria> ListarLlavesPrimarias(string p_NombreTabla)
        {
            SqlDataReader reader;
            SqlConnection cnx = SqlHelper.Conectar();
            String sql = "LISTAR_LLAVES_PRIMARIA";

            BeanLlavePrimaria objEntidad;
            List<BeanLlavePrimaria> ListadoBeanLlavePrimaria = new List<BeanLlavePrimaria>();
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@NOMBRE_TABLA", SqlDbType.VarChar);
                arParms[0].Value = p_NombreTabla;

                reader = SqlHelper.ExecuteReader(cnx, CommandType.StoredProcedure, sql, arParms);
                int i = 0;
                while (reader.Read())
                {
                    objEntidad = new BeanLlavePrimaria();
                    objEntidad.NombreTabla = Convert.ToString(reader["TABLE_NAME"].Equals(System.DBNull.Value) ? "" : reader["TABLE_NAME"]);
                    objEntidad.NombreColunma = Convert.ToString(reader["COLUMN_NAME"].Equals(System.DBNull.Value) ? "" : reader["COLUMN_NAME"]);
                    ListadoBeanLlavePrimaria.Add(objEntidad);
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
            return ListadoBeanLlavePrimaria;

        }


    }
}
