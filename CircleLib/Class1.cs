namespace CircleLib
{
    public class Geometry
    {
        // Метод для вычисления площади круга по радиусу
        public double CalculateCircleArea(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть больше нуля");
            }

            return Math.PI * radius * radius;
        }

        // Метод для вычисления площади треугольника по формуле Герона
        public double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            // Проверяем, что стороны могут образовать треугольник
            if (sideA <= 0 || sideB <= 0 || sideC <= 0 ||
                sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("Стороны должны быть положительными, и сумма двух сторон должна быть больше третьей");
            }

            // Полупериметр
            double semiPerimeter = (sideA + sideB + sideC) / 2;

            // Площадь по формуле Герона
            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }

        // Метод для проверки, является ли треугольник прямоугольным
        public bool IsRightTriangle(double sideA, double sideB, double sideC)
        {
            // Проверка, что стороны могут образовать треугольник
            if (sideA <= 0 || sideB <= 0 || sideC <= 0 ||
                sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("Стороны должны быть положительными, и сумма двух сторон должна быть больше третьей");
            }

            // Находим максимальную сторону, она будет гипотенузой
            double maxSide = Math.Max(sideA, Math.Max(sideB, sideC));

            // Определяем, какие стороны являются катетами
            if (maxSide == sideA)
            {
                return Math.Abs(sideA * sideA - (sideB * sideB + sideC * sideC)) < 1e-10;
            }
            else if (maxSide == sideB)
            {
                return Math.Abs(sideB * sideB - (sideA * sideA + sideC * sideC)) < 1e-10;
            }
            else
            {
                return Math.Abs(sideC * sideC - (sideA * sideA + sideB * sideB)) < 1e-10;
            }
        }
    }
}