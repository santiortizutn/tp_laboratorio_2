using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones_;

namespace EntidadesInstanciables_
{
    [Serializable]
    public sealed class Instructor:PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public Instructor()
        { }

        /// <summary>
        /// constructor estatico.
        /// </summary>
        static Instructor()
        {
            _random = new Random();
        }

        /// <summary>
        /// constructor que inicializa los atributos del instructor llamando al base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClase();
        }

        /// <summary>
        /// genera random para establecer la clase dle dia.
        /// </summary>
        public void _randomClase()
        {
            int rng1 = _random.Next(1, 3);
            int rng2 = _random.Next(1, 3);

            this._clasesDelDia.Enqueue((Gimnasio.EClases)rng1);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)rng2);

        }

        /// <summary>
        /// stringbuilder que concatena todos los datos a mosgtrar.
        /// </summary>
        /// <returns>retorna un string con los datos a mostar.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder nuevosb = new StringBuilder();
            nuevosb.AppendLine(base.MostrarDatos());
            nuevosb.AppendLine(this.ParticiparEnClase());
            return nuevosb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// sobreescripcion del metodo tostring,
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return this.MostrarDatos();
        }

        /// <summary>
        /// compara las clases del dia del instructor con la clase pasada por parametro.
        /// </summary>
        /// <param name="i">instructor</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna true si hay igualdad, false si no.</returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (var item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// compara las clases del dia del instructor con la clase pasada por parametro.
        /// </summary>
        /// <param name="i">instructor</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna true si NO hay igualdad, false si si.</returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

    }
}
