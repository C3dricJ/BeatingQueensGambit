using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Pieces;

public class Pawn : Piece
{
    public Pawn(PieceColor color)
        : base(color, PieceType.Pawn)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
    {
        return Enumerable.Empty<Position>();
    }
}