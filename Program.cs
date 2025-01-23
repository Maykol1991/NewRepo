Console.WriteLine("Hello, World!");
namespace ConsoleApp_semana_6
{
    class Nodo
    {
        public int Dato { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    class Lista
    {
        private Nodo? cabeza;

        public Lista()
        {
            cabeza = null;
        }

        // Método para agregar un elemento al final de la lista
        public void Agregar(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        // Método de búsqueda que devuelve el número de veces que se encuentra el dato en la lista
        public void Buscar(int valor)
        {
            int contador = 0;
            Nodo? actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato == valor)
                {
                    contador++;
                }
                actual = actual.Siguiente;
            }

            if (contador > 0)
            {
                Console.WriteLine($"El número {valor} aparece {contador} veces en la lista.");
            }
            else
            {
                Console.WriteLine($"El número {valor} no fue encontrado en la lista.");
            }
        }

        // Método para eliminar nodos fuera de un rango dado
        public void EliminarFueraDeRango(int min, int max)
        {
            Nodo? actual = cabeza;
            Nodo? anterior = null;

            while (actual != null)
            {
                if (actual.Dato < min || actual.Dato > max)
                {
                    if (anterior == null) // Si el nodo a eliminar es el primero
                    {
                        cabeza = actual.Siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }
                }
                else
                {
                    anterior = actual;
                }
                actual = actual.Siguiente;
            }
        }

        // Método para mostrar la lista
        public void Mostrar()
        {
            Nodo? actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }

    class Semana6
    {
        public static void Run()
        {
            // Ejercicio 1: Búsqueda en la lista
            Lista lista1 = new Lista();
            lista1.Agregar(5);
            lista1.Agregar(10);
            lista1.Agregar(5);
            lista1.Agregar(15);
            lista1.Agregar(5);

            Console.WriteLine("Ejercicio 1: Búsqueda en la lista");
            lista1.Buscar(5);  // Prueba de búsqueda
            lista1.Buscar(100); // Prueba de búsqueda de número no encontrado
            Console.WriteLine();

            // Ejercicio 2: Eliminar valores fuera de un rango
            Lista lista2 = new Lista();
            Random rand = new Random();

            // Crear una lista con 50 números aleatorios entre 1 y 999
            for (int i = 0; i < 50; i++)
            {
                lista2.Agregar(rand.Next(1, 1000));
            }

            Console.WriteLine("Ejercicio 2: Eliminar valores fuera del rango");
            Console.WriteLine("Lista original:");
            lista2.Mostrar();

            // Leer el rango de valores desde el teclado con validación
            Console.Write("Ingrese el valor mínimo: ");
            int min = LeerEntero();

            Console.Write("Ingrese el valor máximo: ");
            int max = LeerEntero();

            // Eliminar nodos fuera del rango
            lista2.EliminarFueraDeRango(min, max);

            Console.WriteLine($"Lista después de eliminar los valores fuera del rango ({min}, {max}):");
            lista2.Mostrar();
        }

        // Método para leer un entero con validación
        private static int LeerEntero()
        {
            while (true)
            {
                string? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int resultado))
                {
                    return resultado;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero:");
                }
            }
        }
    }

}
