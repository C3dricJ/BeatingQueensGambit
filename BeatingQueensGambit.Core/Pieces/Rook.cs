using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Pieces;

public class Rook : Piece
{
    public Rook(PieceColor color)
        : base(color, PieceType.Rook)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
        {
           return Enumerable.Empty<Position>();
        }
}