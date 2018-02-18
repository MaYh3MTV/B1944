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
using System.Text;

namespace B1944
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Program Files (x86)\Steam\steamapps\common\Battalion 1944\Battalion\configs\presets\default.config");
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Program Files (x86)\Steam\steamapps\common\Battalion 1944\Battalion\configs\custom\custom4.config");

            var version = "";
            var temp = "";

            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                if (line.Contains("version"))
                {
                    version = line;
                    //Console.WriteLine(version);
                    continue;
                }
            }

            foreach (string line2 in lines2)
            {
                if (line2.Contains("version"))
                {
                    temp = line2;
                    //Console.WriteLine(temp);
                    continue;
                }
            }

            label1.Text = "Live: " + version.Split(':')[1].Trim(',').Trim();
            label2.Text = "Current: " + temp.Split(':')[1].Trim(',').Trim();

            compare(version, temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update c = new Update();

            var versions = c.updateConfig();

            compare(versions.Split('|')[0], versions.Split('|')[1]);
        }

        public void compare(string version, string temp)
        {
            label1.Text = "Live: " + version.Split(':')[1].Trim(',').Trim();
            label2.Text = "Current: " + temp.Split(':')[1].Trim(',').Trim();

            if (version.Split(':')[1] == temp.Split(':')[1])
            {
                label3.Text = "The version is up to date";
            }
            else
            {
                label3.Text = "The versions are out of date";
            }
        }
    }
}
