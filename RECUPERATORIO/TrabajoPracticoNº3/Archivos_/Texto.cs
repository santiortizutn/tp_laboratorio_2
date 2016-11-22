using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones_;


namespace Archivos
{
    public class Texto:IArchivo<string>
    {

        public bool guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(archivo, false);

                escritor.Write(datos);

                escritor.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool leer(string archivo, out string datos)
        {
            try
            {
                StreamReader lector = new StreamReader(archivo);

                datos = lector.ReadToEnd();

                lector.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(string);
                throw new ArchivosException(e);
            }
        }
    }
}
