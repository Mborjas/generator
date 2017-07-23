using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DLL_MAPEO
{

    public class consts
    {
        public const string TIPO_DATO_CADENA_C = "string";
        public const string TIPO_DATO_ENTERO_C = "int";
        public const string TIPO_DATO_FECHA_C = "DateTime";
        public const string TIPO_DATO_BOOLEANO_C = "bool";
        public const string TIPO_DATO_DOUBLE_C = "double";
        public const string TIPO_DATO_ENTERO_PEQUEÑO_C = "short";

        public const string TIPO_DATO_CONVERTO_TO_CADENA_C = "ToString";
        public const string TIPO_DATO_CONVERTO_TO_ENTERO_C = "ToInt32";
        public const string TIPO_DATO_CONVERTO_TO_FECHA_C = "ToDateTime";
        public const string TIPO_DATO_CONVERTO_TO_BOOLEANO_C = "ToBoolean";
        public const string TIPO_DATO_CONVERTO_TO_DOUBLE_C = "ToDouble";
        public const string TIPO_DATO_CONVERTO_TO_ENTERO_PEQUEÑO_C = "ToInt16";
        //******************************************************
        public const string TIPO_DATO_CADENA_BD = "VarChar";
        public const string TIPO_DATO_CADENA2_BD = "Char";
        public const string TIPO_DATO_ENTERO_BD = "Int";
        public const string TIPO_DATO_ENTERO2_BD = "TinyInt";
        public const string TIPO_DATO_FECHA_BD = "DateTime";
        public const string TIPO_DATO_BOOLEANO_BD = "Bit";
        public const string TIPO_DATO_DOUBLE_BD = "Decimal";
        public const string TIPO_DATO_NUMERIC_BD = "Numeric";
        //-------------------------- Tipo Dato inicializar
        public const string TIPO_DATO_INICIALIZAR_CADENA_2 = "\"" + "" + "\"";
        public const string TIPO_DATO_INICIALIZAR_CADENA_PEQUEÑO = "\"" + "" + "\"";
        public const string TIPO_DATO_INICIALIZAR_ENTERO_2 = "0";
        public const string TIPO_DATO_INICIALIZAR_FECHA_2 = "DateTime.Today";
        public const string TIPO_DATO_INICIALIZAR_BOOLEANO_2 = "true";
        public const string TIPO_DATO_INICIALIZAR_DOUBLE_2 = "0.0";
        public const string TIPO_DATO_INICIALIZAR_ENTERO_PEQUEÑO_2 = "0";
        public enum TIPO_BASE_DATOS
        {
            SQL_SERVER
        }
    }

}