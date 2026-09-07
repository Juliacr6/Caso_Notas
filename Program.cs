using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO1
{
    internal class Program
    {
        static public void Titulo()
        {
            //FUNCION SIN RETORNO
            Console.WriteLine("**********************");
            Console.WriteLine("\t\tUPN");
            Console.WriteLine("***********************");
        }
        //FUNCION CON RETORNO
        static public double Validar_nota(string mensaje)
        {
            double nota;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (double.TryParse(entrada, out nota) && nota >= 0 && nota <= 20)
                    return nota;
                Console.WriteLine("Error, ingrese un valor entre [0,20]");

            }
        }
        static public double Calcula_EF(double Proyecto_F, double Lab)
        {
            double prom_EF;
            prom_EF = Proyecto_F * 0.6 + Lab * 0.4;
            return prom_EF;
        }
        static public double Bono_Cisco(double nota_EF, string Tiene_Cisco)
        {
            if (Tiene_Cisco == "s")
            {
                nota_EF += 1;
                if (nota_EF> 20)
                    nota_EF= 20;
            }
            return nota_EF;
        }
    
        static public double promedio_curso(double t1, double t2, double t3, double EP, double EF)
        {
            double promedio;
            promedio = t1 * 0.1 + t2 * 0.1 + t3 * 0.1 + EP * 0.2 + EF * 0.5;
            return promedio;
        }
         static public string Condicion(double promedio)
        {
            string estado;
            if (promedio >= 12)
                estado = "Aprobado";
            else
                estado = "Desaprobado";
            return estado;

        }
        static void Main(string[] args)
        {
            string Curso_Cisco;
            Titulo();
            Console.WriteLine("Ingresar nombre de estudiante:");
            string nombre = Console.ReadLine();
            Console.WriteLine("*******INGRESO DE NOTAS************");
            double t1 = Validar_nota("Ingresar nota T1(10%):");
            double t2= Validar_nota("Ingresar nota T2(10%):");
            double t3 = Validar_nota("Ingresar nota T3(10%):");
            double EP = Validar_nota("Ingresar nota del examen Parcial:");
            Console.WriteLine("Ingresar notas para el examen final:");
            double Proy_Final = Validar_nota("Ingresar nota del proyecto final:");
            double N_Lab = Validar_nota("Ingresar nota de laboratorio:");
            //validando
            while (true)
            {
                Console.WriteLine("Realizo el curso de cisco[s/n]:");
                Curso_Cisco = Console.ReadLine().ToLower();
                if (Curso_Cisco == "s" || Curso_Cisco == "n")
                    break;
                Console.WriteLine("Error, ingrese ´s¨ para sí o´n´ para no");
            }
            double nota_EF = Calcula_EF(Proy_Final, N_Lab);
            double nota_EF_Cisco = Bono_Cisco(nota_EF, Curso_Cisco);
            double promedio = promedio_curso(t1, t2, t3, EP, nota_EF_Cisco);
            string condicion_Est = Condicion(promedio);

            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine("REPORTE FINAL"+nombre);


            Console.WriteLine("-------------------------------------------------");


            if (Curso_Cisco == "s")


                Console.WriteLine("FELICITACIONES POR LLEVAR EL CURSO DE CISCO");
            Console.WriteLine("Nota Examen Final: "+nota_EF_Cisco);
            Console.WriteLine("El Promedio de curso:"+promedio);
            Console.WriteLine("Condicion: " + condicion_Est);
            Console.WriteLine("-------------------------------------------------");
            Console.ReadKey();








        }
    }
}
