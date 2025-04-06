namespace QualityCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            calculateQualityButton = new Button();
            totalQualityTextbox = new TextBox();
            maximumQualityTextbox = new TextBox();
            upcycleTextbox = new TextBox();
            recyclerReturnTextbox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            CalculateQualityLabel = new Label();
            label6 = new Label();
            wantedQualityTextbox = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 81);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 0;
            label1.Text = "Total quality chance:";
            // 
            // calculateQualityButton
            // 
            calculateQualityButton.Location = new Point(189, 294);
            calculateQualityButton.Name = "calculateQualityButton";
            calculateQualityButton.Size = new Size(268, 23);
            calculateQualityButton.TabIndex = 1;
            calculateQualityButton.Text = "Calculate";
            calculateQualityButton.UseVisualStyleBackColor = true;
            calculateQualityButton.Click += calculateQualityButton_Click;
            // 
            // totalQualityTextbox
            // 
            totalQualityTextbox.Location = new Point(339, 73);
            totalQualityTextbox.Name = "totalQualityTextbox";
            totalQualityTextbox.Size = new Size(100, 23);
            totalQualityTextbox.TabIndex = 2;
            // 
            // maximumQualityTextbox
            // 
            maximumQualityTextbox.Location = new Point(339, 188);
            maximumQualityTextbox.Name = "maximumQualityTextbox";
            maximumQualityTextbox.Size = new Size(100, 23);
            maximumQualityTextbox.TabIndex = 3;
            maximumQualityTextbox.Text = "5";
            // 
            // upcycleTextbox
            // 
            upcycleTextbox.Location = new Point(339, 150);
            upcycleTextbox.Name = "upcycleTextbox";
            upcycleTextbox.Size = new Size(100, 23);
            upcycleTextbox.TabIndex = 4;
            upcycleTextbox.Text = "10";
            // 
            // recyclerReturnTextbox
            // 
            recyclerReturnTextbox.Location = new Point(339, 111);
            recyclerReturnTextbox.Name = "recyclerReturnTextbox";
            recyclerReturnTextbox.Size = new Size(100, 23);
            recyclerReturnTextbox.TabIndex = 5;
            recyclerReturnTextbox.Text = "25";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(204, 119);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 6;
            label2.Text = "Recycler return chance:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(240, 158);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 7;
            label3.Text = "Upcycle chance:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(202, 196);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 8;
            label4.Text = "Maximum quality level:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(204, 214);
            label5.Name = "label5";
            label5.Size = new Size(215, 15);
            label5.TabIndex = 9;
            label5.Text = "(1 for uncommon, 5 for legendary, etc.)";
            // 
            // CalculateQualityLabel
            // 
            CalculateQualityLabel.AutoSize = true;
            CalculateQualityLabel.Location = new Point(202, 331);
            CalculateQualityLabel.Name = "CalculateQualityLabel";
            CalculateQualityLabel.Size = new Size(0, 15);
            CalculateQualityLabel.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(216, 243);
            label6.Name = "label6";
            label6.Size = new Size(117, 15);
            label6.TabIndex = 11;
            label6.Text = "Wanted quality level:";
            // 
            // wantedQualityTextbox
            // 
            wantedQualityTextbox.Location = new Point(339, 235);
            wantedQualityTextbox.Name = "wantedQualityTextbox";
            wantedQualityTextbox.Size = new Size(100, 23);
            wantedQualityTextbox.TabIndex = 12;
            wantedQualityTextbox.Text = "5";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(204, 261);
            label7.Name = "label7";
            label7.Size = new Size(215, 15);
            label7.TabIndex = 13;
            label7.Text = "(1 for uncommon, 5 for legendary, etc.)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(wantedQualityTextbox);
            Controls.Add(label6);
            Controls.Add(CalculateQualityLabel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(recyclerReturnTextbox);
            Controls.Add(upcycleTextbox);
            Controls.Add(maximumQualityTextbox);
            Controls.Add(totalQualityTextbox);
            Controls.Add(calculateQualityButton);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button calculateQualityButton;
        private TextBox totalQualityTextbox;
        private TextBox maximumQualityTextbox;
        private TextBox upcycleTextbox;
        private TextBox recyclerReturnTextbox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label CalculateQualityLabel;
        private Label label6;
        private TextBox wantedQualityTextbox;
        private Label label7;
    }
}
