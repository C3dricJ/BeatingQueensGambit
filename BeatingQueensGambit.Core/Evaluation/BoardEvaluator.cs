using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Core.Evaluation;

public static class BoardEvaluator
{
    public static int Evaluate(
        ChessBoard board,
        PieceColor perspective)
    {
        int score = 0;

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var piece = board.Squares[row, column];

                if (piece == null)
                    continue;

                int value = GetPieceValue(piece);

                if (piece.Color == perspective)
                {
                    score += value;
                }
                else
                {
                    score -= value;
                }
            }
        }

        return score;
    }

    private static int GetPieceValue(Piece piece)
    {
        return piece switch
        {
            Pawn => 100,

            Knight => 320,

            Bishop => 330,

            Rook => 500,

            Queen => 900,

            King => 20000,

            _ => 0
        };
    }
}