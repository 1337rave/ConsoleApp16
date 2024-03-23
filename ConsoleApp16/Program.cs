using System;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Використання делегатів Action, Predicate, Func для виклику методів
            Action displayCurrentTime = DisplayCurrentTime;
            Action displayCurrentDate = DisplayCurrentDate;
            Action displayCurrentDayOfWeek = DisplayCurrentDayOfWeek;
            Func<double, double, double> calculateTriangleArea = CalculateTriangleArea;
            Func<double, double, double> calculateRectangleArea = CalculateRectangleArea;

            // Виклики методів через делегати
            displayCurrentTime();
            displayCurrentDate();
            displayCurrentDayOfWeek();

            double triangleBase = 5;
            double triangleHeight = 7;
            double triangleArea = calculateTriangleArea(triangleBase, triangleHeight);
            Console.WriteLine($"Triangle Area: {triangleArea}");

            double rectangleWidth = 10;
            double rectangleHeight = 8;
            double rectangleArea = calculateRectangleArea(rectangleWidth, rectangleHeight);
            Console.WriteLine($"Rectangle Area: {rectangleArea}");
        }

        // Метод відображення поточного часу
        static void DisplayCurrentTime()
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToLongTimeString()}");
        }

        // Метод відображення поточної дати
        static void DisplayCurrentDate()
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToLongDateString()}");
        }

        // Метод відображення поточного дня тижня
        static void DisplayCurrentDayOfWeek()
        {
            Console.WriteLine($"Current Day of Week: {DateTime.Now.DayOfWeek}");
        }

        // Метод для підрахунку площі трикутника
        static double CalculateTriangleArea(double @base, double height)
        {
            return 0.5 * @base * height;
        }

        // Метод для підрахунку площі прямокутника
        static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
