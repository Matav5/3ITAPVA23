using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITADoxxer
{
    internal class DBJedinacek
    {
        #region Jedináček
        private static DBJedinacek _instance;

        public static DBJedinacek Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DBJedinacek();
                return _instance;
            }
        }

        private DBJedinacek()
        {
            connection = new MySqlConnection("HOST=mysql.matav.cz;USER=guest;DATABASE=sakila");
            connection.Open();
        }
        #endregion

        MySqlConnection connection;
    }
}
