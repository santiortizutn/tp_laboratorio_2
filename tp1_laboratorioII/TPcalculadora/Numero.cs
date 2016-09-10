using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPcalculadora
{
    public class Numero
    {
        private double numero;

        #region Constructores

        /// <summary>
        /// Constructor por defecto el inicializará el atributo numero en cero en 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que inicializa el atributo numero en el valor pasado por parametro.
        /// </summary>
        /// <param name="numero">Valor que se le asigna a numero.</param>
        public Numero(double numero)
        {

            this.numero = numero;
            
        }

        /// <summary>
        /// Constructor que inicializa el atributo numero en el valor pasado por parametro si es un numero,
        /// de lo contrario se le asigna 0.
        /// </summary>
        /// <param name="numero">Valor que se le asignara a numero.</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Asigna a numero el valor pasado por parametro, luego de validarlo.
        /// </summary>
        /// <param name="numero">Valor que se le asigna numero.</param>
        private void setNumero(string numero)
        {
            this.numero = this.validarNumero(numero);
        }

        /// <summary>
        /// Valida que el valor pasado por parametro sea realmente un numero, de lo contrario retorna 0.
        /// </summary>
        /// <param name="numeroString">Valor a ser validado.</param>
        /// <returns>Retorna el valor convertido a double o 0.</returns>
        private double validarNumero(string numeroString)
        {
            double aux;

            if(double.TryParse(numeroString, out aux))
                return aux;
                return 0;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Sobrecarga del operador "+".
        /// Suma dos variables del tipo Numero.
        /// </summary>
        /// <param name="numero1">Variable de tipo Numero.</param>
        /// <param name="numero2">Variable de tipo Numero.</param>
        /// <returns>Retorna un double como resultado de la operacion.</returns>
        public static double operator + (Numero numero1, Numero numero2)
        {
            double aux;
            aux = numero1.numero + numero2.numero;
            return aux;
        }

        /// <summary>
        /// Sobrecarga del operador "*".
        /// Multiplica dos variables del tipo Numero.
        /// </summary>
        /// <param name="numero1">Variable de tipo Numero.</param>
        /// <param name="numero2">Variable de tipo Numero.</param>
        /// <returns>Retorna un double como resultado de la operacion.</returns>
        public static double operator * (Numero numero1, Numero numero2)
        {
            double aux;
            aux = numero1.numero * numero2.numero;
            return aux;
        }


        /// <summary>
        /// Sobrecarga del operador "/".
        /// Divide dos variables del tipo Numero.
        /// </summary>
        /// <param name="numero1">Variable de tipo Numero.</param>
        /// <param name="numero2">Variable de tipo Numero.</param>
        /// <returns>Retorna un double como resultado de la operacion.</returns>
        public static double operator / (Numero numero1, Numero numero2)
        {
            double aux;
            aux = numero1.numero / numero2.numero;
            return aux;
        }


        /// <summary>
        /// Sobrecarga del operador "-".
        /// Resta dos variables del tipo Numero.
        /// </summary>
        /// <param name="numero1">Variable de tipo Numero.</param>
        /// <param name="numero2">Variable de tipo Numero.</param>
        /// <returns>Retorna un double como resultado de la operacion.</returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            double aux;
            aux = numero1.numero - numero2.numero;
            return aux;
        }


        /// <summary>
        /// Sobrecarga del operador "==".
        /// Compara una variable de tipo Numero con una de tipo double.
        /// </summary>
        /// <param name="numero1">Variable de tipo Numero.</param>
        /// <param name="numero2">Variable de tipo double.</param>
        /// <returns>Retorna true o false, si se cumple o no la igualdad.</returns>
        public static bool operator == (Numero numero1, double numero2)
        {
            if (numero1.numero == numero2)
                return true;
                return false;

        }


        /// <summary>
        /// Sobrecarga del operador "!=".
        /// Compara una variable de tipo Numero con una de tipo double. 
        /// </summary>
        /// <param name="numero1">Variable de tipo Numero.</param>
        /// <param name="numero2">Variable de tipo double.</param>
        /// <returns>Retorna true o false, si se cumple o no la diferencia.</returns>
        public static bool operator != (Numero numero1, double numero2)
        {
            if (numero1.numero != numero2)
                return true;
            return false;

        }

        #endregion
    }
}
