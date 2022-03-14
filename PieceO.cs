namespace TicTacToe
{
    /// <summary>
    /// 
    /// This class represents the O piece of the game.
    /// 
    /// </summary>
    /// 
    internal class PieceO : Piece
    {
        #region CONSTRUCTORS

        public PieceO() : base('O') { }

        #endregion

        #region METHODS

        public override Piece Clone()
        {
            return new PieceO();
        }

        #endregion
    }
}
