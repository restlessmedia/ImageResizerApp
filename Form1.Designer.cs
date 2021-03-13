namespace ImageResizerApp
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
      this.button1 = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.button2 = new System.Windows.Forms.Button();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.label1 = new System.Windows.Forms.Label();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.button3 = new System.Windows.Forms.Button();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(22, 25);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(93, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Select file(s)";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.Filter = "Image files|*.jpg;*.jpeg;*.png";
      this.openFileDialog1.Multiselect = true;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.pictureBox1.Location = new System.Drawing.Point(312, 25);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(476, 104);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(22, 69);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(93, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Save location";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(120, 74);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 3;
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(22, 146);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(676, 199);
      this.listBox1.TabIndex = 4;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(713, 322);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(75, 23);
      this.button3.TabIndex = 5;
      this.button3.Text = "Process";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(22, 111);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(100, 17);
      this.checkBox1.TabIndex = 6;
      this.checkBox1.Text = "Enable watcher";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 361);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.button1);
      this.MaximumSize = new System.Drawing.Size(816, 400);
      this.MinimumSize = new System.Drawing.Size(816, 400);
      this.Name = "Form1";
      this.Text = "blakestanley - Watermarker";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

