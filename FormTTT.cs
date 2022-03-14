using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class FormTTT : Form
    {
        #region INTERNAL FIELDS

        private Game game;
        private Label[] cells;

        #endregion

        #region CONSTRUCTORS

        public FormTTT()
        {
            InitializeComponent();
        }

        #endregion

        #region FORM HANDLERS

        /// <summary>
        /// 
        /// Creates and array of the labels used to display the 
        /// board; and assigns the labels' handlers and information
        /// for the events needed for the GUI funcionality.
        /// 
        /// </summary>
        /// 
        private void FormTTT_Load(object sender, EventArgs e)
        {
            int i = 0;
            this.cells = new Label[] { Cell11, Cell12, Cell13, Cell21, Cell22, Cell23, Cell31, Cell32, Cell33 };
            foreach (Label cell in this.cells)
            {
                cell.Tag = new Position(i/3+1, i%3+1);
                i++;
                cell.Click += OnClickPosition;
                cell.MouseEnter += OnMouseEnter;
                cell.MouseLeave += OnMouseLeave;
            }
            ResetControls();
        }

        /// <summary>
        /// 
        /// Warns the players if a game is in progress when trying
        /// to close the form.
        /// 
        /// </summary>
        /// 
        private void FormTTT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(this.game is null) && this.game.State == Game.GameState.InProgress)
            {
                DialogResult result = MessageBox.Show("WARNING: There is game in progress. Are you sure to quit?",
                    "Game in Progress", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                e.Cancel = result == DialogResult.No;
            }
        }

        #endregion

        #region LABELS HANDLERS

        /// <summary>
        /// 
        /// Updates the GUI and game object based on the current
        /// player's selection to play.
        /// 
        /// </summary>
        /// 
        private void OnClickPosition(Object sender, EventArgs e)
        {
            Label cell = (Label)sender;
            cell.Text = this.game.PlayerInTurn.Piece.ToString();
            cell.Enabled = false;
            Position position = (Position)(cell.Tag);
            this.game.Play(position);
        }

        /// <summary>
        /// 
        /// Changes label background color when mouse pointer 
        /// enters its area.
        /// 
        /// </summary>
        /// 
        private void OnMouseEnter(Object sender, EventArgs e)
        {
            Label cell = (Label)sender;
            cell.BackColor = Color.Goldenrod;
        }

        /// <summary>
        /// 
        /// Changes back to label original background color.
        /// 
        /// /// </summary>
        /// 
        private void OnMouseLeave(Object sender, EventArgs e)
        {
            Label cell = (Label)sender;
            cell.BackColor = Color.BlanchedAlmond;
        }

        #endregion

        #region BUTTON HANDLERS

        /// <summary>
        /// 
        /// Starts the game.
        /// 
        /// </summary>
        /// 
        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.game = new Game(TxtPlayer1.Text, TxtPlayer2.Text);
            this.game.OnTurnFinished += OnTurnFinished;
            BeginGameControls();
        }

        /// <summary>
        /// 
        /// Reset all for a new game.
        /// 
        /// </summary>
        /// 
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        #endregion

        #region GUI METHODS

        /// <summary>
        /// 
        /// Sets GUI controls state after starting a game.
        /// 
        /// </summary>
        /// 
        private void BeginGameControls()
        {
            foreach (Label cell in this.cells)
            {
                cell.Enabled = true;
                cell.Text = "";
            }
            BtnStart.Enabled = false;
            TxtPlayer1.Enabled = false;
            TxtPlayer2.Enabled = false;
            LblMessage.Text = "The turn is now for " + game.PlayerInTurn.Name.ToUpper() + " with " + game.PlayerInTurn.Piece + "s.";
        }

        /// <summary>
        /// 
        /// Sets GUI controls state after ending a game.
        /// 
        /// </summary>
        /// 
        private void EndGameControls()
        {
            foreach (Label cell in this.cells)
            {
                cell.Enabled = false;
            }
            BtnStart.Text = "New Game";
            BtnStart.Enabled = true;
            BtnStart.Click -= this.BtnStart_Click;
            BtnStart.Click += this.BtnNewGame_Click;
            TxtPlayer1.Enabled = false;
            TxtPlayer2.Enabled = false;
        }

        /// <summary>
        /// 
        /// Sets GUI controls state before starting a game.
        /// 
        /// </summary>
        /// 
        private void ResetControls()
        {
            foreach (Label cell in this.cells)
            {
                cell.Enabled = false;
                cell.Text = "";
            }
            TxtPlayer1.Enabled = true;
            TxtPlayer2.Enabled = true;
            BtnStart.Text = "Start";
            BtnStart.Enabled = TxtPlayer1.Text != "" && TxtPlayer2.Text != "";
            BtnStart.Click -= this.BtnNewGame_Click;
            BtnStart.Click += this.BtnStart_Click;
            LblMessage.Text = "Please, set or change both player names to start a new game.";
        }

        #endregion

        #region TEXTBOX HANDLERS

        /// <summary>
        /// 
        /// The start button is enabled only when both names are
        /// non-empty strings.
        /// 
        /// </summary>
        /// 
        private void OnNameChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.Trim();
            BtnStart.Enabled = TxtPlayer1.Text != "" && TxtPlayer2.Text != "";
        }

        #endregion

        #region GAME HANDLERS

        /// <summary>
        /// 
        /// Handles the state-changed event of the game, displaying
        /// the notifications according the actual state of the game.
        /// 
        /// </summary>
        /// 
        private void OnTurnFinished()
        {
            switch (game.State)
            {
                case Game.GameState.Won:
                    LblMessage.Text = "CONGRATULATIONS " + game.PlayerInTurn.Name + "! You are the winner.";
                    EndGameControls();
                    break;
                case Game.GameState.Draw:
                    LblMessage.Text = "Tough game! Nobody won.";
                    EndGameControls();
                    break;
                case Game.GameState.InProgress:
                    LblMessage.Text = "The turn is now for " + game.PlayerInTurn.Name.ToUpper() + " with " + game.PlayerInTurn.Piece + "s.";
                    break;
            }
        }

        #endregion
    }
}
