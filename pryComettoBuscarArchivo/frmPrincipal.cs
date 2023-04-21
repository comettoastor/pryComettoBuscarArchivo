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
            if (txtBuscar.Text != "")
            {
                StreamReader streamReader = new StreamReader("LIBROS.txt");
                string auxiliar;
                while (streamReader.EndOfStream == false)
                {
                    auxiliar = streamReader.ReadLine();
                    if (auxiliar.Contains(txtBuscar.Text))
                    {
                        lblResultado.Text = "LIBRO ENCONTRADO:\n" + auxiliar;
                        lblResultado.BackColor = Color.Green;
                        streamReader.Close();
                        break; //FRENO CORTA LA EJECUCION DEL PROCEDIMIENTO
                    }
                    else
                    {
                        lblResultado.Text = "LIBRO NO ENCONTRADO";
                        lblResultado.BackColor = Color.Red;
                    }
                }
                streamReader.Close();
            }
            else
            {
                MessageBox.Show("Error - Ingrese el nombre del libro a buscar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("LIBROS.txt",true);
            streamWriter.Write("CONSTITUCION DE LA NACION ARGENTINA\nCODIGO CIVIL Y COMERCIAL DE LA NACION\nLA VUELTA AL MUNDO EN 80 DIAS\nROBINSON CRUSOE");
            streamWriter.Close();
        }
    }
}
