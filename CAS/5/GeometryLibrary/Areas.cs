namespace GeometryLibrary;

public static class Areas
{
    public static double Square(double side)
    {
        ValidatePositive(side, nameof(side));
        return side * side;
    }

    public static double Rectangle(double width, double height)
    {
        ValidatePositive(width, nameof(width));
        ValidatePositive(height, nameof(height));
        return width * height;
    }

    public static double Triangle(double baseLength, double height)
    {
        ValidatePositive(baseLength, nameof(baseLength));
        ValidatePositive(height, nameof(height));
        return baseLength * height / 2.0;
    }

    private static void ValidatePositive(double value, string name)
    {
        if (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
            throw new ArgumentOutOfRangeException(name, "Размер должен быть неотрицательным конечным числом.");
    }
}
