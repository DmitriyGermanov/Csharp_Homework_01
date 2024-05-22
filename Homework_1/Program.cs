internal class Program
{
    private static void Main(string[] args)
    {
        Program program = new Program();
        int[,] array = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
        int[] simpleArray = new int[array.GetLength(0) * array.GetLength(1)];
        int index = 0;
        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
            {
                simpleArray[index] = array[i, j];
                index++;
            }
        ArraySort(0, simpleArray.Length - 1, simpleArray);
        index = 0;
        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = simpleArray[index];
                index++;
            }

        ArrayView(array);
    }
    private static int[] ArraySort(int left, int right, int[] array)
    {
        if (left < right)
        {
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
    private static void ArrayView(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write($"{array[i, j]} ".PadLeft(2));
            Console.WriteLine("");
        }

    }
}