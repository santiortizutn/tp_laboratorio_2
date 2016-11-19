using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones_
{
    public class ArchivosException:Exception
    {
        public ArchivosException(Exception innerException)
            : base("Error al guardar el archivo.", innerException)
        { }

       
    }
}
