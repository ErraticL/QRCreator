
namespace qr_creator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button_WOC3 = new ePOSOne.btnProduct.Button_WOC();
            this.button_WOC2 = new ePOSOne.btnProduct.Button_WOC();
            this.button_WOC1 = new ePOSOne.btnProduct.Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(12, 303);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Enter your text here...";
            this.textBox1.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(268, 240);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 18);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Random QR color";
            this.toolTip1.SetToolTip(this.checkBox1, "Generates QR codes with a random color. Not recommended if you want to print the " +
        "QR code");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(268, 217);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(85, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Keep input";
            this.toolTip1.SetToolTip(this.checkBox2, "If this is checked, the textbox will not clear after the QR code has been generat" +
        "ed");
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = global::qr_creator.Properties.Resources.update_white;
            this.pictureBox7.Location = new System.Drawing.Point(291, 12);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(24, 24);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox7, "Check for updates");
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::qr_creator.Properties.Resources.github_white;
            this.pictureBox6.Location = new System.Drawing.Point(321, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "Opens the Github repo ");
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::qr_creator.Properties.Resources.cancel_white;
            this.pictureBox2.Location = new System.Drawing.Point(351, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Closes the QR Creator");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(28, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Click me to save as a .png!");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Your QR code will appear here!";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // button_WOC3
            // 
            this.button_WOC3.BorderColor = System.Drawing.Color.White;
            this.button_WOC3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.button_WOC3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_WOC3.FlatAppearance.BorderSize = 0;
            this.button_WOC3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC3.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC3.Location = new System.Drawing.Point(129, 273);
            this.button_WOC3.Name = "button_WOC3";
            this.button_WOC3.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC3.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(49)))));
            this.button_WOC3.OnHoverTextColor = System.Drawing.Color.Gray;
            this.button_WOC3.Size = new System.Drawing.Size(129, 24);
            this.button_WOC3.TabIndex = 18;
            this.button_WOC3.Text = "Generate QR code";
            this.button_WOC3.TextColor = System.Drawing.Color.White;
            this.button_WOC3.UseVisualStyleBackColor = true;
            this.button_WOC3.Click += new System.EventHandler(this.button_WOC3_Click);
            // 
            // button_WOC2
            // 
            this.button_WOC2.BorderColor = System.Drawing.Color.White;
            this.button_WOC2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.button_WOC2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_WOC2.FlatAppearance.BorderSize = 0;
            this.button_WOC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC2.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC2.Location = new System.Drawing.Point(264, 273);
            this.button_WOC2.Name = "button_WOC2";
            this.button_WOC2.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC2.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(49)))));
            this.button_WOC2.OnHoverTextColor = System.Drawing.Color.Gray;
            this.button_WOC2.Size = new System.Drawing.Size(111, 24);
            this.button_WOC2.TabIndex = 17;
            this.button_WOC2.Text = "Print QR code";
            this.button_WOC2.TextColor = System.Drawing.Color.White;
            this.button_WOC2.UseVisualStyleBackColor = true;
            this.button_WOC2.Click += new System.EventHandler(this.button_WOC2_Click);
            // 
            // button_WOC1
            // 
            this.button_WOC1.BorderColor = System.Drawing.Color.White;
            this.button_WOC1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.button_WOC1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_WOC1.FlatAppearance.BorderSize = 0;
            this.button_WOC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC1.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC1.Location = new System.Drawing.Point(12, 273);
            this.button_WOC1.Name = "button_WOC1";
            this.button_WOC1.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.button_WOC1.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(49)))));
            this.button_WOC1.OnHoverTextColor = System.Drawing.Color.Gray;
            this.button_WOC1.Size = new System.Drawing.Size(111, 24);
            this.button_WOC1.TabIndex = 16;
            this.button_WOC1.Text = "Open save folder";
            this.button_WOC1.TextColor = System.Drawing.Color.White;
            this.button_WOC1.UseVisualStyleBackColor = true;
            this.button_WOC1.Click += new System.EventHandler(this.button_WOC1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(387, 337);
            this.Controls.Add(this.button_WOC3);
            this.Controls.Add(this.button_WOC2);
            this.Controls.Add(this.button_WOC1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR Creator by Erratic";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private ePOSOne.btnProduct.Button_WOC button_WOC1;
        private ePOSOne.btnProduct.Button_WOC button_WOC2;
        private ePOSOne.btnProduct.Button_WOC button_WOC3;
    }
}

