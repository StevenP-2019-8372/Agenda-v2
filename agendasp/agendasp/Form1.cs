using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_entidad;
using Capa_negocio;

namespace agendasp
{
    public partial class Form1 : Form
    {
        Classentidad objent = new Classentidad();
        Classnegocio objneg = new Classnegocio();

        public Form1()
        {
            InitializeComponent();
        }
        void mantenimiento(string accion)
        {
            objent.id = tid.Text;
            objent.nombre = tnombre.Text;
            objent.apellido = tapellido.Text;
            objent.direccion = tdireccion.Text;
            objent.fechadn = tfecha.Text;
            objent.movil = Convert.ToInt32(tmovil.Text);
            objent.telefono = Convert.ToInt32(ttelefono.Text);
            objent.correo = tcorreo.Text;
            objent.genero = tgenero.Text;
            objent.estado = testado.Text;
            objent.accion = accion;
            String men = objneg.N_mantenimiento_cliente(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            tid.Text = "";
            tnombre.Text = "";
            tapellido.Text = "";
            tdireccion.Text = "";
            tfecha.Text = "";
            tmovil.Text = "";
            ttelefono.Text = "";
            tcorreo.Text = "";
            tgenero.Text = "";
            testado.Text = "";
            check();
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.Gray)
            {
                BackColor = Color.White;
                groupBox1.BackColor = Color.White;
                groupBox2.BackColor = Color.White;
                groupBox3.BackColor = Color.White;
                groupBox4.BackColor = Color.White;
                groupBox5.BackColor = Color.White;
                dataGridView1.BackColor = Color.DarkGray;
            }
            else
            {
                BackColor = Color.Gray;
                groupBox1.BackColor = Color.Gray;
                groupBox2.BackColor = Color.Gray;
                groupBox3.BackColor = Color.Gray;
                groupBox4.BackColor = Color.Gray;
                groupBox5.BackColor = Color.Gray;
                dataGridView1.BackColor = Color.Lavender;
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tgenero.Text = "Hombre";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tgenero.Text = "Mujer";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            testado.Text = "Casado/a";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            testado.Text = "Viudo/a";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            testado.Text = "Divorciado/a";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            testado.Text = "Soltero/a";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tfecha.Text = dateTimePicker1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tid.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + tnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {

                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tid.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + tnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {

                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tid.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + tnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {

                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void tbuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbuscar.Text != "")
            {
                objent.nombre = tbuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_clientes();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            tid.Text = dataGridView1[0, fila].Value.ToString();
            tnombre.Text = dataGridView1[1, fila].Value.ToString();
            tapellido.Text = dataGridView1[2, fila].Value.ToString();
            tdireccion.Text = dataGridView1[3, fila].Value.ToString();
            tfecha.Text = dataGridView1[4, fila].Value.ToString();
            tmovil.Text = dataGridView1[5, fila].Value.ToString();
            ttelefono.Text = dataGridView1[6, fila].Value.ToString();
            tcorreo.Text = dataGridView1[7, fila].Value.ToString();
            tgenero.Text = dataGridView1[8, fila].Value.ToString();
            testado.Text = dataGridView1[9, fila].Value.ToString();
        }

        private void tgenero_TextChanged(object sender, EventArgs e)
        {/*
            if (tgenero.Text == "Hombre")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;

            }
            if (tgenero.Text == "Mujer")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            else
            {
                check();
            }
            */
           
        }
        void check()
        {
             if (tgenero.Text == "")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                if (testado.Text == "")
                {
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                }
            }
            
        }
        private void testado_TextChanged(object sender, EventArgs e)
        {
           /* if (testado.Text == "Casado/a")
            {
                radioButton3.Checked = true;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
            }
           else if (testado.Text == "Viudo/a")
            {
                radioButton3.Checked = false;
                radioButton4.Checked = true;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
            }
            else if (tgenero.Text == "Divorciado/a")
            {
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = true;
            }
           else if (tgenero.Text == "Soltero/a")
            {
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = true;
                radioButton6.Checked = false;
            }*/
            
           
        }
    }
}
