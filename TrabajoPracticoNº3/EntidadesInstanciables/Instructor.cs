using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor:PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        public Instructor()
        { }

        static Instructor()
        {
            _random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClase();
        }

        public void _randomClase()
        {
            int rng1 = _random.Next(1, 3);
            int rng2 = _random.Next(1, 3);

            this._clasesDelDia.Enqueue((Gimnasio.EClases)rng1);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)rng2);

        }


        protected override string MostrarDatos()
        {
            StringBuilder nuevosb = new StringBuilder();
            nuevosb.AppendLine(base.MostrarDatos());
            nuevosb.AppendLine(this.ParticiparEnClase());
            return nuevosb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder nuevosb = new StringBuilder();
            nuevosb.AppendLine("Clases del dia :");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                nuevosb.AppendLine(item.ToString());
            }
            return nuevosb.ToString();
        }

        public override string ToString()
        {

            return this.MostrarDatos();
        }

        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (var item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

    }
}
