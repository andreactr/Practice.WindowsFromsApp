using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data_Access;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Data data = new Data();
        bool flag = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        //INSERT
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (flag == true)
            {
                int a = dataGridView1.CurrentRow.Index;
                if (validarNombre() == false && validarEdad() == false && validarCorreo() == false)
                {
                    return;
                }
                else
                {
                    //update
                    int idUpd = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());                   
                    data.UpdatePersonas(idUpd, tbNombre.Text, int.Parse(tbEdad.Text), tbEmail.Text);
                    MessageBox.Show("succesfully updated");
                    SelectAll();
                    Limpiar();
                    tbNombre.Focus();
                    
                }
                
                flag = false;
            } else {
                if (validarNombre() == false)
                {
                    return;
                }
                if (validarEdad() == false)
                {
                    return;
                }
                if (validarCorreo() == false)
                {
                    return;
                }
                data.CreatePersona(tbNombre.Text, int.Parse(tbEdad.Text), tbEmail.Text);
                MessageBox.Show("succesfully saved");
                SelectAll();
                Limpiar();
                tbNombre.Focus();
            }
        }

        private bool validarCorreo()
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                erpError.SetError(tbEmail, "Debe ingresar un correo");
                return false;
            }
            else
            {
                erpError.SetError(tbEmail, "");
                return true;
            }
        }


        private bool validarEdad()
        {
            int Edad;
            if(!int.TryParse(tbEdad.Text, out Edad) || tbEdad.Text == "" || tbEdad.Text == "0")
            {
                erpError.SetError(tbEdad, "Debe ingresar un valor numérico");
                tbEdad.Clear();
                tbEdad.Focus();
                return false;
            }
            else
            {
                erpError.SetError(tbEdad, "");
                return true;
            }
        }

        private bool validarNombre()
        {
            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                erpError.SetError(tbNombre, "Debe ingresar un nombre");
                return false;
            }
            else
            {
                erpError.SetError(tbNombre, "");
                return true;
            }
        }


        private void Limpiar()
        {
            tbNombre.Clear();
            tbEmail.Clear();
            tbEdad.Clear();
            tbBuscador.Clear();
            SelectAll();
        }


        //SELECT *
        void SelectAll()
        {
           
            dataGridView1.DataSource = data.GetPersonas();
        }

        //CARGAR TABLE FROM SQL
        private void Form1_Load(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tbNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbEdad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            flag = true;
        }

        //DELETE
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Respuesta == DialogResult.Yes) {
                
                string idDel = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                
                data.DeletePersonas(idDel);
                MessageBox.Show("succesfully deleted");
                SelectAll();
                Limpiar();
                tbNombre.Focus();
               
            }
        }

        //BUSCAR    
        private void button1_Click_1(object sender, EventArgs e)
        {
            //data.GetPersonasPorBuscador(tbBuscador.Text);
            dataGridView1.DataSource = data.GetPersonasPorBuscador(tbBuscador.Text);
        }
       
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
