using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPcalculadora
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultadoAux;
            Numero numero1;
            Numero numero2;
            string aux;
            
            numero1 = new Numero(this.txtNumero1.Text);
            numero2 = new Numero(this.txtNumero2.Text);

            resultadoAux = Calculadora.operar(numero1, numero2, this.cmbOperacion.Text);
            
            aux = Convert.ToString(resultadoAux);

            this.lblResultado.Text = aux;


        }

        private void limpiar()
        {
            this.lblResultado.Text = "Resultado";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = string.Empty;
        }
    }
}
