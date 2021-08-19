using System;
using System.Collections.Generic;
using System.Linq;
using GambitChess.Game.Pieces;
using GambitChess.Game.Pieces.Types;

namespace GambitChess.Game
{
    public static class Variant
    {
        /// <summary>Regular chess.</summary>
        public static PieceSet Standard { get; } = new PieceSet(
            "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR",
            new[] { Side.White, Side.Black },
            CreatePieces((s, p) => new IPiece[]
            {
                new Pawn(s, p),
                new King(s)
            }, s => new IPiece[]
            {
                new Rook(s),
                new Bishop(s),
                new Knight(s),
                new Queen(s)
            }, new[] { Side.White, Side.Black }));

        private static IPiece[] CreatePieces(
            Func<Side, IEnumerable<IPiece>, IEnumerable<IPiece>> nonPromotable,
            Func<Side, IEnumerable<IPiece>> promotable,
            params Side[] sides)
        {
            List<IPiece> pieces = new();
            foreach (Side side in sides)
            {
                IPiece[] starting = promotable.Invoke(side).ToArray();
                pieces.AddRange(starting);
                pieces.AddRange(nonPromotable.Invoke(side, starting));
            }
            return pieces.ToArray();
        }
    }
}
