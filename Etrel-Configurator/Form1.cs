using IPChanger;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Diagnostics;

namespace Etrel_Configurator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonImage.Enabled = false;
            buttonImageSelect.Enabled = false;
            buttonConfigSettings.Enabled = false;
            //Has to have a port specified
            if (TCPCheck(IPEndPoint.Parse("10.124.146.134:80")))
            {
                richTextBox1.Text += "Charger online" + Environment.NewLine;
            }
        }

        private async void buttonConfigClick(object sender, EventArgs e)
        {
            buttonConfig.Enabled = false;
            richTextBox1.Text += "Uploading config..." + Environment.NewLine;
            try
            {
                Charger charger = new Charger(textBox1.Text, "root@etrel.com", "toor");
                await charger.UploadConfig(ImportConfig());
                richTextBox1.Text += "Config upload success" + Environment.NewLine;
            }
            catch (Exception ex) { richTextBox1.Text += ex.Message + Environment.NewLine; }
            buttonConfig.Enabled = true;
        }

        public Dictionary<string, Dictionary<string, string>> ImportConfig()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("default-config.json"));
            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) { throw new Exception("stream null when importing default-config.json"); }
            using StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            var defaultConfig = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(result);
            if (defaultConfig == null) { throw new Exception("Default config null"); }
            return defaultConfig;
        }

        private async void buttonRestartClick(object sender, EventArgs e)
        {
            buttonRestart.Enabled = false;
            richTextBox1.Text += "Atempting restart..." + Environment.NewLine;
            try
            {
                Charger charger = new Charger(textBox1.Text, "root@etrel.com", "toor");
                await charger.RestartCharger();
                richTextBox1.Text += "Restart with charger success" + Environment.NewLine;
            }
            catch (Exception ex) { richTextBox1.Text += ex.Message + Environment.NewLine; }
            buttonRestart.Enabled = true;
        }

        private void buttonImageClick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static bool TCPCheck(IPEndPoint endpoint)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(endpoint);
                    return true;
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        private void buttonOpenGUI_Click(object sender, EventArgs e)
        {
            //Need to support https at some point
            //System.Diagnostics.Process.Start("http://" + textBox1.Text);
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "http://" + textBox1.Text,
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }
    }
}