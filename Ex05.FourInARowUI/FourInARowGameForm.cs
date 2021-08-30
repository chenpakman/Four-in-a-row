using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ex05.FourInARowLogic;
using System.Threading;

namespace Ex05.FourInARowUI
{
    internal class FourInARowGameForm : Form
    {
        private Button[,] m_TheGameBoardButtons;
        private readonly List<Button> r_ChipLocationButtons = new List<Button>();
        private readonly FormGameSettings r_GameSettings;
        private readonly Label r_LabelPlayer1 = new Label();
        private readonly Label r_LabelPlayer2 = new Label();
        private readonly FourInARow r_Game;

        public FourInARowGameForm()
        {
            r_GameSettings = new FormGameSettings();
            if(r_GameSettings.ShowDialog() == DialogResult.OK)
            {
                r_Game = new FourInARow(
                    r_GameSettings.BoardCols,
                    r_GameSettings.BoardRows,
                    r_GameSettings.Player2Type());
                initBoardGame();
                ShowDialog();
            }
        }

        private void initBoardGame()
        {
            int width = r_GameSettings.BoardCols;
            int length = r_GameSettings.BoardRows;
            int topButtonForEachRow = 40;

            m_TheGameBoardButtons = new Button[length, width];
            for(int buttonIndex = 0; buttonIndex < width; buttonIndex++)
            {
                Button button = new Button();
                button.Text = (buttonIndex + 1).ToString();
                button.Size = new Size(30, 20);
                button.Location = new Point((buttonIndex + 1) * 35, 10);
                this.Controls.Add(button);
                button.Click += button_Click;
                r_ChipLocationButtons.Add(button);
            }

            for(int r = 0; r < r_GameSettings.BoardRows; r++)
            {
                for(int c = 0; c < r_GameSettings.BoardCols; c++)
                {
                    m_TheGameBoardButtons[r, c] = new Button();
                    m_TheGameBoardButtons[r, c].Size = new Size(30, 30);
                    m_TheGameBoardButtons[r, c].Location = new Point((c + 1) * 35, topButtonForEachRow);
                    m_TheGameBoardButtons[r, c].Enabled = false;
                    this.Controls.Add(m_TheGameBoardButtons[r, c]);
                }

                topButtonForEachRow = topButtonForEachRow + 40;
            }

            r_LabelPlayer1.Text = r_GameSettings.Player1Name + ':' + r_Game.GetPlayer1.PlayerScore;
            r_LabelPlayer1.AutoSize = true;
            r_LabelPlayer1.Location = new Point(
                m_TheGameBoardButtons[(length - 1) / 2, (width - 1) / 2].Left / 2,
                10 + m_TheGameBoardButtons[length - 1, width - 1].Bottom);
            this.Controls.Add(r_LabelPlayer1);

            r_LabelPlayer2.Text = r_GameSettings.Player2Name + ':' + r_Game.GetPlayer2.PlayerScore;
            r_LabelPlayer2.AutoSize = true;
            r_LabelPlayer2.Location = new Point(
                r_LabelPlayer1.Right + 10,
                10 + m_TheGameBoardButtons[length - 1, width - 1].Bottom);
            this.Controls.Add(r_LabelPlayer2);

            this.ClientSize = new Size(
                m_TheGameBoardButtons[length - 1, width - 1].Right + r_ChipLocationButtons[0].Left,
                m_TheGameBoardButtons[length - 1, width - 1].Bottom + r_ChipLocationButtons[0].Left);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = "4 in a Row !!";
        }

        private void updatePlayerScoreLabel()
        {
            r_LabelPlayer1.Text = r_GameSettings.Player1Name + ':' + r_Game.GetCurrentPlayer().PlayerScore.ToString();
            r_LabelPlayer2.Text = r_GameSettings.Player2Name + ':' + r_Game.GetPreviousPlayer().PlayerScore.ToString();
        }

        private bool isGameOver(int i_CurrentChipRow, int i_PlayerColumnChoice)
        {
            bool gameTie = r_Game.TheGameBoard.IsFullBoard();
            r_Game.IsPlayerWon(i_CurrentChipRow, i_PlayerColumnChoice);
            bool gameWon = r_Game.GetCurrentPlayer().IsPlayerWon;
            if(gameTie)
            {
                announceTieAndCheckIfContinue();
            }
            else if(gameWon)
            {
                announceWinAndCheckIfContinue();
            }

            return gameTie || gameWon;
        }

        private void announceWinAndCheckIfContinue()
        {
            r_Game.GetCurrentPlayer().PlayerScore += 1;
            DialogResult dialogResult = MessageBox.Show(
                string.Format(
                    @"Player {1} Won:{0}Another round?",
                    Environment.NewLine,
                    r_Game.GetCurrentPlayer().NumberOfPlayer),
                @"A Win!",
                MessageBoxButtons.YesNo);
            checkIfContinue(dialogResult);
        }

