using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas_;
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

        public static bool operator !=(Gimnasio gim, Alumno a)
        {
            return !(gim == a);
        }

        public static Instructor operator ==(Gimnasio gim, EClases clase)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item == clase)
                    return item;

            }
            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio gim, EClases clase)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item != clase)
                    return item;

            }
            return null;
        }

        public static bool operator ==(Gimnasio gim, Instructor i)
        {
            if (gim._instructores.Contains(i))
                return true;
            return false;
        }

        public static bool operator !=(Gimnasio gim, Instructor i)
        {
            return !(gim == i);
        }

        public static Gimnasio operator +(Gimnasio gim, Alumno alu)
        {
            if (gim == alu)
                throw new AlumnoRepetidoException();

            gim._alumnos.Add(alu);
            return gim;
            
        }

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

        public static Gimnasio operator +(Gimnasio gim, Instructor i)
        {
            if (gim != i)
                gim._instructores.Add(i);
            return gim;
        }

        #endregion
    }
}
