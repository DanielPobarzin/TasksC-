using System;
using System.Collections.Generic;
using System.Text;

class SimpleTerminal
{
    private List<string> lines;
    private int cursorRow;
    private int cursorCol;

    public SimpleTerminal()
    {
        lines = [""];
        cursorRow = 0;
        cursorCol = 0;
    }

    public void ProcessInput(string input)
    {
        foreach (char c in input)
        {
            switch (c)
            {
                case 'L':
                    MoveCursorLeft();
                    break;
                case 'R':
                    MoveCursorRight();
                    break;
                case 'U':
                    MoveCursorUp();
                    break;
                case 'D':
                    MoveCursorDown();
                    break;
                case 'B':
                    MoveCursorToBeginning();
                    break;
                case 'E':
                    MoveCursorToEnd();
                    break;
                case 'N':
                    InsertNewline();
                    break;
                default:
                    InsertCharacter(c);
                    break;
            }
        }
    }

    private void MoveCursorLeft()
    {
        if (cursorCol > 0)
        {
            cursorCol--;
        }
    }

    private void MoveCursorRight()
    {
        if (cursorCol < lines[cursorRow].Length)
        {
            cursorCol++;
        }
    }

    private void MoveCursorUp()
    {
        if (cursorRow > 0)
        {
            cursorRow--;
        }
    }

    private void MoveCursorDown()
    {
        if (cursorRow < lines.Count - 1)
        {
            cursorRow++;
        }
    }

    private void MoveCursorToBeginning()
    {
        cursorCol = 0;
    }

    private void MoveCursorToEnd()
    {
        cursorCol = lines[cursorRow].Length;
    }

    private void InsertNewline()
    {
        string remainder = lines[cursorRow].Substring(cursorCol,lines[cursorRow].Length);
        lines[cursorRow] = lines[cursorRow].Substring(0, cursorCol);
        lines.Insert(cursorRow + 1, remainder);
        cursorRow++;
        cursorCol = 0;
    }

    private void InsertCharacter(char c)
    {
        lines[cursorRow] = lines[cursorRow].Insert(cursorCol, c.ToString());
        cursorCol++;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string line in lines)
        {
            sb.AppendLine(line);
        }
        return sb.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
         int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++){
        SimpleTerminal terminal = new SimpleTerminal();
        string input = Console.ReadLine();
        terminal.ProcessInput(input);
        Console.WriteLine(terminal + "-");
        }
    }
}