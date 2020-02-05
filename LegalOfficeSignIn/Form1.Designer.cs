namespace LegalOfficeSignIn
{
    partial class frmApptScheduler
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDuty = new System.Windows.Forms.Label();
            this.lblAppt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.dutyBox = new System.Windows.Forms.ComboBox();
            this.apptBox = new System.Windows.Forms.ComboBox();
            this.chkLegal = new System.Windows.Forms.CheckBox();
            this.cardBox = new System.Windows.Forms.ComboBox();
            this.noteBox = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.attnBox = new System.Windows.Forms.ComboBox();
            this.lblAttn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Schedule Appointment";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(77, 48);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblDuty
            // 
            this.lblDuty.AutoSize = true;
            this.lblDuty.Location = new System.Drawing.Point(50, 74);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(65, 13);
            this.lblDuty.TabIndex = 2;
            this.lblDuty.Text = "Duty Status:";
            // 
            // lblAppt
            // 
            this.lblAppt.AutoSize = true;
            this.lblAppt.Location = new System.Drawing.Point(46, 101);
            this.lblAppt.Name = "lblAppt";
            this.lblAppt.Size = new System.Drawing.Size(69, 13);
            this.lblAppt.TabIndex = 3;
            this.lblAppt.Text = "Appointment:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Legal Assistance:";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(56, 151);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(59, 13);
            this.lblCard.TabIndex = 5;
            this.lblCard.Text = "Card Type:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(82, 175);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(118, 45);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(156, 20);
            this.nameBox.TabIndex = 0;
            // 
            // dutyBox
            // 
            this.dutyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dutyBox.FormattingEnabled = true;
            this.dutyBox.Location = new System.Drawing.Point(118, 71);
            this.dutyBox.Name = "dutyBox";
            this.dutyBox.Size = new System.Drawing.Size(121, 21);
            this.dutyBox.TabIndex = 1;
            // 
            // apptBox
            // 
            this.apptBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apptBox.FormattingEnabled = true;
            this.apptBox.Location = new System.Drawing.Point(118, 98);
            this.apptBox.Name = "apptBox";
            this.apptBox.Size = new System.Drawing.Size(199, 21);
            this.apptBox.TabIndex = 2;
            // 
            // chkLegal
            // 
            this.chkLegal.AutoSize = true;
            this.chkLegal.Location = new System.Drawing.Point(117, 125);
            this.chkLegal.Name = "chkLegal";
            this.chkLegal.Size = new System.Drawing.Size(15, 14);
            this.chkLegal.TabIndex = 3;
            this.chkLegal.UseVisualStyleBackColor = true;
            this.chkLegal.CheckedChanged += new System.EventHandler(this.chkLegal_CheckedChanged);
            // 
            // cardBox
            // 
            this.cardBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardBox.Enabled = false;
            this.cardBox.FormattingEnabled = true;
            this.cardBox.Location = new System.Drawing.Point(118, 148);
            this.cardBox.Name = "cardBox";
            this.cardBox.Size = new System.Drawing.Size(156, 21);
            this.cardBox.TabIndex = 4;
            // 
            // noteBox
            // 
            this.noteBox.Location = new System.Drawing.Point(117, 257);
            this.noteBox.Multiline = true;
            this.noteBox.Name = "noteBox";
            this.noteBox.Size = new System.Drawing.Size(200, 74);
            this.noteBox.TabIndex = 8;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(118, 175);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 20);
            this.dtpDate.TabIndex = 5;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(150, 337);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 9;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(35, 260);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(80, 13);
            this.lblNotes.TabIndex = 15;
            this.lblNotes.Text = "Attorney Notes:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(82, 201);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 16;
            this.lblTime.Text = "Time:";
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "hh:mm tt";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(118, 201);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(121, 20);
            this.dtpTime.TabIndex = 6;
            // 
            // attnBox
            // 
            this.attnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attnBox.Enabled = false;
            this.attnBox.FormattingEnabled = true;
            this.attnBox.Location = new System.Drawing.Point(117, 227);
            this.attnBox.Name = "attnBox";
            this.attnBox.Size = new System.Drawing.Size(156, 21);
            this.attnBox.TabIndex = 7;
            // 
            // lblAttn
            // 
            this.lblAttn.AutoSize = true;
            this.lblAttn.Location = new System.Drawing.Point(66, 230);
            this.lblAttn.Name = "lblAttn";
            this.lblAttn.Size = new System.Drawing.Size(49, 13);
            this.lblAttn.TabIndex = 18;
            this.lblAttn.Text = "Attorney:";
            // 
            // frmApptScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 367);
            this.Controls.Add(this.attnBox);
            this.Controls.Add(this.lblAttn);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.noteBox);
            this.Controls.Add(this.cardBox);
            this.Controls.Add(this.chkLegal);
            this.Controls.Add(this.apptBox);
            this.Controls.Add(this.dutyBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAppt);
            this.Controls.Add(this.lblDuty);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApptScheduler";
            this.ShowIcon = false;
            this.Text = "Appointment Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Label lblAppt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ComboBox dutyBox;
        private System.Windows.Forms.ComboBox apptBox;
        private System.Windows.Forms.CheckBox chkLegal;
        private System.Windows.Forms.ComboBox cardBox;
        private System.Windows.Forms.TextBox noteBox;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.ComboBox attnBox;
        private System.Windows.Forms.Label lblAttn;
    }
}

