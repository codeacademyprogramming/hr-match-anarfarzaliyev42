namespace HR_Match
{
    partial class AddCVForm
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
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSurname = new System.Windows.Forms.TextBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxEducation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxExperience = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxSalary = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.maskedPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(308, 12);
            this.tbxName.MaxLength = 50;
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(157, 20);
            this.tbxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Soyad";
            // 
            // tbxSurname
            // 
            this.tbxSurname.Location = new System.Drawing.Point(308, 59);
            this.tbxSurname.MaxLength = 50;
            this.tbxSurname.Name = "tbxSurname";
            this.tbxSurname.Size = new System.Drawing.Size(157, 20);
            this.tbxSurname.TabIndex = 2;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "Kisi",
            "Qadin"});
            this.comboBoxGender.Location = new System.Drawing.Point(308, 102);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(157, 21);
            this.comboBoxGender.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cins";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Yas";
            // 
            // tbxAge
            // 
            this.tbxAge.Location = new System.Drawing.Point(308, 146);
            this.tbxAge.MaxLength = 2;
            this.tbxAge.Name = "tbxAge";
            this.tbxAge.Size = new System.Drawing.Size(157, 20);
            this.tbxAge.TabIndex = 6;
            this.tbxAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAge_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tehsil";
            // 
            // comboBoxEducation
            // 
            this.comboBoxEducation.FormattingEnabled = true;
            this.comboBoxEducation.Items.AddRange(new object[] {
            "Ali",
            "Natamam Ali",
            "Orta"});
            this.comboBoxEducation.Location = new System.Drawing.Point(308, 186);
            this.comboBoxEducation.Name = "comboBoxEducation";
            this.comboBoxEducation.Size = new System.Drawing.Size(157, 21);
            this.comboBoxEducation.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Is tecrubesi";
            // 
            // comboBoxExperience
            // 
            this.comboBoxExperience.FormattingEnabled = true;
            this.comboBoxExperience.Items.AddRange(new object[] {
            "1 ilden asagi,",
            "1 ilden - 3 ile qeder",
            "3 ilden - 5 ile qeder",
            "5 ilden daha cox"});
            this.comboBoxExperience.Location = new System.Drawing.Point(308, 230);
            this.comboBoxExperience.Name = "comboBoxExperience";
            this.comboBoxExperience.Size = new System.Drawing.Size(157, 21);
            this.comboBoxExperience.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Kateqoriya";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Hekim",
            "Jurnalist",
            "IT mutexessis",
            "Tercumeci"});
            this.comboBoxCategory.Location = new System.Drawing.Point(308, 272);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(157, 21);
            this.comboBoxCategory.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Seher";
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Items.AddRange(new object[] {
            "Baki",
            "Gence",
            "Seki"});
            this.comboBoxCity.Location = new System.Drawing.Point(308, 312);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(157, 21);
            this.comboBoxCity.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(137, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Minimum teleb etdiyin emek haqqi";
            // 
            // tbxSalary
            // 
            this.tbxSalary.Location = new System.Drawing.Point(308, 352);
            this.tbxSalary.MaxLength = 6;
            this.tbxSalary.Name = "tbxSalary";
            this.tbxSalary.Size = new System.Drawing.Size(157, 20);
            this.tbxSalary.TabIndex = 16;
            this.tbxSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSalary_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Mobil telefon ";
            // 
            // maskedPhoneNumber
            // 
            this.maskedPhoneNumber.Location = new System.Drawing.Point(308, 387);
            this.maskedPhoneNumber.Mask = "(+\\9\\94) 00-000-00-00";
            this.maskedPhoneNumber.Name = "maskedPhoneNumber";
            this.maskedPhoneNumber.Size = new System.Drawing.Size(157, 20);
            this.maskedPhoneNumber.TabIndex = 20;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(390, 413);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Elave Et";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(308, 413);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Yenile";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // AddCVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.maskedPhoneNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxSalary);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxCity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxExperience);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxEducation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxAge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxSurname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxName);
            this.Name = "AddCVForm";
            this.Text = "AddCVForm";
            this.Load += new System.EventHandler(this.AddCVForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSurname;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxAge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxEducation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxExperience;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxSalary;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedPhoneNumber;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
    }
}