using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etrel_Configurator
{
    public partial class TextSettingControl : UserControl
    {
        public string SettingName { get { return label1.Text; } }
        public string SettingValue { get { return textBox1.Text; } }
        public string SettingEndpoint { get; }
        public TextSettingControl(string name, string value, string apiEndpoint)
        {
            InitializeComponent();
            label1.Text = name;
            textBox1.Text = value;
            this.SettingEndpoint = apiEndpoint;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
