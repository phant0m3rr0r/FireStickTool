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
    public partial class Form2 : Form
    {
        string appUnSelect;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            //string output;
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "shell pm list packages -3";
            process.StartInfo = startInfo;
            process.Start();
            //output = process.StandardOutput.ReadLine();
            //MessageBox.Show(output);


            List<string> line = new List<string>();
            while (!process.StandardOutput.EndOfStream)
            {
                
                line.Add(process.StandardOutput.ReadLine());
                //listBox1.Items.Add(line[i].ToString());
                //i++;
            }

            var appList = line.Select(x => x.Replace("package:", string.Empty)).ToArray();

            
            foreach (string s in appList)
            {
                //List<string> app = new List<string>();
                //string[] app = new string[] { };
                //app = s.Split('package:').ToList();
                listBox1.Items.Add(s.ToString());
            }
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string output;
            string appUnSelect = listBox1.SelectedItem.ToString();

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "uninstall " + appUnSelect;
            process.StartInfo = startInfo;
            process.Start();
            output = process.StandardOutput.ReadToEnd();

            
            MessageBox.Show(appUnSelect);
            
            if (output.Contains("Success"))
            {
                MessageBox.Show("Success");
                listBox1.Items.Clear();

                //Auto Refresh List
                startInfo.FileName = "adb.exe";
                startInfo.Arguments = "shell pm list packages -3";
                process.StartInfo = startInfo;
                process.Start();
                //output = process.StandardOutput.ReadLine();
                //MessageBox.Show(output);


                List<string> line = new List<string>();
                while (!process.StandardOutput.EndOfStream)
                {

                    line.Add(process.StandardOutput.ReadLine());
                    //listBox1.Items.Add(line[i].ToString());
                    //i++;
                }

                var appList = line.Select(x => x.Replace("package:", string.Empty)).ToArray();


                foreach (string s in appList)
                {
                    //List<string> app = new List<string>();
                    //string[] app = new string[] { };
                    //app = s.Split('package:').ToList();
                    listBox1.Items.Add(s.ToString());
                }

            }
            else
            {
                MessageBox.Show("Failed");
            }

        }
    }
}
