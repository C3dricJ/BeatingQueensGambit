using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Pieces;

public class Bishop : Piece
{
    public Bishop(PieceColor color)
        : base(color, PieceType.Bishop)
    {
    }

    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
        {
           return Enumerable.Empty<Position>();
        }
}