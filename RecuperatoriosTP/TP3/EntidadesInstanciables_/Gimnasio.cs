using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones_;
using System.Xml.Serialization;
using Archivos;

namespace EntidadesInstanciables_
{

    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(PersonaGimnasio))]
    [XmlInclude(typeof(Persona))]
    [Serializable]
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }

        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
        }


        public enum EClases
        {
            CrossFit, Natacion, Pilates, Yoga
        }

        #region Constructores

        /// <summary>
        /// Constructor por defecrto que instancia las listas.
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        #endregion




        #region Metodos

        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> archivoXml = new Xml<Gimnasio>();
            archivoXml.guardar("gimnasio.xml", gim);

            return true;
        }

        public static Gimnasio Leer()
        {
            Gimnasio gim;

            Xml<Gimnasio> archivoXml = new Xml<Gimnasio>();

            archivoXml.leer("gimnasio.xml", out gim);

            return gim;
        }

        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Alumno item in gim._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            foreach (Instructor item in gim._instructores)
            {
                sb.AppendLine(item.ToString());
            }
            foreach (Jornada item in gim._jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Recorre la lista de alumnos del gimnasio y comparar con el alumno pasado por paramnetro.
        /// </summary>
        /// <param name="gim">Gimnasio</param>
        /// <param name="a">alumno </param>
        /// <returns> Retorna true si hay igualdad, false si no.</returns>
        public static bool operator ==(Gimnasio gim, Alumno a)
        {
            for (int i = 0; i < gim._alumnos.Count; i++)
            {
                if (gim._alumnos[i] == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Recorre la lista de alumnos del gimnasio y comparar con el alumno pasado por paramnetro.
        /// </summary>
        /// <param name="gim">Gimnasio</param>
        /// <param name="a">Alumno</param>
        /// <returns> Retorna true si NO hay igualdad, false si la hay. </returns>
        public static bool operator !=(Gimnasio gim, Alumno a)
        {
            return !(gim == a);
        }

        /// <summary>
        /// Recorre la lista de instructores del gimnasio y compara con la clase pasada por parametro.
        /// </summary>
        /// <param name="gim">Gimnasio.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Retorna el instructor si pertence a la clase pasada.</returns>
        public static Instructor operator ==(Gimnasio gim, EClases clase)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item == clase)
                    return item;

            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// Recorre la lista de instructores del gimnasio y compara con la clase pasada por parametro.
        /// </summary>
        /// <param name="gim">Gimnasio.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Retorna el instructor si NO pertence a la clase pasada.</returns>
        public static Instructor operator !=(Gimnasio gim, EClases clase)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item != clase)
                    return item;

            }
            return null;
        }
        /// <summary>
        /// Recorre la lista de instructores del gimnasio y compara con el instructor pasado por parametro.
        /// </summary>
        /// <param name="gim">Gimasio.</param>
        /// <param name="i">Instructor.</param>
        /// <returns>Retorna true si el instructor existe, false si no.</returns>
        public static bool operator ==(Gimnasio gim, Instructor i)
        {
            if (gim._instructores.Contains(i))
                return true;
            return false;
        }

        /// <summary>
        /// Recorre la lista de instructores del gimnasio y compara con el instructor pasado por parametro.
        /// </summary>
        /// <param name="gim">Gimasio.</param>
        /// <param name="i">Instructor.</param>
        /// <returns>Retorna true si el instructor NO existe, false si si.</returns>
        public static bool operator !=(Gimnasio gim, Instructor i)
        {
            return !(gim == i);
        }


        /// <summary>
        /// Agrega el alumno al gimnasio, si este no pertenece.
        /// </summary>
        /// <param name="gim">gimnasio.</param>
        /// <param name="alu">alumno.</param>
        /// <returns>reyorna el gimnasio.</returns>
        public static Gimnasio operator +(Gimnasio gim, Alumno alu)
        {
            if (gim == alu)
                throw new AlumnoRepetidoException();

            gim._alumnos.Add(alu);
            return gim;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {

            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g._alumnos)
            {
                if (alumno == clase)
                    jornada += alumno;
            }

            g._jornada.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega el instructor al gimnasio si este no pertenece aun.
        /// </summary>
        /// <param name="gim">gimnasio</param>
        /// <param name="i">instructor</param>
        /// <returns>retorna el gimnasio</returns>
        public static Gimnasio operator +(Gimnasio gim, Instructor i)
        {
            if (gim != i)
                gim._instructores.Add(i);
            return gim;
        }

        #endregion
    }
}
