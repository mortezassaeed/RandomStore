using RandomMatrix;

var distanceFrom0_0 = new Matrix2x2(100,100)
       .Generate2x2Randorm(0,1)
       .FindFirstAllOnesMatrix(3);


if (distanceFrom0_0 != null)
{
    Console.WriteLine($"bingoo ({distanceFrom0_0!.Value.x},{distanceFrom0_0!.Value.y})");
}
else
{
    Console.WriteLine($"there is no matrix of ones....");
}

Console.ReadKey();