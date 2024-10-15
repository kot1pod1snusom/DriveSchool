namespace DriveSchool
{
    partial class RegistrMenu
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
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxName = new TextBox();
            textBoxPassword = new TextBox();
            labelInputName = new Label();
            labelInputPassword = new Label();
            buttonLogIn = new Button();
            buttonRegistr = new Button();
            checkBoxShowHidePassword = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(textBoxName, 2, 2);
            tableLayoutPanel1.Controls.Add(textBoxPassword, 2, 5);
            tableLayoutPanel1.Controls.Add(labelInputName, 2, 1);
            tableLayoutPanel1.Controls.Add(labelInputPassword, 2, 4);
            tableLayoutPanel1.Controls.Add(buttonLogIn, 1, 10);
            tableLayoutPanel1.Controls.Add(buttonRegistr, 5, 10);
            tableLayoutPanel1.Controls.Add(checkBoxShowHidePassword, 2, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 12;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(282, 394);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxName
            // 
            tableLayoutPanel1.SetColumnSpan(textBoxName, 6);
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(59, 67);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(162, 23);
            textBoxName.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            tableLayoutPanel1.SetColumnSpan(textBoxPassword, 6);
            textBoxPassword.Dock = DockStyle.Fill;
            textBoxPassword.Location = new Point(59, 163);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(162, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // labelInputName
            // 
            labelInputName.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(labelInputName, 6);
            labelInputName.Dock = DockStyle.Fill;
            labelInputName.Location = new Point(59, 32);
            labelInputName.Name = "labelInputName";
            labelInputName.Size = new Size(162, 32);
            labelInputName.TabIndex = 2;
            labelInputName.Text = "Введите ваше имя";
            // 
            // labelInputPassword
            // 
            labelInputPassword.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(labelInputPassword, 6);
            labelInputPassword.Dock = DockStyle.Fill;
            labelInputPassword.Location = new Point(59, 128);
            labelInputPassword.Name = "labelInputPassword";
            labelInputPassword.Size = new Size(162, 32);
            labelInputPassword.TabIndex = 3;
            labelInputPassword.Text = "Введите пароль";
            // 
            // buttonLogIn
            // 
            tableLayoutPanel1.SetColumnSpan(buttonLogIn, 3);
            buttonLogIn.Dock = DockStyle.Fill;
            buttonLogIn.Location = new Point(31, 323);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(78, 26);
            buttonLogIn.TabIndex = 4;
            buttonLogIn.Text = "Войти";
            buttonLogIn.UseVisualStyleBackColor = true;
            // 
            // buttonRegistr
            // 
            tableLayoutPanel1.SetColumnSpan(buttonRegistr, 4);
            buttonRegistr.Dock = DockStyle.Fill;
            buttonRegistr.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRegistr.Location = new Point(143, 323);
            buttonRegistr.Name = "buttonRegistr";
            buttonRegistr.Size = new Size(106, 26);
            buttonRegistr.TabIndex = 5;
            buttonRegistr.Text = "Создать аккаунт";
            buttonRegistr.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowHidePassword
            // 
            checkBoxShowHidePassword.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(checkBoxShowHidePassword, 6);
            checkBoxShowHidePassword.Dock = DockStyle.Fill;
            checkBoxShowHidePassword.Location = new Point(59, 227);
            checkBoxShowHidePassword.Name = "checkBoxShowHidePassword";
            checkBoxShowHidePassword.Size = new Size(162, 26);
            checkBoxShowHidePassword.TabIndex = 6;
            checkBoxShowHidePassword.Text = "Скрыть пароль";
            checkBoxShowHidePassword.UseVisualStyleBackColor = true;
            // 
            // RegistrMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 394);
            Controls.Add(tableLayoutPanel1);
            Name = "RegistrMenu";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxName;
        private TextBox textBoxPassword;
        private Label labelInputName;
        private Label labelInputPassword;
        private Button buttonLogIn;
        private Button buttonRegistr;
        private CheckBox checkBoxShowHidePassword;
    }
}