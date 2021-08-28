using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Ex05.FourInARowLogic;

namespace Ex05.FourInARowUI
{
    class FourInARowGameForm:Form
    {
        private  Button[,] m_TheGameBoardButtons;
        private  readonly List<Button> r_ChipLocaitionButtons=new List<Button>();
        private  FormGameSettings r_GameSettings;
        private readonly Label r_player1Label = new Label();
        private readonly Label r_player2Label = new Label();
        private readonly FourInARow r_Game;


        public FourInARowGameForm(FormGameSettings i_GameSettings)
        {
            r_GameSettings = i_GameSettings;
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
                button.Text = (buttonIndex+1).ToString();
                button.Size = new Size(30, 20);
                button.Location=new Point((buttonIndex+1)* 35,10);
                this.Controls.Add(button);
                r_ChipLocaitionButtons.Add(button);
                
            }
            for (int r = 0; r < r_GameSettings.BoardRows; r++)
            {
                

                for (int c = 0; c < r_GameSettings.BoardCols; c++)
                {
                    m_TheGameBoardButtons[c, r] = new Button();
                    m_TheGameBoardButtons[c, r].Size = new Size(30, 30);
                    m_TheGameBoardButtons[c, r].Location=new Point((c + 1) * 35, topButtenForEachRow);
                    m_TheGameBoardButtons[c, r].Enabled = false;
                    this.Controls.Add(m_TheGameBoardButtons[c, r]);
                }
                topButtenForEachRow = topButtenForEachRow +40;

            }

            this.r_player1Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            r_player1Label.Text = r_GameSettings.Player1Name+": 0";
            //r_player1Label.Location = new Point(m_TheGameBoardButtons[(width - 1)/2, (length - 1)/2].Left/2, 10 + m_TheGameBoardButtons[width - 1, length - 1].Bottom);
            this.r_player1Label.Location = new Point(90, 200);
            this.Controls.Add(r_player1Label);

            r_player2Label.Text = r_GameSettings.Player2Name;

            this.ClientSize = new Size(m_TheGameBoardButtons[width-1, length-1].Right+ r_ChipLocaitionButtons[0].Left, m_TheGameBoardButtons[width - 1, length - 1].Bottom+ r_ChipLocaitionButtons[0].Left);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = "4 in a Row !!";

        }

    }
}
