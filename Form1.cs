using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NameChanger
{
    public partial class Form1 : Form
    {
        string path;
        DirectoryInfo d;
        FileInfo[] files;
        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.settingPath != null)
            {
                folderBrowserDialog1.SelectedPath = Properties.Settings.Default.settingPath;
                path = Properties.Settings.Default.settingPath;
                ShowFiles();
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                ShowFiles();
                Properties.Settings.Default.settingPath = path;
                Properties.Settings.Default.Save();
            }
        }

        void ShowFiles()
        {
            listBox1.Items.Clear();
            d = new DirectoryInfo(path);
            files = d.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (FileInfo file in files)
            {
                file.MoveTo(path + "\\" + textBox1.Text + "_" + (i + 1) + file.Extension);
                i++;
            }
            listBox1.Items.Clear();
            ShowFiles();
        }
    }
}
