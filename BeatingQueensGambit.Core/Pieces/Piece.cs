using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Pieces;

public abstract class Piece
{
    public PieceColor Color { get; }

    public PieceType Type { get; }

    public bool IsWhite => Color == PieceColor.White;

    public bool IsBlack => Color == PieceColor.Black;

    protected Piece(PieceColor color, PieceType type)
    {
        Color = color;
        Type = type;
    }

    public abstract IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition);
}