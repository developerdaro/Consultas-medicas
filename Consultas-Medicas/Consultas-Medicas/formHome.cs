using Controlador;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultas_Medicas
{
    public partial class formHome : Form
    {
        ControllerUsuarios obj_usuario = new ControllerUsuarios();
        ControllerConnection obj_conexion = new ControllerConnection();
        public formHome()
        {
            InitializeComponent();
            Principal_Load(); 
            Principal_Load2(); 
            rolmedico();
            usuarios();


        }

        private void formHome_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int rol = cmbRoles.SelectedIndex + 1;
            int ciudad = cmbxCiudad.SelectedIndex + 1;
            obj_usuario.setidentificacion_usuario(txtidentificacion.Text);
            obj_usuario.setnombre_usuario(txtnombre.Text);
            obj_usuario.setapellido_usuario(txtapellido.Text);
            obj_usuario.setidentificacion_usuario(txtidentificacion.Text);
            obj_usuario.setciudad_id_ciudad(ciudad);
            obj_usuario.setrol_id_rol(rol);


            obj_conexion.GetControllerConnection();
            obj_usuario.insert(obj_usuario.getidentificacion_usuario(),
                obj_usuario.getnombre_usuario(),
                obj_usuario.getapellido_usuario(),
                obj_usuario.getciudad_id_ciudad(),
                obj_usuario.getrol_id_rol());

            cleanFields();

        

        }
        private void cleanFields()
        {
            txtidentificacion.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            cmbxCiudad.SelectedIndex = 0; ;
            cmbRoles.SelectedIndex = 0; ;

        }

        private void Principal_Load( )
        {

            cmbRoles.DisplayMember = "nombre_rol";
            cmbRoles.ValueMember = "id_rol";
            cmbRoles.DataSource = obj_usuario.consultroles();
 

        }
        private void Principal_Load2()
        {

       

            cmbxCiudad.DisplayMember = "nombre_ciudad";
            cmbxCiudad.ValueMember = "id_ciudad";
            cmbxCiudad.DataSource = obj_usuario.consulciudades();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnregistromedico_Click(object sender, EventArgs e)
        {
            int rolmedico = cmbxmedicos.SelectedIndex + 1;

            obj_usuario.setespecialista_dcotro(txtespecializacion.Text);
            obj_usuario.setusuario_id_usuario(rolmedico);


            obj_conexion.GetControllerConnection();
            obj_usuario.insertMedico(obj_usuario.getespecialista_dcotro(),
            obj_usuario.getusuario_id_usuario());

            cleanFieldsMedico();
        }

        public void cleanFieldsMedico()
        {
            txtespecializacion.Text = "";
            cmbxmedicos.SelectedIndex = 0 ;
         
        }

        private void rolmedico()
        {



            cmbxmedicos.DisplayMember = "nombre_usuario";
            cmbxmedicos.ValueMember = "id_usuario";
            cmbxmedicos.DataSource = obj_usuario.consultrolesmedicos();

            
                cmbxregistromedico.DisplayMember = "nombre_usuario";
            cmbxregistromedico.ValueMember = "id_usuario";
            cmbxregistromedico.DataSource = obj_usuario.consultrolesmedicos();

        }

        private void usuarios()
        {



            cmbusuarios.DisplayMember = "nombre_usuario";
            cmbusuarios.ValueMember = "id_usuario";
            cmbusuarios.DataSource = obj_usuario.consult();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int usuarios = cmbusuarios.SelectedIndex + 1;
            int medicos = cmbxregistromedico.SelectedIndex + 1;

            obj_usuario.setmotivo_consulta(txtmotivoconsulta.Text);
            obj_usuario.setfecha_consulta(txtfecha.Text);
            obj_usuario.sethora_consulta(txthora.Text);
         
            obj_usuario.setusuario_id_usuario(usuarios);
            obj_usuario.setdoctor_id_doctor(medicos);


            obj_conexion.GetControllerConnection();
            obj_usuario.insertconsulta(obj_usuario.getmotivo_consulta(),
                obj_usuario.getfecha_consulta(),
                obj_usuario.gethora_consulta(),
                obj_usuario.getusuario_id_usuario(),
                obj_usuario.getdoctor_id_doctor());

            cleanFieldscitas();
        }

        public void cleanFieldscitas()
        {
            txtmotivoconsulta.Text = "";
            txtfecha.Text = "";
            txthora.Text = "";
            cmbusuarios.SelectedIndex = 0;
            cmbxregistromedico.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtbuscadoridentificador.Text);
      
            var ds = obj_usuario.consultaporidentificacion(id);

            dataconsulta.DataSource = ds;
            dataconsulta.DataMember = "tbl";
     
        }

        private void dataconsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
