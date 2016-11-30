using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones_;
using EntidadesInstanciables_;
using EntidadesAbstractas;

namespace UnitTestTP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstructorSinInstanciar()
        {
            Instructor instructorDePrueba;
            instructorDePrueba = new Instructor(1998, "Santiago", "Ortiz", "40880945", Persona.ENacionalidad.Argentino);

            Assert.AreNotEqual(null, instructorDePrueba.Nombre);
            Assert.AreNotEqual(null, instructorDePrueba.Apellido);
            Assert.AreNotEqual(null, instructorDePrueba.DNI);
            Assert.AreNotEqual(null, instructorDePrueba.Nacionalidad);

            Assert.IsNotNull(instructorDePrueba);
        }

        [TestMethod]
        public void DocumentoValidado()
        {
            Random random;
            random = new Random();

            int dniNuevo = random.Next(1, 90000000);

            Alumno alumnoPrueba;
            alumnoPrueba = new Alumno(1998, "Santiago", "Ortiz", dniNuevo.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);

            Assert.AreEqual(alumnoPrueba.DNI, dniNuevo);
        }

        [TestMethod]
        public void ValidarAlumnoRepetido()
        {
            try
            {
                Alumno alumnoUno;
                alumnoUno = new Alumno(1, "Santiago", "Ortiz", "40880945", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);

                Alumno alumnoDos;
                alumnoDos = new Alumno(5, "Santiago", "Ortiz", "40880945", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);

                Gimnasio gimnasioPrueba = new Gimnasio();

                gimnasioPrueba += alumnoUno;
                gimnasioPrueba += alumnoDos;

                Assert.Fail("Alumno repetido.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void ValidarSinInstructor()
        {
            try
            {
                Gimnasio gimnasioPrueba;
                gimnasioPrueba = new Gimnasio();

                gimnasioPrueba += Gimnasio.EClases.Natacion;

                Assert.Fail("No hay instructor.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(SinInstructorException));
            }
        }
    }
}
