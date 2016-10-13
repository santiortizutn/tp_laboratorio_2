using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Clase_12_Library
{
    public class Moto:Vehiculo
    {
        #region "Constructores"

        /// <summary>
        /// Contructor de 3 parametros que llama al base e inicializa los atributos del vehiculo.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="patente">Patente de la moto.</param>
        /// <param name="color">Color de la moto.</param>
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        { }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Muestra todos los atributos del vehiculo y la cantidad de ruedas que posee.
        /// </summary>
        /// <returns>Retorna un string con los datos a mostrar.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS: " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
