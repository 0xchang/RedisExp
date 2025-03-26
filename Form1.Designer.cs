namespace RedisExp
{
    partial class RedisExpUI
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
            label1 = new Label();
            label2 = new Label();
            addressBox = new TextBox();
            portBox = new TextBox();
            expBox = new ComboBox();
            attackBtn = new Button();
            contentBox = new RichTextBox();
            pathBox = new TextBox();
            logTextBox = new RichTextBox();
            label3 = new Label();
            passBox = new TextBox();
            menuStrip1 = new MenuStrip();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(918, 37);
            label1.Name = "label1";
            label1.Size = new Size(108, 31);
            label1.TabIndex = 0;
            label1.Text = "IP地址：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1313, 37);
            label2.Name = "label2";
            label2.Size = new Size(86, 31);
            label2.TabIndex = 1;
            label2.Text = "端口：";
            // 
            // addressBox
            // 
            addressBox.Location = new Point(1020, 34);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(287, 38);
            addressBox.TabIndex = 2;
            addressBox.Text = "192.168.1.1";
            // 
            // portBox
            // 
            portBox.Location = new Point(1391, 30);
            portBox.Name = "portBox";
            portBox.Size = new Size(109, 38);
            portBox.TabIndex = 3;
            portBox.Text = "6379";
            // 
            // expBox
            // 
            expBox.DisplayMember = "1";
            expBox.FormattingEnabled = true;
            expBox.Items.AddRange(new object[] { "info查询","ssh公钥", "webshell", "定时任务反弹shell" });
            expBox.Location = new Point(32, 69);
            expBox.Name = "expBox";
            expBox.Size = new Size(242, 39);
            expBox.TabIndex = 4;
            expBox.SelectedIndexChanged += expBox_TextChanged;
            // 
            // attackBtn
            // 
            attackBtn.Location = new Point(305, 66);
            attackBtn.Name = "attackBtn";
            attackBtn.Size = new Size(150, 46);
            attackBtn.TabIndex = 5;
            attackBtn.Text = "Attack";
            attackBtn.UseVisualStyleBackColor = true;
            attackBtn.Click += attackBtn_Click;
            // 
            // contentBox
            // 
            contentBox.Location = new Point(32, 127);
            contentBox.Name = "contentBox";
            contentBox.Size = new Size(1512, 461);
            contentBox.TabIndex = 6;
            contentBox.Text = "ssh公钥/webshell";
            contentBox.TextChanged += contentBox_TextChanged;
            // 
            // pathBox
            // 
            pathBox.Location = new Point(482, 71);
            pathBox.Name = "pathBox";
            pathBox.Size = new Size(345, 38);
            pathBox.TabIndex = 7;
            pathBox.Text = "路径";
            // 
            // logTextBox
            // 
            logTextBox.Location = new Point(32, 613);
            logTextBox.Name = "logTextBox";
            logTextBox.Size = new Size(1512, 504);
            logTextBox.TabIndex = 8;
            logTextBox.Text = "日志记录";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(918, 81);
            label3.Name = "label3";
            label3.Size = new Size(86, 31);
            label3.TabIndex = 9;
            label3.Text = "密码：";
            // 
            // passBox
            // 
            passBox.Location = new Point(1020, 78);
            passBox.Name = "passBox";
            passBox.Size = new Size(287, 38);
            passBox.TabIndex = 10;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1574, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // RedisExpUI
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 1129);
            Controls.Add(passBox);
            Controls.Add(label3);
            Controls.Add(logTextBox);
            Controls.Add(pathBox);
            Controls.Add(contentBox);
            Controls.Add(attackBtn);
            Controls.Add(expBox);
            Controls.Add(portBox);
            Controls.Add(addressBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "RedisExpUI";
            Text = "RedisExploit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox addressBox;
        private TextBox portBox;
        private ComboBox expBox;
        private Button attackBtn;
        private RichTextBox contentBox;
        private TextBox pathBox;
        private RichTextBox logTextBox;
        private Label label3;
        private TextBox passBox;
        private MenuStrip menuStrip1;
    }
}
