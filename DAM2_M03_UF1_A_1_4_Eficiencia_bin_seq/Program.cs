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
        int low = 0;
        int high = array.Length - 1;
        int cont = 0;


        return 0;
    }

    public static int BusquedaDicotomica(int[] array, int target)
    {
        return 0;
    }
}