
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL_MAPEO
{

    public class GeneradorCodigo
    {

        //************************************************************************************
        //************************************************************************************
        //*************************** BEAN ENTIDAD *******************************************
        //************************************************************************************
        //************************************************************************************
        public StringBuilder GenerarEntidades(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine(" public class Bean" + p_objTabla.Nombre + " {");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine("    public " + ConvertirTipoDatoSQLTO_C(objColumnas) + "  " + objColumnas.NombreColumna + "{ get; set; } ");
            }
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }
        //************************************************************************************
        //************************************************************************************
        //******************************INTERFACE*********************************************
        //************************************************************************************
        //************************************************************************************

        #region "Interface"

        public StringBuilder InterfaceDAO(Tabla p_objTabla)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("public override I" + p_objTabla.Nombre + "DAO get" + p_objTabla.Nombre + "DAO()");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("return  new SqlServer" + p_objTabla.Nombre + "DAO();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine();
            p_Cadena.AppendLine();
            p_Cadena.AppendLine();
            p_Cadena.AppendLine("--------------------------------------------------------------");
            p_Cadena.AppendLine();
            p_Cadena.AppendLine();
            p_Cadena.AppendLine();
            p_Cadena.AppendLine("public interface I" + p_objTabla.Nombre + "DAO");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("Boolean Insertar(List<Bean" + p_objTabla.Nombre + "> listado);");
            p_Cadena.AppendLine("Bean" + p_objTabla.Nombre + " Insertar(Bean" + p_objTabla.Nombre + "  p_objBean" + p_objTabla.Nombre + "); ");
            p_Cadena.AppendLine("Boolean Actualizar(List<Bean" + p_objTabla.Nombre + "> listado);");
            p_Cadena.AppendLine("Boolean Eliminar(List<Bean" + p_objTabla.Nombre + "> listado);");
            p_Cadena.AppendLine("Bean" + p_objTabla.Nombre + " Obtener(Bean" + p_objTabla.Nombre + " bean);");
            p_Cadena.AppendLine("List<Bean" + p_objTabla.Nombre + "> ListarTodos();");
            p_Cadena.AppendLine("List<Bean" + p_objTabla.Nombre + "> BuscarPor(Bean" + p_objTabla.Nombre + " bean);");
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }

        #endregion

        //************************************************************************************
        //************************************************************************************
        //******************************SQL SERVER DAO****************************************
        //************************************************************************************
        //************************************************************************************

        #region "Sql server dao"

        public StringBuilder SqlServer_Tabla_DAO(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("public class SqlServer" + p_objTabla.Nombre + "DAO : I" + p_objTabla.Nombre + "DAO");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("public Boolean Insertar(List<Bean" + p_objTabla.Nombre + "> listado)");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine(GeneraMetodoInsertar(p_objTabla).ToString());
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(GeneraMetodoInsertar2(p_objTabla).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("public Boolean Actualizar(List<Bean" + p_objTabla.Nombre + "> listado)");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine(GeneraMetodoActualizar(p_objTabla).ToString());
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(GeneraMetodoActualizar2(p_objTabla).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("public Boolean Eliminar(List<Bean" + p_objTabla.Nombre + "> listado)");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine(GeneraMetodoEliminar(p_objTabla).ToString());
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(GeneraMetodoEliminar2(p_objTabla).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("public Bean" + p_objTabla.Nombre + " Obtener(Bean" + p_objTabla.Nombre + " p_objBean" + p_objTabla.Nombre + ")");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine(GeneraMetodoObtener(p_objTabla).ToString());
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("public List<Bean" + p_objTabla.Nombre + "> ListarTodos()");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine(GeneraMetodoListar(p_objTabla).ToString());
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }

        #region Metodos

        private StringBuilder GeneraMetodoListar(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("SqlDataReader reader;");
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "ListarTodo" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("Bean" + p_objTabla.Nombre + " objEntidad; ");
            p_Cadena.AppendLine("List<Bean" + p_objTabla.Nombre + "> ListadoBean" + p_objTabla.Nombre + " = new List<Bean" + p_objTabla.Nombre + ">();");
            p_Cadena.AppendLine("try { ");
            p_Cadena.AppendLine("   SqlParameter[] arParms = new SqlParameter[1];");
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                p_Cadena.AppendLine("arParms[" + i + "] = new SqlParameter(" + "\"" + "@" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");
                p_Cadena.AppendLine("arParms[" + i + "].Value =0;");
                i += 1;
                break;
            }
            p_Cadena.AppendLine("reader = SqlHelper.ExecuteReader(cnx, CommandType.StoredProcedure, sql,arParms); ");
            p_Cadena.AppendLine("while (reader.Read()) ");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("objEntidad  = new Bean" + p_objTabla.Nombre + "(); ");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                //strTipoDatoConvertBd = F_TipoDatoConvertBd_Str(type1, column)
                p_Cadena.AppendLine("objEntidad." + objColumnas.NombreColumna + "=" + F_TipoDatoConvertBd_Str(objColumnas.TipoDato, objColumnas.NombreColumna) + ";");
            }
            p_Cadena.AppendLine(" ListadoBean" + p_objTabla.Nombre + ".Add(objEntidad);");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("}catch(Exception ex){");
            p_Cadena.AppendLine(" }finally{");
            p_Cadena.AppendLine(" cnx.Close();");
            p_Cadena.AppendLine(" cnx.Dispose();");
            p_Cadena.AppendLine(" }");
            p_Cadena.AppendLine(" return ListadoBean" + p_objTabla.Nombre + ";");
            return p_Cadena;
        }
        private StringBuilder GeneraMetodoObtener(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("SqlDataReader reader;");
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "ListarTodo" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("Bean" + p_objTabla.Nombre + " objEntidad = new Bean" + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("try { ");
            p_Cadena.AppendLine("   SqlParameter[] arParms = new SqlParameter[1];");
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                p_Cadena.AppendLine("arParms[" + i + "] = new SqlParameter(" + "\"" + "@" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");
                p_Cadena.AppendLine("arParms[" + i + "].Value = p_objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                i += 1;
                break;
            }
            p_Cadena.AppendLine("reader = SqlHelper.ExecuteReader(cnx, CommandType.StoredProcedure, sql,arParms); ");
            p_Cadena.AppendLine("while(reader.Read())");
            p_Cadena.AppendLine("   { ");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine("objEntidad." + objColumnas.NombreColumna + "=" + F_TipoDatoConvertBd_Str(objColumnas.TipoDato, objColumnas.NombreColumna) + ";");
            }
            p_Cadena.AppendLine("   }");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("  catch (Exception ex)");
            p_Cadena.AppendLine("   {");
            p_Cadena.AppendLine("   }");
            p_Cadena.AppendLine("   finally");
            p_Cadena.AppendLine("   {");
            p_Cadena.AppendLine("   cnx.Close();");
            p_Cadena.AppendLine("   cnx.Dispose();");
            p_Cadena.AppendLine("   }");
            p_Cadena.AppendLine("return objEntidad;");
            return p_Cadena;
        }
        private StringBuilder GeneraMetodoEliminar(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "Del" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("cnx.Open(); ");
            p_Cadena.AppendLine("SqlTransaction l_trans = cnx.BeginTransaction();");
            p_Cadena.AppendLine("try ");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine(" foreach (Bean" + p_objTabla.Nombre + " objBean" + p_objTabla.Nombre + " in listado)");
            p_Cadena.AppendLine(" { ");
            p_Cadena.AppendLine("       SqlParameter[] arParms = new SqlParameter[" + (p_objTabla.ListarColumnasLlavePrimaria().Count() + 1) + "];");
            //*** PARAMETROS
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(" + "\"@" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");
                p_Cadena.AppendLine("   arParms[" + i + "].Value = objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                i += 1;
            }
            p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(" + "\"@" + "Estado" + "\"" + ", SqlDbType." + "Char" + ");");
            p_Cadena.AppendLine("   arParms[" + i + "].Value = objBean" + p_objTabla.Nombre + ".Estado;");
            i = 0;
            p_Cadena.AppendLine("     SqlHelper.ExecuteNonQuery(l_trans, CommandType.StoredProcedure, sql, arParms);");
            p_Cadena.AppendLine("     l_trans.Commit();");
            p_Cadena.AppendLine("   }");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("catch(Exception ex)");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     l_trans.Rollback();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("finally");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     l_trans.Dispose();");
            p_Cadena.AppendLine("     cnx.Close();");
            p_Cadena.AppendLine("     cnx.Dispose();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("return true; ");
            return p_Cadena;
        }
        private StringBuilder GeneraMetodoEliminar2(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("public int Eliminar(Bean" + p_objTabla.Nombre + " p_objBean" + p_objTabla.Nombre + ")");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "Del" + "" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("cnx.Open(); ");
            p_Cadena.AppendLine("SqlTransaction l_trans = cnx.BeginTransaction();");
            p_Cadena.AppendLine("int p_Id" + p_objTabla.Nombre + " = 0;");
            p_Cadena.AppendLine("try { ");
            p_Cadena.AppendLine("   SqlParameter[] arParms = new SqlParameter[" + (p_objTabla.ListarColumnasLlavePrimaria().Count() + 1) + "];");
            //*** PARAMETROS
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(" + "\"@" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");
                p_Cadena.AppendLine("   arParms[" + i + "].Value = p_objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                i += 1;
            }
            p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(" + "\"@" + "Estado" + "\"" + ", SqlDbType." + "Char" + ");");
            p_Cadena.AppendLine("   arParms[" + i + "].Value = p_objBean" + p_objTabla.Nombre + ".Estado;");
            i = 0;
            p_Cadena.AppendLine("     p_Id" + p_objTabla.Nombre + " = Convert.ToInt32(SqlHelper.ExecuteScalar(l_trans, CommandType.StoredProcedure, sql, arParms));");
            p_Cadena.AppendLine("     l_trans.Commit();");
            p_Cadena.AppendLine("} ");
            p_Cadena.AppendLine("catch(Exception ex)");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("     l_trans.Rollback();");
            p_Cadena.AppendLine("} ");
            p_Cadena.AppendLine("finally");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("     l_trans.Dispose();");
            p_Cadena.AppendLine("     cnx.Close();");
            p_Cadena.AppendLine("     cnx.Dispose();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("return p_Id" + p_objTabla.Nombre + ";");
            p_Cadena.AppendLine("}");


            return p_Cadena;

        }
        private StringBuilder GeneraMetodoInsertar(Tabla p_objTabla)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "Ins" + "" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("cnx.Open(); ");
            p_Cadena.AppendLine("SqlTransaction l_trans = cnx.BeginTransaction();");
            p_Cadena.AppendLine("try { ");
            p_Cadena.AppendLine(" foreach (Bean" + p_objTabla.Nombre + " objBean" + p_objTabla.Nombre + " in listado)");
            p_Cadena.AppendLine(" { ");
            p_Cadena.AppendLine("   SqlParameter[] arParms = new SqlParameter[" + p_objTabla.ListarColumnas().Count() + "];");
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (objColumnas.EsColunnaIdentidad == false)
                {
                    p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(" + "\"@" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");

                    if (objColumnas.TipoDato.Trim().Equals("datetime")) // EN CASO SE FECHA EL CAMPO
                    {
                        p_Cadena.AppendLine("   if (objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + " == DateTime.MinValue)");
                        p_Cadena.AppendLine("   { ");
                        p_Cadena.AppendLine("       arParms[" + i + "].Value = DBNull.Value;");
                        p_Cadena.AppendLine("   }");
                        p_Cadena.AppendLine("   else");
                        p_Cadena.AppendLine("   { ");
                        p_Cadena.AppendLine("       arParms[" + i + "].Value = objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                        p_Cadena.AppendLine("   }");
                    }
                    else
                    {
                        p_Cadena.AppendLine("   arParms[" + i + "].Value = objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                    }

                    i += 1;
                }
            }
            p_Cadena.AppendLine(" SqlHelper.ExecuteNonQuery(l_trans, CommandType.StoredProcedure, sql, arParms);");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("     l_trans.Commit();");
            p_Cadena.AppendLine("}catch(Exception ex){");
            p_Cadena.AppendLine("     l_trans.Rollback();");
            p_Cadena.AppendLine("}finally{");
            p_Cadena.AppendLine("     l_trans.Dispose();");
            p_Cadena.AppendLine("     cnx.Close();");
            p_Cadena.AppendLine("     cnx.Dispose();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("return true; ");
            return p_Cadena;

        }
        private StringBuilder GeneraMetodoInsertar2(Tabla p_objTabla)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("public int Insertar(Bean" + p_objTabla.Nombre + " p_bean" + p_objTabla.Nombre + ")");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "Ins" + "" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("cnx.Open(); ");
            p_Cadena.AppendLine("SqlTransaction l_trans = cnx.BeginTransaction();");
            p_Cadena.AppendLine("int p_Id" + p_objTabla.Nombre + "=0;");
            p_Cadena.AppendLine("try { ");
            p_Cadena.AppendLine("   SqlParameter[] arParms = new SqlParameter[" + p_objTabla.ListarColumnas().Count() + "];");
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (objColumnas.EsColunnaIdentidad == false)
                {
                    p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(" + "\"@" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");
                    if (objColumnas.TipoDato.Trim().Equals("datetime")) // EN CASO SE FECHA EL CAMPO
                    {
                        p_Cadena.AppendLine("   if (p_bean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + " == DateTime.MinValue)");
                        p_Cadena.AppendLine("   { ");
                        p_Cadena.AppendLine("       arParms[" + i + "].Value = DBNull.Value;");
                        p_Cadena.AppendLine("   }");
                        p_Cadena.AppendLine("   else");
                        p_Cadena.AppendLine("   { ");
                        p_Cadena.AppendLine("       arParms[" + i + "].Value = p_bean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                        p_Cadena.AppendLine("   }");
                    }
                    else
                    {
                        p_Cadena.AppendLine("   arParms[" + i + "].Value = p_bean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                    }
                    i += 1;
                }
            }
            p_Cadena.AppendLine(" p_Id" + p_objTabla.Nombre + "=Convert.ToInt32(SqlHelper.ExecuteScalar(l_trans, CommandType.StoredProcedure, sql, arParms));");
            p_Cadena.AppendLine("     l_trans.Commit();");
            p_Cadena.AppendLine("}catch(Exception ex){");
            p_Cadena.AppendLine("     l_trans.Rollback();");
            p_Cadena.AppendLine("}finally{");
            p_Cadena.AppendLine("     l_trans.Dispose();");
            p_Cadena.AppendLine("     cnx.Close();");
            p_Cadena.AppendLine("     cnx.Dispose();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("return p_Id" + p_objTabla.Nombre + ";");
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }
        private StringBuilder GeneraMetodoActualizar(Tabla p_objTabla)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "Upd" + "" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("cnx.Open(); ");
            p_Cadena.AppendLine("SqlTransaction l_trans = cnx.BeginTransaction();");
            p_Cadena.AppendLine("try { ");
            p_Cadena.AppendLine(" foreach (Bean" + p_objTabla.Nombre + " objBean" + p_objTabla.Nombre + " in listado)");
            p_Cadena.AppendLine(" { ");
            p_Cadena.AppendLine("   SqlParameter[] arParms = new SqlParameter[" + p_objTabla.ListarColumnas().Count() + "];");
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(@" + "\"" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");
                if (objColumnas.TipoDato.Trim().Equals("datetime")) // EN CASO SE FECHA EL CAMPO
                {
                    p_Cadena.AppendLine("   if (objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + " == DateTime.MinValue)");
                    p_Cadena.AppendLine("   { ");
                    p_Cadena.AppendLine("       arParms[" + i + "].Value = DBNull.Value;");
                    p_Cadena.AppendLine("   }");
                    p_Cadena.AppendLine("   else");
                    p_Cadena.AppendLine("   { ");
                    p_Cadena.AppendLine("       arParms[" + i + "].Value = objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                    p_Cadena.AppendLine("   }");
                }
                else
                {
                    p_Cadena.AppendLine("   arParms[" + i + "].Value = objBean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                }
                i += 1;
            }
            p_Cadena.AppendLine("     SqlHelper.ExecuteNonQuery(l_trans, CommandType.StoredProcedure, sql, arParms);");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("     l_trans.Commit();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("catch(Exception ex)");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     l_trans.Rollback();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("finally");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     l_trans.Dispose();");
            p_Cadena.AppendLine("     cnx.Close();");
            p_Cadena.AppendLine("     cnx.Dispose();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("return true; ");
            return p_Cadena;
        }
        private StringBuilder GeneraMetodoActualizar2(Tabla p_objTabla)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("public int Actualizar(Bean" + p_objTabla.Nombre + " p_bean" + p_objTabla.Nombre + ")");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("SqlConnection cnx = SqlHelper.Conectar();");
            p_Cadena.AppendLine("String sql = " + "\"" + "Upd" + "" + p_objTabla.Nombre + "\"" + ";");
            p_Cadena.AppendLine("cnx.Open(); ");
            p_Cadena.AppendLine("SqlTransaction l_trans = cnx.BeginTransaction();");
            p_Cadena.AppendLine("int p_Id" + p_objTabla.Nombre + " = 0;");
            p_Cadena.AppendLine("try { ");
            p_Cadena.AppendLine("   SqlParameter[] arParms = new SqlParameter[" + p_objTabla.ListarColumnas().Count() + "];");
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine("   arParms[" + i + "] = new SqlParameter(@" + "\"" + objColumnas.NombreColumna + "\"" + ", SqlDbType." + F_TipoDatoProcedureBD_Str(objColumnas) + ");");
                if (objColumnas.TipoDato.Trim().Equals("datetime")) // EN CASO SE FECHA EL CAMPO
                {
                    p_Cadena.AppendLine("   if (p_bean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + " == DateTime.MinValue)");
                    p_Cadena.AppendLine("   { ");
                    p_Cadena.AppendLine("       arParms[" + i + "].Value = DBNull.Value;");
                    p_Cadena.AppendLine("   }");
                    p_Cadena.AppendLine("   else");
                    p_Cadena.AppendLine("   { ");
                    p_Cadena.AppendLine("       arParms[" + i + "].Value = p_bean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                    p_Cadena.AppendLine("   }");
                }
                else
                {
                    p_Cadena.AppendLine("   arParms[" + i + "].Value = p_bean" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
                }
                i += 1;
            }
            p_Cadena.AppendLine("     p_Id" + p_objTabla.Nombre + " = Convert.ToInt32(SqlHelper.ExecuteScalar(l_trans, CommandType.StoredProcedure, sql, arParms));");
            p_Cadena.AppendLine("     l_trans.Commit();");
            p_Cadena.AppendLine("} ");
            p_Cadena.AppendLine("catch(Exception ex)");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("     l_trans.Rollback();");
            p_Cadena.AppendLine("} ");
            p_Cadena.AppendLine("finally");
            p_Cadena.AppendLine("{ ");
            p_Cadena.AppendLine("     l_trans.Dispose();");
            p_Cadena.AppendLine("     cnx.Close();");
            p_Cadena.AppendLine("     cnx.Dispose();");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("return p_Id" + p_objTabla.Nombre + ";");
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }

        #endregion

        #endregion

        //************************************************************************************
        //************************************************************************************
        //************************************ CLASE CONTROL *********************************
        //************************************************************************************
        //************************************************************************************

        #region "Clase Control"



        public StringBuilder Clase_Negocio(Tabla p_objTabla, Tabla p_objTabla2)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("public class " + p_objTabla.Nombre + " {");
            p_Cadena.AppendLine("    public string Id { get; set; } ");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine("    public " + ConvertirTipoDatoSQLTO_C(objColumnas) + "  " + objColumnas.NombreColumna + "{ get; set; } ");
            }
            p_Cadena.AppendLine("     public EstadoRegistro estadoRegistro { get; set; }");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("private List<" + p_objTabla2.Nombre + "> Listado" + p_objTabla2.Nombre + " = null;");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_Constructor(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("//***********************************************************************************");
            p_Cadena.AppendLine("//***********************************************************************************");
            p_Cadena.AppendLine("//****************************" + p_objTabla2.Nombre + "****************************");
            p_Cadena.AppendLine("//***********************************************************************************");
            p_Cadena.AppendLine("//***********************************************************************************");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_Agregar(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_Eliminar(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_Listar(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_Obtener(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_CargarListadoBd(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_DeshacerCambio(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_GuardarCambio(p_objTabla, p_objTabla2).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_Negocio_GuardarCambio2(p_objTabla, p_objTabla2).ToString());
            return p_Cadena;
        }

        #region Metodos


        public StringBuilder Clase_Negocio_Constructor(Tabla p_objTabla, Tabla p_objTabla2)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("public " + p_objTabla.Nombre + "()");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("    Listado" + p_objTabla2.Nombre + " = new List<" + p_objTabla2.Nombre + ">();");
            p_Cadena.AppendLine("    this.Id = " + "\"" + "0" + "\"" + ";");
            //foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            //{
            //    p_Cadena.AppendLine("    this." + objColumnas.NombreColumna + "=" + F_TipoDatoInicializarDatos_C(objColumnas) + ";");
            //}
            p_Cadena.AppendLine("     this.estadoRegistro = new EstadoRegistro(EstadoMetodo.ObtenerEstadoActivoPublicado());");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("public " + p_objTabla.Nombre + "(int p_Nro" + p_objTabla.Nombre + ")");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     DAOFactory objDAOFactory = DAOFactory.getDAOFactory(DAOFactory.SQLSERVER);");
            p_Cadena.AppendLine("     I" + p_objTabla2.Nombre + "DAO objI" + p_objTabla2.Nombre + "DAO = objDAOFactory.get" + p_objTabla2.Nombre + "DAO();");
            p_Cadena.AppendLine("     Bean" + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + " = objI" + p_objTabla2.Nombre + "DAO.ObtenerXNro" + p_objTabla2.Nombre + "(p_Nro" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("     this.Id =  Convert.ToString(objBean" + p_objTabla2.Nombre + ".Id" + p_objTabla2.Nombre + ");");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasSinEstado())
            {
                p_Cadena.AppendLine("    this." + objColumnas.NombreColumna + "= objBean" + p_objTabla2.Nombre + "." + objColumnas.NombreColumna + ";");
            }
            p_Cadena.AppendLine("    this.estadoRegistro = new EstadoRegistro(objBean" + p_objTabla2.Nombre + ".Estado);");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            return p_Cadena;
        }
        public StringBuilder Clase_Negocio_Agregar(Tabla p_objTabla, Tabla p_objTabla2)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("//********** AGREGAR MODFICAR **********************");
            p_Cadena.AppendLine("public " + p_objTabla2.Nombre + " Agregar" + p_objTabla2.Nombre + "(" + p_objTabla2.Nombre + " p_obj" + p_objTabla2.Nombre + ")");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("    " + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + " = null;");
            p_Cadena.AppendLine("    bool ExisteRegistro = false; ");
            p_Cadena.AppendLine("    if (p_obj" + p_objTabla2.Nombre + ".Id ==  " + "\"" + "0" + "\"" + ")//" + "********** NUEVO *************");
            p_Cadena.AppendLine("       {");
            p_Cadena.AppendLine("         obj" + p_objTabla2.Nombre + " = p_obj" + p_objTabla2.Nombre + ";");
            p_Cadena.AppendLine("         obj" + p_objTabla2.Nombre + ".Id = " + "\"" + "N" + "\"" + "+(Listado" + p_objTabla2.Nombre + ".Count + 1);");
            p_Cadena.AppendLine("         obj" + p_objTabla2.Nombre + ".estadoRegistro = new EstadoRegistro(obj" + p_objTabla2.Nombre + ".Id,p_obj" + p_objTabla2.Nombre + ".estadoRegistro.Estado, TipoAccion.NUEVO);");
            p_Cadena.AppendLine("         Listado" + p_objTabla2.Nombre + ".Add(obj" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("         ExisteRegistro = true;");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("     else //********** MODIFICAR *************");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("      " + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + "2 = null;");
            p_Cadena.AppendLine("      foreach (" + p_objTabla2.Nombre + " objEntidad in Listado" + p_objTabla2.Nombre + ")");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("          if (objEntidad.Id == p_obj" + p_objTabla2.Nombre + ".Id)");
            p_Cadena.AppendLine("             {");
            p_Cadena.AppendLine("                 obj" + p_objTabla2.Nombre + "2 = objEntidad;");
            p_Cadena.AppendLine("                 obj" + p_objTabla2.Nombre + "2 = p_obj" + p_objTabla2.Nombre + ";");
            p_Cadena.AppendLine("                 obj" + p_objTabla2.Nombre + "2.estadoRegistro = new EstadoRegistro(obj" + p_objTabla2.Nombre + "2.Id,obj" + p_objTabla2.Nombre + "2.estadoRegistro.Estado,TipoAccion.MODIFICAR);");
            p_Cadena.AppendLine("              obj" + p_objTabla2.Nombre + " = obj" + p_objTabla2.Nombre + "2;");
            p_Cadena.AppendLine("               ExisteRegistro = true; ");
            p_Cadena.AppendLine("               break; ");
            p_Cadena.AppendLine("             }");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("          if (ExisteRegistro == false)");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("        Listado" + p_objTabla2.Nombre + ".Add(p_obj" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("        obj" + p_objTabla2.Nombre + " = p_obj" + p_objTabla2.Nombre + ";");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("     ");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("      return obj" + p_objTabla2.Nombre + ";");
            p_Cadena.AppendLine("}");
            return p_Cadena;

        }
        public StringBuilder Clase_Negocio_Eliminar(Tabla p_objTabla, Tabla p_objTabla2)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("//********** ELIMINAR **********************");
            p_Cadena.AppendLine("public void Eliminar" + p_objTabla2.Nombre + "(String Id)");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("      foreach (" + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + " in Listado" + p_objTabla2.Nombre + ")");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("          if ( obj" + p_objTabla2.Nombre + ".Id == Id)");
            p_Cadena.AppendLine("             {");
            p_Cadena.AppendLine("              obj" + p_objTabla2.Nombre + ".estadoRegistro = new EstadoRegistro(Id, obj" + p_objTabla2.Nombre + ".estadoRegistro.Estado,TipoAccion.ELIMINAR);");
            p_Cadena.AppendLine("             }");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("}");
            return p_Cadena;

        }
        public StringBuilder Clase_Negocio_Listar(Tabla p_objTabla, Tabla p_objTabla2)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("//********** LISTAR **********************");
            p_Cadena.AppendLine("public List<" + p_objTabla2.Nombre + "> Listar" + p_objTabla2.Nombre + "()");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     return Listado" + p_objTabla2.Nombre + ";");
            p_Cadena.AppendLine("}");
            return p_Cadena;

        }
        public StringBuilder Clase_Negocio_Obtener(Tabla p_objTabla, Tabla p_objTabla2)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine(" //*********** OBTENER ***********************");
            p_Cadena.AppendLine("public " + p_objTabla2.Nombre + " Obtener" + p_objTabla2.Nombre + "XId(string Id)");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine(" " + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + " = null;");
            p_Cadena.AppendLine("      foreach (" + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + "2 in Listado" + p_objTabla2.Nombre + ")");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("             if ( obj" + p_objTabla2.Nombre + "2.Id == Id)");
            p_Cadena.AppendLine("                 {");
            p_Cadena.AppendLine("                     obj" + p_objTabla2.Nombre + " = obj" + p_objTabla2.Nombre + "2;");
            p_Cadena.AppendLine("                     break;");
            p_Cadena.AppendLine("                 }");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("         return obj" + p_objTabla2.Nombre + "; ");
            p_Cadena.AppendLine("}");
            return p_Cadena;

        }
        public StringBuilder Clase_Negocio_CargarListadoBd(Tabla p_objTabla, Tabla p_objTabla2)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("//********** CARGAR LISTADO BD ***************");
            p_Cadena.AppendLine(" private void Cargar" + p_objTabla2.Nombre + "()");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("         Listado" + p_objTabla2.Nombre + ".Clear();");
            p_Cadena.AppendLine("     DAOFactory objDAOFactory = DAOFactory.getDAOFactory(DAOFactory.SQLSERVER);");
            p_Cadena.AppendLine("     I" + p_objTabla2.Nombre + "DAO objI" + p_objTabla2.Nombre + "DAO = objDAOFactory.get" + p_objTabla2.Nombre + "DAO();");
            p_Cadena.AppendLine("      foreach (Bean" + p_objTabla2.Nombre + " objBean" + p_objTabla2.Nombre + " in objI" + p_objTabla2.Nombre + "DAO.ListarTodos())");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("          " + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + " = new " + p_objTabla2.Nombre + "();");
            p_Cadena.AppendLine("         obj" + p_objTabla2.Nombre + ".Id = Convert.ToString(objBean" + p_objTabla2.Nombre + ".Id" + p_objTabla2.Nombre + ");");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasSinEstado())
            {

                p_Cadena.AppendLine("   obj" + p_objTabla2.Nombre + "." + objColumnas.NombreColumna + "= objBean" + p_objTabla2.Nombre + "." + objColumnas.NombreColumna + ";");
            }
            p_Cadena.AppendLine("   obj" + p_objTabla2.Nombre + ".estadoRegistro = new EstadoRegistro(objBean" + p_objTabla2.Nombre + ".Estado);");
            p_Cadena.AppendLine("         Listado" + p_objTabla2.Nombre + ".Add(obj" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("}");
            return p_Cadena;

        }
        public StringBuilder Clase_Negocio_DeshacerCambio(Tabla p_objTabla, Tabla p_objTabla2)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("//*********** DESHACER CAMBIOS ***************");
            p_Cadena.AppendLine(" public void CancelarCambios" + p_objTabla2.Nombre + "()");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }
        public StringBuilder Clase_Negocio_GuardarCambio(Tabla p_objTabla, Tabla p_objTabla2)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine(" //*********** GUARDAR CAMBIOS ***************");
            p_Cadena.AppendLine(" public void Guardar" + p_objTabla2.Nombre + "()");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     DAOFactory objDAOFactory = DAOFactory.getDAOFactory(DAOFactory.SQLSERVER);");
            p_Cadena.AppendLine("     I" + p_objTabla2.Nombre + "DAO objI" + p_objTabla2.Nombre + "DAO = objDAOFactory.get" + p_objTabla2.Nombre + "DAO();");
            p_Cadena.AppendLine(" ");
            p_Cadena.AppendLine("     List<Bean" + p_objTabla2.Nombre + "> listadoInsertar = new List<Bean" + p_objTabla2.Nombre + ">(); ");
            p_Cadena.AppendLine("     List<Bean" + p_objTabla2.Nombre + "> listadoActualizacion = new List<Bean" + p_objTabla2.Nombre + ">(); ");
            p_Cadena.AppendLine("     List<Bean" + p_objTabla2.Nombre + "> listadoEliminacion = new List<Bean" + p_objTabla2.Nombre + ">(); ");
            p_Cadena.AppendLine(" ");
            p_Cadena.AppendLine("     foreach (" + p_objTabla2.Nombre + " obj" + p_objTabla2.Nombre + " in Listado" + p_objTabla2.Nombre + ") ");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("            int Id = 0;");
            p_Cadena.AppendLine("            Int32.TryParse(obj" + p_objTabla2.Nombre + ".Id, out Id);");
            p_Cadena.AppendLine("            Bean" + p_objTabla2.Nombre + " objBean" + p_objTabla2.Nombre + " = new Bean" + p_objTabla2.Nombre + "();");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasSinEstado())
            {
                p_Cadena.AppendLine("   objBean" + p_objTabla2.Nombre + "." + objColumnas.NombreColumna + "= obj" + p_objTabla2.Nombre + "." + objColumnas.NombreColumna + ";");
            }
            p_Cadena.AppendLine("       objBean" + p_objTabla2.Nombre + ".Estado = obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoEstadoBD;");
            p_Cadena.AppendLine("       if (obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoBD == TipoAccionBD.INSERT) ");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("             listadoInsertar.Add(objBean" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("      else if (obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoBD == TipoAccionBD.UPDATE)");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("             listadoActualizacion.Add(objBean" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("      else if (obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoBD == TipoAccionBD.DELETE)");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("             listadoEliminacion.Add(objBean" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("  if (listadoInsertar.Count > 0) ");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("      objI" + p_objTabla2.Nombre + "DAO.Insertar(listadoInsertar);");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("  if (listadoActualizacion.Count > 0) ");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("      objI" + p_objTabla2.Nombre + "DAO.Actualizar(listadoActualizacion);");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("  if (listadoEliminacion.Count > 0) ");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("      objI" + p_objTabla2.Nombre + "DAO.Eliminar(listadoEliminacion);");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("}");
            return p_Cadena;

        }
        public StringBuilder Clase_Negocio_GuardarCambio2(Tabla p_objTabla, Tabla p_objTabla2)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine(" //*********** GUARDAR CAMBIOS ***************");
            p_Cadena.AppendLine(" public void Guardar" + p_objTabla2.Nombre + "(" + p_objTabla2.Nombre + " p_obj" + p_objTabla2.Nombre + ")");
            p_Cadena.AppendLine("{");
            p_Cadena.AppendLine("     DAOFactory objDAOFactory = DAOFactory.getDAOFactory(DAOFactory.SQLSERVER);");
            p_Cadena.AppendLine("     I" + p_objTabla2.Nombre + "DAO objI" + p_objTabla2.Nombre + "DAO = objDAOFactory.get" + p_objTabla2.Nombre + "DAO();");
            p_Cadena.AppendLine(" ");
            p_Cadena.AppendLine(" ");
            p_Cadena.AppendLine("            int Id = 0;");
            p_Cadena.AppendLine("            Int32.TryParse(p_obj" + p_objTabla2.Nombre + ".Id, out Id);");
            p_Cadena.AppendLine("            Bean" + p_objTabla2.Nombre + " objBean" + p_objTabla2.Nombre + " = new Bean" + p_objTabla2.Nombre + "();");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasSinEstado())
            {
                p_Cadena.AppendLine("   objBean" + p_objTabla2.Nombre + "." + objColumnas.NombreColumna + "= p_obj" + p_objTabla2.Nombre + "." + objColumnas.NombreColumna + ";");
            }
            p_Cadena.AppendLine("       objBean" + p_objTabla2.Nombre + ".Estado = obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoEstadoBD;");
            p_Cadena.AppendLine("       int p_Nro" + p_objTabla2.Nombre + "=0;");
            p_Cadena.AppendLine("       if (p_obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoBD == TipoAccionBD.INSERT) ");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("              p_Nro" + p_objTabla2.Nombre + "=objI" + p_objTabla2.Nombre + "DAO.Insertar(objBean" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("      else if (p_obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoBD == TipoAccionBD.UPDATE)");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("              p_Nro" + p_objTabla2.Nombre + "=objI" + p_objTabla2.Nombre + "DAO.Actualizar(objBean" + p_objTabla2.Nombre + ");");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("      else if (p_obj" + p_objTabla2.Nombre + ".estadoRegistro.TipoBD == TipoAccionBD.DELETE)");
            p_Cadena.AppendLine("         {");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("         }");
            p_Cadena.AppendLine("         return new " + p_objTabla2.Nombre + "(p_Nro" + p_objTabla2.Nombre + ")");
            p_Cadena.AppendLine("}");

            return p_Cadena;
        }
        #endregion

        #endregion

        //************************************************************************************
        //************************************************************************************
        //************************************ MANTENIMIENTO GUI *****************************
        //************************************************************************************
        //************************************************************************************

        #region "Mantenimiento GUI"

        public StringBuilder Clase_GUI_Mantenimiento(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Clase_GUI_GenerarContenidoGUI(p_objTabla).ToString());
            p_Cadena.AppendLine("");
            return p_Cadena;
        }

        public StringBuilder Clase_GUI_GenerarContenidoGUI(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine(" this.grvListado" + p_objTabla.Nombre + ".RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvListado_RowEnter);");
            p_Cadena.AppendLine(" this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);");
            p_Cadena.AppendLine(" this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);");
            p_Cadena.AppendLine(" this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);");
            p_Cadena.AppendLine(" this.btnCancelarCambios.Click += new System.EventHandler(this.btnCancelarCambios_Click);");
            p_Cadena.AppendLine(" this.btnGuardarBd.Click += new System.EventHandler(this.btnGuardarBd_Click);");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("//*******************************************************************************************************************************");
            p_Cadena.AppendLine("//*******************************************************************************************************************************");
            p_Cadena.AppendLine("//*******************************************************************************************************************************");
            p_Cadena.AppendLine("//******************************************  " + p_objTabla.Nombre.ToUpper() + " **************************************************************");
            p_Cadena.AppendLine("//*******************************************************************************************************************************");
            p_Cadena.AppendLine("//*******************************************************************************************************************************");
            p_Cadena.AppendLine("//*******************************************************************************************************************************");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(" private void grvListado_RowEnter(object sender, DataGridViewCellEventArgs e)");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("         Int32 i = e.RowIndex;");
            p_Cadena.AppendLine("         Seleccionar(e.RowIndex);");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("  private void btnNuevo_Click(object sender, EventArgs e)");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("         Nuevo();");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("private void btnInsertar_Click(object sender, EventArgs e)");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("         Insertar();");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(" private void btnEliminar_Click(object sender, EventArgs e)");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("         Eliminar();");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("private void btnCancelarCambios_Click(object sender, EventArgs e)");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("         CancelarCambio();");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(" private void btnGuardarBd_Click(object sender, EventArgs e)");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("         GuardarCambio();");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("  private void Seleccionar(int p_Fila){ ");
            p_Cadena.AppendLine("   string p_Id; ");
            p_Cadena.AppendLine("   Int32 i = p_Fila; ");
            p_Cadena.AppendLine("    if (i >= 0){ ");
            p_Cadena.AppendLine("     p_Id = Convert.ToString(this.grvListado" + p_objTabla.Nombre + ".Rows[i].Cells[" + "\"" + "ColId" + "\"" + "].Value);");
            p_Cadena.AppendLine("     " + p_objTabla.Nombre + " obj" + p_objTabla.Nombre + " = objAdministrador" + p_objTabla.Nombre + ".Obtener" + p_objTabla.Nombre + "XId(p_Id);");
            p_Cadena.AppendLine("    Cargar" + p_objTabla.Nombre + "(ref obj" + p_objTabla.Nombre + ");");
            p_Cadena.AppendLine("    } ");
            p_Cadena.AppendLine("    } ");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("  private void SeleccionarRegistro(string p_Id){ ");
            p_Cadena.AppendLine("   foreach (DataGridViewRow objRow in this.grvListado" + p_objTabla.Nombre + ".Rows) ");
            p_Cadena.AppendLine("    { ");
            p_Cadena.AppendLine("    objRow.Selected = false;");
            p_Cadena.AppendLine("    } ");
            p_Cadena.AppendLine("    foreach (DataGridViewRow objRow in this.grvListado" + p_objTabla.Nombre + ".Rows)");
            p_Cadena.AppendLine("       { ");
            p_Cadena.AppendLine("    if (Convert.ToString(objRow.Cells[" + "\"" + "ColId" + "\"" + "].Value) == p_Id) ");
            p_Cadena.AppendLine("           { ");
            p_Cadena.AppendLine("               objRow.Selected = true; ");
            p_Cadena.AppendLine("               this.grvListado" + p_objTabla.Nombre + ".CurrentCell=objRow.Cells["+ "\"" +"ColId"+ "\"" + "];");
            p_Cadena.AppendLine("               break;");
            p_Cadena.AppendLine("           } ");
            p_Cadena.AppendLine("       } ");
            p_Cadena.AppendLine("    } ");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("     private void Nuevo()");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("          " + p_objTabla.Nombre + " obj" + p_objTabla.Nombre + " = new " + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("          obj" + p_objTabla.Nombre + " = objAdministrador" + p_objTabla.Nombre + ".Agregar" + p_objTabla.Nombre + "(obj" + p_objTabla.Nombre + ");");
            p_Cadena.AppendLine("          CargarGrid" + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("          SeleccionarRegistro(obj" + p_objTabla.Nombre + ".Id);");
            p_Cadena.AppendLine("          Cargar" + p_objTabla.Nombre + "(ref obj" + p_objTabla.Nombre + ");");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("     private void Insertar()");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("     " + p_objTabla.Nombre + " obj" + p_objTabla.Nombre + " = objAdministrador" + p_objTabla.Nombre + ".Obtener" + p_objTabla.Nombre + "XId(this.txtId.Text);");
            p_Cadena.AppendLine("     Obtener" + p_objTabla.Nombre + "(ref obj" + p_objTabla.Nombre + ");");
            p_Cadena.AppendLine("     obj" + p_objTabla.Nombre + " = objAdministrador" + p_objTabla.Nombre + ".Agregar" + p_objTabla.Nombre + "(obj" + p_objTabla.Nombre + ");");
            p_Cadena.AppendLine("     CargarGrid" + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("     SeleccionarRegistro(obj" + p_objTabla.Nombre + ".Id);");
            p_Cadena.AppendLine("     Cargar" + p_objTabla.Nombre + "(ref obj" + p_objTabla.Nombre + ");");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("     private void Eliminar()");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("     " + p_objTabla.Nombre + " obj" + p_objTabla.Nombre + " = objAdministrador" + p_objTabla.Nombre + ".Obtener" + p_objTabla.Nombre + "XId(this.txtId.Text);");
            p_Cadena.AppendLine("        objAdministrador" + p_objTabla.Nombre + ".Eliminar" + p_objTabla.Nombre + "(obj" + p_objTabla.Nombre + ".Id);");
            p_Cadena.AppendLine("        CargarGrid" + p_objTabla.Nombre + "(); ");
            p_Cadena.AppendLine("        SeleccionarRegistro(obj" + p_objTabla.Nombre + ".Id); ");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("     private void CancelarCambio()");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("          objAdministrador" + p_objTabla.Nombre + ".CancelarCambios" + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("           CargarGrid" + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("     private void GuardarCambio()");
            p_Cadena.AppendLine("     {");
            p_Cadena.AppendLine("           objAdministrador" + p_objTabla.Nombre + ".Guardar" + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("           CargarGrid" + p_objTabla.Nombre + "();");
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("  private void Cargar" + p_objTabla.Nombre + "(ref " + p_objTabla.Nombre + " obj" + p_objTabla.Nombre + ")");
            p_Cadena.AppendLine("  {");
            p_Cadena.AppendLine("     this.txtId.Text = Convert.ToString(obj" + p_objTabla.Nombre + ".Id);");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine(" this.txt" + objColumnas.NombreColumna + ".Text = Convert." + ConvertirTipoDatoSQL_ConvertTO_C(objColumnas) + "(obj" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ");");
            }
            p_Cadena.AppendLine(" }");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(" private void Obtener" + p_objTabla.Nombre + "(ref " + p_objTabla.Nombre + " obj" + p_objTabla.Nombre + ")");
            p_Cadena.AppendLine("     {");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine("obj" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + "= Convert." + ConvertirTipoDatoSQL_ConvertTO_C(objColumnas) + "(this.txt" + objColumnas.NombreColumna + ".Text);");
            }
            p_Cadena.AppendLine("     }");
            p_Cadena.AppendLine("");
            return p_Cadena;
        }

        public StringBuilder Clase_GUI_CrearTable(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("void CrearTabla" + p_objTabla.Nombre + "(){");
            p_Cadena.AppendLine(" private DataTable dt" + p_objTabla.Nombre + " = new DataTable();");
            p_Cadena.AppendLine("   dt" + p_objTabla.Nombre + ".Columns.Add(" + "\"" + "Id" + "\"" + ", typeof(string));");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                p_Cadena.AppendLine("dt" + p_objTabla.Nombre + ".Columns.Add(" + "\"" + objColumnas.NombreColumna + "\"" + ",typeof(" + ConvertirTipoDatoSQLTO_C(objColumnas) + "));");
            }
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }


        public StringBuilder Clase_GUI_CrearGrid(Tabla p_objTabla)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("void CargarGrid" + p_objTabla.Nombre + "(){");
            p_Cadena.AppendLine(" dt" + p_objTabla.Nombre + ".Rows.Clear();");
            p_Cadena.AppendLine(" foreach (" + p_objTabla.Nombre + " obj" + p_objTabla.Nombre + " in obj" + p_objTabla.Nombre + ".ListarTodos())");
            p_Cadena.AppendLine(" {");
            p_Cadena.AppendLine(" DataRow dtw = dt" + p_objTabla.Nombre + ".NewRow();");
            p_Cadena.AppendLine("         dtw["+ "\"" +"Id"+"\""+"] = obj" + p_objTabla.Nombre + ".Id;");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasSinEstado())
            {
                p_Cadena.AppendLine("dtw[" + "\"" + objColumnas.NombreColumna + "\"" + "] = obj" + p_objTabla.Nombre + "." + objColumnas.NombreColumna + ";");
            }
            p_Cadena.AppendLine("   dtw["+ "\"" +"Estado"+"\""+"] = obj"+p_objTabla.Nombre+".estadoRegistro.ImpresionEstado;");
            p_Cadena.AppendLine("dt" + p_objTabla.Nombre + ".Rows.Add(dtw);");
            p_Cadena.AppendLine("}");
            p_Cadena.AppendLine("this.grvListado" + p_objTabla.Nombre + ".DataSource = dt" + p_objTabla.Nombre + ";");
            p_Cadena.AppendLine("}");
            return p_Cadena;
        }
        #endregion

        //************************************************************************************
        //************************************************************************************
        //************************************ MANTENIMIENTO PROCEDURE ***********************
        //************************************************************************************
        //************************************************************************************

        #region "MantenimientoProcedure"

        public StringBuilder Clase_GUI_Mantenimiento_Procedure(Tabla p_objTabla, consts.TIPO_BASE_DATOS p_TipoBaseDatos)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("----- Procedure Insertar ----- ");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Generar_Procedure_Insertar(p_objTabla, p_TipoBaseDatos).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("----- Procedure Actualizar -----");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Generar_Procedure_Actualizar(p_objTabla, p_TipoBaseDatos).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("----- Procedure Eliminar -----");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Generar_Procedure_Eliminar(p_objTabla, p_TipoBaseDatos).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("----- Procedure ListaTodo ----- ");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine(Generar_Procedure_Listar(p_objTabla, p_TipoBaseDatos).ToString());
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("----- Procedure Obtener -----");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            return p_Cadena;

        }

        #region Metodos
        public StringBuilder Generar_Procedure_Insertar(Tabla p_objTabla, consts.TIPO_BASE_DATOS p_TipoBaseDatos)
        {

            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("CREATE PROCEDURE dbo.Ins" + p_objTabla.Nombre);
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (objColumnas.EsLlavePrimaria == false)
                {
                    if (i != p_objTabla.ListarColumnas().Count() - 1)
                    {
                        p_Cadena.AppendLine("    @" + objColumnas.NombreColumna + " " + F_TipoDatoProcedureBD_Str2(objColumnas, p_TipoBaseDatos) + ",");
                    }
                }
                if (i == p_objTabla.ListarColumnas().Count() - 1)
                {
                    p_Cadena.AppendLine("    @" + objColumnas.NombreColumna + " " + F_TipoDatoProcedureBD_Str2(objColumnas, p_TipoBaseDatos) + "");
                }
                i += 1;
            }
            p_Cadena.AppendLine("AS BEGIN ");
            p_Cadena.AppendLine("     INSERT INTO DBO." + p_objTabla.Nombre + "(");
            i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (objColumnas.EsLlavePrimaria == false)
                {
                    if (i != p_objTabla.ListarColumnas().Count() - 1)
                    {
                        p_Cadena.AppendLine("      " + objColumnas.NombreColumna + ",");
                    }
                }
                if (i == p_objTabla.ListarColumnas().Count() - 1)
                {
                    p_Cadena.AppendLine("   " + objColumnas.NombreColumna + "");
                }
                i += 1;
            }
            i = 0;
            p_Cadena.AppendLine("     )VALUES(");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (objColumnas.EsLlavePrimaria == false)
                {
                    if (i != p_objTabla.ListarColumnas().Count() - 1)
                    {
                        p_Cadena.AppendLine("           " + "@" + objColumnas.NombreColumna + ",");
                    }
                }
                if (i == p_objTabla.ListarColumnas().Count() - 1)
                {
                    p_Cadena.AppendLine("       " + "@" + objColumnas.NombreColumna + "");
                }
                i += 1;
            }
            p_Cadena.AppendLine("     )");
            p_Cadena.AppendLine("end ");
            return p_Cadena;
        }
        public StringBuilder Generar_Procedure_Actualizar(Tabla p_objTabla, consts.TIPO_BASE_DATOS p_TipoBaseDatos)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("CREATE PROCEDURE dbo.Upd" + p_objTabla.Nombre);
            //**PARAMETROS
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (i != p_objTabla.ListarColumnas().Count() - 1)//SI NO ES ULTIMO REGISTRO
                {
                    p_Cadena.AppendLine("    @" + objColumnas.NombreColumna + " " + F_TipoDatoProcedureBD_Str2(objColumnas, p_TipoBaseDatos) + ",");
                }
                if (i == p_objTabla.ListarColumnas().Count() - 1)
                {
                    p_Cadena.AppendLine("    @" + objColumnas.NombreColumna + " " + F_TipoDatoProcedureBD_Str2(objColumnas, p_TipoBaseDatos) + "");
                }
                i += 1;
            }
            i = 0;
            p_Cadena.AppendLine(" AS  ");
            p_Cadena.AppendLine(" Begin");
            //**UPDATE
            p_Cadena.AppendLine("         UPDATE " + p_objTabla.Nombre + " ");
            bool flag = true;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (objColumnas.EsLlavePrimaria == false)
                {
                    if (flag)
                    {
                        if (i == p_objTabla.ListarColumnas().Count() - 1)//SI ES ULTIMO REGISTRO
                        {
                            p_Cadena.AppendLine("    SET    " + objColumnas.NombreColumna + "=@" + objColumnas.NombreColumna + "");
                        }
                        else
                        {
                            p_Cadena.AppendLine("    SET    " + objColumnas.NombreColumna + "=@" + objColumnas.NombreColumna + ",");
                        }
                        flag = false;
                    }
                    else
                    {
                        if (i == p_objTabla.ListarColumnas().Count() - 1)//SI ES ULTIMO REGISTRO
                        {
                            p_Cadena.AppendLine("            " + objColumnas.NombreColumna + "=@" + objColumnas.NombreColumna + "");
                        }
                        else
                        {
                            p_Cadena.AppendLine("            " + objColumnas.NombreColumna + "=@" + objColumnas.NombreColumna + ",");
                        }
                    }
                }
                i += 1;
            }
            i = 0;
            //** WHERE
            p_Cadena.AppendLine("         WHERE  ");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                if (i == p_objTabla.ListarColumnasLlavePrimaria().Count() - 1)//SI ES ULTIMO REGISTRO
                {
                    p_Cadena.AppendLine("       " + objColumnas.NombreColumna + " = @" + objColumnas.NombreColumna + " ");
                }
                else
                {
                    p_Cadena.AppendLine("       " + objColumnas.NombreColumna + " = @" + objColumnas.NombreColumna + " AND");
                }
                i += 1;
            }
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("end ");
            return p_Cadena;
        }
        public StringBuilder Generar_Procedure_Eliminar(Tabla p_objTabla, consts.TIPO_BASE_DATOS p_TipoBaseDatos)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("CREATE PROCEDURE dbo.Del" + p_objTabla.Nombre);
            //**PARAMETROS
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                if (objColumnas.EsLlavePrimaria == true)
                {
                    p_Cadena.AppendLine("    @" + objColumnas.NombreColumna + " " + F_TipoDatoProcedureBD_Str2(objColumnas, p_TipoBaseDatos) + ",");
                }
                i += 1;
            }
            p_Cadena.AppendLine(" @Estado char(1) ");
            i = 0;
            p_Cadena.AppendLine(" AS ");
            p_Cadena.AppendLine(" BEGIN ");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            //** UPDATE
            p_Cadena.AppendLine("         UPDATE " + p_objTabla.Nombre + " ");
            p_Cadena.AppendLine("             SET ESTADO=@Estado");
            //** WHERE
            p_Cadena.AppendLine("         WHERE");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                if (objColumnas.EsLlavePrimaria == true)
                {
                    if (i == p_objTabla.ListarColumnasLlavePrimaria().Count() - 1)//SI ES ULTIMO REGISTRO
                    {
                        p_Cadena.AppendLine("              " + objColumnas.NombreColumna + "=@" + objColumnas.NombreColumna + "");
                    }
                    else
                    {
                        p_Cadena.AppendLine("              " + objColumnas.NombreColumna + "=@" + objColumnas.NombreColumna + " AND ");
                    }
                }
                i += 1;
            }
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("");
            p_Cadena.AppendLine("end ");
            return p_Cadena;
        }
        public StringBuilder Generar_Procedure_Listar(Tabla p_objTabla, consts.TIPO_BASE_DATOS p_TipoBaseDatos)
        {
            StringBuilder p_Cadena = new StringBuilder();
            p_Cadena.AppendLine("CREATE PROCEDURE dbo.ListarTodo" + p_objTabla.Nombre);
            //**PARAMETROS
            int i = 0;
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                if (i == p_objTabla.ListarColumnasLlavePrimaria().Count() - 1)//SI ES ULTIMO REGISTRO
                {
                    p_Cadena.AppendLine("           @" + objColumnas.NombreColumna + " " + F_TipoDatoProcedureBD_Str2(objColumnas, p_TipoBaseDatos) + "");
                }
                else
                {
                    p_Cadena.AppendLine("           @" + objColumnas.NombreColumna + " " + F_TipoDatoProcedureBD_Str2(objColumnas, p_TipoBaseDatos) + ",");
                }
                i += 1;
            }
            i = 0;
            p_Cadena.AppendLine("AS BEGIN ");
            p_Cadena.AppendLine("       SELECT");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnas())
            {
                if (i != p_objTabla.ListarColumnas().Count() - 1)
                {
                    p_Cadena.AppendLine("           " + objColumnas.NombreColumna + ",");
                }
                if (i == p_objTabla.ListarColumnas().Count() - 1)
                {
                    p_Cadena.AppendLine("           " + objColumnas.NombreColumna + "");
                }
                i += 1;
            }
            i = 0;
            p_Cadena.AppendLine("       FROM DBO." + p_objTabla.Nombre + "");
            p_Cadena.AppendLine("       WHERE ");
            p_Cadena.AppendLine("               (");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                p_Cadena.AppendLine("               @" + objColumnas.NombreColumna + "=0");
                i += 1;
            }
            p_Cadena.AppendLine("               OR ");
            foreach (Columnas objColumnas in p_objTabla.ListarColumnasLlavePrimaria())
            {
                p_Cadena.AppendLine("               " + objColumnas.NombreColumna + "=@" + objColumnas.NombreColumna + "");
                i += 1;
            }
            p_Cadena.AppendLine("               )");
            p_Cadena.AppendLine("      END");
            return p_Cadena;
        }
        #endregion

        #endregion

        //************************************************************************************
        //************************************************************************************
        //************************************ UTIL ******************************************
        //************************************************************************************
        //************************************************************************************

        #region Util

        public StringBuilder F_TipoDatoConvertBd_Str(string TipoDatoBD, string p_NombreColumna)
        {
            string p_Cadena = "";
            p_Cadena = TipoDatoBD.ToLower();
            if (TipoDatoBD.Length > 3)
            {
                p_Cadena = TipoDatoBD.Substring(0, 4);
            }
            p_Cadena = p_Cadena.Trim();
            p_Cadena = p_Cadena.Trim();
            switch (p_Cadena)
            {
                case "char":
                    p_Cadena = "Convert.ToString(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? " + "\"" + "\"" + " : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "varc":
                    p_Cadena = "Convert.ToString(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? " + "\"" + "\"" + " : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "deci":
                    p_Cadena = "Convert.ToDouble(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? 0.0 : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "nume":
                    p_Cadena = "Convert.ToDouble(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? 0.0 : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "date":
                    p_Cadena = "Convert.ToDateTime(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? DateTime.Today : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "int":
                    p_Cadena = "Convert.ToInt32(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? 0 : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "bit":
                    p_Cadena = "Convert.ToBoolean(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? true : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "tiny":
                    p_Cadena = "Convert.ToInt16(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? 0 : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
                case "doub":
                    p_Cadena = "Convert.ToDouble(reader[" + "\"" + p_NombreColumna + "\"" + "].Equals(System.DBNull.Value) ? 0.0 : reader[" + "\"" + p_NombreColumna + "\"" + "])";
                    break;
            }
            StringBuilder p_cad = new StringBuilder(p_Cadena);
            return p_cad;
        }

        public StringBuilder F_TipoDatoProcedureBD_Str(Columnas p_objColumnas)
        {
            string p_Cadena = "";
            p_Cadena = p_objColumnas.TipoDato.ToLower();
            p_Cadena = p_Cadena.Trim();
            switch (p_Cadena)
            {
                case "char":
                    p_Cadena = consts.TIPO_DATO_CADENA2_BD;
                    break;
                case "varchar":
                    p_Cadena = consts.TIPO_DATO_CADENA_BD;
                    break;
                case "decimal":
                    p_Cadena = consts.TIPO_DATO_DOUBLE_BD;
                    break;
                case "numeric":
                    p_Cadena = consts.TIPO_DATO_DOUBLE_BD;
                    break;
                case "datetime":
                    p_Cadena = consts.TIPO_DATO_FECHA_BD;
                    break;
                case "int":
                    p_Cadena = consts.TIPO_DATO_ENTERO_BD;
                    break;
                case "tinyint":
                    p_Cadena = consts.TIPO_DATO_ENTERO2_BD;
                    break;
                case "bit":
                    p_Cadena = consts.TIPO_DATO_BOOLEANO_BD;
                    break;
                case "int identity":
                    p_Cadena = consts.TIPO_DATO_ENTERO_BD;
                    break;
            }
            StringBuilder p_cad = new StringBuilder(p_Cadena);
            return p_cad;
        }



        public StringBuilder ConvertirTipoDatoSQLTO_C(Columnas p_objColumnas)
        {
            string p_Cadena = "";
            if (p_objColumnas.TipoDato.Length > 3)
            {
                p_Cadena = p_objColumnas.TipoDato.Substring(0, 4);
            }
            else
            {
                p_Cadena = p_objColumnas.TipoDato;
            }
            p_Cadena = p_Cadena.Trim();
            switch (p_Cadena)
            {
                case "char":
                    p_Cadena = consts.TIPO_DATO_CADENA_C;
                    break;
                case "varc":
                    p_Cadena = consts.TIPO_DATO_CADENA_C;
                    break;
                case "deci":
                    p_Cadena = consts.TIPO_DATO_DOUBLE_C;
                    break;
                case "nume":
                    p_Cadena = consts.TIPO_DATO_DOUBLE_C;
                    break;
                case "date":
                    p_Cadena = consts.TIPO_DATO_FECHA_C;
                    break;
                case "int":
                    p_Cadena = consts.TIPO_DATO_ENTERO_C;
                    break;
                case "bit":
                    p_Cadena = consts.TIPO_DATO_BOOLEANO_C;
                    break;
                case "tiny":
                    p_Cadena = consts.TIPO_DATO_ENTERO_PEQUEÑO_C;
                    break;
            }
            StringBuilder p_cad = new StringBuilder(p_Cadena);
            return p_cad;
        }



        public StringBuilder ConvertirTipoDatoSQL_ConvertTO_C(Columnas p_objColumnas)
        {
            string p_Cadena = "";
            if (p_objColumnas.TipoDato.Length > 3)
            {
                p_Cadena = p_objColumnas.TipoDato.Substring(0, 4);
            }
            else
            {
                p_Cadena = p_objColumnas.TipoDato;
            }
            p_Cadena = p_Cadena.Trim();
            switch (p_Cadena)
            {
                case "char":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_CADENA_C;
                    break;
                case "varc":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_CADENA_C;
                    break;
                case "deci":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_DOUBLE_C;
                    break;
                case "nume":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_DOUBLE_C;
                    break;
                case "date":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_FECHA_C;
                    break;
                case "int":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_ENTERO_C;
                    break;
                case "bit":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_BOOLEANO_C;
                    break;
                case "tiny":
                    p_Cadena = consts.TIPO_DATO_CONVERTO_TO_ENTERO_PEQUEÑO_C;
                    break;
            }
            StringBuilder p_cad = new StringBuilder(p_Cadena);
            return p_cad;
        }


        //******** SOLO IMPRIME LOS TIPOS DE DATOS DE SQL SERVER
        public StringBuilder F_TipoDatoProcedureBD_Str2(Columnas p_objColumnas, consts.TIPO_BASE_DATOS p_TipoBaseDatos)
        {
            string p_Cadena = "";
            if (p_objColumnas.TipoDato.Length > 3)
            {
                p_Cadena = p_objColumnas.TipoDato.Substring(0, 4);
            }
            else
            {
                p_Cadena = p_objColumnas.TipoDato;
            }
            p_Cadena = p_Cadena.Trim();
            switch (p_Cadena)
            {
                case "char":
                    p_Cadena = consts.TIPO_DATO_CADENA2_BD + "(" + p_objColumnas.tamanio + ")";
                    break;
                case "varc":
                    p_Cadena = consts.TIPO_DATO_CADENA_BD + "(" + p_objColumnas.tamanio + ")";
                    break;
                case "deci":
                    p_Cadena = consts.TIPO_DATO_DOUBLE_BD + "(" + p_objColumnas.tamanio + "," + p_objColumnas.Decimales + ")";
                    break;
                case "nume":
                    p_Cadena = consts.TIPO_DATO_NUMERIC_BD + "(" + p_objColumnas.tamanio + "," + p_objColumnas.Decimales + ")";
                    break;
                case "date":
                    p_Cadena = consts.TIPO_DATO_FECHA_BD;
                    break;
                case "int":
                    p_Cadena = consts.TIPO_DATO_ENTERO_BD;
                    break;
                case "bit":
                    p_Cadena = consts.TIPO_DATO_BOOLEANO_BD;
                    break;
                case "tiny":
                    p_Cadena = consts.TIPO_DATO_ENTERO2_BD;
                    break;
            }
            StringBuilder p_cad = new StringBuilder(p_Cadena);
            return p_cad;
        }

        public StringBuilder F_TipoDatoInicializarDatos_C(Columnas p_objColumnas)
        {
            string p_Cadena = "";
            if (p_objColumnas.TipoDato.Length > 3)
            {
                p_Cadena = p_objColumnas.TipoDato.Substring(0, 4);
            }
            p_Cadena = p_Cadena.Trim();
            switch (p_Cadena)
            {
                case "char":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_CADENA_2;
                    break;
                case "varc":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_CADENA_2;
                    break;
                case "deci":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_DOUBLE_2;
                    break;
                case "nume":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_DOUBLE_2;
                    break;
                case "date":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_FECHA_2;
                    break;
                case "int":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_ENTERO_2;
                    break;
                case "bit":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_BOOLEANO_2;
                    break;
                case "tiny":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_ENTERO_PEQUEÑO_2;
                    break;
                case "smal":
                    p_Cadena = consts.TIPO_DATO_INICIALIZAR_ENTERO_PEQUEÑO_2;
                    break;

            }
            StringBuilder p_cad = new StringBuilder(p_Cadena);
            return p_cad;

        }

        #endregion




    }
}
