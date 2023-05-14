using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryComettoBuscarArchivo
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Checkeo si la textbox tiene un libro ingresado
            if (txtBuscar.Text != "")
            {
                //Instancio el streamReader para leer el archivo de libros, creo una variable auxiliar
                //que guarde la linea leida y otra libros que guarde los libros que encuentre
                StreamReader streamReader = new StreamReader("LIBROS.txt");
                string auxiliar;
                string libros = "";
                //Empiezo a leer el archivo con un mientras hasta que sea el end of file
                while (streamReader.EndOfStream == false)
                {
                    auxiliar = streamReader.ReadLine();
                    //Pongo la linea y el libro ingresado en minusculas para no tener que distinguir mayus/minus
                    if (auxiliar.ToLower().Contains(txtBuscar.Text.ToLower()))
                    {
                        libros = libros + auxiliar + "\n";
                        
                    }
                }
                streamReader.Close();
                //Si encuentro libros que los muestre en un label con color verde y sino con el mensaje en rojo
                if (libros != "")
                {
                    lblResultado.Text = libros;
                    lblResultado.BackColor = Color.Green;
                }
                else
                {
                    lblResultado.Text = "LIBRO NO ENCONTRADO";
                    lblResultado.BackColor = Color.Red;
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre del libro a buscar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Instancio un StreamWriter para crear el archivo de libros en la misma carpeta del ejecutable
            StreamWriter streamWriter = new StreamWriter("LIBROS.txt");
            streamWriter.Write("CONSTITUCION DE LA NACION ARGENTINA\nCODIGO CIVIL Y COMERCIAL DE LA NACION\nLA VUELTA AL MUNDO EN 80 DIAS\nROBINSON CRUSOE");
            streamWriter.Close();
            MessageBox.Show("Archivo de libros generado", "Archivo Generado", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
