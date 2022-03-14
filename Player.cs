namespace TicTacToe
{
    /// <summary>
    /// 
    /// This class represents a player.
    /// 
    /// </summary>
    /// 
    internal class Player
    {
        #region INTERNAL FIELDS

        private readonly string name;
        private readonly Piece piece;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// 
        /// Name of the player.
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// 
        /// Piece assigned to the player.
        /// 
        /// </summary>
        public Piece Piece
        {
            get
            {
                return this.piece;
            }
        }

        #endregion

        #region CONSTRUCTORS

        /// <param name="name">Name of the player.</param>
        /// <param name="piece">Piece assigned to the player.</param>
        public Player(string name, Piece piece)
        {
            this.name = name;
            this.piece = piece; 
        }

        #endregion

    }
}
