namespace StockFolio.View
{
    partial class AuthView
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
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            label4 = new Label();
            btnLogin = new Button();
            label5 = new Label();
            txtLoginEmail = new TextBox();
            txtLoginPassword = new TextBox();
            tabPage2 = new TabPage();
            btnRegister = new Button();
            txtRegisterPassword = new TextBox();
            label1 = new Label();
            txtRegisterEmail = new TextBox();
            label2 = new Label();
            txtRegisterUsername = new TextBox();
            label3 = new Label();
            label6 = new Label();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(40, 146);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(724, 377);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(btnLogin);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtLoginEmail);
            tabPage1.Controls.Add(txtLoginPassword);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(708, 323);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Login";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 146);
            label4.Name = "label4";
            label4.Size = new Size(111, 32);
            label4.TabIndex = 8;
            label4.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(272, 224);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 46);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 76);
            label5.Name = "label5";
            label5.Size = new Size(71, 32);
            label5.TabIndex = 7;
            label5.Text = "Email";
            // 
            // txtLoginEmail
            // 
            txtLoginEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLoginEmail.Location = new Point(198, 76);
            txtLoginEmail.Name = "txtLoginEmail";
            txtLoginEmail.Size = new Size(472, 39);
            txtLoginEmail.TabIndex = 9;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLoginPassword.Location = new Point(198, 146);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(472, 39);
            txtLoginPassword.TabIndex = 10;
            txtLoginPassword.UseSystemPasswordChar = true;
            txtLoginPassword.KeyPress += txtLoginPassword_KeyPress;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnRegister);
            tabPage2.Controls.Add(txtRegisterPassword);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(txtRegisterEmail);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(txtRegisterUsername);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(708, 323);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Register";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(281, 252);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 46);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtRegisterPassword
            // 
            txtRegisterPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRegisterPassword.Location = new Point(207, 174);
            txtRegisterPassword.Name = "txtRegisterPassword";
            txtRegisterPassword.Size = new Size(465, 39);
            txtRegisterPassword.TabIndex = 5;
            txtRegisterPassword.UseSystemPasswordChar = true;
            txtRegisterPassword.KeyPress += txtRegisterPassword_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 35);
            label1.Name = "label1";
            label1.Size = new Size(121, 32);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // txtRegisterEmail
            // 
            txtRegisterEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRegisterEmail.Location = new Point(207, 104);
            txtRegisterEmail.Name = "txtRegisterEmail";
            txtRegisterEmail.Size = new Size(465, 39);
            txtRegisterEmail.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 104);
            label2.Name = "label2";
            label2.Size = new Size(71, 32);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // txtRegisterUsername
            // 
            txtRegisterUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRegisterUsername.Location = new Point(207, 35);
            txtRegisterUsername.Name = "txtRegisterUsername";
            txtRegisterUsername.Size = new Size(465, 39);
            txtRegisterUsername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 174);
            label3.Name = "label3";
            label3.Size = new Size(111, 32);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(255, 34);
            label6.Name = "label6";
            label6.Size = new Size(289, 71);
            label6.TabIndex = 1;
            label6.Text = "StockFolio";
            // 
            // AuthView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 569);
            Controls.Add(label6);
            Controls.Add(tabControl);
            Name = "AuthView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockFolio Login/Register";
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage tabPage2;
        private TextBox txtRegisterPassword;
        private TextBox txtRegisterEmail;
        private TextBox txtRegisterUsername;
        private Button btnRegister;
        private Button btnLogin;
        private TextBox txtLoginPassword;
        private TextBox txtLoginEmail;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
