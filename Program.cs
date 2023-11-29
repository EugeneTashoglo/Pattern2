using System;
using System.Collections.Generic;

// Абстрактное выражение
interface IExpression
{
    int Interpret(Dictionary<string, int> context);
}

// Конкретное выражение
class NumberExpression : IExpression
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret(Dictionary<string, int> context)
    {
        return _number;
    }
}

// Конкретное выражение для сложения
class AddExpression : IExpression
{
    private IExpression _leftExpression;
    private IExpression _rightExpression;

    public AddExpression(IExpression left, IExpression right)
    {
        _leftExpression = left;
        _rightExpression = right;
    }

    public int Interpret(Dictionary<string, int> context)
    {
        return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        // Создаем контекст
        Dictionary<string, int> context = new Dictionary<string, int>();
        context.Add("a", 5);
        context.Add("b", 10);

        // Создаем выражения
        IExpression expression = new AddExpression(new NumberExpression(2), new NumberExpression(3));

        // Интерпретируем выражение
        int result = expression.Interpret(context);

        // Выводим результат
        Console.WriteLine("Результат: " + result);
    }
}
