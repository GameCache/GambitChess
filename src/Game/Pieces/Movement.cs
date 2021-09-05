namespace GambitChess.Game.Pieces
{
    /// <summary>Details for how a piece can move.</summary>
    /// <param name="ChangeX">Rank change.</param>
    /// <param name="ChangeY">File change.</param>
    /// <param name="RepeatWhileEmpty">If the movement can continue if potentially ending in an empty square.</param>
    /// <param name="CanCapture">If the movement can end by capturing an opposing piece.</param>
    /// <param name="MustCapture">If the movement must end with capturing an opposing piece.</param>
    internal record Movement(
        int ChangeX,
        int ChangeY,
        bool RepeatWhileEmpty,
        bool CanCapture,
        bool MustCapture)
    { }
}