        private void announceTieAndCheckIfContinue()
        {
            DialogResult dialogResult = MessageBox.Show(
                string.Format(@"Tie!!{0}Another round?", System.Environment.NewLine),
                @"A Tie!",
                MessageBoxButtons.YesNo);

            checkIfContinue(dialogResult);
        }

        private void checkIfContinue(DialogResult i_DialogResult)
        {
            if(i_DialogResult == DialogResult.Yes)
            {
                enableButtons();
                updatePlayerScoreLabel();
                clearTheGameBoardButtons();
                r_Game.InitGame();
            }
            else if(i_DialogResult == DialogResult.No)
            {
                quitGame();
            }
        }

        private void clearTheGameBoardButtons()
        {
            foreach(Button button in m_TheGameBoardButtons)
            {
                button.Text = string.Empty;
            }
        }

        private void quitGame()
        {
            string messageToTheUser = string.Format(
                "Game Over{0}Player 1 Score:{1}{0}Player 2 Score{2}",
                Environment.NewLine,
                r_Game.GetPlayer1.PlayerScore,
                r_Game.GetPlayer2.PlayerScore);

            MessageBox.Show(messageToTheUser, "Game Over");
            Application.Exit();
        }

        private void button_Click(object i_Sender, EventArgs i_E)
        {
            int currentChipRowPerson = 0;
            bool isFullColumnForHumanMove = false;
            Button selectedButton = i_Sender as Button;
            int theButtonNumber = int.Parse(selectedButton.Text);
            bool doComputerMove;

            humanMove(theButtonNumber, ref isFullColumnForHumanMove, ref currentChipRowPerson);
            if(!isGameOver(currentChipRowPerson, theButtonNumber))
            {
                doComputerMove = r_Game.GetPlayer2.PlayerType == Player.ePlayerType.Computer
                                 && !isFullColumnForHumanMove;
                if(doComputerMove)
                {
                    computerMove();
                }
                else
                {
                    r_Game.m_GameRound++;
                }
            }
        }

        private void humanMove(
            int i_SelectedButtonNumber,
            ref bool o_IsFullColumnForHumanMove,
            ref int io_CurrentChipRowPerson)
        {
            r_Game.UpdateNewChipInBoard(
                i_SelectedButtonNumber,
                ref io_CurrentChipRowPerson,
                ref o_IsFullColumnForHumanMove,
                (char)r_Game.GetCurrentPlayer().PlayerLetterType);
            m_TheGameBoardButtons[io_CurrentChipRowPerson, i_SelectedButtonNumber - 1].Text =
                ((char)r_Game.GetCurrentPlayer().PlayerLetterType).ToString();
            m_TheGameBoardButtons[io_CurrentChipRowPerson, i_SelectedButtonNumber - 1].Enabled = true;
            m_TheGameBoardButtons[io_CurrentChipRowPerson, i_SelectedButtonNumber - 1].Enabled = false;
            if(r_Game.TheGameBoard.IsFullColumn(i_SelectedButtonNumber - 1))
            {
                r_ChipLocationButtons[i_SelectedButtonNumber - 1].Enabled = false;
            }
        }

        private void computerMove()
        {
            int computerChoice = 0;
            bool isFullColumnForComputerMove = true;
            int currentChipRowComputer = 0;

            while(isFullColumnForComputerMove)
            {
                computerChoice = r_Game.GetComputerChoice();
                r_Game.UpdateNewChipInBoard(
                    computerChoice,
                    ref currentChipRowComputer,
                    ref isFullColumnForComputerMove,
                    (char)r_Game.GetPreviousPlayer().PlayerLetterType);
            }

            if(r_Game.TheGameBoard.IsFullColumn(computerChoice - 1))
            {
                r_ChipLocationButtons[computerChoice - 1].Enabled = false;
            }

            Thread.Sleep(500);
            m_TheGameBoardButtons[currentChipRowComputer, computerChoice - 1].Text =
                ((char)r_Game.GetPreviousPlayer().PlayerLetterType).ToString();
            m_TheGameBoardButtons[currentChipRowComputer, computerChoice - 1].Enabled = true;
            m_TheGameBoardButtons[currentChipRowComputer, computerChoice - 1].Enabled = false;
            r_Game.m_GameRound++;
            if(!isGameOver(currentChipRowComputer, computerChoice))
            {
                r_Game.m_GameRound--;
            }
        }

        private void enableButtons()
        {
            for(int buttonIndex = 0; buttonIndex < r_GameSettings.BoardCols; buttonIndex++)
            {
                r_ChipLocationButtons[buttonIndex].Enabled = true;
            }
        }
    }
}