using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPcalculadora
{
    public class Calculadora
    {
        #region Metodos

        /// <summary>
        /// Realiza la operacion con los parametros pasados, luego de verificar si el operador es valido.
        /// </summary>
        /// <param name="numero1">Primer valor a operar.</param>
        /// <param name="numero2">Segundo valor a operar.</param>
        /// <param name="operador">Operador(+, -, *, /)</param>
        /// <returns>Retorna el resultado o 0 en caso de que no se haya podido efectuar la operacion. </returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            operador = validarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = numero1 + numero2;

                    break;

                case "-":
                    resultado = numero1 - numero2;

                    break;

                case "*":
                    resultado = numero1 * numero2;

                    break;

                case "/":

                    if (numero2 == 0)
                    {
                        resultado = 0;
                    }
                    resultado = numero1 / numero2;

                    break;

            }
            return resultado;
        }

        /// <summary>
        /// Valida que el string pasado por parametro sea igual o no a los operadores +, -, * y /.
        /// </summary>
        /// <param name="operador">Valor a ser validado.</param>
        /// <returns>Retorna el string validado o el operador + en caso de que no haya coincidencia.</returns>
        public static string validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }

            return operador;
        }
        #endregion
    }
}
