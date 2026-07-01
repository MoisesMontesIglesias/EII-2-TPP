using System;
using System.Collections;

// Colecciones genéricas.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// LINQ
using System.Linq;

using Modelo;

namespace Linq
{
    class Program
    {
        
        private static Model modelo = new Model();

        static void Main()
        {
            //SintaxisLinq();
            //EjemploJoin();
            //EjemploGroupBy();

            //Consulta1();
            //Consulta2();
            //Consulta3();
            //Consulta4();
            //Consulta5();
            //Consulta6();
            Consulta7();

            //ConsultaEj1();
            //ConsultaEj2();
            //ConsultaEj3();
            //ConsultaEj4();
            //ConsultaEj5();

        }

        private static void SintaxisLinq()
        {
            //Obtener las llamadas de más de 15 segundos de duración


            //Sintaxis de consulta
            var c1 =
                from pc in modelo.PhoneCalls
                where pc.Seconds > 15
                select pc;
            Show(c1);

            Console.WriteLine();
            
            //Equivalente con sintaxis de métodos.
            //¡OJO! SE DEFINE LA CONSULTA. NO SE EJECUTA. ¿POR QUÉ?
            var c1_m = modelo.PhoneCalls.Where(ll => ll.Seconds > 15);
            //¿Qué ocurre si la consulta anterior la finalizamos con un .ToList()?

            Show(c1_m);
            Limpiar();
        }

        private static void EjemploJoin()
        {
            //Mostrar las llamadas de cada empleado con el formato: "<Nombre>;<Duración de la llamada>"

            //El método Join, une dos colecciones a partir de un atributo común:
            //Lo utilizamos sobre un IEnumerable (modelo.PhoneCalls)
            var result = modelo.PhoneCalls.Join(

                modelo.Employees, //para unir sus elementos con los de un segundo IEnumerable (modelo.Employees)

                llamada => llamada.SourceNumber, //Atributo clave del primer IEnumerable (PhoneCalls)

                emp => emp.TelephoneNumber, //Atributo clave del 2º IEnumerable (Employees)

                (llamada, emp) => $"{emp.Name};{llamada.Seconds}" // Función que recibe y trata cada par de llamada-empleado de claves coincidentes.
            );//Devuelve Strings por los "" --> si no pasasemos las comillas, serian tuplas, el problema es que ocupa mucha memoria y almacena la clase entera emp y llamada
            // no almacena solo el valor que nos interesa

            Show(result);
            Limpiar();
        }


        private static void EjemploGroupBy() // Se agrupa por diccionarios. Ej: Agrupar gente por edad --> Clave: 38 --> Valores: Lista de personas de 38 años
        {
            //GroupBy: Vamos a mostrar la duración de las llamadas agrupadas por número de teléfono (origen)

            var llamadas = modelo.PhoneCalls;
            var resultado = llamadas.GroupBy(ll => ll.SourceNumber);

            //resultado ahora mismo es un  IEnumerable<IGrouping>
            Console.WriteLine("Imprimiendo directamente:");
            Show(resultado);


            Console.WriteLine("\nImprimiendo mediante recorrido:");
            foreach (var grupo in resultado)
            {
                //Cada IGrouping tiene una Key:
                Console.Write("\nClave [" + grupo.Key + "] : ");
                //Y tenemos un listado. En este caso, de llamadas:
                foreach (var llamada in grupo)
                {
                    Console.Write(llamada.Seconds + " ");
                }
            }

            //Sin embargo GroupBy nos presenta otras opciones, vamos a combinar éstas
            //con los objetos anónimos:

            var opcion2 = llamadas.GroupBy(
                ll => ll.SourceNumber, //Agrupamos por número de origen

                //el primer parámetro es el número de origen (clave)
                //el segundo parámetro es un IEnumerable<PhoneCall> asociados a esa clave.
                (numero, llamadasEncontradas) =>
                new //Vamos emplear una función que cree objetos anónimos con la info que necesitamos
                {
                    Key = numero,
                    //Duraciones sigue siendo un IEnumerable.
                    Duraciones = llamadasEncontradas.Select(ll => ll.Seconds) //Aplicamos un reduce que en C# es un Aggregate. El codigo seria:
                    //Duraciones = llamadasEncontradas.Select(ll => ll.Seconds).Aggregate("", (acumulado, actual) => $"{acumulado} {actual}")
                }
                );

            Console.WriteLine("\n\nImprimiendo directamente:");
            Show(opcion2);
            Console.WriteLine("\nImprimiendo con el Aggregate:");
            var conAggregate = opcion2.Select( a => $"{a.Key} : { a.Duraciones.Aggregate("", (acumulado, actual) => $"{acumulado} {actual}") }" );
            //¿Podríamos hacer el Aggregate directamente en el objeto anónimo?
            Show(conAggregate);
            Limpiar();
        }

