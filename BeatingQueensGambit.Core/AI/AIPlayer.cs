using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Moves;

namespace BeatingQueensGambit.Core.AI;

public static class AIPlayer
{
    public static Move? FindBestMove(
        ChessBoard board,
        PieceColor color,
        int depth)
    {
        Move? bestMove = null;

        int bestScore = int.MinValue;

        var moves =
            MoveGenerator.GenerateLegalMoves(
                board,
                color);

        foreach (var move in moves)
        {
            var clone = board.Clone();

            clone.ApplyMove(move);

            int score =
                Minimax.Search(
                    clone,
                    depth - 1,
                    false,
                    color);

            if (score > bestScore)
            {
                bestScore = score;
                bestMove = move;
            }
        }

        return bestMove;
    }
}