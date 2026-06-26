using BeatingQueensGambit.Core.Enums;

namespace BeatingQueensGambit.Core.Pieces;

public abstract class Piece
{
    public PieceColor Color { get; }

    public PieceType Type { get; }

    protected Piece(PieceColor color, PieceType type)
    {
        Color = color;
        Type = type;
    }
}