using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex05.FourInARowUI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        public string Player1Name
        {
            get
            {
                return textBoxPlayer1.Text;
            }
            set
            {
                textBoxPlayer1.Text = value;
            }
        }

        public string Player2Name
        {
            get
            {
                return textBoxPlayer2.Text;
            }
            set
            {
                textBoxPlayer2.Text = value;
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
                return (int)NumericUpDownRows.Value;
            }
        }

        public int Player2Type()
        {

            int playerType = 2;
            if (!CheckBoxPlayer2.Checked)
            {
                playerType = 1;
            }

            return playerType;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (!textBoxPlayer2.Enabled)
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

        
    }
}
