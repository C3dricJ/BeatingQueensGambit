using BeatingQueensGambit.Core.Enums;

namespace BeatingQueensGambit.Core.Pieces;

public class Queen : Piece
{
    public Queen(PieceColor color)
        : base(color, PieceType.Queen)
    {
    }
}