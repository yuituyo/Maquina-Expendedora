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
        private ContextoPizza manejador;
        private List<Label> lista_ingredientes = new List<Label>();
        private Stack<List<Label>> historial = new Stack<List<Label>>();
        private Stack<int> historialPrecio = new Stack<int>();
        private Dictionary<string, Ingrediente> Inventario;


        int precio_total = 0;
        int altura_label = 110;
        readonly int total_ingredientes = 12;
        int ingredientes_seleccionados = 0;

        bool ingredientes_completos = false;


        public class Ingrediente
        {
            public string Nombre { get; set; }
            public int Precio { get; set; }
            public int Inventario { get; set; }
            public int Temporal { get; set; }
            public Ingrediente(string nombre, int precio, int inventario, int temporal)
            {
                Nombre = nombre;
                Precio = precio;
                Inventario = inventario;
                Temporal = temporal;
            }
        }

        //Colores
        Color Piel = ColorTranslator.FromHtml("#FFFEDA");
        Color Azul = ColorTranslator.FromHtml("#9AC4F8");
        Color Cafesoso = ColorTranslator.FromHtml("#CB958E");
        Color Rosa = ColorTranslator.FromHtml("#E36588");
        Color Morado = ColorTranslator.FromHtml("#9A275A");
        Color desactivado = Color.Gray;

        public Inicio()
        {
            InitializeComponent();
            InicializarInventario();
            Desactivar_proteinas();
            Desactivar_vegetales();
            manejador = new ContextoPizza(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InicializarInventario()
        {
            Inventario = new Dictionary<string, Ingrediente>
            {
                { "Cheddar", new Ingrediente("Queso cheddar", 3, 10, 0) },
                { "Cabra", new Ingrediente("Queso cabra", 10, 10, 0) },
                { "Mozzarela", new Ingrediente("Queso mozzarella", 5, 10, 0) },
                { "Manchego", new Ingrediente("Queso manchego", 5, 10, 0) },
                { "Peperoni", new Ingrediente("Peperoni", 3, 10, 0) },
                { "Albondiga", new Ingrediente("Albondiga", 7, 10, 0) },
                { "Tocino", new Ingrediente("Tocino", 10, 10, 0) },
                { "Costilla", new Ingrediente("Costilla", 20, 10, 0) },
                { "Albahaca", new Ingrediente("Albahaca", 2, 10, 0) },
                { "Cebolla", new Ingrediente("Cebolla", 5, 10, 0) },
                { "Oregano", new Ingrediente("Oregano", 2, 10, 0) },
                { "Pimiento", new Ingrediente("Pimiento", 2, 10, 0) }
            };
        }

        //Limpiar lista
        public void Limpiar_lista()
        {
            foreach (Label ingrediente in lista_ingredientes)
            {
                this.PanelIngredientes.Controls.Remove(ingrediente);
            }

            lista_ingredientes.Clear();
        }

        //Desactivar
        public void Desactivar_quesos()
        {
            Elegir_Chedar.BackColor = Color.Gray;
            Elegir_Chedar.Enabled = false;
            Elegir_cabra.BackColor = Color.Gray;
            Elegir_cabra.Enabled = false;
            Elegir_mozzarella.BackColor = Color.Gray;
            Elegir_mozzarella.Enabled = false;
            Elegir_manchego.BackColor = Color.Gray;
            Elegir_manchego.Enabled = false;
        }

        public void Desactivar_proteinas()
        {
            Elegir_peperoni.BackColor = Color.Gray;
            Elegir_peperoni.Enabled = false;
            Elegir_albondiga.BackColor = Color.Gray;
            Elegir_albondiga.Enabled = false;
            Elegir_tocino.BackColor = Color.Gray;
            Elegir_tocino.Enabled = false;
            Elegir_costilla.BackColor = Color.Gray;
            Elegir_costilla.Enabled = false;
        }

        public void Desactivar_vegetales()
        {
            Elegir_albahaca.BackColor = Color.Gray;
            Elegir_albahaca.Enabled = false;
            Elegir_cebolla.BackColor = Color.Gray;
            Elegir_cebolla.Enabled = false;
            Elegir_oregano.BackColor = Color.Gray;
            Elegir_oregano.Enabled = false;
            Elegir_pimiento.BackColor = Color.Gray;
            Elegir_pimiento.Enabled = false;
        }

        //Activar
        public void Activar_quesos()
        {
            Elegir_Chedar.BackColor = Morado;
            Elegir_Chedar.Enabled = true;
            Elegir_cabra.BackColor = Morado;
            Elegir_cabra.Enabled = true;
            Elegir_mozzarella.BackColor = Morado;
            Elegir_mozzarella.Enabled = true;
            Elegir_manchego.BackColor = Morado;
            Elegir_manchego.Enabled = true;
        }

        public void Activar_proteinas()
        {
            Elegir_peperoni.BackColor = Morado;
            Elegir_peperoni.Enabled = true;
            Elegir_albondiga.BackColor = Morado;
            Elegir_albondiga.Enabled = true;
            Elegir_tocino.BackColor = Morado;
            Elegir_tocino.Enabled = true;
            Elegir_costilla.BackColor = Morado;
            Elegir_costilla.Enabled = true;
        }

        public void Activar_vegetales()
        {
            Elegir_albahaca.BackColor = Morado;
            Elegir_albahaca.Enabled = true;
            Elegir_cebolla.BackColor = Morado;
            Elegir_cebolla.Enabled = true;
            Elegir_oregano.BackColor = Morado;
            Elegir_oregano.Enabled = true;
            Elegir_pimiento.BackColor = Morado;
            Elegir_pimiento.Enabled = true;
        }

        //Actualizar
        public void actualizar_ingredientes()
        {

            if (ingredientes_seleccionados >= total_ingredientes)
            {
                MessageBox.Show("Has seleccionado el máximo de ingredientes permitidos.");
                ingredientes_completos = true;
                return;
            }

            ingredientes_seleccionados++;

            ingredientes_totales.Text = (ingredientes_seleccionados) + "/" + total_ingredientes;

        }

        public void Restar_ingredientes()
        {
            foreach (var item in Inventario)
            {
                if (item.Value.Temporal > 0)
                {

                    item.Value.Inventario -= item.Value.Temporal;
                    item.Value.Temporal = 0;

                }

            }
        }

        public void ComprobarInventario()
        {

            if (Inventario["Cheddar"].Inventario <= 0)
            {
                Elegir_Chedar.Enabled = false;
                Elegir_Chedar.BackColor = desactivado;
            }

            if (Inventario["Cabra"].Inventario <= 0)
            {
                Elegir_cabra.Enabled = false;
                Elegir_cabra.BackColor = desactivado;
            }

            if (Inventario["Mozzarela"].Inventario <= 0)
            {
                Elegir_mozzarella.Enabled = false;
                Elegir_mozzarella.BackColor = desactivado;
            }

            if (Inventario["Manchego"].Inventario <= 0)
            {
                Elegir_manchego.Enabled = false;
                Elegir_manchego.BackColor = desactivado;
            }

            if (Inventario["Peperoni"].Inventario <= 0)
            {
                Elegir_peperoni.Enabled = false;
                Elegir_peperoni.BackColor = desactivado;
            }

            if (Inventario["Albondiga"].Inventario <= 0)
            {
                Elegir_albondiga.Enabled = false;
                Elegir_albondiga.BackColor = desactivado;
            }

            if (Inventario["Tocino"].Inventario <= 0)
            {
                Elegir_tocino.Enabled = false;
                Elegir_tocino.BackColor = desactivado;
            }

            if (Inventario["Costilla"].Inventario <= 0)
            {
                Elegir_costilla.Enabled = false;
                Elegir_costilla.BackColor = desactivado;
            }

            if (Inventario["Albahaca"].Inventario <= 0)
            {
                Elegir_albahaca.Enabled = false;
                Elegir_albahaca.BackColor = desactivado;
            }

            if (Inventario["Cebolla"].Inventario <= 0)
            {
                Elegir_cebolla.Enabled = false;
                Elegir_cebolla.BackColor = desactivado;
            }

            if (Inventario["Oregano"].Inventario <= 0)
            {
                Elegir_oregano.Enabled = false;
                Elegir_oregano.BackColor = desactivado;
            }

            if (Inventario["Cabra"].Inventario <= 0)
            {
                Elegir_pimiento.Enabled = false;
                Elegir_pimiento.BackColor = desactivado;
            }

        }

        private void ElegirIngrediente_Click(object sender, EventArgs e)
        {

            string nombreIngrediente = (sender as Button).Tag.ToString();
            manejador.Seleccionar(nombreIngrediente);
        }

        public void ProcesarSeleccion(string nombre)
        {
            if (Inventario[nombre].Inventario > 0 && Inventario[nombre].Temporal < 10)
            {
                Inventario[nombre].Temporal++;
                // Lógica de Label
                Label lbl = new Label { Text = nombre, Location = new Point(50, altura_label) };
                this.PanelIngredientes.Controls.Add(lbl);
                lista_ingredientes.Add(lbl);
                altura_label += 22;

                actualizar_ingredientes();

                precio_total += Inventario[nombre].Precio;
                Label_precio.Text = precio_total.ToString();
            }
        }

        public void ReiniciarTodo()
        {
            Limpiar_lista();
            lista_ingredientes.Clear();
            historial.Clear();
            Activar_quesos();
            Desactivar_proteinas();
            Desactivar_vegetales();

            InicializarInventario();

            altura_label = 110;
            precio_total = 0;
            Label_precio.Text = "0";

            Confirmar.Text = "Confirmar";
            ingredientes_seleccionados = 0;
            ingredientes_totales.Text = "0/" + total_ingredientes;
            manejador = new ContextoPizza(this);
            Estado.Text = "Fase: Quesos";
        }

        public void RestaurarLista(List<Label> restaurar)
        {

            foreach (Label label in restaurar)
            {

                if (!this.PanelIngredientes.Controls.Contains(label))
                {

                    this.PanelIngredientes.Controls.Add(label);
                    altura_label += 22;
                }

            }

        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            manejador.Confirmar();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            manejador.Cancelar();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            manejador.Regreso();
        }


        public class EstadoQuesos : IEstadoPizza
        {
            public void Confirmar(ContextoPizza contexto)
            {
                contexto.Form.Desactivar_quesos();
                contexto.Form.Activar_proteinas();
                contexto.Form.historial.Push(new List<Label>(contexto.Form.lista_ingredientes));
                contexto.Form.historialPrecio.Push(contexto.Form.precio_total);
                contexto.Form.Estado.Text = "Elige las proteínas...";
                contexto.EstadoActual = new EstadoProteinas();
            }
            public void Regreso(ContextoPizza contexto)
            {
                contexto.Form.ReiniciarTodo();
                contexto.Form.historial.Clear();
            }
            public void Cancelar(ContextoPizza contexto)
            {
                contexto.Form.ReiniciarTodo();
            }
            public void SelecionarIngredientes(ContextoPizza contexto, string nombreIngrediente)
            {
                contexto.Form.ProcesarSeleccion(nombreIngrediente);
            }
        }

        public class EstadoProteinas : IEstadoPizza
        {
            public void Confirmar(ContextoPizza contexto)
            {
                contexto.Form.Desactivar_proteinas();
                contexto.Form.Activar_vegetales();
                contexto.Form.historialPrecio.Push(contexto.Form.precio_total);
                contexto.Form.historial.Push(new List<Label>(contexto.Form.lista_ingredientes));
                contexto.Form.Estado.Text = "Elige los vegetales...";
                contexto.EstadoActual = new EstadoVegetales();
            }
            public void Regreso(ContextoPizza contexto)
            {

                contexto.Form.Inventario["Peperoni"].Temporal = 0;
                contexto.Form.Inventario["Albondiga"].Temporal = 0;
                contexto.Form.Inventario["Tocino"].Temporal = 0;
                contexto.Form.Inventario["Costilla"].Temporal = 0;

                //Regreso costo
                contexto.Form.precio_total = contexto.Form.historialPrecio.Pop();
                int restaurarPrecio = contexto.Form.precio_total;
                contexto.Form.Label_precio.Text = restaurarPrecio.ToString();

                //Regresar lista de ingredientes
                contexto.Form.altura_label = 110;
                contexto.Form.ingredientes_totales.Text = contexto.Form.historial.Peek().Count() + "/" + contexto.Form.total_ingredientes;
                contexto.Form.ingredientes_seleccionados = contexto.Form.historial.Peek().Count();
                contexto.Form.Limpiar_lista();
                contexto.Form.lista_ingredientes = contexto.Form.historial.Pop();
                contexto.Form.RestaurarLista(contexto.Form.lista_ingredientes);

                //Forma
                contexto.Form.Desactivar_proteinas();
                contexto.Form.Activar_quesos();
                contexto.Form.Estado.Text = "Elige los quesos...";
                contexto.Form.Confirmar.Text = "Confirmar";
                contexto.EstadoActual = new EstadoQuesos();
            }
            public void Cancelar(ContextoPizza contexto)
            {
                contexto.Form.ReiniciarTodo();
            }
            public void SelecionarIngredientes(ContextoPizza contexto, string nombreIngrediente)
            {
                contexto.Form.ProcesarSeleccion(nombreIngrediente);
            }
        }

        public class EstadoVegetales : IEstadoPizza
        {
            public void Confirmar(ContextoPizza contexto)
            {
                contexto.Form.Desactivar_vegetales();
                contexto.Form.Estado.Text = "Esperando pago...";
                contexto.Form.Confirmar.Text = "Pagar";
                contexto.EstadoActual = new EstadoPago();

            }
            public void Regreso(ContextoPizza contexto)
            {
                contexto.Form.Inventario["Albahaca"].Temporal = 0;
                contexto.Form.Inventario["Cebolla"].Temporal = 0;
                contexto.Form.Inventario["Oregano"].Temporal = 0;
                contexto.Form.Inventario["Pimiento"].Temporal = 0;

                //Regreso costo
                contexto.Form.precio_total = contexto.Form.historialPrecio.Pop();
                int restaurarPrecio = contexto.Form.precio_total;
                contexto.Form.Label_precio.Text = restaurarPrecio.ToString();

                //Regresar lista de ingredientes
                contexto.Form.altura_label = 110;
                contexto.Form.ingredientes_totales.Text = +contexto.Form.historial.Peek().Count() + "/" + contexto.Form.total_ingredientes;
                contexto.Form.ingredientes_seleccionados = contexto.Form.historial.Peek().Count();
                contexto.Form.Limpiar_lista();
                contexto.Form.lista_ingredientes = contexto.Form.historial.Pop();
                contexto.Form.RestaurarLista(contexto.Form.lista_ingredientes);

                contexto.Form.Desactivar_vegetales();
                contexto.Form.Activar_proteinas();
                contexto.Form.Estado.Text = "Elige las proteínas...";
                contexto.Form.Confirmar.Text = "Confirmar";
                contexto.EstadoActual = new EstadoProteinas();
            }
            public void Cancelar(ContextoPizza contexto)
            {
                contexto.Form.ReiniciarTodo();
            }
            public void SelecionarIngredientes(ContextoPizza contexto, string nombreIngrediente)
            {
                contexto.Form.ProcesarSeleccion(nombreIngrediente);
            }

        }

        public class EstadoPago : IEstadoPizza
        {
            public void Confirmar(ContextoPizza contexto)
            {
                


            }

            public void Regreso(ContextoPizza contexto)
            {
                contexto.Form.Inventario["Albahaca"].Temporal = 0;
                contexto.Form.Inventario["Cebolla"].Temporal = 0;
                contexto.Form.Inventario["Oregano"].Temporal = 0;
                contexto.Form.Inventario["Pimiento"].Temporal = 0;

                //Regreso costo
                contexto.Form.precio_total = contexto.Form.historialPrecio.Peek();
                int restaurarPrecio = contexto.Form.precio_total;
                contexto.Form.Label_precio.Text = restaurarPrecio.ToString();

                //Regresar lista de ingredientes
                contexto.Form.altura_label = 110;
                contexto.Form.ingredientes_totales.Text = +contexto.Form.historial.Peek().Count() + "/" + contexto.Form.total_ingredientes;
                contexto.Form.ingredientes_seleccionados = contexto.Form.historial.Peek().Count();
                contexto.Form.Limpiar_lista();
                contexto.Form.lista_ingredientes = contexto.Form.historial.Peek();
                contexto.Form.RestaurarLista(contexto.Form.lista_ingredientes);

                contexto.Form.Desactivar_proteinas();
                contexto.Form.Activar_vegetales();
                contexto.Form.Estado.Text = "Elige los vegetales";
                contexto.Form.Confirmar.Text = "Confirmar";
                contexto.EstadoActual = new EstadoVegetales();
            }

            public void Cancelar(ContextoPizza contexto)
            {
                contexto.Form.ReiniciarTodo();
            }

            public void SelecionarIngredientes(ContextoPizza contexto, string nombreIngrediente)
            {

            }
        }
    }
}
