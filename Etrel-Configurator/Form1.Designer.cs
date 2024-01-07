namespace Etrel_Configurator
{
    partial class Form1
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
            buttonConfig = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            buttonRestart = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            buttonImage = new Button();
            progressBar1 = new ProgressBar();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // buttonConfig
            // 
            buttonConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonConfig.Location = new Point(12, 390);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Size = new Size(313, 30);
            buttonConfig.TabIndex = 0;
            buttonConfig.Text = "Upload Config";
            buttonConfig.UseVisualStyleBackColor = true;
            buttonConfig.Click += buttonConfigClick;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(12, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(313, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "10.124.146.134";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(131, 9);
            label1.Name = "label1";
            label1.Size = new Size(87, 30);
            label1.TabIndex = 2;
            label1.Text = "Address";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonRestart
            // 
            buttonRestart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonRestart.Location = new Point(12, 426);
            buttonRestart.Name = "buttonRestart";
            buttonRestart.Size = new Size(313, 30);
            buttonRestart.TabIndex = 3;
            buttonRestart.Text = "Restart";
            buttonRestart.UseVisualStyleBackColor = true;
            buttonRestart.Click += buttonRestartClick;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(12, 101);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(313, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "192.168.1.101";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(131, 68);
            label2.Name = "label2";
            label2.Size = new Size(77, 30);
            label2.TabIndex = 5;
            label2.Text = "Master";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonImage
            // 
            buttonImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonImage.Location = new Point(12, 350);
            buttonImage.Name = "buttonImage";
            buttonImage.Size = new Size(313, 34);
            buttonImage.TabIndex = 6;
            buttonImage.Text = "Upload Image";
            buttonImage.UseVisualStyleBackColor = true;
            buttonImage.Click += buttonImageClick;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 462);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(313, 23);
            progressBar1.TabIndex = 7;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(12, 130);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(313, 214);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 497);
            Controls.Add(richTextBox1);
            Controls.Add(progressBar1);
            Controls.Add(buttonImage);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(buttonRestart);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(buttonConfig);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonConfig;
        private TextBox textBox1;
        private Label label1;
        private Button buttonRestart;
        private TextBox textBox2;
        private Label label2;
        private Button buttonImage;
        private ProgressBar progressBar1;
        private RichTextBox richTextBox1;
    }
}