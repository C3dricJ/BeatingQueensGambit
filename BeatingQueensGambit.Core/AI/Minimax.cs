using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Evaluation;
using BeatingQueensGambit.Core.Moves;

namespace BeatingQueensGambit.Core.AI;

public static class Minimax
{
    public static int Search(
        ChessBoard board,
        PieceColor perspective)
    {
        var moves =
            MoveGenerator.GenerateLegalMoves(
                board,
                perspective);

        // No legal moves.
        if (moves.Count == 0)
        {
            return BoardEvaluator.Evaluate(
                board,
                perspective);
        }

        int bestScore = int.MinValue;

        foreach (Move move in moves)
        {
            var clone = board.Clone();

            clone.ApplyMove(move);

            int score =
                BoardEvaluator.Evaluate(
                    clone,
                    perspective);

            if (score > bestScore)
            {
                bestScore = score;
            }
        }

        return bestScore;
    }
}