using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int[] Add(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new ArgumentException("Arrays must have the same length.");
            }

            int[] result = new int[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }

            return result;
        }

        public static int[,] Add(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrices must have the same dimensions.");
            }

            int rows = matrix1.GetLength(0);
            int columns = matrix1.GetLength(1);

            int[,] result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

    }

    class Program
    {
        static void Main()
        {
            // Приклади використання класу MathOperations
            Console.WriteLine(MathOperations.Add(5, 3));

            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };
            int[] resultArray = MathOperations.Add(array1, array2);
            Console.WriteLine(string.Join(", ", resultArray));

            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
            int[,] resultMatrix = MathOperations.Add(matrix1, matrix2);

            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

}
