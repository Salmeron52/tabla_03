using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            
            //Si no existe el archivo, lo creamos:
            if (!File.Exists("miniAgenda.txt"))
            {
                StreamWriter sw = new StreamWriter("miniAgenda.txt"); //Creamos el fichero
                sw.Close();
            }
            //Si el archivo existe, leemos cada una de las líneas, las mostramos en la tabla y reppetimos
            //hasta el final del arcivo.
            else
            {
                StreamReader sr = new StreamReader("miniAgenda.txt");

                while (!sr.EndOfStream)
                {
                    string nombre = sr.ReadLine();
                    string telefono = sr.ReadLine();
                    string email = sr.ReadLine();

                    tabla.Rows.Add(nombre, telefono, email);
                }
                sr.Close();
            }
        }

        private void limpiarTextBox()
        {
            textBoxNombre.Text = null; //limpia el textbox
            textBoxTelefono.Text = null;
            textBoxMail.Text = null;
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            //Si todos los campos están vacíos no hacemos nada

            if (textBoxNombre.Text == "" && textBoxTelefono.Text == "" && textBoxMail.Text == "")
            {
                MessageBox.Show("No se ha introducido ningún dato");
            }
            else
            {
                GrabarDatos();
                tabla.Rows.Add(textBoxNombre.Text, textBoxTelefono.Text, textBoxMail.Text); // Agrega una fila a la tabla
                limpiarTextBox();
            }
            textBoxNombre.Focus();
        }

        private void GrabarDatos()
        {
            StreamWriter sw = new StreamWriter("miniAgenda.txt", true);
            sw.WriteLine(textBoxNombre.Text);
            sw.WriteLine(textBoxTelefono.Text);
            sw.WriteLine(textBoxMail.Text);
            sw.Close();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            //Si no hay un nombre escrito en el textBoxNombre, mostramos un mensaje advirtiendo al usuario
            if (textBoxNombre.Text == "")
            {
                MessageBox.Show("Introduzca un nombre para borrar");
                textBoxNombre.Select();
            }
            
            //Recorremos todo el DataGridView, si encontramos el nombre que queremos borrar, lo borramos
            //y salimos del bucle

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (tabla.Rows[i].Cells[0].Value.ToString() == textBoxNombre.Text)
                {
                    tabla.Rows.RemoveAt(i);
                    BorrarRegistro();
                    MessageBox.Show("Registro borrado.");
                    limpiarTextBox();
                    textBoxNombre.Select();
                    break;
                }
            }
        }

        private void BorrarRegistro()
        {
            //Como no podemos borrar un solo registro y el registro sí se ha borrado ya de la tabla,
            //lo que hacemos es sobreescribir el archivo con todos los registros de la tabla.

            StreamWriter sw = new StreamWriter("miniAgenda.txt");
            
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                sw.WriteLine(tabla.Rows[i].Cells[0].Value.ToString()); //nombre (Primera celda de la fila i)
                sw.WriteLine(tabla.Rows[i].Cells[1].Value.ToString()); //telefono (Segunda celda de la fila i)
                sw.WriteLine(tabla.Rows[i].Cells[2].Value.ToString()); //email (Tercera celda de la fila i)             {
            }
            sw.Close();
        }

        private void buttonModificar_Click(object sender, EventArgs e) //¡¡¡REPARAR ESTE MÉTODO!!!
        {
            //iNTRODUCIMOS UN NOMBRE EN EL TEXTBOXNOMBRE Y lo buscamos en el datagridview. Si no existe, enviamos un mensaje.
            //Si lo encontramos, mostramos los datos en los textbox correspondientes.
            //Si los datos de los textbox no están vacíos, los modificamos y sobreescribimos el archivo.
           
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //iNTRODUCIMOS UN NOMBRE EN EL TEXTBOXNOMBRE Y lo buscamos en el datagridview. Si no existe, enviamos un mensaje.
            //Si lo encontramos, mostramos los datos en los textbox correspondientes.
            //Si encontramos una parte del nombre en el datagridview, mostramos todos los registros que contengan esa parte.
            
            
            
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (tabla.Rows[i].Cells[0].Value.ToString().Contains(textBoxNombre.Text))
                {
                    textBoxNombre.Text = tabla.Rows[i].Cells[0].Value.ToString();
                    textBoxTelefono.Text = tabla.Rows[i].Cells[1].Value.ToString();
                    textBoxMail.Text = tabla.Rows[i].Cells[2].Value.ToString();
                }
                /**
                {
                    textBoxTelefono.Text = tabla.Rows[i].Cells[1].Value.ToString();
                    textBoxMail.Text = tabla.Rows[i].Cells[2].Value.ToString();
                    break;
                }**/
            }

            if (textBoxTelefono.Text == "" && textBoxMail.Text == "")
            {
                MessageBox.Show("No se ha encontrado el nombre");
                textBoxNombre.Select();
            }
        }
    }
}