        private static void Consulta1()
        {
            // Modificar la consulta para mostrar los empleados cuyo nombre empieza por F.
            //var resultado = modelo.Employees;

            //var c2 =
            //    from em in modelo.Employees
            //    where em.Name.Equals("F")
            //    select em;
            //Show(c2);

            var c2 = modelo.Employees.Where(ll => ll.Name.StartsWith("F"));
            Show(c2);

            //Show(resultado);
            //El resultado esperado es: Felipe
        }

        private static void Consulta2()
        {

            //Mostrar Nombre y fecha de nacimiento de los empleados de Cantabria con el formato:
            // Nombre=<Nombre>,Fecha=<Fecha>

            var c2 = modelo.Employees.Where(e => e.Province.Equals("Cantabria")).Select(e => $"{e.Name};{e.DateOfBirth}");

            Show(c2);

            /*El resultado esperado es:
              Alvaro 19/10/1945 0:00:00
              Dario 16/12/1973 0:00:0066
            */
        }



        // A partir de aquí, necesitaréis métodos presentes en: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-5.0

        private static void Consulta3()
        {

            //Mostrar los nombres de los departamentos que tengan más de un empleado mayor de edad.
            var c2 = modelo.Departments.Where(d => d.Employees.Count(e => e.Age >= 18) > 1).Select(d => $"{d.Name}");
            Show(c2);
            /*El resultado esperado es:
                Computer Science
                Medicine
            */


            //Posteriormente, cree una nueva versión de la consulta para que:
            //Muestre los nombres de los departamentos que tengan más de un empleado mayor de edad
            //y
            //que el despacho (Office.Number) COMIENCE por "2.1"
            var c2_2 = modelo.Departments.Where(d => d.Employees.Count(e => e.Age > 18 && e.Office.Number.StartsWith("2.1")) > 1 ).Select(d => $"{d.Name}");
            Show(c2_2);
            //El resultado esperado es: Medicine
        }

        private static void Consulta4()
        {
            //El nombre de los departamentos donde ningún empleado tenga despacho en el Building "Faculty of Science".
            //Resultado esperado: [Department: Mathematics]
            var c2 = modelo.Employees.Where(e => e.Office.Equals("Faculty of Science")).Select(e => $"{e.Department}");
            Show(c2);
        }

        private static void Consulta5()
        {


            // Mostrar las llamadas de teléfono de más de 5 segundos de duración para cada empleado que tenga más de 50 años
            //Cada línea debería mostrar el nombre del empleado y la duración de la llamada en segundos.
            //El resultado debe estar ordenado por duración de las llamadas (de más a menos).
            /*
                { Nombre = Eduardo, Duracion = 23 }
                { Nombre = Eduardo, Duracion = 22 }
                { Nombre = Alvaro, Duracion = 15 }
                { Nombre = Alvaro, Duracion = 10 }
                { Nombre = Felipe, Duracion = 7 }
            */
            var c2 = modelo.PhoneCalls.Where(p => p.Seconds > 5).Join(modelo.Employees.Where(e => e.Age > 50), p => p.SourceNumber, e => e.TelephoneNumber, (e, p) => $"Nombre = {p.Name}, Duracion = {e.Seconds}");
            Show(c2);
        }

        private static void Consulta6()
        {
            //Mostrar la llamada realizada más larga para cada empleado, mostrando por pantalla: Nombre_empleado : duracion_llamada_mas_larga
            /* ¡OJO NO ESTÁ APLICADO EL FORMATO 
                { Nombre = Alvaro, Maxima = 15 }
                { Nombre = Bernardo, Maxima = 63 }
                { Nombre = Eduardo, Maxima = 23 }
                { Nombre = Felipe, Maxima = 7 }
             */
            var c2 = modelo.PhoneCalls.Join(modelo.Employees, p => p.SourceNumber, e => e.TelephoneNumber,  (p,e) => new
            {
                Nombre = e.Name,
                Duration = p.Seconds
            }).Aggregate(new Dictionary<string, int>(), (acum,value) =>
            {
                if (acum.ContainsKey(value.Nombre))
                {
                    if(value.Duration > acum[value.Nombre])
                    {
                        acum[value.Nombre] = value.Duration;
                    }
                }
                else
                {
                    acum[value.Nombre] = value.Duration;
                }
                return acum;
            }).Select(x => new
            {
                Nombre = x.Key,
                Duration = x.Value
            }).Select(x => $"{x.Nombre} : {x.Duration}");
            Show(c2);
        }


