using System;
using System.Collections.Generic;
using System.Linq;
using BeatingQueensGambit.Core.Game;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Moves;

namespace BeatingQueensGambit.Engine.AI;

public class ChessAI
{
    public Difficulty Difficulty { get; set; } = Difficulty.Easy;
    private readonly Random _random = new();

    public Move? ChooseMove(ChessGame game)
    {
        var legalMoves = GetAllLegalMoves(game);

        Console.WriteLine("--------------------------------");
        Console.WriteLine($"AI Turn: {game.CurrentTurn}");
        Console.WriteLine($"Status : {game.StatusMessage}");
        Console.WriteLine($"Legal Moves: {legalMoves.Count}");

        foreach (var move in legalMoves)
        {
            Console.WriteLine(
                $"{move.From.Row},{move.From.Column} -> {move.To.Row},{move.To.Column}");
        }

        Console.WriteLine("--------------------------------");

        if (legalMoves.Count == 0)
            return null;

        return legalMoves[_random.Next(legalMoves.Count)];
    }


    private List<Move> GetAllLegalMoves(ChessGame game)
    {
        var moves = new List<Move>();

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var from = new Position(row, column);

                var piece = game.Board.GetPiece(from);

                if (piece == null)
                    continue;

                if (piece.Color != game.CurrentTurn)
                    continue;

                foreach (var destination in game.GetLegalMoves(from))
                {
                    moves.Add(new Move(from, destination));
                }
            }
        }

        return moves;
    }

    private Move RandomMove(List<Move> moves)
    {
        return moves[_random.Next(moves.Count)];
    }

private Move CaptureMove(
    ChessGame game,
    List<Move> moves)
    {
        foreach (var move in moves)
        {
            if (game.Board.GetPiece(move.To) != null)
                return move;
        }

        return RandomMove(moves);
    }

private Move BestMove(
    ChessGame game,
    List<Move> moves)
    {
        Move? bestMove = null;

        int bestValue = -1;

        foreach (var move in moves)
        {
            var piece =
                game.Board.GetPiece(move.To);

            int value = piece switch
            {
                BeatingQueensGambit.Core.Pieces.Queen => 9,
                BeatingQueensGambit.Core.Pieces.Rook => 5,
                BeatingQueensGambit.Core.Pieces.Bishop => 3,
                BeatingQueensGambit.Core.Pieces.Knight => 3,
                BeatingQueensGambit.Core.Pieces.Pawn => 1,
                _ => 0
            };

            if (value > bestValue)
            {
                bestValue = value;
                bestMove = move;
            }
        }

        return bestMove ?? RandomMove(moves);
    }
}