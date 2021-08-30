
namespace Ex05.FourInARowUI
{
    partial class FormGameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.LabelPlayer1 = new System.Windows.Forms.Label();
            this.LabelPlayer2 = new System.Windows.Forms.Label();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.NumericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.labelCols = new System.Windows.Forms.Label();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckBoxPlayer2
            // 
            this.CheckBoxPlayer2.AutoSize = true;
            this.CheckBoxPlayer2.Location = new System.Drawing.Point(61, 87);
            this.CheckBoxPlayer2.Name = "CheckBoxPlayer2";
            this.CheckBoxPlayer2.Size = new System.Drawing.Size(22, 21);
            this.CheckBoxPlayer2.TabIndex = 0;
            this.CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.CheckBoxPlayer2_CheckedChanged);
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(33, 26);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(64, 20);
            this.labelPlayers.TabIndex = 1;
            this.labelPlayers.Text = "Players:";
            // 
            // LabelPlayer1
            // 
            this.LabelPlayer1.AutoSize = true;
            this.LabelPlayer1.Location = new System.Drawing.Point(57, 58);
            this.LabelPlayer1.Name = "LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(65, 20);
            this.LabelPlayer1.TabIndex = 2;
            this.LabelPlayer1.Text = "Player1:";
            // 
            // LabelPlayer2
            // 
            this.LabelPlayer2.AutoSize = true;
            this.LabelPlayer2.Location = new System.Drawing.Point(89, 87);
            this.LabelPlayer2.Name = "LabelPlayer2";
            this.LabelPlayer2.Size = new System.Drawing.Size(69, 20);
            this.LabelPlayer2.TabIndex = 3;
            this.LabelPlayer2.Text = "Player 2:";
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(176, 84);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(143, 26);
            this.textBoxPlayer2.TabIndex = 4;
            this.textBoxPlayer2.Text = "[Computer]";
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(176, 52);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(143, 26);
            this.textBoxPlayer1.TabIndex = 5;
            this.textBoxPlayer1.Text = "Player 1";
            // 
            // NumericUpDownRows
            // 
            this.NumericUpDownRows.Location = new System.Drawing.Point(116, 203);
            this.NumericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDownRows.Name = "NumericUpDownRows";
            this.NumericUpDownRows.Size = new System.Drawing.Size(50, 26);
            this.NumericUpDownRows.TabIndex = 6;
            this.NumericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(269, 203);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(50, 26);
            this.numericUpDownCols.TabIndex = 7;
            this.numericUpDownCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(207, 205);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(44, 20);
            this.labelCols.TabIndex = 8;
            this.labelCols.Text = "Cols:";
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(57, 203);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(53, 20);
            this.labelRows.TabIndex = 9;
            this.labelRows.Text = "Rows:";
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(33, 157);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(92, 20);
            this.labelBoardSize.TabIndex = 10;
            this.labelBoardSize.Text = "Board size :";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(37, 282);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(282, 27);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 353);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.NumericUpDownRows);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.LabelPlayer2);
            this.Controls.Add(this.LabelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.CheckBoxPlayer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4 in a Row!";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxPlayer2;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label LabelPlayer1;
        private System.Windows.Forms.Label LabelPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.NumericUpDown NumericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Button buttonStart;
    }
}