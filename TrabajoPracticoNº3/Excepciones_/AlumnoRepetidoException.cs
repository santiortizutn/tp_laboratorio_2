using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones_
{
    public class AlumnoRepetidoException:Exception
    {
        public AlumnoRepetidoException()
            : base("El alumno ya existe.")
        {

        }
    }
}
