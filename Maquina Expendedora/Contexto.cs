using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Expendedora
{
    public interface IEstadoPizza
    {
        void Confirmar(ContextoPizza contexto);
        void Regreso(ContextoPizza contexto);
        void Cancelar(ContextoPizza contexto);
        void SelecionarIngredientes(ContextoPizza contexto,string nombreIngrediente);

    }

    public class ContextoPizza
    {
        public IEstadoPizza EstadoActual;
        public Inicio Form{ get; }

        public ContextoPizza(Inicio form)
        {
            Form = form;
            EstadoActual = new Inicio.EstadoQuesos();
        }

        public void Seleccionar(string nombre) => EstadoActual.SelecionarIngredientes(this, nombre);
        public void Confirmar() => EstadoActual.Confirmar(this);
        public void Regreso() => EstadoActual.Regreso(this);
        public void Cancelar() => EstadoActual.Cancelar(this);


    }

}
