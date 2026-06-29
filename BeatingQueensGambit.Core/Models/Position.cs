namespace BeatingQueensGambit.Core.Models;

/// <summary>
/// Represents one square on the chess board.
/// </summary>
public class Position
{
    public int Row { get; }

    public int Column { get; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override string ToString()
    {
        char file = (char)('a' + Column);
        int rank = 8 - Row;

        return $"{file}{rank}";
    }
}