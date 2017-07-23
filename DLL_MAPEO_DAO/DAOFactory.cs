using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL_MAPEO_DAO
{
    public abstract class DAOFactory
    {
        public static int SQLSERVER = 1;

        public abstract ITablaDAO getTablaDAO();
        public abstract IColumnasDAO getColumnasDAO();

        public static DAOFactory getDAOFactory(int whichFactory)
        {
            switch (whichFactory)
            {
                case 1:
                    return new SqlServerDAOFactory();
                /*case DB2:
                    return new Db2DAOFactory();
                case SQLSERVER:
                    return new SqlServerDAOFactory();
                case XML:
                    return new XmlDAOFactory();*/
                default:
                    return null;
            }
        }



    }
}
