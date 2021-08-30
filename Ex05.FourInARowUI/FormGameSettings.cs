using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.FourInARowUI
{
    public partial class FormGameSettings : Form
    {
        private string m_Player1Name = string.Empty;
        private string m_Player2Name = "Computer";

        public FormGameSettings()
        {
            InitializeComponent();
        }

        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }
        }

        public string Player2Name
        {
            get
            {
                return m_Player2Name;
            }
        }

        public int BoardCols
        {
            get
            {
                return (int)numericUpDownCols.Value;
            }
        }

        public int BoardRows
        {
            get
            {
                return (int)numericUpDownRows.Value;
            }
        }

        public int Player2Type()
        {
            int playerType = 2;
            if(!checkBoxPlayer2.Checked)
            {
                playerType = 1;
            }

            return playerType;
        }

        private void buttonStart_Click(object i_Sender, EventArgs i_E)
        {
            this.Close();
            updatePlayer1Name();
            updatePlayer2Name();
            this.DialogResult = DialogResult.OK;
        }

        private void checkBoxPlayer2_CheckedChanged(object i_Sender, EventArgs i_E)
        {
            if(!textBoxPlayer2.Enabled)
            {
                textBoxPlayer2.Enabled = true;
                this.textBoxPlayer2.BackColor = Color.White;
                this.textBoxPlayer2.Text = String.Empty;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                this.textBoxPlayer2.BackColor = SystemColors.Control;
                this.textBoxPlayer2.Text = @"[Computer]";
            }
        }

        private void updatePlayer1Name()
        {
            m_Player1Name = textBoxPlayer1.Text == string.Empty ? "Player 1" : textBoxPlayer1.Text;
        }

        private void updatePlayer2Name()
        {
            if(!checkBoxPlayer2.Checked)
            {
                m_Player2Name = "Computer";
            }
            else
            {
                m_Player2Name = textBoxPlayer2.Text == string.Empty ? "Player 2" : textBoxPlayer2.Text;
            }
        }
    }
}