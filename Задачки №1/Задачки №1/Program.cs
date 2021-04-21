using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задачки__1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("№1 Введите массив:");
            int[] MyArray1 = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), new Converter<String, int>(Convert.ToInt32));
            Console.WriteLine("Наибольший периметр треугольника: " + Task1(ref MyArray1)); 


            Console.WriteLine("№2 Введите массив:");
            int[] MyArray2 = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), new Converter<String, int>(Convert.ToInt32));

            Task2(ref MyArray2);
            Array.Reverse(MyArray2);
            for (int i = 0; i < MyArray2.Length; i++)
            {
                Console.Write(MyArray2[i]);
            }

            Console.ReadLine();


            //Console.WriteLine("№3 Введите количество строк матрицы:");
            //int lines = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите количество столбцов матрицы:");
            //int columns = Convert.ToInt32(Console.ReadLine());

            //int[,] array = new int[lines, columns];
            //for (int i = 0; i < lines; i++)
            //{
            //    Console.WriteLine("Введите очередную строку матрицы:");
            //    List<String> MyArray2 = Console.ReadLine().Split(ch, StringSplitOptions.RemoveEmptyEntries).ToList<String>();
            //    for (int j = 0; j < columns; j++)
            //    {
            //        array[i, j] = Convert.ToInt32(MyArray2[j]);
            //    }
            //}
            //Task3(array, columns, lines);

            int lines = 5;
            int columns = 6;
            int[,] array = CreateMatrix(lines, columns);
            Console.WriteLine("№3 Исходная матрица:");
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("\r\n");
            }
            Task3(array, lines, columns);
            Console.WriteLine("Получившаяся матрица:");
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("\r\n");
            }
            Console.ReadLine();
        }

        #region Генерация матрицы
        static int[,] CreateMatrix(int lines,int columns)
        {
            int[,] Matrix = new int[lines, columns];
            Random rand = new Random();
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Matrix[i, j] = rand.Next( 5000, 6001);
                }
            }
            return Matrix;
        }

        #endregion
        #region Task1

        static int Task1(ref int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);

            for(int i = 0; i < arr.Length-2; i++)
            {
                if ((arr[i] < (arr[i+1] + arr[i+2])) && (arr[i+1] < (arr[i] + arr[i+2])) && (arr[i+2] < (arr[i+1] + arr[i])))
                {
                   return (arr[i] + arr[i+1] + arr[i+2]);

                }
            }

            return 0;
        }

        #endregion
        #region Task2
        static void Task2(ref int[] arr)
        {
            int MatrixSize = arr.Length;
            int index = 0;

            for (int i = 0; i < MatrixSize - 1; i++)
            {
                index = i;

                for (int j = i + 1; j < MatrixSize; j++)
                {
                    String str1 = Convert.ToString(arr[j]) + Convert.ToString(arr[index]);
                    String str2 = Convert.ToString(arr[index]) + Convert.ToString(arr[j]);

                    if (Convert.ToInt64(str1).CompareTo(Convert.ToInt64(str2)) == -1)
                    {
                        index = j;
                    }
                }

                if (index != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[index];
                    arr[index] = temp;
                }
            }
        }
        #endregion
        #region Task3
        static void Task3(int[,] arr, int m,int n)
        {
            for(int i = 0; i < n-1; i++)
            {
                FuncForTask3(arr, 0,i,m,n);
            }

            for (int i = 1; i < m - 1; i++)
            {
                FuncForTask3(arr, i, 0, m, n);
            }
        }

        static void FuncForTask3(int[,] arr, int m,int k,int lenX,int lenY)
        {
            List<int> NewArr = new List<int>();

            int m1 = m;
            int k1 = k;
            while (ProvForTask3(m1,k1,lenX,lenY))
            {
                NewArr.Add(arr[m1, k1]);
                m1++;
                k1++;
            }

            NewArr.Sort();
            int g = 0;
            while (ProvForTask3(m, k, lenX, lenY))
            {
               arr[m,k]=NewArr[g];
                m++;
                k++;
                g++;
            }

        }

        static bool ProvForTask3(int indexX,int indexY, int i,int j)
        {
            if (indexX < i && indexY < j) return true;
            else return false;
        }

        #endregion      

    }
}
