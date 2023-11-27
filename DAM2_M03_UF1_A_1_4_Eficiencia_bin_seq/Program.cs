using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Mida;Cerca seqüencial;Cerca dicotòmica");

        string filePath = "resultats.csv";

        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            writer.WriteLine("Mida;Cerca seqüencial;Cerca dicotòmica");
        }

        // Creamos vectores de enteros desde 500 hasta 100000
        for (int tamaño = 500; tamaño <= 100000; tamaño += 500)
        {
            // Creamos el vector con
            int[] vector = new int[tamaño * 2];

            for (int i = 0; i < tamaño * 2; i++)
            {
                vector[i] = (i + 1) * 2;
            }

            int numeroDeBusquedas = tamaño / 2;
            long totalDeComparacionesSeq = 0;
            long totalDeComparacionesBin = 0;

            for (int i = 0; i < numeroDeBusquedas; i++)
            {
                int index = new Random().Next(0, tamaño);
                int target = vector[index];

                int sequentialComparisons = BusquedaSecuencial(vector, target);
                totalDeComparacionesSeq += sequentialComparisons;

                int binaryComparisons = BusquedaBinaria(vector, target);
                totalDeComparacionesBin += binaryComparisons;
            }
            //Console.WriteLine(totalDeComparacionesSeq);
            long avgSequentialComparisons = totalDeComparacionesSeq / numeroDeBusquedas;
            //Console.WriteLine(avgSequentialComparisons);
            long avgBinaryComparisons = totalDeComparacionesBin / numeroDeBusquedas;

            // Escribir resultados en la consola
            Console.WriteLine($"{tamaño};{avgSequentialComparisons};{avgBinaryComparisons}");

            // Añadir los resultados al archivo CSV
            PasarLosResultadosACSV(filePath, tamaño, avgSequentialComparisons, avgBinaryComparisons);
        }
    }

    public static int BusquedaSecuencial(int[] array, int target)
    {
        int comparaciones = 0;
        bool encontrado = false;
        int i = 0;

        while (i < array.Length && !encontrado)
        {
            comparaciones++;
            if (array[i] == target) encontrado = true;
            else i++;
        }

        return comparaciones;
    }

    public static int BusquedaBinaria(int[] array, int target)
    {
        int comparaciones = 0;
        bool encontrado = false;
        int izquierda = 0;
        int derecha = array.Length - 1;

        while (izquierda <= derecha && !encontrado)
        {
            comparaciones++;
            int mitad = izquierda + (derecha - izquierda) / 2;

            if (array[mitad] == target) encontrado = true;
            else if (array[mitad] < target) izquierda = mitad + 1;
            else derecha = mitad - 1;
        }

        return comparaciones;
    }

    static void PasarLosResultadosACSV(string filePath, int size, long avgSequentialComparisons, long avgBinaryComparisons)
    { 
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{size};{avgSequentialComparisons};{avgBinaryComparisons}");
        }
    }
}
