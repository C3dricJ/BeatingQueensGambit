using BeatingQueensGambit.Core.Models;

namespace BeatingQueensGambit.Core.Moves;

/// <summary>
/// Represents a move from one square to another.
/// </summary>
public class Move
{
    public Position From { get; }

    public Position To { get; }

    public Move(Position from, Position to)
    {
        From = from;
        To = to;
    }

    public override string ToString()
    {
        return $"{From} -> {To}";
    }
}