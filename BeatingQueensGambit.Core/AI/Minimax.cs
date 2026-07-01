using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Evaluation;

namespace BeatingQueensGambit.Core.AI;

public static class Minimax
{
    public static int Search(
        ChessBoard board,
        int depth,
        bool maximizingPlayer,
        PieceColor perspective)
    {
        if (depth == 0)
        {
            return BoardEvaluator.Evaluate(
                board,
                perspective);
        }

        PieceColor currentColor =
            maximizingPlayer
                ? perspective
                : (perspective == PieceColor.White
                    ? PieceColor.Black
                    : PieceColor.White);

        var moves =
            MoveGenerator.GenerateLegalMoves(
                board,
                currentColor);

        if (moves.Count == 0)
        {
            return BoardEvaluator.Evaluate(
                board,
                perspective);
        }

        if (maximizingPlayer)
        {
            int bestScore = int.MinValue;

            foreach (var move in moves)
            {
                var clone = board.Clone();

                clone.ApplyMove(move);

                int score =
                    Search(
                        clone,
                        depth - 1,
                        false,
                        perspective);

                bestScore =
                    Math.Max(bestScore, score);
            }

            return bestScore;
        }

        int worstScore = int.MaxValue;

        foreach (var move in moves)
        {
            var clone = board.Clone();

            clone.ApplyMove(move);

            int score =
                Search(
                    clone,
                    depth - 1,
                    true,
                    perspective);

            worstScore =
                Math.Min(worstScore, score);
        }

        return worstScore;
    }
}