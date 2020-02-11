namespace Security_Office_Sign_In
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.signTest = new System.Windows.Forms.Label();
            this.fridayLabel = new System.Windows.Forms.Label();
            this.apptBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.ComboBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.squadronBox = new System.Windows.Forms.ComboBox();
            this.squadronLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(183, 86);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(218, 20);
            this.nameBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appointment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date:";
            // 
            // signTest
            // 
            this.signTest.AutoSize = true;
            this.signTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signTest.Location = new System.Drawing.Point(138, 7);
            this.signTest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signTest.Name = "signTest";
            this.signTest.Size = new System.Drawing.Size(278, 44);
            this.signTest.TabIndex = 6;
            this.signTest.Text = "PLEASE SIGN IN";
            this.signTest.UseCompatibleTextRendering = true;
            // 
            // fridayLabel
            // 
            this.fridayLabel.AutoSize = true;
            this.fridayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fridayLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.fridayLabel.Location = new System.Drawing.Point(9, 42);
            this.fridayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.Size = new System.Drawing.Size(561, 31);
            this.fridayLabel.TabIndex = 7;
            this.fridayLabel.Text = "***Security Office Closed on Down Fridays***";
            // 
            // apptBox
            // 
            this.apptBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apptBox.FormattingEnabled = true;
            this.apptBox.Location = new System.Drawing.Point(183, 133);
            this.apptBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.apptBox.Name = "apptBox";
            this.apptBox.Size = new System.Drawing.Size(135, 21);
            this.apptBox.TabIndex = 2;
            this.apptBox.SelectedIndexChanged += new System.EventHandler(this.apptBox_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(184, 158);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker.MinDate = new System.DateTime(2019, 12, 17, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker.TabIndex = 3;
            this.dateTimePicker.Value = new System.DateTime(2019, 12, 17, 0, 0, 0, 0);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(146, 183);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "Time:";
            // 
            // timeBox
            // 
            this.timeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeBox.FormattingEnabled = true;
            this.timeBox.Location = new System.Drawing.Point(183, 180);
            this.timeBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(92, 21);
            this.timeBox.TabIndex = 4;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(70, 205);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(107, 13);
            this.lblDesc.TabIndex = 12;
            this.lblDesc.Text = "Description (If Other):";
            // 
            // descBox
            // 
            this.descBox.Enabled = false;
            this.descBox.Location = new System.Drawing.Point(183, 205);
            this.descBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(218, 70);
            this.descBox.TabIndex = 5;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(225, 279);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(76, 30);
            this.btnEnter.TabIndex = 6;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // squadronBox
            // 
            this.squadronBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.squadronBox.FormattingEnabled = true;
            this.squadronBox.Location = new System.Drawing.Point(183, 109);
            this.squadronBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.squadronBox.Name = "squadronBox";
            this.squadronBox.Size = new System.Drawing.Size(76, 21);
            this.squadronBox.TabIndex = 1;
            // 
            // squadronLbl
            // 
            this.squadronLbl.AutoSize = true;
            this.squadronLbl.Location = new System.Drawing.Point(123, 111);
            this.squadronLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.squadronLbl.Name = "squadronLbl";
            this.squadronLbl.Size = new System.Drawing.Size(56, 13);
            this.squadronLbl.TabIndex = 16;
            this.squadronLbl.Text = "Squadron:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 318);
            this.Controls.Add(this.squadronLbl);
            this.Controls.Add(this.squadronBox);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.apptBox);
            this.Controls.Add(this.fridayLabel);
            this.Controls.Add(this.signTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Security Office Sign-In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label signTest;
        private System.Windows.Forms.Label fridayLabel;
        private System.Windows.Forms.ComboBox apptBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox timeBox;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ComboBox squadronBox;
        private System.Windows.Forms.Label squadronLbl;
    }
}

