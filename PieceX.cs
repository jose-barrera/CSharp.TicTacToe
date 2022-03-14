namespace TicTacToe
{
    /// <summary>
    /// 
    /// This class represents the X piece of the game.
    /// 
    /// </summary>
    /// 
    internal class PieceX : Piece
    {
        #region CONSTRUCTORS

        public PieceX() : base('X') { }

        #endregion

        #region METHODS

        public override Piece Clone()
        {
            return new PieceX();
        }

        #endregion
    }
}
