using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maquina_Expendedora
{
    public partial class Inicio : Form
    {
        //variables globales
        private List<Label> lista_ingredientes = new List<Label>();


        //Colores
        Color color1 = ColorTranslator.FromHtml("#FFFEDA");
        Color color2 = ColorTranslator.FromHtml("#9AC4F8");
        Color color3 = ColorTranslator.FromHtml("#CB958E");
        Color color4 = ColorTranslator.FromHtml("#E36588");
        Color color5 = ColorTranslator.FromHtml("#9A275A");

        public Inicio()
        {
            InitializeComponent();
            this.BackColor = color1;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label ingrediente_1 = new Label();

            // 2. Configurar las propiedades
            ingrediente_1.Text = "Cheddar";
            ingrediente_1.Location = new System.Drawing.Point(50, 100); // Coordenadas (X, Y)
            ingrediente_1.AutoSize = true; // Hace que el label se ajuste al tamaño del texto
            ingrediente_1.Name = "ingrediente_queso";

            // 3. Agregar el label al formulario
            // Si quieres agregarlo a un panel específico, cambia 'this' por el nombre del panel
            this.panel16.Controls.Add(ingrediente_1);

            lista_ingredientes.Add(ingrediente_1);


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
