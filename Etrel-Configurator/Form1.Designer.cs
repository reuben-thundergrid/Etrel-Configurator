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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonConfig = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            buttonRestart = new Button();
            buttonImage = new Button();
            richTextBox1 = new RichTextBox();
            buttonConfigSettings = new Button();
            buttonImageSelect = new Button();
            SuspendLayout();
            // 
            // buttonConfig
            // 
            buttonConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonConfig.Location = new Point(12, 479);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Size = new Size(278, 30);
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
            buttonRestart.Location = new Point(12, 515);
            buttonRestart.Name = "buttonRestart";
            buttonRestart.Size = new Size(313, 30);
            buttonRestart.TabIndex = 3;
            buttonRestart.Text = "Restart";
            buttonRestart.UseVisualStyleBackColor = true;
            buttonRestart.Click += buttonRestartClick;
            // 
            // buttonImage
            // 
            buttonImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonImage.Location = new Point(12, 439);
            buttonImage.Name = "buttonImage";
            buttonImage.Size = new Size(278, 34);
            buttonImage.TabIndex = 6;
            buttonImage.Text = "Upload Image";
            buttonImage.UseVisualStyleBackColor = true;
            buttonImage.Click += buttonImageClick;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(12, 71);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(313, 362);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // buttonConfigSettings
            // 
            buttonConfigSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonConfigSettings.Location = new Point(295, 479);
            buttonConfigSettings.Name = "buttonConfigSettings";
            buttonConfigSettings.Size = new Size(30, 30);
            buttonConfigSettings.TabIndex = 9;
            buttonConfigSettings.Text = "⚙️";
            buttonConfigSettings.UseVisualStyleBackColor = true;
            // 
            // buttonImageSelect
            // 
            buttonImageSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonImageSelect.Location = new Point(295, 439);
            buttonImageSelect.Name = "buttonImageSelect";
            buttonImageSelect.Size = new Size(30, 30);
            buttonImageSelect.TabIndex = 10;
            buttonImageSelect.Text = "🖼️";
            buttonImageSelect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 557);
            Controls.Add(buttonImageSelect);
            Controls.Add(buttonConfigSettings);
            Controls.Add(richTextBox1);
            Controls.Add(buttonImage);
            Controls.Add(buttonRestart);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(buttonConfig);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "0.0.7";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonConfig;
        private TextBox textBox1;
        private Label label1;
        private Button buttonRestart;
        private Button buttonImage;
        private RichTextBox richTextBox1;
        private Button buttonConfigSettings;
        private Button buttonImageSelect;
    }
}