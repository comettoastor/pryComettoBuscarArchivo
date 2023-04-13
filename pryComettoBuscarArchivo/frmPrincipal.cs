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
            StreamReader streamReader = new StreamReader("LIBRO.txt");
            string auxiliar;
            while (streamReader.EndOfStream == false)
            {
                auxiliar = streamReader.ReadLine();
                if (auxiliar.Contains(txtBuscar.Text))
                {
                    lblDatos.Text = "ENCONTRADO " + auxiliar;
                    break; //FRENO CORTA LA EJECUCION DEL PROCEDIMIENTO
                }
                else
                {
                    lblDatos.Text = "NO ENCONTRADO";
                }
            }
        }
    }
}
