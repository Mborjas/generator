using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DLL_MAPEO_DAO;

namespace DLL_MAPEO
{

    public class AdministradorTablas
    {
        private List<Tabla> listadoTabla;

        public AdministradorTablas() 
        {
            listadoTabla = new List<Tabla>();
            CargarTablas();
        }

        //********** LISTAR **************************
        public List<Tabla> ListarTabla()
        {
            return listadoTabla;
        }

        //********** CARGAR LISTADO BD ***************
        private void CargarTablas()
        {
            listadoTabla.Clear();
            DAOFactory objDAOFactory = DAOFactory.getDAOFactory(DAOFactory.SQLSERVER);
            ITablaDAO objITablaDAO = objDAOFactory.getTablaDAO();

            foreach (BeanTabla objBeanTabla in objITablaDAO.ListarTablas())
            {
                Tabla objTabla = new Tabla();
                objTabla.Id = objBeanTabla.Id;
                objTabla.Nombre = objBeanTabla.Nombre;
                listadoTabla.Add(objTabla);
            }
        }


    }
}
