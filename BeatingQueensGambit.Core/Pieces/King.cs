using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Pieces;

public class King : Piece
{
    public King(PieceColor color)
        : base(color, PieceType.King)
    {
    }

    
    public override IEnumerable<Position> GetLegalMoves(
        ChessBoard board,
        Position currentPosition)
        {
           return Enumerable.Empty<Position>();
        }
}