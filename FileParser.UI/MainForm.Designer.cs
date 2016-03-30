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
            this.OutputList = new FileParser.Controls.CustomList();
            this.SuspendLayout();
            // 
            // OutputList
            // 
            this.OutputList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.OutputList.FormattingEnabled = true;
            this.OutputList.ItemColor = System.Drawing.Color.Empty;
            itemColorOption1.Filename = "inputA";
            itemColorOption1.LColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            itemColorOption2.Filename = "inputB";
            itemColorOption2.LColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.OutputList.LineColors.Add(itemColorOption1);
            this.OutputList.LineColors.Add(itemColorOption2);
            this.OutputList.Location = new System.Drawing.Point(12, 15);
            this.OutputList.Name = "OutputList";
            this.OutputList.Size = new System.Drawing.Size(379, 563);
            this.OutputList.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 597);
            this.Controls.Add(this.OutputList);
            this.Name = "MainForm";
            this.Text = "File Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomList OutputList;
    }
}

