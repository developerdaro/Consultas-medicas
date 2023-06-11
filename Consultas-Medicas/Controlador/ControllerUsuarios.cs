using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controlador
{
    public class ControllerUsuarios
    {
        private string identificacion_usuario;
        private string nombre_usuario;
        private string apellido_usuario;
        private int ciudad_id_ciudad;
        private int rol_id_rol;

        public void setidentificacion_usuario(string identificacion_usuario)
        {
            this.identificacion_usuario = identificacion_usuario;
        }
        public void setnombre_usuario(string nombre_usuario)
        {
            this.nombre_usuario = nombre_usuario;
        }
        public void setapellido_usuario(string apellido_usuario)
        {
            this.apellido_usuario = apellido_usuario;
        }
        public void setciudad_id_ciudad(int ciudad_id_ciudad)
        {
            this.ciudad_id_ciudad = ciudad_id_ciudad;
        }
        public void setrol_id_rol(int rol_id_rol)
        {
            this.rol_id_rol = rol_id_rol;
        }

        public string getidentificacion_usuario()
        {
            return identificacion_usuario;
        }
        public string getnombre_usuario()
        {
            return nombre_usuario;
        }
        public string getapellido_usuario()
        {
            return apellido_usuario;
        }
        public int getciudad_id_ciudad()
        {
            return ciudad_id_ciudad;
        }
        public int getrol_id_rol()
        {
            return rol_id_rol;
        }

        private string especialista_dcotro;
        private int usuario_id_usuario;

        public void setespecialista_dcotro(string especialista_dcotro)
        {
            this.especialista_dcotro = especialista_dcotro;
        }

        public string getespecialista_dcotro()
        {
            return especialista_dcotro;
        }
        public void setusuario_id_usuario(int usuario_id_usuario)
        {
            this.usuario_id_usuario = usuario_id_usuario;
        }

        public int getusuario_id_usuario()
        {
            return usuario_id_usuario;


        }

        private string motivo_consulta;
        private string fecha_consulta;
        private string hora_consulta;
        private int doctor_id_doctor;

        public void setmotivo_consulta(string motivo_consulta)
        {
            this.motivo_consulta = motivo_consulta;
        }

        public string getmotivo_consulta()
        {
            return motivo_consulta;
        }

        public void setfecha_consulta(string fecha_consulta)
        {
            this.fecha_consulta = fecha_consulta;
        }

        public string getfecha_consulta()
        {
            return fecha_consulta;
        }

        public void sethora_consulta(string hora_consulta)
        {
            this.hora_consulta = hora_consulta;
        }

        public string gethora_consulta()
        {
            return hora_consulta;
        }

        public void setdoctor_id_doctor(int doctor_id_doctor)
        {
            this.doctor_id_doctor = doctor_id_doctor;
        }

        public int getdoctor_id_doctor()
        {
            return doctor_id_doctor;
        }






        ModelConnection obj_connection = new ModelConnection();


    

        public void insert(string identificacion_usuario, string nombre_usuario, string apellido_usuario,
            int ciudad_id_ciudad, int Rol_id_rol)
        {
             
            string instructionSQL = "INSERT INTO usuario (identificacion_usuario,nombre_usuario,apellido_usuario,Ciudad_id_ciudad,Rol_id_rol) VALUES ('" + identificacion_usuario + "', '" + nombre_usuario+ "', '" + apellido_usuario+ "', '" + ciudad_id_ciudad + "','"+ Rol_id_rol + "')";
            MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection.connectSQL());
            try
            {
                obj_command.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con exito");
                obj_connection.closeSQL();

             }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
            }
        }
        public void insertconsulta(string motivo_consulta, string fecha_consulta, string hora_consulta,
           int usuario_is_usuario, int doctor_id_doctor)
        {

            string instructionSQL = "INSERT INTO consulta (motivo_consulta,fecha_consulta,hora_consulta,usuario_id_usuario,doctor_id_doctor) VALUES ('" + motivo_consulta + "', '" + fecha_consulta + "', '" + hora_consulta + "', '" + usuario_is_usuario + "','" + doctor_id_doctor + "')";
            MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection.connectSQL());
            try
            {
                obj_command.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con exito");
                obj_connection.closeSQL();

            }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
            }
        }
        public void insertMedico(string especialista_dcotro, int usuario_id_usuario)
        {

            string instructionSQL = "INSERT INTO doctor (especialista_doctor,usuario_id_usuario) VALUES ('" + especialista_dcotro + "', '" + usuario_id_usuario + "')";
            MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection.connectSQL());
            try
            {
                obj_command.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con exito");
                obj_connection.closeSQL();

            }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
            }
        }

        public List<String> consult()
        {
            String instructionSQL = "SELECT * FROM usuario" ;
            MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection.connectSQL());
            try
            {
                MySqlDataReader dataReader = obj_command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    List<String> listRestaurants = new List<String>();
                    while (dataReader.Read())
                    {
                        listRestaurants.Add(dataReader.GetString(1));
                    }
                    return listRestaurants;
                }
                else
                {
                    MessageBox.Show(" ");
                    return null;
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
                return null;
            }

        }


        public List<String> consultroles()
        {
            String instructionSQL = "SELECT * FROM rol";
            MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection.connectSQL());
            try
            {
                MySqlDataReader dataReader = obj_command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    List<String> listRestaurants = new List<String>();
                    while (dataReader.Read())
                    {
                        listRestaurants.Add(dataReader.GetString(1));
                    }
                    return listRestaurants;
                }
                else
                {
                    MessageBox.Show(" ");
                    return null;
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
                return null;
            }

        }

        public DataSet consultaporidentificacion(int identificacion)
        {
            string sql = "select nombre_usuario,motivo_consulta,fecha_consulta,hora_consulta from consulta inner join usuario on identificacion_usuario=" + identificacion;
            MySqlDataAdapter adapter;
            DataSet ds = new DataSet();
            adapter = new MySqlDataAdapter(sql, obj_connection.connectSQL());
            adapter.Fill(ds, "tbl");
            return ds;
        }

        public List<String> consultrolesmedicos()
        {
            String instructionSQL = "SELECT nombre_usuario FROM usuario  inner join rol on Rol_id_rol=2";
            MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection.connectSQL());
            try
            {
                MySqlDataReader dataReader = obj_command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    List<String> listRestaurants = new List<String>();
                    while (dataReader.Read())
                    {
                        listRestaurants.Add(dataReader.GetString(0));
                    }
                    return listRestaurants;
                }
                else
                {
                    MessageBox.Show(" ");
                    return null;
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
                return null;
            }

        }

        public List<String> consulciudades()
        {
            String instructionSQL = "SELECT * FROM ciudad";
            MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection.connectSQL());
            try
            {
                
                MySqlDataReader dataReader = obj_command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    List<String> listRestaurants = new List<String>();
                    while (dataReader.Read())
                    {
                        listRestaurants.Add(dataReader.GetString(1));
                    }
                    return listRestaurants;
                }
                else
                {
                    MessageBox.Show("There are not restaurants in the database");
                    return null;
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show(Convert.ToString(err));
                return null;
            }

        }



        //public ModelUsuario search(String name_restaurant)
        //{
        //    String instructionSQL = "SELECT * FROM usuario WHERE name_restaurant='" + name_restaurant + "';";
        //    MySqlCommand obj_command = new MySqlCommand(instructionSQL, obj_connection);
        //    try
        //    {
        //        MySqlDataReader dataRead = obj_command.ExecuteReader();
        //        dataRead.Read();
        //        obj_usuario.setName(dataRead.GetString(1));
        //        obj_usuario.setAddress(dataRead.GetString(2));
        //        obj_usuario.setTime(dataRead.GetString(3));
        //        obj_usuario.setFood(dataRead.GetString(4));
        //        return obj_restaurant;
        //    }
        //    catch (MySqlException err)
        //    {
        //        MessageBox.Show(err + "");
        //        return null;
        //    }
        //}


    }
}
