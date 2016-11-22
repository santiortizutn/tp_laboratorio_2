using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas_;
using Excepciones_;

namespace EntidadesInstanciables_
{
    [Serializable]
    public sealed class Alumno:PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        /// <summary>
        /// constructor por defecto paea serializar.
        /// </summary>
        public Alumno()
        { }

        /// <summary>
        /// constructor que instancia los atributos del alumno llamando al base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        public enum EEstadoCuenta
        {
            Deudor, MesPrueba, AlDia
        }

        /// <summary>
        /// muestra los datos del alumno.
        /// </summary>
        /// <returns>retorna un string con los datos a mostrar.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder nuevosb = new StringBuilder();
            nuevosb.AppendLine(this.ToString()); ;
            nuevosb.AppendLine(this.ParticiparEnClase());
            nuevosb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            
            return nuevosb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>retorna la clase que toma el alumno en string.</returns>
        protected override string ParticiparEnClase()
        {
            return "CLASE QUE TOMA: " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// spbrescripcion del metodo to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.MostrarDatos();
        }

        /// <summary>
        /// compara un alumno y una clase.
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna true si el alumno toma la clase indicada.</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }

        /// <summary>
        /// compara un alumno y una clase.
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna true si el alumno NO toma la clase indicada.</returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            return false;
        }
    }
}
