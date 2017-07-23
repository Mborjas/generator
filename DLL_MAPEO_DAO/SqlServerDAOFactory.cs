using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL_MAPEO_DAO
{
    public class SqlServerDAOFactory : DAOFactory
    {
        public override ITablaDAO getTablaDAO()
        {
            return new SqlServerTablaDAO();
        }
        public override IColumnasDAO getColumnasDAO()
        {
            return new SqlServerColumnasDAO();
        }
    }
}
