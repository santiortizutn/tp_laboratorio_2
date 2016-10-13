using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        #region "Constructores"

        /// <summary>
        /// Contructor de 3 parametros que llama al base e inicializa los atributos del vehiculo.
        /// </summary>
        /// <param name="marca">Marca del auto.</param>
        /// <param name="patente">Patente del auto.</param>
        /// <param name="color">Color del auto.</param>
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        { }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Muestra todos los atributos del vehiculo y la cantidad de ruedas que posee.
        /// </summary>
        /// <returns>Retorna un string con los datos a mostrar.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS: " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
