
namespace ELearningPlatform.Panels.Creator.Quiz
{
    partial class Quiz
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.comboCourseBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.QuizID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qcorrect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdataButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.correctAnsBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.answerDBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.answerCBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.answerBBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.answerABox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(21, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 31);
            this.label9.TabIndex = 109;
            this.label9.Text = "Course";
            // 
            // comboCourseBox
            // 
            this.comboCourseBox.FormattingEnabled = true;
            this.comboCourseBox.Location = new System.Drawing.Point(111, 98);
            this.comboCourseBox.Name = "comboCourseBox";
            this.comboCourseBox.Size = new System.Drawing.Size(306, 28);
            this.comboCourseBox.TabIndex = 108;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuizID,
            this.CoursesID,
            this.QuestionsID,
            this.CourseList,
            this.Question,
            this.AnswerA,
            this.AnswerB,
            this.AnswerC,
            this.AnswerD,
            this.Qcorrect});
            this.dataGridView1.Location = new System.Drawing.Point(711, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(676, 548);
            this.dataGridView1.TabIndex = 107;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // QuizID
            // 
            this.QuizID.DataPropertyName = "QuizID";
            this.QuizID.HeaderText = "QuizID";
            this.QuizID.MinimumWidth = 6;
            this.QuizID.Name = "QuizID";
            this.QuizID.ReadOnly = true;
            this.QuizID.Visible = false;
            this.QuizID.Width = 125;
            // 
            // CoursesID
            // 
            this.CoursesID.DataPropertyName = "CoursesID";
            this.CoursesID.HeaderText = "CoursesID";
            this.CoursesID.MinimumWidth = 6;
            this.CoursesID.Name = "CoursesID";
            this.CoursesID.ReadOnly = true;
            this.CoursesID.Visible = false;
            this.CoursesID.Width = 125;
            // 
            // QuestionsID
            // 
            this.QuestionsID.DataPropertyName = "QuestionsID";
            this.QuestionsID.HeaderText = "QuestionsID";
            this.QuestionsID.MinimumWidth = 6;
            this.QuestionsID.Name = "QuestionsID";
            this.QuestionsID.ReadOnly = true;
            this.QuestionsID.Visible = false;
            this.QuestionsID.Width = 125;
            // 
            // CourseList
            // 
            this.CourseList.DataPropertyName = "CourseList";
            this.CourseList.HeaderText = "Course";
            this.CourseList.MinimumWidth = 6;
            this.CourseList.Name = "CourseList";
            this.CourseList.ReadOnly = true;
            this.CourseList.Width = 125;
            // 
            // Question
            // 
            this.Question.DataPropertyName = "Question";
            this.Question.HeaderText = "Question";
            this.Question.MinimumWidth = 6;
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.Width = 125;
            // 
            // AnswerA
            // 
            this.AnswerA.DataPropertyName = "AnswerA";
            this.AnswerA.HeaderText = "A";
            this.AnswerA.MinimumWidth = 6;
            this.AnswerA.Name = "AnswerA";
            this.AnswerA.ReadOnly = true;
            this.AnswerA.Width = 125;
            // 
            // AnswerB
            // 
            this.AnswerB.DataPropertyName = "AnswerB";
            this.AnswerB.HeaderText = "B";
            this.AnswerB.MinimumWidth = 6;
            this.AnswerB.Name = "AnswerB";
            this.AnswerB.ReadOnly = true;
            this.AnswerB.Width = 125;
            // 
            // AnswerC
            // 
            this.AnswerC.DataPropertyName = "AnswerC";
            this.AnswerC.HeaderText = "C";
            this.AnswerC.MinimumWidth = 6;
            this.AnswerC.Name = "AnswerC";
            this.AnswerC.ReadOnly = true;
            this.AnswerC.Width = 125;
            // 
            // AnswerD
            // 
            this.AnswerD.DataPropertyName = "AnswerD";
            this.AnswerD.HeaderText = "D";
            this.AnswerD.MinimumWidth = 6;
            this.AnswerD.Name = "AnswerD";
            this.AnswerD.ReadOnly = true;
            this.AnswerD.Width = 125;
            // 
            // Qcorrect
            // 
            this.Qcorrect.DataPropertyName = "Qcorrect";
            this.Qcorrect.HeaderText = "Correct Answer";
            this.Qcorrect.MinimumWidth = 6;
            this.Qcorrect.Name = "Qcorrect";
            this.Qcorrect.ReadOnly = true;
            this.Qcorrect.Width = 125;
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(42)))));
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RefreshButton.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.Image = global::ELearningPlatform.Properties.Resources.refresh2b;
            this.RefreshButton.Location = new System.Drawing.Point(578, 541);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(0);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(41, 41);
            this.RefreshButton.TabIndex = 106;
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(42)))));
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(429, 541);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(135, 41);
            this.DeleteButton.TabIndex = 105;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpdataButton
            // 
            this.UpdataButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(42)))));
            this.UpdataButton.Enabled = false;
            this.UpdataButton.FlatAppearance.BorderSize = 0;
            this.UpdataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdataButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UpdataButton.ForeColor = System.Drawing.Color.White;
            this.UpdataButton.Location = new System.Drawing.Point(282, 541);
            this.UpdataButton.Margin = new System.Windows.Forms.Padding(0);
            this.UpdataButton.Name = "UpdataButton";
            this.UpdataButton.Size = new System.Drawing.Size(135, 41);
            this.UpdataButton.TabIndex = 104;
            this.UpdataButton.Text = "Update";
            this.UpdataButton.UseVisualStyleBackColor = false;
            this.UpdataButton.Click += new System.EventHandler(this.UpdataButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(42)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(58, 541);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 41);
            this.button1.TabIndex = 103;
            this.button1.Text = "Create Question";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(23, 461);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 31);
            this.label8.TabIndex = 102;
            this.label8.Text = "Correct Answer:";
            // 
            // correctAnsBox
            // 
            this.correctAnsBox.BackColor = System.Drawing.Color.White;
            this.correctAnsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.correctAnsBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.correctAnsBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.correctAnsBox.Location = new System.Drawing.Point(203, 461);
            this.correctAnsBox.Name = "correctAnsBox";
            this.correctAnsBox.ReadOnly = true;
            this.correctAnsBox.Size = new System.Drawing.Size(476, 36);
            this.correctAnsBox.TabIndex = 101;
            this.correctAnsBox.Text = "Correct Answer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(23, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 31);
            this.label7.TabIndex = 100;
            this.label7.Text = "Answer D:";
            // 
            // answerDBox
            // 
            this.answerDBox.BackColor = System.Drawing.Color.White;
            this.answerDBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.answerDBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.answerDBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.answerDBox.Location = new System.Drawing.Point(144, 407);
            this.answerDBox.Name = "answerDBox";
            this.answerDBox.Size = new System.Drawing.Size(535, 36);
            this.answerDBox.TabIndex = 99;
            this.answerDBox.Text = "Answer D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(23, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 31);
            this.label6.TabIndex = 98;
            this.label6.Text = "Answer C:";
            // 
            // answerCBox
            // 
            this.answerCBox.BackColor = System.Drawing.Color.White;
            this.answerCBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.answerCBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.answerCBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.answerCBox.Location = new System.Drawing.Point(144, 349);
            this.answerCBox.Name = "answerCBox";
            this.answerCBox.Size = new System.Drawing.Size(535, 36);
            this.answerCBox.TabIndex = 97;
            this.answerCBox.Text = "Answer C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(23, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 31);
            this.label5.TabIndex = 96;
            this.label5.Text = "Answer B:";
            // 
            // answerBBox
            // 
            this.answerBBox.BackColor = System.Drawing.Color.White;
            this.answerBBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.answerBBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.answerBBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.answerBBox.Location = new System.Drawing.Point(144, 291);
            this.answerBBox.Name = "answerBBox";
            this.answerBBox.Size = new System.Drawing.Size(535, 36);
            this.answerBBox.TabIndex = 95;
            this.answerBBox.Text = "Answer B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 31);
            this.label3.TabIndex = 94;
            this.label3.Text = "Answer A:";
            // 
            // answerABox
            // 
            this.answerABox.BackColor = System.Drawing.Color.White;
            this.answerABox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.answerABox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.answerABox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.answerABox.Location = new System.Drawing.Point(144, 233);
            this.answerABox.Name = "answerABox";
            this.answerABox.Size = new System.Drawing.Size(535, 36);
            this.answerABox.TabIndex = 93;
            this.answerABox.Text = "Answer A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 31);
            this.label4.TabIndex = 92;
            this.label4.Text = "Quiz Question: ";
            // 
            // TitleBox
            // 
            this.TitleBox.BackColor = System.Drawing.Color.White;
            this.TitleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.TitleBox.Location = new System.Drawing.Point(75, 173);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(604, 36);
            this.TitleBox.TabIndex = 91;
            this.TitleBox.Text = "Question";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(42)))));
            this.label1.Location = new System.Drawing.Point(233, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 45);
            this.label1.TabIndex = 89;
            this.label1.Text = "Create";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(346, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 38);
            this.label2.TabIndex = 90;
            this.label2.Text = "Quiz!";
            // 
            // Quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboCourseBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdataButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.correctAnsBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.answerDBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.answerCBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.answerBBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.answerABox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Quiz";
            this.Size = new System.Drawing.Size(1403, 618);
            this.Load += new System.EventHandler(this.Quiz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboCourseBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdataButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox correctAnsBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox answerDBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox answerCBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox answerBBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox answerABox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuizID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Question;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnswerA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnswerB;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnswerC;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnswerD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qcorrect;
    }
}
