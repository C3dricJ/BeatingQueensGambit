namespace BeatingQueensGambit.Core.Models;

/// <summary>
/// Represents one square on the chess board.
/// </summary>
public class Position : IEquatable<Position>
{
    public int Row { get; }

    public int Column { get; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool Equals(Position? other)
    {
        if (other is null)
            return false;

        return Row == other.Row &&
               Column == other.Column;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Position);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }
}