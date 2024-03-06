namespace StockFolio.View
{
    partial class MainView
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
            lblGreeting = new Label();
            tabControl1 = new TabControl();
            tabPortfolio = new TabPage();
            groupBox5 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            btnBuy = new Button();
            tbBuyPrice = new TextBox();
            label1 = new Label();
            cbStock = new ComboBox();
            nUDQuantity = new NumericUpDown();
            dataGridUserStocks = new DataGridView();
            groupBox4 = new GroupBox();
            label7 = new Label();
            lblTotalQuantity = new Label();
            groupBox3 = new GroupBox();
            lblTotalProfit = new Label();
            groupBox2 = new GroupBox();
            label3 = new Label();
            lblNetWorth = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            lblTotalInvestment = new Label();
            tabStocks = new TabPage();
            dataGridViewStocksList = new DataGridView();
            btnLogout = new Button();
            tabControl1.SuspendLayout();
            tabPortfolio.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUDQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridUserStocks).BeginInit();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabStocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocksList).BeginInit();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Segoe UI", 15F);
            lblGreeting.Location = new Point(24, 11);
            lblGreeting.Margin = new Padding(4, 0, 4, 0);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(70, 54);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "Hi,";
            lblGreeting.Click += lblGreeting_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPortfolio);
            tabControl1.Controls.Add(tabStocks);
            tabControl1.ItemSize = new Size(78, 30);
            tabControl1.Location = new Point(24, 81);
            tabControl1.Margin = new Padding(6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1549, 996);
            tabControl1.TabIndex = 1;
            // 
            // tabPortfolio
            // 
            tabPortfolio.Controls.Add(groupBox5);
            tabPortfolio.Controls.Add(dataGridUserStocks);
            tabPortfolio.Controls.Add(groupBox4);
            tabPortfolio.Controls.Add(groupBox3);
            tabPortfolio.Controls.Add(groupBox2);
            tabPortfolio.Controls.Add(groupBox1);
            tabPortfolio.Location = new Point(8, 38);
            tabPortfolio.Margin = new Padding(6);
            tabPortfolio.Name = "tabPortfolio";
            tabPortfolio.Padding = new Padding(93, 107, 93, 107);
            tabPortfolio.Size = new Size(1533, 950);
            tabPortfolio.TabIndex = 0;
            tabPortfolio.Text = "My Portfolio";
            tabPortfolio.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(btnBuy);
            groupBox5.Controls.Add(tbBuyPrice);
            groupBox5.Controls.Add(label1);
            groupBox5.Controls.Add(cbStock);
            groupBox5.Controls.Add(nUDQuantity);
            groupBox5.Location = new Point(25, 216);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(854, 387);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Buy Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 184);
            label5.Name = "label5";
            label5.Size = new Size(65, 32);
            label5.TabIndex = 6;
            label5.Text = "Price";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 123);
            label4.Name = "label4";
            label4.Size = new Size(106, 32);
            label4.TabIndex = 5;
            label4.Text = "Quantity";
            // 
            // btnBuy
            // 
            btnBuy.Location = new Point(170, 276);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(150, 46);
            btnBuy.TabIndex = 4;
            btnBuy.Text = "Buy";
            btnBuy.UseVisualStyleBackColor = true;
            btnBuy.Click += btnBuy_Click;
            // 
            // tbBuyPrice
            // 
            tbBuyPrice.Location = new Point(170, 177);
            tbBuyPrice.Name = "tbBuyPrice";
            tbBuyPrice.Size = new Size(240, 39);
            tbBuyPrice.TabIndex = 3;
            tbBuyPrice.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 63);
            label1.Name = "label1";
            label1.Size = new Size(71, 32);
            label1.TabIndex = 2;
            label1.Text = "Stock";
            // 
            // cbStock
            // 
            cbStock.FormattingEnabled = true;
            cbStock.Location = new Point(170, 55);
            cbStock.Name = "cbStock";
            cbStock.Size = new Size(240, 40);
            cbStock.TabIndex = 1;
            // 
            // nUDQuantity
            // 
            nUDQuantity.Location = new Point(170, 116);
            nUDQuantity.Name = "nUDQuantity";
            nUDQuantity.Size = new Size(240, 39);
            nUDQuantity.TabIndex = 0;
            nUDQuantity.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // dataGridUserStocks
            // 
            dataGridUserStocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUserStocks.Location = new Point(25, 634);
            dataGridUserStocks.Name = "dataGridUserStocks";
            dataGridUserStocks.RowHeadersWidth = 82;
            dataGridUserStocks.Size = new Size(1481, 300);
            dataGridUserStocks.TabIndex = 5;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(lblTotalQuantity);
            groupBox4.Location = new Point(1154, 30);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(352, 144);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Total Quantity";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(6, 59);
            label7.Name = "label7";
            label7.Size = new Size(0, 54);
            label7.TabIndex = 1;
            // 
            // lblTotalQuantity
            // 
            lblTotalQuantity.AutoSize = true;
            lblTotalQuantity.Font = new Font("Segoe UI", 14F);
            lblTotalQuantity.Location = new Point(12, 59);
            lblTotalQuantity.Name = "lblTotalQuantity";
            lblTotalQuantity.Size = new Size(102, 51);
            lblTotalQuantity.TabIndex = 0;
            lblTotalQuantity.Text = "1000";
            lblTotalQuantity.Click += lblTotalUnits_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblTotalProfit);
            groupBox3.Location = new Point(782, 30);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(352, 144);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Total Profit";
            // 
            // lblTotalProfit
            // 
            lblTotalProfit.AutoSize = true;
            lblTotalProfit.Font = new Font("Segoe UI", 14F);
            lblTotalProfit.Location = new Point(17, 59);
            lblTotalProfit.Name = "lblTotalProfit";
            lblTotalProfit.Size = new Size(102, 51);
            lblTotalProfit.TabIndex = 0;
            lblTotalProfit.Text = "1000";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(lblNetWorth);
            groupBox2.Location = new Point(402, 30);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 144);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Net Worth";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(6, 59);
            label3.Name = "label3";
            label3.Size = new Size(69, 51);
            label3.TabIndex = 1;
            label3.Text = "Rs.";
            // 
            // lblNetWorth
            // 
            lblNetWorth.AutoSize = true;
            lblNetWorth.Font = new Font("Segoe UI", 14F);
            lblNetWorth.Location = new Point(71, 59);
            lblNetWorth.Name = "lblNetWorth";
            lblNetWorth.Size = new Size(102, 51);
            lblNetWorth.TabIndex = 0;
            lblNetWorth.Text = "1000";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblTotalInvestment);
            groupBox1.Location = new Point(25, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(352, 144);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Total Investment";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(6, 59);
            label2.Name = "label2";
            label2.Size = new Size(69, 51);
            label2.TabIndex = 1;
            label2.Text = "Rs.";
            // 
            // lblTotalInvestment
            // 
            lblTotalInvestment.AutoSize = true;
            lblTotalInvestment.Font = new Font("Segoe UI", 14F);
            lblTotalInvestment.Location = new Point(71, 59);
            lblTotalInvestment.Name = "lblTotalInvestment";
            lblTotalInvestment.Size = new Size(102, 51);
            lblTotalInvestment.TabIndex = 0;
            lblTotalInvestment.Text = "1000";
            lblTotalInvestment.Click += label1_Click;
            // 
            // tabStocks
            // 
            tabStocks.Controls.Add(dataGridViewStocksList);
            tabStocks.Location = new Point(8, 38);
            tabStocks.Margin = new Padding(6);
            tabStocks.Name = "tabStocks";
            tabStocks.Padding = new Padding(93, 107, 93, 107);
            tabStocks.Size = new Size(1533, 950);
            tabStocks.TabIndex = 1;
            tabStocks.Text = "Stocks";
            tabStocks.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStocksList
            // 
            dataGridViewStocksList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStocksList.Location = new Point(34, 29);
            dataGridViewStocksList.Name = "dataGridViewStocksList";
            dataGridViewStocksList.RowHeadersWidth = 82;
            dataGridViewStocksList.Size = new Size(1455, 792);
            dataGridViewStocksList.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1426, 20);
            btnLogout.Margin = new Padding(6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(139, 49);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1604, 1092);
            Controls.Add(btnLogout);
            Controls.Add(tabControl1);
            Controls.Add(lblGreeting);
            Margin = new Padding(4, 2, 4, 2);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockFolio";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPortfolio.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUDQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridUserStocks).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabStocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStocksList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGreeting;
        private TabControl tabControl1;
        private TabPage tabPortfolio;
        private TabPage tabStocks;
        private Button btnLogout;
        private GroupBox groupBox1;
        private Label lblTotalInvestment;
        private GroupBox groupBox2;
        private Label label3;
        private Label lblNetWorth;
        private Label label2;
        private GroupBox groupBox4;
        private Label label7;
        private Label lblTotalQuantity;
        private GroupBox groupBox3;
        private Label lblTotalProfit;
        private DataGridView dataGridViewStocksList;
        private DataGridView dataGridUserStocks;
        private GroupBox groupBox5;
        private Label label1;
        private ComboBox cbStock;
        private NumericUpDown nUDQuantity;
        private Label label5;
        private Label label4;
        private Button btnBuy;
        private TextBox tbBuyPrice;
    }
}