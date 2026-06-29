using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Pieces;

public class Queen : Piece
{
    public Queen(PieceColor color)
        : base(color, PieceType.Queen)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
    ChessBoard board,
    Position currentPosition)
    {
        return Enumerable.Empty<Position>();
    }
}