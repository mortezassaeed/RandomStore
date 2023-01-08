using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMatrix;
internal class Matrix2x2
{
    public int[,] Mtx { get; private set; }

    public Matrix2x2(int firstDimSize, int secounfDimSize)
    {
        Mtx = new int[firstDimSize, secounfDimSize];
    }

    public Matrix2x2 Generate2x2Randorm(int minValue, int maxValue)
    {
        Random rnd = new Random();

        for (int i = 0; i < Mtx.GetLength(0); i++)
        {
            for (int j = 0; j < Mtx.GetLength(1); j++)
            {
                Mtx[i, j] = rnd.Next(minValue, maxValue + 1);
            }
        }
        return this;
    }

    //deprecated
    public (int x, int y)? FindFirstAllOnesMatrix()
    {
        for (int i = 0; i < Mtx.GetLength(0) - 2; i++)
        {
            bool finished = false;
            for (int j = 0; j < Mtx.GetLength(1); j++)
            {
                var result = SumOfItems(i, j,3) +
                SumOfItems(i + 1, j,3) +
                SumOfItems(i + 2, j, 3);

                Console.WriteLine($"totla = {result}");

                if (result == 9)
                {
                    return (i, j);
                }
            }
            if (finished)
                return null;
        }
        return null;
    }

    public (int x, int y)? FindFirstAllOnesMatrix(int squreMatrixDim)
    {
        for (int i = 0; i < Mtx.GetLength(0) - (squreMatrixDim - 1); i++)
        {
            bool finished = false;
            for (int j = 0; j < Mtx.GetLength(1); j++)
            {
                int result = 0;
                for (int z = 0; z < squreMatrixDim; z++)
                {
                    result += SumOfItems(i + z, j, squreMatrixDim);
                }

                Console.WriteLine($"totla = {result}");

                if (result == Math.Pow(squreMatrixDim, 2))
                {
                    return (i, j);
                }
            }
            if (finished)
                return null;
        }
        return null;
    }

    private int SumOfItems(int firstDimIndex, int secoundDimIndex, int length)
    {
        var sum = 0;

        for (int i = 0; i < Math.Min(length, Mtx.GetLength(1) - secoundDimIndex); i++)
        {
            var currentPoint = Mtx[firstDimIndex, secoundDimIndex + i];
            Console.WriteLine($"({firstDimIndex} , {secoundDimIndex + i}) = {Mtx[firstDimIndex, secoundDimIndex + i]}");
            sum += currentPoint;
        }
        Console.WriteLine($"sum = {sum}");
        return sum;
    }
}
