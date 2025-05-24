namespace endlightout
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

            this.movesLabel = new System.Windows.Forms.Label();
            this.movesLabel.Text = "Moves: 0";
            this.Controls.Add(this.movesLabel);

            this.newGameButton = new System.Windows.Forms.Button();
            this.newGameButton.Text = "New Game";
            this.Controls.Add(this.newGameButton);
            
        
            this.gridSizeSelector = new System.Windows.Forms.ComboBox();
            this.gridSizeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gridSizeSelector.Items.AddRange(new object[] { "3", "4", "5", "6" });
            this.gridSizeSelector.Location = new System.Drawing.Point(10, 10);
            this.gridSizeSelector.SelectedIndexChanged += new System.EventHandler(this.GridSizeSelector_SelectedIndexChanged);
            this.Controls.Add(this.gridSizeSelector);
        




    }

    #endregion
}
}

