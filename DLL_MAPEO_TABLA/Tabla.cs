using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DLL_MAPEO_DAO;

namespace DLL_MAPEO
{
    public class Tabla
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        // -------- CARGA COLUNNAS 
        private List<Columnas> listadoColumnas=null;
        // ------- CARGA LLAVE PRIMARIAS
        private List<LlavePrimaria> ListadoLlavePrimaria = null;

        public Tabla()
        {
            listadoColumnas = new List<Columnas>();
            ListadoLlavePrimaria = new List<LlavePrimaria>();
        }

        public Tabla(string p_NombreTabla)
        {
            listadoColumnas = new List<Columnas>();
            ListadoLlavePrimaria = new List<LlavePrimaria>();
            this.Id = p_NombreTabla;
            this.Nombre = p_NombreTabla;
            CargarColumnas();
            CargarLlavesPrimarias();
            EstablecerLlavePrimaria();
        }

        //************************************************************************************************************
        //************************************************************************************************************
        //************************************ COLUNNAS ***************************************
        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************

        //********** LISTAR **************************
        public List<Columnas> ListarColumnas()
        {
            return listadoColumnas;
        }

        //********** CARGAR LISTADO BD ***************
        private void CargarColumnas()
        {
            listadoColumnas.Clear();
            DAOFactory objDAOFactory = DAOFactory.getDAOFactory(DAOFactory.SQLSERVER);
            IColumnasDAO objIColumnasDAO = objDAOFactory.getColumnasDAO();

            foreach (BeanColumnas objBeanColumnas in objIColumnasDAO.ListarColumnas(this.Nombre))
            {
                Columnas objColumnas = new Columnas();
                objColumnas.Id = objBeanColumnas.Id;
                objColumnas.EsLlavePrimaria = objBeanColumnas.EsLlavePrimaria;
                objColumnas.NombreColumna = objBeanColumnas.NombreColumna;
                objColumnas.TipoDato = objBeanColumnas.TipoDato;
                objColumnas.tamanio = objBeanColumnas.tamanio;
                objColumnas.Decimales = objBeanColumnas.Decimales;
                objColumnas.EsColumnaEstado = objBeanColumnas.EsColumnaEstado;
                objColumnas.EsColunnaIdentidad = objBeanColumnas.EsColumnaIdentidad;
                listadoColumnas.Add(objColumnas);
            }
        }
        //************************************************************************************************************
        //************************************************************************************************************
        //************************************ LLAVE PRIMARIA ********************************************************
        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************
        
        public List<Columnas> ListarColumnasLlavePrimaria()
        {
            List<Columnas> listadoColumnas = new List<Columnas>();
            foreach (Columnas objColumnas in ListarColumnas())
             {
                 if (objColumnas.EsLlavePrimaria == true)
                 {
                     listadoColumnas.Add(objColumnas);
                 }
             }
             return listadoColumnas;
        }


        public List<Columnas> ListarColumnasSinEstado()
        {
            List<Columnas> listadoColumnas = new List<Columnas>();
            foreach (Columnas objColumnas in ListarColumnas())
            {
                if (objColumnas.EsColumnaEstado == false)
                {
                    listadoColumnas.Add(objColumnas);
                }
            }
            return listadoColumnas;
        }


        //**********************************
        public void EstablecerLlavePrimaria()
        {
            foreach (Columnas objColumnas in listadoColumnas)
            {
                 foreach (LlavePrimaria objLlavePrimaria in ListadoLlavePrimaria)
                 {
                     if (objColumnas.NombreColumna == objLlavePrimaria.NombreColunma)
                     {
                         objColumnas.EsLlavePrimaria = true;
                         break;
                     }
                 }
            }
        }


        //********** CARGAR LISTADO BD ***************
        private void CargarLlavesPrimarias()
        {
            ListadoLlavePrimaria.Clear();
            DAOFactory objDAOFactory = DAOFactory.getDAOFactory(DAOFactory.SQLSERVER);
            IColumnasDAO objIColumnasDAO = objDAOFactory.getColumnasDAO();

            foreach (BeanLlavePrimaria objBeanLlavePrimaria in objIColumnasDAO.ListarLlavesPrimarias(this.Nombre))
            {
                LlavePrimaria objColumnas = new LlavePrimaria();
                objColumnas.NombreTabla = objBeanLlavePrimaria.NombreTabla;
                objColumnas.NombreColunma = objBeanLlavePrimaria.NombreColunma;

                ListadoLlavePrimaria.Add(objColumnas);
            }
        }


    }
}
