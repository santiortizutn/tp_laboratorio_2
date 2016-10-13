using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }

        public EMarca _marca;
        public string _patente;
        public ConsoleColor _color;

        #region "Constructores"

        /// <summary>
        /// Constructor de tres parametros que inicializa los atributos del vehiculo. 
        /// </summary>
        /// <param name="marca">Marca del vehiculo.</param>
        /// <param name="patente">Patente del vehiculo.</param>
        /// <param name="color">Color del vehiculo.</param>
        public Vehiculo(EMarca marca, string patente, ConsoleColor color)
        {
            this._marca = marca;
            this._patente = patente;
            this._color = color;

        }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadRuedas { get; }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Muestro todos los atributos del vehiculo.
        /// </summary>
        /// <returns>Retorna un string con los datos a mostrar.</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente.
        /// </summary>
        /// <param name="v1">Vehiculo uno.</param>
        /// <param name="v2">Vehiculo dos.</param>
        /// <returns>Retorna true si los vehiculos son iguales.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1._patente == v2._patente);
        }

        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta.
        /// </summary>
        /// <param name="v1">Vehiculo uno.</param>
        /// <param name="v2">Vehiculo dos.</param>
        /// <returns>Retorna true si los vehiculos son distintos.</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion
    }
}
