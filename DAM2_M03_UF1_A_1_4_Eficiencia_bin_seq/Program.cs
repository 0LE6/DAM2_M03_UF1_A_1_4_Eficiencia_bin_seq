internal class Program
{
    private static void Main(string[] args)
    {

        // Práctica A1.4

        // Creamos StreamWriter para generar csv
        StreamWriter sW = new StreamWriter("resultats.csv");

        /* resultats.csv
        Mida;Cerca seqüencial;Cerca dicotòmica
        500;???;??
        1000;???;??
        1500;???;??
        2000;???;??
        …
        100000;???;??
        */

        for (int i = 500; i < 100000; i += 500)
        {
            int[] vector = new int[i];
        }

        // Búsqueda lineal
        int[] arrayParaBusquedaSec = { 3, 5, 1, 2, 8 };
        int targetSec = 8; 
        BusquedaSecuencial(arrayParaBusquedaSec, targetSec);

        // Búsqueda dicotómica
        int[] arrayParaBusquedaDic = { 3, 5, 1, 2, 8 };
        int targetDic = 8;
        BusquedaDicotomica(arrayParaBusquedaDic, targetDic);

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


    public static int BusquedaDicotomica(int[] array, int target)
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

}