using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Moves;
using BeatingQueensGambit.Core.Rules;

namespace BeatingQueensGambit.Core.AI;

public static class MoveGenerator
{
    public static List<Move> GenerateLegalMoves(
        ChessBoard board,
        PieceColor color)
    {
        var legalMoves = new List<Move>();

        foreach (var position in board.GetAllOccupiedSquares())
        {
            var piece = board.GetPiece(position);

            if (piece == null)
                continue;

            if (piece.Color != color)
                continue;

            var destinations =
                piece.GetLegalMoves(board, position);

            foreach (var destination in destinations)
            {
                var clone = board.Clone();

                clone.ApplyMove(
                    new Move(position, destination));

                if (!KingSafety.IsKingInCheck(
                    clone,
                    color))
                {
                    legalMoves.Add(
                        new Move(position, destination));
                }
            }
        }

        return legalMoves;
    }
}