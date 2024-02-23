using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the coefficients of the quadratic equation (a, b, c):");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        double x1 = 0, x2 = 0;
        SolveQuadraticEquation(a, b, c, ref x1, ref x2);
        Console.WriteLine($"The solutions are: x1 = {x1}, x2 = {x2}");
    }
    public static void SolveQuadraticEquation(double a, double b, double c, ref double x1, ref double x2)
    {
        double discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            Console.WriteLine("The quadratic equation has complex roots.");
            return;
        }
        x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
    }
}