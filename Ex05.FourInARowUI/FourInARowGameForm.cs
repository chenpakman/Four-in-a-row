using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Ex05.FourInARowLogic;
using System.Threading;

namespace Ex05.FourInARowUI
{
    class FourInARowGameForm : Form
    {
        private Button[,] m_TheGameBoardButtons;
        private readonly List<Button> r_ChipLocaitionButtons = new List<Button>();
        private FormGameSettings r_GameSettings;
        private readonly Label r_player1Label = new Label();
        private readonly Label r_player2Label = new Label();
        private readonly FourInARow r_Game;


        public FourInARowGameForm(FormGameSettings i_GameSettings)
        {
            r_GameSettings = i_GameSettings;
            r_Game = new FourInARow(r_GameSettings.BoardCols, r_GameSettings.BoardRows, r_GameSettings.Player2Type());
            InitBoardGame();

        }

        public void InitBoardGame()
        {
            int width = r_GameSettings.BoardCols;
            int length = r_GameSettings.BoardRows;
            int topButtenForEachRow = 40;
            m_TheGameBoardButtons = new Button[width, length];
            for(int buttonIndex = 0; buttonIndex < width; buttonIndex++)
            {
                Button button = new Button();
                button.Text = (buttonIndex + 1).ToString();
                button.Size = new Size(30, 20);
                button.Location = new Point((buttonIndex + 1) * 35, 10);
                this.Controls.Add(button);
                button.Click += button_Click;
                r_ChipLocaitionButtons.Add(button);

            }

            for(int r = 0; r < r_GameSettings.BoardRows; r++)
            {


                for(int c = 0; c < r_GameSettings.BoardCols; c++)
                {
                    m_TheGameBoardButtons[c, r] = new Button();
                    m_TheGameBoardButtons[c, r].Size = new Size(30, 30);
                    m_TheGameBoardButtons[c, r].Location = new Point((c + 1) * 35, topButtenForEachRow);
                    m_TheGameBoardButtons[c, r].Enabled = false;
                    this.Controls.Add(m_TheGameBoardButtons[c, r]);
                }

                topButtenForEachRow = topButtenForEachRow + 40;

            }

            // this.r_player1Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            r_player1Label.Text = r_GameSettings.Player1Name + ":" + r_Game.GetPlayer1.PlayerScore;
            r_player1Label.AutoSize = true;
            r_player1Label.Location = new Point(
                m_TheGameBoardButtons[(width - 1) / 2, (length - 1) / 2].Left / 2,
                10 + m_TheGameBoardButtons[width - 1, length - 1].Bottom);
            this.Controls.Add(r_player1Label);

            r_player2Label.Text = r_GameSettings.Player2Name + ":" + r_Game.GetPlayer2.PlayerScore;
            r_player2Label.AutoSize = true;
            r_player2Label.Location = new Point(
                r_player1Label.Left + 30,
                10 + m_TheGameBoardButtons[width - 1, length - 1].Bottom);
            this.Controls.Add(r_player2Label);

            this.ClientSize = new Size(
                m_TheGameBoardButtons[width - 1, length - 1].Right + r_ChipLocaitionButtons[0].Left,
                m_TheGameBoardButtons[width - 1, length - 1].Bottom + r_ChipLocaitionButtons[0].Left);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = "4 in a Row !!";


        }
        private void updatePlayerScoreLabel()
        {
            r_player1Label.Text = r_GameSettings.Player1Name+":"+r_Game.GetCurrentPlayer().PlayerScore.ToString();
            r_player2Label.Text = r_GameSettings.Player2Name + ":"+r_Game.GetPreviousPlayer().PlayerScore.ToString();
        }

        private bool isGameOver(int i_CurrentChipRow, int i_PlayerColumnChoice)
        {
            //bool gameOver = r_Game.IsGameOver();
            bool gameTie = r_Game.TheGameBoard.IsFullBoard();
            bool gameWon = r_Game.IsPlayerWon(i_CurrentChipRow,i_PlayerColumnChoice);

                if (gameTie)
                {
                    announceTieAndCheckIfContinue();
                }
                else if (gameWon)
                {
                    //r_Game.GetCurrentPlayer().PlayerScore++;
                    announceWinAndCheckIfContinue();
                    
                }
            

            return gameTie|| gameWon;
        }

        private void announceWinAndCheckIfContinue()
        {
            r_Game.GetCurrentPlayer().PlayerScore += 1;
            DialogResult dialogResult = MessageBox.Show(
                string.Format("Player {1} Won:{0}Another round?", Environment.NewLine, r_Game.GetCurrentPlayer().NumberOfPlayer),
            "A Win!", MessageBoxButtons.YesNo);
            checkIfContinue(dialogResult);
        }
        private void announceTieAndCheckIfContinue()
        {
            DialogResult dialogResult = MessageBox.Show(
                string.Format("Tie!!{0}Another round?", System.Environment.NewLine),
                "A Tie!",
                MessageBoxButtons.YesNo);
            checkIfContinue(dialogResult);
        }

        private void checkIfContinue(DialogResult i_DialogResult)
        {
            if (i_DialogResult == DialogResult.Yes)
            {
                updatePlayerScoreLabel();
                clearTheGameBoardButtons();
                r_Game.InitGame();
                
            }
            else if (i_DialogResult == DialogResult.No)
            {
                quitGame();
            }
        }

        private void clearTheGameBoardButtons()
        {
            foreach (Button button in m_TheGameBoardButtons)
            {
                button.Text = string.Empty;
            }

        }
        private void quitGame()
        {
            string messageToTheUser= string.Format(
                "Game Over{0}Player 1 Score:{1}{0}Player 2 Score{2}",
                Environment.NewLine,
                r_Game.GetPlayer1.PlayerScore,
                r_Game.GetPlayer2.PlayerScore);
            MessageBox.Show(messageToTheUser, "Game Over");
            Application.Exit();
        }
        private void button_Click(object i_Sender, EventArgs i_E)
        {
            int o_CurrentChipRow = 0;
            bool isFullColumnForComputerMove = true;
            bool isFullColumnForHumanMove = false;
           
            if (!isGameOver(o_CurrentChipRow, int.Parse((i_Sender as Button).Text)))
            {
                r_Game.UpdateBoardAndMoveToNextTurn(int.Parse((i_Sender as Button).Text), ref o_CurrentChipRow, ref isFullColumnForHumanMove);
                m_TheGameBoardButtons[int.Parse((i_Sender as Button).Text) - 1, o_CurrentChipRow].Text =
               r_Game.GetCurrentPlayer().PlayerLetterType.ToString();
                if (r_Game.GetPlayer2.PlayerType == Player.ePlayerType.Computer && !isFullColumnForHumanMove && !isGameOver(o_CurrentChipRow, int.Parse((i_Sender as Button).Text)))
                {
                    
                    while(isFullColumnForComputerMove)
                    {
                        r_Game.UpdateBoardAndMoveToNextTurn(
                            r_Game.GetComputerChoice(),
                            ref o_CurrentChipRow,
                            ref isFullColumnForComputerMove);
                    }
                    Thread.Sleep(500);
                    m_TheGameBoardButtons[r_Game.GetComputerChoice()-1, o_CurrentChipRow].Text =
                        r_Game.GetPlayer2.PlayerLetterType.ToString();
                }
                
                //isGameOver(o_CurrentChipRow, int.Parse((i_Sender as Button).Text));
                if (r_Game.GetPlayer2.PlayerType == Player.ePlayerType.Person)
                { r_Game.m_GameRound++; }
            }

        }
    }
}
