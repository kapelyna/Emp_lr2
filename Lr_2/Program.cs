using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Кількість елементів у послідовності
        int N = 11;
        int numElements = N + 10;

        // Генератор випадкових чисел
        Random rand = new Random();

        // Генерація випадкової послідовності
        List<int> data = new List<int>();
        for (int i = 0; i < numElements; i++)
        {
            data.Add(rand.Next(1, 6)); // Генеруємо числа від 1 до 5
        }

        // Виведення вихідних даних
        Console.WriteLine("Вихідні дані: " + string.Join(" ", data));

        // Варіаційний ряд (відсортовані значення)
        List<int> sortedData = data.OrderBy(x => x).ToList();
        Console.WriteLine("Варіаційний ряд: " + string.Join(" ", sortedData));

        // Статистичний розподіл (кількість кожного елемента)
        var frequency = data.GroupBy(x => x)
                            .ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("Статистичний розподіл:");
        foreach (var pair in frequency)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value} разів");
        }

        // Інтегральна частота (нахил по мірі накопичення частот)
        var cumulativeFrequency = new Dictionary<int, int>();
        int cumulative = 0;
        foreach (var pair in frequency.OrderBy(x => x.Key))
        {
            cumulative += pair.Value;
            cumulativeFrequency[pair.Key] = cumulative;
        }

        Console.WriteLine("Інтегральна частота:");
        foreach (var pair in cumulativeFrequency)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        // Частість (відношення частоти до кількості елементів)
        Console.WriteLine("Частість:");
        foreach (var pair in frequency)
        {
            double relativeFrequency = (double)pair.Value / numElements;
            Console.WriteLine($"{pair.Key}: {relativeFrequency:F6}");
        }
    }
}
