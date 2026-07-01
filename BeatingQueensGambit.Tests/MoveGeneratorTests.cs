using Xunit;
using BeatingQueensGambit.Core.AI;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Tests;

public class MoveGeneratorTests
{
    [Fact]
    public void WhiteKingHasMoves()
    {
        var board = new ChessBoard();

        board.SetPiece(
            new Position(7,4),
            new King(PieceColor.White));

        board.SetPiece(
            new Position(0,4),
            new King(PieceColor.Black));

        var moves =
            MoveGenerator.GenerateLegalMoves(
                board,
                PieceColor.White);

        Assert.NotEmpty(moves);
    }

    [Fact]
    public void BlackKingHasMoves()
    {
        var board = new ChessBoard();

        board.SetPiece(
            new Position(7,4),
            new King(PieceColor.White));

        board.SetPiece(
            new Position(0,4),
            new King(PieceColor.Black));

        var moves =
            MoveGenerator.GenerateLegalMoves(
                board,
                PieceColor.Black);

        Assert.NotEmpty(moves);
    }

    [Fact]
    public void EmptyBoardHasNoMoves()
    {
        var board = new ChessBoard();

        var moves =
            MoveGenerator.GenerateLegalMoves(
                board,
                PieceColor.White);

        Assert.Empty(moves);
    }
}