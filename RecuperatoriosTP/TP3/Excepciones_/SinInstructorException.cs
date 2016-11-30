using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones_
{
    public class SinInstructorException : Exception
    {
        public SinInstructorException():base("No hay un instructor para la clase.")
        {

        }
    }
}
