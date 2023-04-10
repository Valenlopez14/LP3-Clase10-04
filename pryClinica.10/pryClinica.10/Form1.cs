using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryClinica._10
{
    public partial class frmConsulta : Form
    {
        Especialidades esp;
        Medicos med;
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            dgvGrilla.Columns.Add("C1", "MATRICULA");
            dgvGrilla.Columns.Add("C2", "NOMBRE");
            dgvGrilla.Columns.Add("C1", "CELULAR");

            try
            {
                Especialidades esp = new Especialidades();
                Medicos med = new Medicos();
                //Rellenar la lista desplegable con los datos de la BD
                lstEspecialidad.DisplayMember = "nombre";
                //Cambiar el nombre por el codigo q tiene en la BD
                lstEspecialidad.ValueMember = "especialidad";
                //De donde tomar los datos
                lstEspecialidad.DataSource = esp.getAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas con la Base de datos", "ERROR");
                this.Close();
            }



        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Borrar todo lo que haya de alguna consulta anterior
            dgvGrilla.Rows.Clear();

            int especialidad = Convert.ToInt32(lstEspecialidad.SelectedValue);

            //Muestra el numero de posicion del elemento en un mensaje
            MessageBox.Show(lstEspecialidad.SelectedValue.ToString());

            Medicos med = new Medicos();
            DataTable tabla = med.getAll();
            foreach (DataRow fila in tabla.Rows)
            {
                //Comparo si la fila es la misma que la especialidad seleccionado por el usuario
                if (Convert.ToInt32(fila["especialidad"]) == especialidad)
                {
                    //Cargo la grilla con los elementos que cumplieron la condicion
                    dgvGrilla.Rows.Add(fila["matricula"], fila["nombre"], fila["celular"]);

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 f2 = new frm2();
            f2.ShowDialog();
        }
    }
}
