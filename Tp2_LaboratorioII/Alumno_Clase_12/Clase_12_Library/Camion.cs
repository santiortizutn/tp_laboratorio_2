using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Camion : Vehiculo
    {
        #region "Constructores"

        /// <summary>
        /// Contructor de 3 parametros que llama al base e inicializa los atributos del vehiculo.
        /// </summary>
        /// <param name="marca">Marca del camion.</param>
        /// <param name="patente">Patente del camion.</param>
        /// <param name="color">Color del camion.</param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        { }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 8;
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

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
