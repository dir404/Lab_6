using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class Quaternion
    {
        public double W { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

       
        public Quaternion(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

       
        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
        }

        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z);
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
            double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
            double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
            double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;

            return new Quaternion(w, x, y, z);
        }

        
        public double Norm()
        {
            return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
        }

        public Quaternion Conjugate()
        {
            return new Quaternion(W, -X, -Y, -Z);
        }

        public Quaternion Inverse()
        {
            double normSquared = W * W + X * X + Y * Y + Z * Z;
            if (normSquared == 0)
            {
                throw new InvalidOperationException("Quaternion has zero norm, cannot compute inverse.");
            }

            double inverseNorm = 1 / normSquared;
            return new Quaternion(W * inverseNorm, -X * inverseNorm, -Y * inverseNorm, -Z * inverseNorm);
        }

        public static bool operator ==(Quaternion q1, Quaternion q2)
        {
            return q1.W == q2.W && q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z;
        }

        public static bool operator !=(Quaternion q1, Quaternion q2)
        {
            return !(q1 == q2);
        }

        public double[,] ToRotationMatrix()
        {
            // логікa для конвертації кватерніона в матрицю обертання
            
            return new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }; // Приклад
        }

        public static Quaternion FromRotationMatrix(double[,] matrix)
        {
            // логікa для конвертації кватерніона в матрицю обертання

            return new Quaternion(1, 0, 0, 0); // Приклад
        }
    }

    class Program
    {
        static void Main()
        {
            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Quaternion q2 = new Quaternion(5, 6, 7, 8);

            Quaternion sum = q1 + q2;
            Console.WriteLine($"Sum: {sum.W}, {sum.X}, {sum.Y}, {sum.Z}");

            Quaternion difference = q1 - q2;
            Console.WriteLine($"Difference: {difference.W}, {difference.X}, {difference.Y}, {difference.Z}");

            Quaternion product = q1 * q2;
            Console.WriteLine($"Product: {product.W}, {product.X}, {product.Y}, {product.Z}");

            Console.WriteLine($"Norm of q1: {q1.Norm()}");
            Console.WriteLine($"Conjugate of q1: {q1.Conjugate().W}, {q1.Conjugate().X}, {q1.Conjugate().Y}, {q1.Conjugate().Z}");

            try
            {
                Quaternion inverse = q1.Inverse();
                Console.WriteLine($"Inverse of q1: {inverse.W}, {inverse.X}, {inverse.Y}, {inverse.Z}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine($"Are q1 and q2 equal? {q1 == q2}");
            Console.WriteLine($"Are q1 and q2 not equal? {q1 != q2}");

            Console.ReadLine();
        }
    }

}
