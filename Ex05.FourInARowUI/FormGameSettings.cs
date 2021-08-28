using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.FourInARowUI
{
    class FormGameSettings:Form
    {
        private readonly Label r_BoardSizeLable= new Label();
        private readonly Label r_PlayersLable= new Label();
        private readonly Label r_Player1Lable= new Label();
        private readonly Label r_Player2Lable= new Label();
        private readonly Label r_ColsLable= new Label();
        private readonly Label r_RowsLable= new Label();
        private readonly NumericUpDown r_NumericUpDownRows = new NumericUpDown();
        private readonly NumericUpDown r_NumericUpDownCols = new NumericUpDown();
        private readonly TextBox r_Player1TextBox = new TextBox();
        private readonly TextBox r_Player2TextBox = new TextBox();
        private readonly CheckBox r_Player2CheckBox = new CheckBox();
        private readonly Button r_StartButton = new Button();

        public FormGameSettings()
        {
            initGameSettingsForm();

        }

        private void initGameSettingsForm()
        {
            r_PlayersLable.Text = "Players:";
            r_PlayersLable.AutoSize = true;
            r_PlayersLable.Location = new Point(15, 15);
            this.Controls.Add(r_PlayersLable);

            r_Player1Lable.Text = "Player 1:";
            r_Player1Lable.AutoSize = true;
            r_Player1Lable.Location = new Point(r_PlayersLable.Left + 15, r_PlayersLable.Top + 25);
            this.Controls.Add(r_Player1Lable);

            r_Player1TextBox.Location = new Point(r_Player1Lable.Right + 25, r_Player1Lable.Top);
            this.Controls.Add(r_Player1TextBox);

            r_Player2CheckBox.Location = new Point(r_Player1Lable.Left, r_Player1Lable.Top + 35);
            r_Player2CheckBox.AutoSize = true;
            r_Player2CheckBox.Checked = false;
            r_Player2CheckBox.CheckedChanged += Player2CheckBox_CheckedChanged;
            this.Controls.Add(r_Player2CheckBox);

            r_Player2Lable.Text = "Player 2:";
            r_Player2Lable.AutoSize = true;
            r_Player2Lable.Location = new Point(r_Player2CheckBox.Right, r_Player1Lable.Top + 35);
            this.Controls.Add(r_Player2Lable);

            r_Player2TextBox.Location = new Point(r_Player1TextBox.Left, r_Player2Lable.Top);
            r_Player2TextBox.Text = "[Computer]";
            r_Player2TextBox.Enabled = false;
            this.Controls.Add(r_Player2TextBox);


            r_BoardSizeLable.Text = "Board size:";
            r_BoardSizeLable.AutoSize = true;
            r_BoardSizeLable.Location = new Point(r_PlayersLable.Left, r_Player2Lable.Top+40);
            this.Controls.Add(r_BoardSizeLable);

            r_RowsLable.Text = "Rows :";
            r_RowsLable.AutoSize = true;
            r_RowsLable.Location = new Point(r_Player1Lable.Left, r_BoardSizeLable.Top+25);
            this.Controls.Add(r_RowsLable);

            r_NumericUpDownRows.Maximum = 10;
            r_NumericUpDownRows.Minimum = 4;
            r_NumericUpDownRows.Size = new System.Drawing.Size(38, 40);
            r_NumericUpDownRows.Location = new Point(r_RowsLable.Right + 5, r_RowsLable.Top);
            this.Controls.Add(r_NumericUpDownRows);

            r_ColsLable.Text = "Cols :";
            r_ColsLable.AutoSize = true;
            r_ColsLable.Location = new Point(r_NumericUpDownRows.Right + 15, r_RowsLable.Top);
            this.Controls.Add(r_ColsLable);

            r_NumericUpDownCols.Maximum = 10;
            r_NumericUpDownCols.Minimum = 4;
            r_NumericUpDownCols.Size = r_NumericUpDownRows.Size;
            r_NumericUpDownCols.Location = new Point(r_ColsLable.Right + 5, r_RowsLable.Top);
            this.Controls.Add(r_NumericUpDownCols);

            r_StartButton.Text = "Start!";
            r_StartButton.Click += startButton_click;
            r_StartButton.Size= new System.Drawing.Size(200, 20);
            r_StartButton.Location = new Point(r_PlayersLable.Left, r_RowsLable.Top + 40);
            this.Controls.Add(r_StartButton);

            this.Text = "Game Settings";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ClientSize = new Size(r_StartButton.Right + 10, r_StartButton.Top + 40);
            this.StartPosition = FormStartPosition.CenterScreen;



        }

        private void startButton_click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string Player1Name
        {
            get
            {
                return r_Player1TextBox.Text;
            }
            set
            {
                r_Player1TextBox.Text = value;
            }
        }

        public string Player2Name
        {
            get
            {
                return r_Player2TextBox.Text;
            }
            set
            {
                r_Player2TextBox.Text = value;
            }
        }

        public int BoardCols
        {
            get
            {
                return (int)r_NumericUpDownCols.Value;
            }
        }

        public int BoardRows
        {
            get
            {
                return (int)r_NumericUpDownRows.Value;
            }
        }

        public int Player2Type()
        {
            
            int playerType=2;
            if(!r_Player2CheckBox.Checked)
            {
                playerType = 1;
            }

            return playerType;

        }

        private void Player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (!r_Player2TextBox.Enabled)
            {
                r_Player2TextBox.Enabled = true;
                this.r_Player2TextBox.BackColor = Color.White;
                this.r_Player2TextBox.Text = String.Empty;
            }
            else
            {
                r_Player2TextBox.Enabled = false;
                this.r_Player2TextBox.BackColor = SystemColors.Control;
                this.r_Player2TextBox.Text = @"[Computer]";
            }
        }
    }
}
