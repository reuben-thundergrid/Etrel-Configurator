using Etrel_Configurator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etrel_Configurator
{
    public partial class SettingsForm : Form
    {
        public ChargerConfig chargerConfig;
        public bool save = false;
        public SettingsForm(ChargerConfig chargerConfig)
        {
            InitializeComponent();
            this.chargerConfig = chargerConfig;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            int count = 0;
            foreach (var apiEndpoint in chargerConfig.ApiEndpoints)
            {
                foreach (var setting in apiEndpoint.Value)
                {
                    var item = new TextSettingControl(setting.Key, setting.Value, apiEndpoint.Key);
                    item.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(item, 0, count);
                    count++; //Add each entry to new row
                }
            }

            //Magic to fix scroll bar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tableLayoutPanel1.Padding = new Padding(0, 0, vertScrollWidth, 0);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveConfig_Click(object sender, EventArgs e)
        {
            foreach(var item in tableLayoutPanel1.Controls.Cast<TextSettingControl>())
            {
                chargerConfig.ApiEndpoints[item.SettingEndpoint][item.SettingName] = item.SettingValue;
            }
            save = true;
            Close();
        }

        private void resetConfig_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("default-config.json"));
            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) { throw new Exception("stream null when importing default-config.json"); }
            using StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
                        
            chargerConfig = JsonConvert.DeserializeObject<ChargerConfig>(result);
            SettingsForm_Load(sender, e);
        }
    }
}
