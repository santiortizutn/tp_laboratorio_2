using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones_;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            XmlSerializer serializador;
            XmlTextWriter escritor;

            try
            {
                escritor = new XmlTextWriter(archivo, Encoding.UTF8);
                serializador = new XmlSerializer(typeof(T));

                serializador.Serialize(escritor, datos);

                escritor.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool leer(string archivo, out T datos)
        {
            XmlSerializer serializador;
            XmlTextReader lector;

            try
            {
                lector = new XmlTextReader(archivo);
                serializador = new XmlSerializer(typeof(T));

                datos = (T)serializador.Deserialize(lector);

                lector.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
    }
}
