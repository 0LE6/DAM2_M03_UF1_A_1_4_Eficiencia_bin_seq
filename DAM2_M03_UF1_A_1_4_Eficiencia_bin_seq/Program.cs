using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Mida;Cerca seqüencial;Cerca dicotòmica");

        string filePath = "resultats.csv";

        // Crear el StreamWriter fuera del bucle para escribir el encabezado
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            writer.WriteLine("Mida;Cerca seqüencial;Cerca dicotòmica");
        }

        for (int size = 500; size <= 100000; size += 500)
        {
            int[] vector = new int[size];
            for (int i = 0; i < size; i++)
            {
                vector[i] = (i + 1) * 2;
            }

            int numSearches = size / 2;
            long totalSequentialComparisons = 0;
            long totalBinaryComparisons = 0;

            for (int i = 0; i < numSearches; i++)
            {
                // Generar índices únicos en lugar de valores aleatorios
                int index = new Random().Next(0, size);
                int target = vector[index];

                int sequentialComparisons = BusquedaSecuencial(vector, target);
                totalSequentialComparisons += sequentialComparisons;

                int binaryComparisons = BusquedaBinaria(vector, target);
                totalBinaryComparisons += binaryComparisons;
            }

            long avgSequentialComparisons = totalSequentialComparisons / numSearches;
            long avgBinaryComparisons = totalBinaryComparisons / numSearches;

            // Escribir resultados en la consola
            Console.WriteLine($"{size};{avgSequentialComparisons};{avgBinaryComparisons}");

            // Añadir los resultados al archivo CSV
            PasarLosResultadosACSV(filePath, size, avgSequentialComparisons, avgBinaryComparisons);
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
        // Añadir los resultados al archivo CSV
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{size};{avgSequentialComparisons};{avgBinaryComparisons}");
        }
    }
}
