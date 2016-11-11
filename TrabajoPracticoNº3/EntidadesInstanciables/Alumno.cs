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
    public sealed class Alumno:PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
        { }

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

        protected override string MostrarDatos()
        {
            StringBuilder nuevosb = new StringBuilder();
            nuevosb.AppendLine(this.ToString()); ;
            nuevosb.AppendLine(this.ParticiparEnClase());
            nuevosb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            
            return nuevosb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "CLASE QUE TOMA: " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return base.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            return false;
        }
    }
}
