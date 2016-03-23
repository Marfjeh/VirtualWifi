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

namespace VirtualWifi
{
    public partial class Form1 : Form
    {
        public string txtExecutable = "netsh";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResult.Text = Environment.NewLine;
            if (txtExecutable.Trim() != string.Empty)
            {
                StreamReader outputReader = null;
                StreamReader errorReader = null;

                try
                {

                    //Create Process Start information
                    ProcessStartInfo processStartInfo =
                        new ProcessStartInfo(txtExecutable.Trim(), "wlan set hostednetwork mode=allow ssid=" + textBox1.Text + " key=" + textBox2.Text.Trim());
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //netsh wlan start hostednetwork
            txtResult.Text = Environment.NewLine;
            if (txtExecutable.Trim() != string.Empty)
            {
                StreamReader outputReader = null;
                StreamReader errorReader = null;

                try
                {

                    //Create Process Start information
                    ProcessStartInfo processStartInfo =
                        new ProcessStartInfo(txtExecutable.Trim(), "wlan start hostednetwork".Trim());
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

        private void button2_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Please select executable.");
            }
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
    }
}
