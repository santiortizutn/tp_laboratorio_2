using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones_
{
    public class DniInvalidoException:Exception
    {
        private string _mensajeBase;

        public DniInvalidoException()
            : this("La nacionalidad no coincide con el dni.")
        { }

        public DniInvalidoException(Exception e):base("La nacionalidad no coincide con el dni.")
        {
            throw new NacionalidadInvalidaException();
        }

        public DniInvalidoException(string message):base(message)
        { }

        public DniInvalidoException(string message, Exception e)
            : this(e)
        { }
    }
}
