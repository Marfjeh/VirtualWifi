using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;

namespace VirtualWifi
{
    public partial class Form1 : Form
    {
        static RootObject config;
        public string txtExecutable = "netsh";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveCfg();
            txtResult.Text = Environment.NewLine;
            if (txtExecutable.Trim() != string.Empty)
            {
                StreamReader outputReader = null;
                StreamReader errorReader = null;

                try
                {

                    //Create Process Start information
                    ProcessStartInfo processStartInfo =
                        new ProcessStartInfo(txtExecutable.Trim(), "wlan set hostednetwork mode=allow ssid=" + config.SSID + " key=" + config.Password.Trim());
                    processStartInfo.ErrorDialog = false;
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardError = true;
                    processStartInfo.RedirectStandardInput = true;
                    processStartInfo.RedirectStandardOutput = true;

                    //Execute the process
                    Process process = new Process();
                    process.StartInfo = processStartInfo;
                    bool processStarted = process.Start();
                    if (processStarted)
                    {
                        //Get the output stream
                        outputReader = process.StandardOutput;
                        errorReader = process.StandardError;
                        process.WaitForExit();

                        //Display the result
                        string displayText = "";
                        displayText += outputReader.ReadToEnd();
                        txtResult.Text = displayText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (outputReader != null)
                    {
                        outputReader.Close();
                    }
                    if (errorReader != null)
                    {
                        errorReader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select executable.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reloadCfg();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
        void msg(string message)
        {
            MessageBox.Show(message, "Virtual Wifi");
        }

        void startnet()
        {
            #region start
            //netsh wlan stop hostednetwork
            txtResult.Text = Environment.NewLine;
            if (txtExecutable.Trim() != string.Empty)
            {
                StreamReader outputReader = null;
                StreamReader errorReader = null;

                try
                {

                    //Create Process Start information
                    ProcessStartInfo processStartInfo =
                        new ProcessStartInfo(txtExecutable.Trim(), "wlan stop hostednetwork".Trim());
                    processStartInfo.ErrorDialog = false;
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardError = true;
                    processStartInfo.RedirectStandardInput = true;
                    processStartInfo.RedirectStandardOutput = true;

                    //Execute the process
                    Process process = new Process();
                    process.StartInfo = processStartInfo;
                    bool processStarted = process.Start();
                    if (processStarted)
                    {
                        //Get the output stream
                        outputReader = process.StandardOutput;
                        errorReader = process.StandardError;
                        process.WaitForExit();

                        //Display the result
                        string displayText = "";
                        displayText += outputReader.ReadToEnd();
                        txtResult.Text = displayText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (outputReader != null)
                    {
                        outputReader.Close();
                    }
                    if (errorReader != null)
                    {
                        errorReader.Close();
                    }
                }
            }
            else
            {
                msg("Please select executable.");
            }
#endregion
        }

        private void cannotStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
           msg("This is due to no wifi adaptar being available or this might be because you don't have the process running.");
        }

        void saveCfg()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (!File.Exists("settings.cfg"))
                {
                    sb.Append("{\r\n");
                    sb.Append("\"SSID\":\"" + textBox1.Text + "\",\r\n");
                    sb.Append("\"Password\":\"" + textBox2.Text + "\",\r\n");
                    sb.Append("\"pwVisible\":" + checkBox1.Checked.ToString() + "\r\n");
                    sb.Append("}\r\n");
                }
                else if (File.Exists("settings.cfg"))
                {
                    sb.Append("{\r\n");
                    sb.Append("\"SSID\":\"" + textBox1.Text + "\",\r\n");
                    sb.Append("\"Password\":\"" + textBox2.Text + "\",\r\n");
                    sb.Append("\"pwVisible\":" + checkBox1.Checked.ToString() + "\r\n");
                    sb.Append("}\r\n");
                }

               

               
            }
            catch(Exception e)
            {
                MessageBox.Show("Woops! An error: " + e.Message);
            }
        }
        void reloadCfg()
        {

            
            
            if (!File.Exists("settings.cfg"))
            {
                File.Create("settings.cfg");

                StringBuilder sb = new StringBuilder();
                sb.Append("{\r\n");
                sb.Append("\"SSID\":\"MySSID\",\r\n");
                sb.Append("\"Password\":\"MyPassword\",\r\n");
                sb.Append("\"pwVisible\":true\r\n");
                sb.Append("}\r\n");
            }

            try {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                config = jss.Deserialize<RootObject>(File.ReadAllText("settings.cfg"));
            }

            catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                reloadCfg();
            }
        }

        public class RootObject
        {
            public string SSID { get; set; }
            public string Password { get; set; }
            public bool pwVisible { get; set; }
        }
    }
}
