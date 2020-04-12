namespace SuperShopAppPractice3
{
    partial class SuperShopUi
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
            this.ShowDetailsButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProductSaveButton = new System.Windows.Forms.Button();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShopSaveButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowDetailsButton
            // 
            this.ShowDetailsButton.Location = new System.Drawing.Point(191, 283);
            this.ShowDetailsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShowDetailsButton.Name = "ShowDetailsButton";
            this.ShowDetailsButton.Size = new System.Drawing.Size(165, 28);
            this.ShowDetailsButton.TabIndex = 13;
            this.ShowDetailsButton.Text = "Show Details";
            this.ShowDetailsButton.UseVisualStyleBackColor = true;
            this.ShowDetailsButton.Click += new System.EventHandler(this.ShowDetailsButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProductSaveButton);
            this.groupBox3.Controls.Add(this.quantityTextBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.itemTextBox);
            this.groupBox3.Location = new System.Drawing.Point(16, 140);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(527, 135);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Product Information";
            // 
            // ProductSaveButton
            // 
            this.ProductSaveButton.Location = new System.Drawing.Point(385, 92);
            this.ProductSaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProductSaveButton.Name = "ProductSaveButton";
            this.ProductSaveButton.Size = new System.Drawing.Size(100, 28);
            this.ProductSaveButton.TabIndex = 7;
            this.ProductSaveButton.Text = "Save";
            this.ProductSaveButton.UseVisualStyleBackColor = true;
            this.ProductSaveButton.Click += new System.EventHandler(this.ProductSaveButton_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(151, 60);
            this.quantityTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(333, 22);
            this.quantityTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Product/Item Id";
            // 
            // itemTextBox
            // 
            this.itemTextBox.Location = new System.Drawing.Point(151, 26);
            this.itemTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(333, 22);
            this.itemTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ShopSaveButton);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.addressTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(527, 124);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shop Information";
            // 
            // ShopSaveButton
            // 
            this.ShopSaveButton.Location = new System.Drawing.Point(385, 87);
            this.ShopSaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShopSaveButton.Name = "ShopSaveButton";
            this.ShopSaveButton.Size = new System.Drawing.Size(100, 28);
            this.ShopSaveButton.TabIndex = 7;
            this.ShopSaveButton.Text = "Save";
            this.ShopSaveButton.UseVisualStyleBackColor = true;
            this.ShopSaveButton.Click += new System.EventHandler(this.ShopSaveButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(155, 23);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(329, 22);
            this.nameTextBox.TabIndex = 6;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(155, 55);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(329, 22);
            this.addressTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // SuperShopUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 322);
            this.Controls.Add(this.ShowDetailsButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SuperShopUi";
            this.Text = "Super Shop";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowDetailsButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ProductSaveButton;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ShopSaveButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

