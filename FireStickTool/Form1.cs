using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FireStickTool
{
    public partial class Form1 : Form
    {

        string file;
        string filepath;

        public Form1()
        {
            InitializeComponent();
            string output;

            Process myproc = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "disconnect";
            myproc.StartInfo = startInfo;
            myproc.Start();
            output = myproc.StandardOutput.ReadToEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string output;


            Process myproc = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "connect " + textBox1.Text;
            myproc.StartInfo = startInfo;
            myproc.Start();
            output = myproc.StandardOutput.ReadToEnd();
            richTextBox1.Text = output;

            if (output.Contains("connected"))
            {
                textBox1.Enabled = false;
                button1.Enabled = false;
                MessageBox.Show("Success");
                
            } else
            {
                MessageBox.Show("Failed");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string output;

            Process myproc = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "disconnect";
            myproc.StartInfo = startInfo;
            myproc.Start();
            output = myproc.StandardOutput.ReadToEnd();
            richTextBox1.Text = output;


            if (output.Contains("disconnected"))
            {
                textBox1.Enabled = true;
                button1.Enabled = true;
                MessageBox.Show("Device Disconnected");
                
            }
            else
            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "APK|*.apk";
            openfile.Title = "Open a file..";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                apkTextBox.Text = openfile.SafeFileName;
            }
            filepath = openfile.FileName;
            file = openfile.SafeFileName;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string output;
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments ="install " + filepath;
            process.StartInfo = startInfo;
            process.Start();
            output = process.StandardOutput.ReadToEnd();
            richTextBox1.Text = output;
            
            if (output.Contains("Success"))
            {
                MessageBox.Show(file +" Installed");
            }
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
