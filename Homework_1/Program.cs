internal class Program
{
    private static void Main(string[] args)
    {
        Program program = new Program();
        int[,] array = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
        int[] array2 = { 4, 2, 9, 2, 8, 9, 3, 2 ,4 ,65};
        foreach (int i in array2)
            Console.Write(i + " ");
        Console.WriteLine();
        program.ArraySort(0, array2.Length - 1, array2);
        foreach (int i in array2)
            Console.Write(i + " ");
    }
    private int[] ArraySort(int left, int right, int[] array)
    {
        if (left < right)
        {
            //Console.WriteLine(left + " " + right);
            int pivot = PartitionSort(left, right, array);
            ArraySort(left, pivot - 1, array);
            ArraySort(pivot + 1, right, array);
        }
        return array;
    }
    private static int PartitionSort(int left, int right, int[] array)
    {
        int pivotIndex = left + (right - left) / 2;
        int pivotValue = array[pivotIndex];
        Swap(array, pivotIndex, right);  
        int rightPoint = right - 1;
        int leftPoint = left;
        while (leftPoint <= rightPoint)
        {
            while (leftPoint <= rightPoint && array[leftPoint] < pivotValue)
            {
                leftPoint++;
            }

            while (leftPoint <= rightPoint && array[rightPoint] > pivotValue)
            {
                rightPoint--;
            }

            if (leftPoint <= rightPoint)
            {
                Swap(array, leftPoint, rightPoint);
                leftPoint++;
                rightPoint--;
            }
        }
        Swap(array, leftPoint, right);
        pivotIndex = leftPoint;
        return pivotIndex;

    }
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    private void ArrayView(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write($"{array[i, j]} ".PadLeft(2));
            Console.WriteLine("");
        }

    }
}