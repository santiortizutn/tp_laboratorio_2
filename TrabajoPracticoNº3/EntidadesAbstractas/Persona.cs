using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDNi
        {
            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNi = dni;
        }

        #endregion

        #region Metodos

        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato < 1 || dato > 89999999)
                    throw new DniInvalidoException();
            }

            return dato;
        }

        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        public string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsDigit(dato[i]))
                    return "ERROR dato no valido.";
            }

            return dato;
        }

        public override string ToString()
        {
            StringBuilder nuevosb;
            nuevosb = new StringBuilder();

            nuevosb.AppendLine("---DATOS DE LA PERSONA---");
            nuevosb.AppendLine("Nombre y Apellido: " + this.Nombre + " " + this.Apellido);
            nuevosb.AppendLine("DNI: " + this.DNI);
            nuevosb.AppendLine("Nacionalidad: " + this.Nacionalidad.ToString());

            return nuevosb.ToString();
        }

        #endregion

    }
}
