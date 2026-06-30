using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Moves;
using BeatingQueensGambit.Core.Rules;

namespace BeatingQueensGambit.Core.Game;

public static class MoveGenerator
{
    public static List<Move> GenerateLegalMoves(
        ChessBoard board,
        PieceColor currentPlayer)
    {
        var moves = new List<Move>();

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var piece = board.Squares[row, column];

                if (piece == null)
                    continue;

                if (piece.Color != currentPlayer)
                    continue;

                var from = new Position(row, column);

                foreach (var destination in piece.GetLegalMoves(board, from))
                {
                    var copy = board.Clone();

                    copy.ApplyMove(new Move(from, destination));

                    if (!KingSafety.IsKingInCheck(copy, currentPlayer))
                    {
                        moves.Add(new Move(from, destination));
                    }
                }
            }
        }

        return moves;
    }
}