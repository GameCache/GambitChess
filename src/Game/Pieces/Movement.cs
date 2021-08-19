namespace GambitChess.Game.Pieces
{
    internal record Movement(
        int ChangeX,
        int ChangeY,
        bool RepeatWhileEmpty,
        bool CanCapture,
        bool MustCapture)
    { }
}