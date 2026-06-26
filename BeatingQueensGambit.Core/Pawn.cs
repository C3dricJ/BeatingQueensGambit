using BeatingQueensGambit.Core.Enums;

namespace BeatingQueensGambit.Core.Pieces;

public class Pawn : Piece
{
    public Pawn(PieceColor color)
        : base(color, PieceType.Pawn)
    {
    }
}