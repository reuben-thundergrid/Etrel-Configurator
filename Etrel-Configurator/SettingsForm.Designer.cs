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
            resetConfig = new Button();
            saveConfig = new Button();
            cancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // resetConfig
            // 
            resetConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resetConfig.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            resetConfig.Location = new Point(12, 485);
            resetConfig.Name = "resetConfig";
            resetConfig.Size = new Size(133, 26);
            resetConfig.TabIndex = 3;
            resetConfig.Text = "Reset to Default";
            resetConfig.UseVisualStyleBackColor = true;
            resetConfig.Click += resetConfig_Click;
            // 
            // saveConfig
            // 
            saveConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveConfig.Location = new Point(151, 485);
            saveConfig.Name = "saveConfig";
            saveConfig.Size = new Size(115, 26);
            saveConfig.TabIndex = 4;
            saveConfig.Text = "Save";
            saveConfig.UseVisualStyleBackColor = true;
            saveConfig.Click += saveConfig_Click;
            // 
            // cancel
            // 
            cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancel.BackColor = Color.Lime;
            cancel.Location = new Point(272, 485);
            cancel.Name = "cancel";
            cancel.Size = new Size(133, 26);
            cancel.TabIndex = 5;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = false;
            cancel.Click += cancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(492, 467);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 523);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(cancel);
            Controls.Add(saveConfig);
            Controls.Add(resetConfig);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button resetConfig;
        private Button saveConfig;
        private Button cancel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}