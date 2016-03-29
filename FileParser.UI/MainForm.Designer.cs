namespace FileParser.UI
{
    partial class MainForm
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
            FileParser.Controls.ItemColorOption itemColorOption1 = new FileParser.Controls.ItemColorOption();
            FileParser.Controls.ItemColorOption itemColorOption2 = new FileParser.Controls.ItemColorOption();
            this.customList1 = new FileParser.Controls.CustomList();
            this.SuspendLayout();
            // 
            // customList1
            // 
            this.customList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.customList1.FormattingEnabled = true;
            this.customList1.ItemColor = System.Drawing.Color.Empty;
            itemColorOption1.Filename = "inputA";
            itemColorOption1.LColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            itemColorOption2.Filename = "inputB";
            itemColorOption2.LColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.customList1.LineColors.Add(itemColorOption1);
            this.customList1.LineColors.Add(itemColorOption2);
            this.customList1.Location = new System.Drawing.Point(12, 15);
            this.customList1.Name = "customList1";
            this.customList1.Size = new System.Drawing.Size(379, 563);
            this.customList1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 597);
            this.Controls.Add(this.customList1);
            this.Name = "MainForm";
            this.Text = "File Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomList customList1;
    }
}

