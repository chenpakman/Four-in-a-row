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
           
            m_TheGameBoardButtons = new Button[length, width];
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
                    m_TheGameBoardButtons[r,c] = new Button();
                    m_TheGameBoardButtons[r, c].Size = new Size(30, 30);
                    m_TheGameBoardButtons[r, c].Location = new Point((c + 1) * 35, topButtenForEachRow);
                    m_TheGameBoardButtons[r, c].Enabled = false;
                    this.Controls.Add(m_TheGameBoardButtons[r, c]);
                }

                topButtenForEachRow = topButtenForEachRow + 40;

            }

            // this.r_player1Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            r_player1Label.Text = r_GameSettings.Player1Name + ":" + r_Game.GetPlayer1.PlayerScore;
            r_player1Label.AutoSize = true;
            r_player1Label.Location = new Point(
                m_TheGameBoardButtons[(length - 1) / 2,(width - 1) / 2].Left / 2,
                10 + m_TheGameBoardButtons[ length - 1, width - 1].Bottom);
            this.Controls.Add(r_player1Label);

            r_player2Label.Text = r_GameSettings.Player2Name + ":" + r_Game.GetPlayer2.PlayerScore;
            r_player2Label.AutoSize = true;
            r_player2Label.Location = new Point(
                r_player1Label.Left + 30,
                10 + m_TheGameBoardButtons[ length - 1, width - 1].Bottom);
            this.Controls.Add(r_player2Label);

            this.ClientSize = new Size(
                m_TheGameBoardButtons[length - 1, width - 1].Right + r_ChipLocaitionButtons[0].Left,
                m_TheGameBoardButtons[length - 1, width - 1].Bottom + r_ChipLocaitionButtons[0].Left);
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
             r_Game.IsPlayerWon(i_CurrentChipRow,i_PlayerColumnChoice);

                if (gameTie)
                {
                    announceTieAndCheckIfContinue();
                }
                else if (r_Game.GetCurrentPlayer().IsPlayerWon)
                {
                    //r_Game.GetCurrentPlayer().PlayerScore++;
                    announceWinAndCheckIfContinue();
                    
                }
            

            return gameTie|| r_Game.GetCurrentPlayer().IsPlayerWon;
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
            int o_CurrentChipRowCommputer = 0;
            int o_CurrentChipRowPerson = 0;
            int computerChoice = 0;
            bool isFullColumnForComputerMove = true;
            bool isFullColumnForHumanMove = false;
           
            
                r_Game.UpdateBoardAndMoveToNextTurn(int.Parse((i_Sender as Button).Text), ref o_CurrentChipRowPerson, ref isFullColumnForHumanMove,(char)r_Game.GetCurrentPlayer().PlayerLetterType);
                m_TheGameBoardButtons[o_CurrentChipRowPerson, int.Parse((i_Sender as Button).Text) - 1].Text =
              ((char)r_Game.GetCurrentPlayer().PlayerLetterType).ToString();
                m_TheGameBoardButtons[o_CurrentChipRowPerson, int.Parse((i_Sender as Button).Text) - 1].Enabled = true;
                m_TheGameBoardButtons[o_CurrentChipRowPerson, int.Parse((i_Sender as Button).Text) - 1].Enabled = false;
            //isGameOver(o_CurrentChipRowPerson, int.Parse((i_Sender as Button).Text));
              
            if (!isGameOver(o_CurrentChipRowPerson, int.Parse((i_Sender as Button).Text))&&r_Game.GetPlayer2.PlayerType == Player.ePlayerType.Computer && !isFullColumnForHumanMove )
                {
                r_Game.m_GameRound++;
                while (isFullColumnForComputerMove)
                    {
                        computerChoice = r_Game.GetComputerChoice();
                        r_Game.UpdateBoardAndMoveToNextTurn(
                            computerChoice,
                            ref o_CurrentChipRowCommputer,
                            ref isFullColumnForComputerMove, (char)r_Game.GetCurrentPlayer().PlayerLetterType);
                    }
                    Thread.Sleep(500);
                    m_TheGameBoardButtons[o_CurrentChipRowCommputer, computerChoice - 1].Text = ((char)r_Game.GetPlayer2.PlayerLetterType).ToString();
                    m_TheGameBoardButtons[o_CurrentChipRowCommputer, computerChoice - 1].Enabled = true;
                    m_TheGameBoardButtons[o_CurrentChipRowCommputer, computerChoice - 1].Enabled = false;
                
                isGameOver(o_CurrentChipRowCommputer, computerChoice);
               
            }


            r_Game.m_GameRound++;



        }
    }
}
