namespace XMLParser
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
            this.Raw = new System.Windows.Forms.TextBox();
            this.Parsebtn = new System.Windows.Forms.Button();
            this.Parsed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Raw
            // 
            this.Raw.Location = new System.Drawing.Point(12, 112);
            this.Raw.Multiline = true;
            this.Raw.Name = "Raw";
            this.Raw.Size = new System.Drawing.Size(645, 421);
            this.Raw.TabIndex = 0;
            // 
            // Parsebtn
            // 
            this.Parsebtn.Location = new System.Drawing.Point(591, 70);
            this.Parsebtn.Name = "Parsebtn";
            this.Parsebtn.Size = new System.Drawing.Size(138, 36);
            this.Parsebtn.TabIndex = 1;
            this.Parsebtn.Text = "Parse";
            this.Parsebtn.UseVisualStyleBackColor = true;
            this.Parsebtn.Click += new System.EventHandler(this.Parsebtn_Click);
            // 
            // Parsed
            // 
            this.Parsed.Location = new System.Drawing.Point(663, 112);
            this.Parsed.Multiline = true;
            this.Parsed.Name = "Parsed";
            this.Parsed.Size = new System.Drawing.Size(645, 421);
            this.Parsed.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 551);
            this.Controls.Add(this.Parsed);
            this.Controls.Add(this.Parsebtn);
            this.Controls.Add(this.Raw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Raw;
        private System.Windows.Forms.Button Parsebtn;
        private System.Windows.Forms.TextBox Parsed;
    }
}

