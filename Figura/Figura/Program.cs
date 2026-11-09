using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figura
{
    internal class Program
    {
        // Clase abstracta Figura
        abstract class Figura
        {
            // Método abstrato para calcular a área da figura
        
            public abstract double CalcularArea();

            public abstract double CalcularPerimetro();

        }

        // Luego implementa clases derivadas Rectangulo, triangulo y circulo
        class Rectangulo : Figura
        {
            private double largo;
            private double altura;
            public Rectangulo(double largo, double altura)
            {
                this.largo = largo;
                this.altura = altura;
            }
            public override double CalcularArea()
            {
                return largo * altura;
            }
            public override double CalcularPerimetro()
            {
                return 2 * (largo + altura);
            }

        }
        class Triangulo : Figura
        {
            private double baseTriangulo;
            private double altura;
            public Triangulo(double baseTriangulo, double altura)
            {
                this.baseTriangulo = baseTriangulo;
                this.altura = altura;
            }
            public override double CalcularArea()
            {
                return (baseTriangulo * altura) / 2;
            }
            public override double CalcularPerimetro()
            {
                // Para simplificar, asumimos un triángulo equilátero
                return 3 * baseTriangulo;
            }

        }
        class Circulo : Figura
        {
            private double radio;
            public Circulo(double radio)
            {
                this.radio = radio;
            }
            public override double CalcularArea()
            {
                return Math.PI * radio * radio;
            }
            public override double CalcularPerimetro()
            {
                return 2 * Math.PI * radio;
            }    
            
        }
        
        // Main
        static void Main(string[] args)
        {
            // Arreglo de figuras, almacena instancias de las formas
            Figura[] figuras = { new Rectangulo(5, 10), new Triangulo(6, 8), new Circulo(4) };

            // Aplica polimorfismo recorriendo el arreglo mediante un bucle para mostrar dinámicamente
            // el nombre de la clase, su área y su perímetro
            foreach (Figura figura in figuras)
            {
                Console.WriteLine($"Figura: {figura.GetType().Name}");
                Console.WriteLine($"Área: {figura.CalcularArea()}");
                Console.WriteLine($"Perímetro: {figura.CalcularPerimetro()}");
                Console.WriteLine();
            }

        }

    }

}   
