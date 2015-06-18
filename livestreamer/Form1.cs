using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace livestreamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Video players |*.exe|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            player.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(twitch.Text == "" || twitch.Text == "<???>")
            {
                MessageBox.Show("Type a streamer's name");

                return;
            }

            if(player.Text == "")
            {
                MessageBox.Show("Select a video player");
            }

            /*string box = string.Format("name: {0}\nquality: {1}\nplayer: {2}", twitch.Text, comboBox1.Text, player.Text);

            MessageBox.Show(box);*/

            string args = string.Format("twitch.tv/{0} {1} --player {2}", twitch.Text, comboBox1.Text, player.Text);

            // Process.Start("cmd.exe", cmd);
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = "livestreamer.exe";
            startInfo.Arguments = args;
            /*startInfo.Verb = "runas";
            startInfo.UseShellExecute = true;*/

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.SelectedText;
        }
    }
}
