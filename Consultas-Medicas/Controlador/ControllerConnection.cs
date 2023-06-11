using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Windows.Forms;

namespace Controlador
{
    public class ControllerConnection
    {
        ModelConnection connection=new ModelConnection();
        
        public  MySqlConnection GetControllerConnection()
        {
            return connection.connectSQL();
        }

        public void closeSQL()
        {
            try
            {
                connection.connectSQL().Close();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err + "");
            }
        }

    }
}
