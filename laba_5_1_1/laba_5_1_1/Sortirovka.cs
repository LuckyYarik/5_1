using System.Diagnostics;

public class Sort
{
    private int[] arr;
    private int _length;

    // ����������� ��� ����������
    public Sort()
    {
        this._length = 10; // ������������� �� ��������� ���������� ��������� � 10
        this.arr = new int[_length];
    }

    // ����������� � �����������
    public Sort(int length)
    {
        this._length = length;
        this.arr = new int[_length];
    }

    // ����� ��� ���������� �������
    public void FillArray()
    {
        Random random = new Random();
        for (int i = 0; i < this._length; i++)
        {
            this.arr[i] = random.Next(1, 100); // ��������� �������� �� 1 �� 99
        }
    }


    public void SortArray()
    {
        bool check11 = Mas(this.arr);
        int[] CopyArr = CopyMas(this.arr);

        // ������ ����������
        Stopwatch gnomeStopwatch = new Stopwatch();
        gnomeStopwatch.Start();
        SortWithGnome(this.arr);
        gnomeStopwatch.Stop();

        // ���������� ��������������
        Stopwatch shuffleStopwatch = new Stopwatch();
        shuffleStopwatch.Start();
        ShakeSort(CopyArr);
        shuffleStopwatch.Stop();

        if (check11)
        {
            check11 = Mas(this.arr);
        }
        Console.WriteLine($"����� ������� ����������: {gnomeStopwatch.Elapsed.TotalMilliseconds} ��, � ����� ���������� ��������������: {shuffleStopwatch.Elapsed.TotalMilliseconds} ��");
        Console.WriteLine("������� ����� ������, ����� ����� � ����. ");
        Console.ReadKey();
    }

    static int[] CopyMas(int[] a)
    {
        int[] b = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            b[i] = a[i];
        }
        return b;
    }

    static void SortWithGnome(int[] arr)
    {
        int n = arr.Length;
        int index = 0;

        while (index < n)
        {
            if (index == 0)
            {
                index++;
            }
            if (arr[index] >= arr[index - 1])
            {
                index++;
            }
            else
            {
                // ������ ������� ��������
                int temp = arr[index];
                arr[index] = arr[index - 1];
                arr[index - 1] = temp;
                index--;
            }
        }
    }

    static void ShakeSort(int[] array)
    {
        int end = array.Length - 1;
        int start = 0;
        int remember = 0;
        bool swapped = true;

        while (swapped)
        {
            swapped = false;

            for (int i = start; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    swapped = true;
                    remember = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = remember;
                }
            }
            end--;

            for (int i = end; i > start; i--)
            {
                if (array[i] < array[i - 1])
                {
                    swapped = true;
                    remember = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = remember;
                }
            }
            start++;
        }
    }

    static bool Mas(int[] arr)
    {
        if (arr.Length < 11)
        {
            Console.Write("��� ������: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("\n");
            return true;
        }
        else
        {
            Console.WriteLine("������ �� ����� ���� ������� �� �����, ��� ��� ����� ������� ������ 10");
            return false;
        }
    }
}
