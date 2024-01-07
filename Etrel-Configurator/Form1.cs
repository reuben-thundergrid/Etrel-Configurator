using IPChanger;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace Etrel_Configurator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonImage.Enabled = false;
        }

        private async void buttonConfigClick(object sender, EventArgs e)
        {
            buttonImage.Enabled = false;
            try
            {
                richTextBox1.Text += "Uploading config..." + Environment.NewLine;
                Charger charger = new Charger(textBox1.Text, "root@etrel.com", "toor");
                richTextBox1.Text += "Auth with charger success" + Environment.NewLine;
                richTextBox1.Text += "Attempting config upload" + Environment.NewLine;
                charger.UploadConfig(ImportConfig());
                richTextBox1.Text += "Config upload success" + Environment.NewLine;
            }
            catch (Exception ex) { richTextBox1.Text += ex.Message + Environment.NewLine; }
            buttonImage.Enabled = true;
        }

        public Dictionary<string, Dictionary<string, string>> ImportConfig()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("default-config.json"));
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
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
    }
}