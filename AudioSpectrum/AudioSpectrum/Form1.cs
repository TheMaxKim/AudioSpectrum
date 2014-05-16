using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioSpectrum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NAudio.CoreAudioApi.MMDeviceEnumerator enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.Active);

            comboBox1.Items.AddRange(devices.ToArray());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var device = (NAudio.CoreAudioApi.MMDevice) comboBox1.SelectedItem;
                progressBar1.Value = (int) Math.Round(device.AudioMeterInformation.MasterPeakValue * 100);
            }
        }
    }
}
