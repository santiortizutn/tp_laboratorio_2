using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones_;
using Archivos;

namespace EntidadesInstanciables_
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;


        #region Constructores

        /// <summary>
        /// constructor por defecto que instancia la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// instancia los atributos de la jornada, llamando al constructor por defecto.
        /// </summary>
        /// <param name="clase">clase</param>
        /// <param name="instructor">instructor</param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// guarda la jornada den un archivo de texto.
        /// </summary>
        /// <param name="jornada">jornada</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {

            Texto txt = new Texto();

            txt.guardar("jornada.txt", jornada.ToString());

            return true;
        }

        public static string Leer()
        {
            string aux;

            Texto txt = new Texto();

            txt.leer("jornada.txt", out aux);

            return aux;
        }

        public override string ToString()
        {
            StringBuilder nuevosb = new StringBuilder();

            nuevosb.AppendLine("JORNADA");
            nuevosb.Append("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            nuevosb.AppendLine("ALUMNOs:");

            foreach (Alumno item in this._alumnos)
            {
                nuevosb.AppendLine(item.ToString());
            }
            nuevosb.AppendLine("<-------------------------------------------------->");

            return nuevosb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// compara el alumno con la lista en jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna true si el alumno esta em la lista</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (j._alumnos.Contains(a))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// compara el alumno con la lista en jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna true si el alumno NO esta em la lista</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// agrega un alumno a la lista de la jornada si este no existe aun.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna la jornada.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    throw new AlumnoRepetidoException();
                }
   
            }
            
            j._alumnos.Add(a);
            return j;
        }

        #endregion
    }
}
