using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tabla_03
{
    public partial class Form1 : Form
    {
        //Ponemos el foco en textBoxNombre al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            //Hacemos click automáticamente en el textBoxNombre al cargar el formulario:
            textBoxNombre.Select();
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void limpiarTextBox()
        {
            textBoxNombre.Text = null; //limpia el textbox
            textBoxTelefono.Text = null;
            textBoxMail.Text = null;
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            tabla.Rows.Add(textBoxNombre.Text, textBoxTelefono.Text, textBoxMail.Text); // Agrega una fila a la tabla
            limpiarTextBox();
            textBoxNombre.Focus();
        }
    }
}
