using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Moves;

namespace BeatingQueensGambit.Core.Openings;

public static class OpeningMoveParser
{
    public static Move Parse(string move)
    {
        Position from = ParseSquare(move[..2]);

        Position to = ParseSquare(move[2..4]);

        return new Move(from, to);
    }

    private static Position ParseSquare(string square)
    {
        int column = square[0] - 'a';

        int row = 8 - (square[1] - '0');

        return new Position(row, column);
    }
}