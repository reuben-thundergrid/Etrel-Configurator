using IPChanger;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Etrel_Configurator.Models;

namespace Etrel_Configurator
{
    public partial class Form1 : Form
    {

        readonly string configFolder;
        readonly string configFile;
        readonly int currentConfigVersion = 1; //Needs to be updated with the default-config.json
        string imagePath;
        ChargerConfig chargerConfig;
        public Form1()
        {
            InitializeComponent();
            buttonImage.Enabled = false;

            configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EtrelConfigurator");
            configFile = Path.Combine(configFolder, "config.json");
            Directory.CreateDirectory(configFolder);
        }

        private async void buttonConfigClick(object sender, EventArgs e)
        {
            buttonConfig.Enabled = false;
            richTextBox1.Text += "Uploading config..." + Environment.NewLine;
            try
            {
                Charger charger = new Charger(textBox1.Text, "root@etrel.com", "toor");
                await charger.UploadConfig(chargerConfig.ApiEndpoints);
                richTextBox1.Text += "Config upload success" + Environment.NewLine;
            }
            catch (Exception ex) { richTextBox1.Text += ex.Message + Environment.NewLine; }
            buttonConfig.Enabled = true;
        }

        private async void buttonRestartClick(object sender, EventArgs e)
        {
            buttonRestart.Enabled = false;
            richTextBox1.Text += "Attempting restart..." + Environment.NewLine;
            try
            {
                Charger charger = new Charger(textBox1.Text, "root@etrel.com", "toor");
                await charger.RestartCharger();
                richTextBox1.Text += "Restart with charger success" + Environment.NewLine;
            }
            catch (Exception ex) { richTextBox1.Text += ex.Message + Environment.NewLine; }
            buttonRestart.Enabled = true;
        }

        private async void buttonImageClick(object sender, EventArgs e)
        {
            buttonImage.Enabled = false;
            try
            {
                Charger charger = new Charger(textBox1.Text, "root@etrel.com", "toor");
                await charger.UploadLogo(imagePath);
                richTextBox1.Text += "Image upload with success" + Environment.NewLine;
            }
            catch (Exception ex) { richTextBox1.Text += ex.Message + Environment.NewLine; }
            buttonImage.Enabled = true;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Timer(); //Starts TCP check loop

            try
            {
                if (File.Exists(configFile))
                {
                    var file = await File.ReadAllTextAsync(configFile);
                    chargerConfig = JsonConvert.DeserializeObject<ChargerConfig>(file);
                    if (chargerConfig.ConfigVersion < currentConfigVersion) { WriteDefaultConfig(); }
                    return;
                }
                WriteDefaultConfig();
            }
            catch (Exception ex)
            {
                var msgBox = MessageBox.Show("Exception happened while reading config file " +
                    Environment.NewLine +
                    Environment.NewLine +
                    ex.Message +
                    Environment.NewLine +
                    Environment.NewLine +
                    "DO YOU WANT TO UNINSTALL WINDOWS",
                    "Error Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (msgBox == DialogResult.Yes)
                {
                    WriteDefaultConfig();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public void WriteDefaultConfig()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("default-config.json"));
            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) { throw new Exception("stream null when importing default-config.json"); }
            using StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();

            File.WriteAllText(configFile, result);
            chargerConfig = JsonConvert.DeserializeObject<ChargerConfig>(result);
        }

        static async Task<bool> TCPCheck(IPEndPoint endpoint)
        {
            if(endpoint.Port == 0) { endpoint.Port = 80; }
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    await tcpClient.ConnectAsync(endpoint);
                    return true;
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        private void buttonOpenGUI_MouseHover(object sender, EventArgs e)
        {
            //Is this a good idea to create this everytime you hover?
            System.Windows.Forms.ToolTip ToolTipOpenGUI = new System.Windows.Forms.ToolTip();
            ToolTipOpenGUI.SetToolTip(this.buttonOpenGUI, "Open Charger Web GUI");
        }

        private void buttonOpenGUI_Click(object sender, EventArgs e)
        {
            //Need to support https at some point
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "http://" + textBox1.Text,
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void buttonImageSelect_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTipImageSelect = new System.Windows.Forms.ToolTip();
            ToolTipImageSelect.SetToolTip(this.buttonOpenGUI, "Select Charger Logo");
        }

        private void buttonConfigSettings_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTipConfigSettings = new System.Windows.Forms.ToolTip();
            ToolTipConfigSettings.SetToolTip(this.buttonOpenGUI, "Edit config");
        }

        private void buttonConfigSettings_Click(object sender, EventArgs e)
        {
            var item = new SettingsForm(chargerConfig);
            item.ShowDialog();
            if (item.save)
            {
                File.WriteAllText(configFile, JsonConvert.SerializeObject(chargerConfig, Formatting.Indented));
            }
        }

        private void buttonImageSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                buttonImage.Enabled = true;
            }
            richTextBox1.AppendText("Image selected " + openFileDialog1.FileName + Environment.NewLine);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Timer()
        {
            while (true)
            {
                try
                {
                    if (await TCPCheck(IPEndPoint.Parse(textBox1.Text)))
                    {
                        panel1.BackColor = Color.Green;
                    }
                    else { panel1.BackColor = Color.Red; }
                }
                catch
                {
                    panel1.BackColor = Color.Gray;
                }
                await Task.Delay(500);
            }
        }
    }
}