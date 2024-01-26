namespace Etrel_Configurator
{
    partial class SettingsForm
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            textSettingControl2 = new TextSettingControl();
            textSettingControl1 = new TextSettingControl();
            textSettingControl3 = new TextSettingControl();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 485);
            button1.Name = "button1";
            button1.Size = new Size(133, 26);
            button1.TabIndex = 3;
            button1.Text = "Reset to Default";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(151, 485);
            button2.Name = "button2";
            button2.Size = new Size(115, 26);
            button2.TabIndex = 4;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.BackColor = Color.Lime;
            button3.Location = new Point(272, 485);
            button3.Name = "button3";
            button3.Size = new Size(133, 26);
            button3.TabIndex = 5;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(textSettingControl2);
            flowLayoutPanel1.Controls.Add(textSettingControl1);
            flowLayoutPanel1.Controls.Add(textSettingControl3);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(393, 467);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // textSettingControl2
            // 
            textSettingControl2.Location = new Point(3, 3);
            textSettingControl2.Name = "textSettingControl2";
            textSettingControl2.Size = new Size(390, 25);
            textSettingControl2.TabIndex = 1;
            // 
            // textSettingControl1
            // 
            textSettingControl1.Location = new Point(3, 34);
            textSettingControl1.Name = "textSettingControl1";
            textSettingControl1.Size = new Size(390, 25);
            textSettingControl1.TabIndex = 0;
            // 
            // textSettingControl3
            // 
            textSettingControl3.Location = new Point(3, 65);
            textSettingControl3.Name = "textSettingControl3";
            textSettingControl3.Size = new Size(390, 25);
            textSettingControl3.TabIndex = 2;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 523);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "SettingsForm";
            Text = "SettingsForm";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextSettingControl textSettingControl2;
        private TextSettingControl textSettingControl1;
        private TextSettingControl textSettingControl3;
    }
}