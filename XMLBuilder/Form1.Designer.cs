namespace XMLBuilder
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
            this.Input = new System.Windows.Forms.TextBox();
            this.Convert = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(18, 182);
            this.Input.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Input.Multiline = true;
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(740, 1204);
            this.Input.TabIndex = 0;
            // 
            // Convert
            // 
            this.Convert.Location = new System.Drawing.Point(621, 115);
            this.Convert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(137, 57);
            this.Convert.TabIndex = 1;
            this.Convert.Text = "Parse";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(766, 182);
            this.Output.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(414, 1204);
            this.Output.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Raw XML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(909, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 1418);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.Input);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

