using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{

    public class ModelConnection
    {

        MySqlConnection obj_connection = new MySqlConnection();


        static string server = "localhost";
        static string user = "root";
        static string passw = "daro.";
        static string port = "3306";
        static string db = "consulta-medica";
        string dataConnection = "server=" + server + "; port=" + port + "; user id=" + user + "; password=" + passw + "; database=" + db + ";";

        public MySqlConnection connectSQL()
        {
            try
            {
                MySqlConnection obj_connection = new MySqlConnection(dataConnection);
                obj_connection.Open();
                return obj_connection;

            }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
                return null;
            }

        }
        public void closeSQL()
        {
            try
            {
                obj_connection.Close();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err + "");
            }
        }

       

    }
}
