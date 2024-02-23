using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the coefficients of the quadratic equation (a, b, c):");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        var solutions = SolveQuadraticEquation(a, b, c);
        Console.WriteLine($"The solutions are: x1 = {solutions.Item1}, x2 = {solutions.Item2}");
    }
    public static (double, double) SolveQuadraticEquation(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            Console.WriteLine("The quadratic equation has complex roots.");
            return (double.NaN, double.NaN);
        }
        double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        return (x1, x2);
    }
}