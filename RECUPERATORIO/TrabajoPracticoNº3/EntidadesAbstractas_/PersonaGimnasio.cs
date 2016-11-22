using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas_
{
    [Serializable]
    public abstract class PersonaGimnasio:Persona
    {
        private int _identificador;

        #region Constructor

        public PersonaGimnasio()
        { }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        #endregion

        #region Metodos

        protected virtual string MostrarDatos()
        {
            StringBuilder nuevosb = new StringBuilder();
            nuevosb.AppendLine(base.ToString());
            nuevosb.AppendLine("ID: " + this._identificador);
            return nuevosb.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        public static bool operator ==(PersonaGimnasio pg1,PersonaGimnasio pg2)
        {
            if (pg1.Equals(pg2) && pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador)
                return true;
            return false;
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    
    }
}
