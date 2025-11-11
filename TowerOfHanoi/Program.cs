namespace TowerOfHanoi;

using System;
using System.Collections.Generic;

/// <summary>
/// Following Marcin Jamro's tutorial on Tower of Hanoi using stacks.
/// </summary>
public class Program
{
    private const int DISCS_COUNT = 10;
    private const int DELAY_MS = 50;
    private static int _columnSize = 30;
    private static HanoiTower _algorithm;
    private static bool _isRunning = true;

    static void Main(string[] args)
    {
        Console.Title = "Tower of Hanoi";

        ShowMainMenu();

        _columnSize = Math.Max(6, GetDiscWidth(DISCS_COUNT) + 2);
        HanoiTower algorithm = new HanoiTower(DISCS_COUNT);
        algorithm.MoveCompleted += Algorithm_Visualize;
        Algorithm_Visualize(algorithm, EventArgs.Empty);
        algorithm.Start();
    }

    private static void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("""
            === TOWER OF HANOI ===

            1. Start new game
            2. Load game
            3. Exit
            """);
        Console.Write("Select an option: ");
        var key = Console.ReadKey();
        switch (key.KeyChar)
        {
            case '1':
                GetUserInput(); // To be added
                break;
            case '2':
                LoadGame(); // To be added
                break;
            case '3':
                _isRunning = false;
                return;
            default:
                ShowMainMenu();
                break;
        }
    }

    private static void GetUserInput()
    {
        throw new NotImplementedException();
    }

    private static void LoadGame()
    {
        throw new NotImplementedException();
    }

    private static void Algorithm_Visualize(object? sender, EventArgs e)
    {
        Console.Clear();

        HanoiTower algorithm = (HanoiTower)sender;
        if (algorithm.DiscsCount <= 0) { return; }

        char[][] visualisation = InitializeVisualization(algorithm);
        PrepareColumn(visualisation, 1, algorithm.DiscsCount, algorithm.From);
        PrepareColumn(visualisation, 2, algorithm.DiscsCount, algorithm.To);
        PrepareColumn(visualisation, 3, algorithm.DiscsCount, algorithm.Auxillary);

        Console.WriteLine(Center("FROM") + Center("TO") + Center("AUXILLARY"));
        DrawVisualization(visualisation);
        Console.WriteLine();
        Console.WriteLine($"Number of moves: {algorithm.MovesCount}");
        Console.WriteLine($"Number of discs: {algorithm.DiscsCount}");

        Thread.Sleep(DELAY_MS);
    }

    private static string? Center(string text)
    {
        int margin = (_columnSize - text.Length) / 2;
        return text.PadLeft(margin + text.Length).PadRight(_columnSize);
    }

    private static void DrawVisualization(char[][] visualisation)
    {
        for (int y = 0; y < visualisation.Length; y++)
        {
            Console.WriteLine(visualisation[y]);
        }
    }

    private static void PrepareColumn(char[][] visualisation, int column, int discsCount, Stack<int> stack)
    {
        int margin = _columnSize * (column - 1);

        for (int y = 0; y < stack.Count; y++)
        {
            int size = stack.ElementAt(y);
            int row = discsCount - (stack.Count - y);
            int columnStart = margin + discsCount - size;
            int columnEnd = columnStart + GetDiscWidth(size);

            for (int x = columnStart; x < columnEnd; x++)
            {
                visualisation[row][x] = '=';
            }
        }
    }

    private static int GetDiscWidth(int size)
    {
        return size * 2 - 1;
    }

    private static char[][] InitializeVisualization(HanoiTower algorithm)
    {
        char[][] visualisation = new char[algorithm.DiscsCount][];

        for (int y = 0; y < visualisation.Length; y++)
        {
            visualisation[y] = new char[_columnSize * 3];
            for (int x = 0; x < _columnSize * 3; x++)
            {
                visualisation[y][x] = ' ';
            }
        }
        return visualisation;
    }
}