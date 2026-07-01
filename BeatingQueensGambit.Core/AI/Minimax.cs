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
        PieceColor perspective,
        int alpha = int.MinValue,
        int beta = int.MaxValue)
    {
        if (depth == 0)
        {
            return BoardEvaluator.Evaluate(
                board,
                perspective);
        }

        PieceColor currentPlayer =
            maximizingPlayer
            ? perspective
            : perspective == PieceColor.White
                ? PieceColor.Black
                : PieceColor.White;

        var legalMoves =
            MoveGenerator.GenerateLegalMoves(
                board,
                currentPlayer);

        if (legalMoves.Count == 0)
        {
            return BoardEvaluator.Evaluate(
                board,
                perspective);
        }

        if (maximizingPlayer)
        {
            int value = int.MinValue;

            foreach (var move in legalMoves)
            {
                var clone = board.Clone();

                clone.ApplyMove(move);

                value = Math.Max(
                    value,
                    Search(
                        clone,
                        depth - 1,
                        false,
                        perspective,
                        alpha,
                        beta));

                alpha = Math.Max(alpha, value);

                if (beta <= alpha)
                {
                    break;
                }
            }

            return value;
        }

        int minValue = int.MaxValue;

        foreach (var move in legalMoves)
        {
            var clone = board.Clone();

            clone.ApplyMove(move);

            minValue = Math.Min(
                minValue,
                Search(
                    clone,
                    depth - 1,
                    true,
                    perspective,
                    alpha,
                    beta));

            beta = Math.Min(beta, minValue);

            if (beta <= alpha)
            {
                break;
            }
        }

        return minValue;
    }
}