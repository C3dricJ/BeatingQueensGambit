using BeatingQueensGambit.Core.Pieces;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Moves;

namespace BeatingQueensGambit.Core.Board;

public static class BoardInitializer
{
    public static void InitializeStandardBoard(ChessBoard board)
    {
        for (int column = 0; column < 8; column++)
        {
            // Place pawns
            board.Squares[1, column] = new Pawn(PieceColor.Black);
            board.Squares[6, column] = new Pawn(PieceColor.White);

            // Place rooks
            board.Squares[0,0] = new Rook(PieceColor.Black);
            board.Squares[0,7] = new Rook(PieceColor.Black);
            board.Squares[7,0] = new Rook(PieceColor.White);
            board.Squares[7,7] = new Rook(PieceColor.White);

            // Place knights
            board.Squares[0,1] = new Knight(PieceColor.Black);
            board.Squares[0,6] = new Knight(PieceColor.Black);
            board.Squares[7,1] = new Knight(PieceColor.White);
            board.Squares[7,6] = new Knight(PieceColor.White);

            // Place bishops
            board.Squares[0,2] = new Bishop(PieceColor.Black);
            board.Squares[0,5] = new Bishop(PieceColor.Black);
            board.Squares[7,2] = new Bishop(PieceColor.White);
            board.Squares[7,5] = new Bishop(PieceColor.White);

            // Place queens
            board.Squares[0,3] = new Queen(PieceColor.Black);
            board.Squares[7,3] = new Queen(PieceColor.White);

            // Place kings
            board.Squares[0,4] = new King(PieceColor.Black);
            board.Squares[7,4] = new King(PieceColor.White);
        }
    }

    public static void ApplyMove(
        ChessBoard board,
        string from,
        string to)
    {
        Position Parse(string square)
        {
            int column = square[0] - 'a';
            int row = 8 - int.Parse(square[1].ToString());

            return new Position(row, column);
        }

        board.ApplyMove(
            new Move(
                Parse(from),
                Parse(to)));
    }
}