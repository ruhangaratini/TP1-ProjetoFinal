﻿namespace LitePDV
{
    partial class LitePDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LitePDV));
            this.SideBarMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.MainScreen = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuDashboard = new System.Windows.Forms.Button();
            this.MenuCustomer = new System.Windows.Forms.Button();
            this.MenuProduct = new System.Windows.Forms.Button();
            this.MenuSale = new System.Windows.Forms.Button();
            this.SideBarMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SideBarMenu
            // 
            this.SideBarMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SideBarMenu.Controls.Add(this.panel2);
            this.SideBarMenu.Controls.Add(this.panel1);
            this.SideBarMenu.Controls.Add(this.panel3);
            this.SideBarMenu.Controls.Add(this.panel4);
            this.SideBarMenu.Controls.Add(this.panel5);
            this.SideBarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBarMenu.Location = new System.Drawing.Point(0, 0);
            this.SideBarMenu.Margin = new System.Windows.Forms.Padding(0);
            this.SideBarMenu.Name = "SideBarMenu";
            this.SideBarMenu.Size = new System.Drawing.Size(183, 661);
            this.SideBarMenu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 95);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MenuDashboard);
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 51);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MenuCustomer);
            this.panel3.Location = new System.Drawing.Point(0, 146);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 51);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.MenuProduct);
            this.panel4.Location = new System.Drawing.Point(0, 197);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 51);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.MenuSale);
            this.panel5.Location = new System.Drawing.Point(0, 248);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(183, 51);
            this.panel5.TabIndex = 3;
            // 
            // MainScreen
            // 
            this.MainScreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainScreen.BackColor = System.Drawing.SystemColors.Control;
            this.MainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainScreen.Location = new System.Drawing.Point(183, 0);
            this.MainScreen.Name = "MainScreen";
            this.MainScreen.Size = new System.Drawing.Size(1001, 661);
            this.MainScreen.TabIndex = 1;
            this.MainScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.MainScreen_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::LitePDV.Properties.Resources.menu;
            this.pictureBox1.Location = new System.Drawing.Point(20, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // MenuDashboard
            // 
            this.MenuDashboard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.MenuDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuDashboard.Image = ((System.Drawing.Image)(resources.GetObject("MenuDashboard.Image")));
            this.MenuDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuDashboard.Location = new System.Drawing.Point(-36, -14);
            this.MenuDashboard.Name = "MenuDashboard";
            this.MenuDashboard.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.MenuDashboard.Size = new System.Drawing.Size(242, 79);
            this.MenuDashboard.TabIndex = 2;
            this.MenuDashboard.Text = "          Dashboard";
            this.MenuDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuDashboard.UseVisualStyleBackColor = false;
            this.MenuDashboard.Click += new System.EventHandler(this.MenuDashboard_Click);
            // 
            // MenuCustomer
            // 
            this.MenuCustomer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.MenuCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuCustomer.Image = global::LitePDV.Properties.Resources.person;
            this.MenuCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuCustomer.Location = new System.Drawing.Point(-36, -14);
            this.MenuCustomer.Name = "MenuCustomer";
            this.MenuCustomer.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.MenuCustomer.Size = new System.Drawing.Size(242, 79);
            this.MenuCustomer.TabIndex = 2;
            this.MenuCustomer.Text = "          Clientes";
            this.MenuCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuCustomer.UseVisualStyleBackColor = false;
            this.MenuCustomer.Click += new System.EventHandler(this.MenuCustomer_Click);
            // 
            // MenuProduct
            // 
            this.MenuProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuProduct.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.MenuProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuProduct.Image = global::LitePDV.Properties.Resources.product;
            this.MenuProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuProduct.Location = new System.Drawing.Point(-36, -14);
            this.MenuProduct.Name = "MenuProduct";
            this.MenuProduct.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.MenuProduct.Size = new System.Drawing.Size(242, 79);
            this.MenuProduct.TabIndex = 2;
            this.MenuProduct.Text = "          Produtos";
            this.MenuProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuProduct.UseVisualStyleBackColor = false;
            this.MenuProduct.Click += new System.EventHandler(this.MenuProduct_Click);
            // 
            // MenuSale
            // 
            this.MenuSale.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuSale.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.MenuSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuSale.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuSale.Image = global::LitePDV.Properties.Resources.sale;
            this.MenuSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuSale.Location = new System.Drawing.Point(-36, -14);
            this.MenuSale.Name = "MenuSale";
            this.MenuSale.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.MenuSale.Size = new System.Drawing.Size(242, 79);
            this.MenuSale.TabIndex = 2;
            this.MenuSale.Text = "          Vendas";
            this.MenuSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuSale.UseVisualStyleBackColor = false;
            this.MenuSale.Click += new System.EventHandler(this.MenuSale_Click);
            // 
            // LitePDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.MainScreen);
            this.Controls.Add(this.SideBarMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LitePDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LitePDV";
            this.Load += new System.EventHandler(this.LitePDV_Load);
            this.SideBarMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel SideBarMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MenuDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button MenuCustomer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button MenuProduct;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button MenuSale;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MainScreen;
    }
}