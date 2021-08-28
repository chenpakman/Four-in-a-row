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
        private readonly Button r_DoneButton = new Button();

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
            r_Player1Lable.Location = new Point(r_PlayersLable.Left + 30, r_PlayersLable.Top + 25);
            this.Controls.Add(r_Player1Lable);

            r_Player1TextBox.Location = new Point(r_Player1Lable.Right + 40, r_Player1Lable.Top);
            this.Controls.Add(r_Player1TextBox);

            r_Player2CheckBox.Location = new Point(r_Player1Lable.Left, r_Player1Lable.Top + 35);
            r_Player2CheckBox.AutoSize = true;
            r_Player2CheckBox.Checked = false;
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



            this.Text = "Game Settings";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;


        }
    }
}
