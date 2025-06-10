
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test Square
        Square square = new Square("Red", 5);
        Console.WriteLine($"Square Color: {square.GetColor()}, Area: {square.GetArea()}");

        // Test Rectangle
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");

        // Test Circle
        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle Color: {circle.GetColor()}, Area: {circle.GetArea()}");

        // Build a list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Yellow", 4));
        shapes.Add(new Rectangle("Purple", 3, 5));
        shapes.Add(new Circle("Orange", 2.5));

        // Iterate through the list and display color and area
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}