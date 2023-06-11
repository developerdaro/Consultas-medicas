using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public  class ModelUsuario
    {
         private string identificacion_usuario;
        private string nombre_usuario;
        private string apellido_usuario;
        private int ciudad_id_ciudad;
        private int rol_id_rol;


        public void setidentificacion_usuario(string identificacion_usuario)
        {
            this.identificacion_usuario = identificacion_usuario;
        } public void setnombre_usuario(string nombre_usuario)
        {
            this.nombre_usuario = nombre_usuario;
        } public void setapellido_usuario(string apellido_usuario)
        {
            this.apellido_usuario = apellido_usuario;
        } public void setciudad_id_ciudad(int ciudad_id_ciudad)
        {
            this.ciudad_id_ciudad = ciudad_id_ciudad;
        } public void setrol_id_rol(int rol_id_rol)
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
        public int getciudad_usuario()
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

    }
}
