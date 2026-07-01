using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Evaluation;

namespace BeatingQueensGambit.Core.AI;

public static class Minimax
{
    public static int Search(
        ChessBoard board,
        PieceColor perspective)
    {
        return BoardEvaluator.Evaluate(
            board,
            perspective);
    }
}