        private static void Consulta7()
        {
            // Mostrar, agrupados por provincia, el nombre de los empleados
            //Tanto la provincia como los empleados de cada provicia seguirán un orden alfabético.
            var c2 = modelo.Employees.OrderBy(e => e.Name).GroupBy(e => e.Province).OrderBy(g => g.Key);
            foreach (var province in c2)
            {
                foreach (var employee in province)
                {
                    Console.WriteLine($"{province.Key} : {employee.Name}");
                }
            }


            /*Resultado esperado:
                Alicante : Carlos
                Asturias : Bernardo Felipe
                Cantabria : Alvaro Dario               
                Granada : Eduardo

            */
        }

    
        private static void ConsultaEj1()
        {
            //Los nombres de los empleados que pertenecen al departamento de “Computer
            //Science”, tienen un despacho en la “Faculty of Science” y han realizado al menos una
            //llamada con duración superior a 1 minuto
            var c2 = modelo.Employees.Where(e => e.Office.Building.Equals("Faculty of Science") && e.Department.Name.Equals("Computer Science")).Join(modelo.PhoneCalls.Where(p => p.Seconds >= 60), e=> e.TelephoneNumber, p => p.SourceNumber, (e,p) => $"{e.Name}");
            Show(c2);
        }

        private static void ConsultaEj2()
        {
            //La suma en segundos de las llamadas cuyo número de origen es el de un empleado del
            //departamento “Computer Science
            var c2 = modelo.PhoneCalls.Join(modelo.Employees.Where(e => e.Department.Name.Equals("Computer Science")), p => p.SourceNumber, e => e.TelephoneNumber, (p, e) => new
            {
                Duration = p.Seconds
            }).Aggregate(0, (acum,value) => acum + value.Duration);
            Console.WriteLine(c2);
        }

        private static void ConsultaEj3()
        {
            //Las llamadas de teléfono realizadas por cada departamento, ordenadas por nombre de
            //departamento.Cada línea debe tener el formato: 
            //Departamento = Nombre; Duración = Segundos

            var c2 = modelo.Departments.OrderBy(d => d.Name).SelectMany(d => d.Employees.Join(modelo.PhoneCalls,
                e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new
                {
                    Name = e.Department.Name,
                    Duration = p.Seconds
                }).Aggregate(new Dictionary<string, int>(), (acum, value) =>
                {
                    if (acum.ContainsKey(value.Name))
                    {
                        acum[value.Name] += value.Duration;
                    }
                    else
                    {
                        acum[value.Name] = value.Duration;
                    }
                    return acum;
                }).Select(x=> new
                {
                    Name = x.Key, Duration = x.Value
                }).Select(x=> $"{x.Name}, {x.Duration}"));
            Show(c2);

        }

        private static void ConsultaEj4()
        {
            //El nombre del departamento con el empleado más joven, junto con el nombre de éste y
            //su edad.Tened en cuenta que puede existir más de un resultado
            var c2 = modelo.Departments.OrderBy(d => d.Name).GroupJoin(modelo.Employees, d => d.Name, e => e.Department.Name,
                (d, e) => new
                {
                    Dname = d.Name,
                    Ename = e.First(e1 => e1.Age.Equals(e.Min(e2 => e2.Age))).Name,
                    MinAge = e.Min(e1 => e1.Age)
                }).Select(value=> $"{value.Dname}, {value.Ename}, {value.MinAge}");
            Show(c2);
        }

        private static void ConsultaEj5()
        {
            //El nombre del departamento que tenga la mayor duración de llamadas telefónicas, 
            //sumando la duración de las llamadas de todos los empleados que pertenecen al mismo. 
            //Puede asumirse que solamente un departamento cumplirá esta condición.
            var c2 = modelo.Employees.Join(modelo.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber,
                (e, p) => new
                {
                    NombreDepartamento = e.Department.Name,
                    Duration = p.Seconds
                }).Aggregate(new Dictionary<string,int>(), (acum,value) =>
                {
                    if (acum.ContainsKey(value.NombreDepartamento))
                    {
                        acum[value.NombreDepartamento] += value.Duration;
                    }
                    else
                    {
                        acum[value.NombreDepartamento] = value.Duration;
                    }
                    return acum;
                }).Aggregate(("",0), (acum, value) =>
                {
                    if(value.Value > acum.Item2)
                    {
                        acum.Item1 = value.Key;
                        acum.Item2 = value.Value;
                    }
                    return acum;
                });
            Console.WriteLine(c2.Item1 + " " + c2.Item2);
        }

        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
        }

        private static void Limpiar()
        {
            Console.WriteLine("Pulse una tecla para continuar la ejecución...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
