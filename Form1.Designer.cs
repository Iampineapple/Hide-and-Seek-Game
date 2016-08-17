namespace Bookapp27_p332
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
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.goThroughTheDoorButton = new System.Windows.Forms.Button();
            this.goHereButton = new System.Windows.Forms.Button();
            this.exitsComboBox = new System.Windows.Forms.ComboBox();
            this.checkHiddenButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.numberKidsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.descriptionTextBox.Location = new System.Drawing.Point(13, 13);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(472, 255);
            this.descriptionTextBox.TabIndex = 0;
            // 
            // goThroughTheDoorButton
            // 
            this.goThroughTheDoorButton.Location = new System.Drawing.Point(12, 303);
            this.goThroughTheDoorButton.Name = "goThroughTheDoorButton";
            this.goThroughTheDoorButton.Size = new System.Drawing.Size(472, 23);
            this.goThroughTheDoorButton.TabIndex = 1;
            this.goThroughTheDoorButton.Text = "Go through the door";
            this.goThroughTheDoorButton.UseVisualStyleBackColor = true;
            this.goThroughTheDoorButton.Visible = false;
            this.goThroughTheDoorButton.Click += new System.EventHandler(this.goThroughTheDoorButton_Click);
            // 
            // goHereButton
            // 
            this.goHereButton.Location = new System.Drawing.Point(14, 274);
            this.goHereButton.Name = "goHereButton";
            this.goHereButton.Size = new System.Drawing.Size(75, 23);
            this.goHereButton.TabIndex = 2;
            this.goHereButton.Text = "Go here:";
            this.goHereButton.UseVisualStyleBackColor = true;
            this.goHereButton.Visible = false;
            this.goHereButton.Click += new System.EventHandler(this.goHereButton_Click);
            // 
            // exitsComboBox
            // 
            this.exitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitsComboBox.FormattingEnabled = true;
            this.exitsComboBox.Location = new System.Drawing.Point(95, 276);
            this.exitsComboBox.Name = "exitsComboBox";
            this.exitsComboBox.Size = new System.Drawing.Size(390, 21);
            this.exitsComboBox.TabIndex = 3;
            this.exitsComboBox.Visible = false;
            // 
            // checkHiddenButton
            // 
            this.checkHiddenButton.Location = new System.Drawing.Point(12, 332);
            this.checkHiddenButton.Name = "checkHiddenButton";
            this.checkHiddenButton.Size = new System.Drawing.Size(473, 23);
            this.checkHiddenButton.TabIndex = 4;
            this.checkHiddenButton.Text = "Check for hiding people";
            this.checkHiddenButton.UseVisualStyleBackColor = true;
            this.checkHiddenButton.Visible = false;
            this.checkHiddenButton.Click += new System.EventHandler(this.checkHiddenButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(237, 361);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(248, 23);
            this.hideButton.TabIndex = 5;
            this.hideButton.Text = "Hide";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // numberKidsComboBox
            // 
            this.numberKidsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberKidsComboBox.FormattingEnabled = true;
            this.numberKidsComboBox.Items.AddRange(new object[] {
            "One",
            "Two",
            "Three",
            "Four",
            "Five"});
            this.numberKidsComboBox.Location = new System.Drawing.Point(14, 362);
            this.numberKidsComboBox.Name = "numberKidsComboBox";
            this.numberKidsComboBox.Size = new System.Drawing.Size(217, 21);
            this.numberKidsComboBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 396);
            this.Controls.Add(this.numberKidsComboBox);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.checkHiddenButton);
            this.Controls.Add(this.exitsComboBox);
            this.Controls.Add(this.goHereButton);
            this.Controls.Add(this.goThroughTheDoorButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button goThroughTheDoorButton;
        private System.Windows.Forms.Button goHereButton;
        private System.Windows.Forms.ComboBox exitsComboBox;
        private System.Windows.Forms.Button checkHiddenButton;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.ComboBox numberKidsComboBox;
    }
}

