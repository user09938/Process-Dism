using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Process_Dism
{
    public partial class Form1 : Form
    {
        //create new instance
        private BackgroundWorker _backgroundWorker1 = new BackgroundWorker();
        private HelperDism _helperDism = new HelperDism();
        private string _mountDir = Path.Combine(Path.GetTempPath(), "mnt");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set value
            comboBoxDismCommand.SelectedIndex = 0;

            //set properties
            _backgroundWorker1.WorkerSupportsCancellation = true;
            _backgroundWorker1.WorkerReportsProgress = true;

            //subscribe to events
            _backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            _backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

            _helperDism.DataReceived += HelperDism_DataReceived;
            _helperDism.ErrorReceived += HelperDism_ErrorReceived;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //create reference
            System.ComponentModel.BackgroundWorker worker = (System.ComponentModel.BackgroundWorker)sender;
            
            //create reference
            HelperDism helperDism = (HelperDism)e.Argument;

            //execute
            helperDism.RunDism(worker, e);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (e.Error.Message.ToLower().StartsWith("error"))
                    toolStripStatusLabel1.Text = e.Error.Message;
                else
                    toolStripStatusLabel1.Text = $"Error: {e.Error.Message}";
            }
            else if (e.Cancelled)
            {
                toolStripStatusLabel1.Text = $"Status: Cancelled by user.";
            }
            else
            {
                toolStripStatusLabel1.Text = "Status: Complete.";
            }
        }


        private void HelperDism_ErrorReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            //append data to RichTextBox
            richTextBoxOutput.BeginInvoke(new MethodInvoker(delegate
            {
                richTextBoxOutput.AppendText(e.Data + Environment.NewLine);
            }));
        }

        private void HelperDism_DataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            string data = e.Data.Trim();
            if (data.StartsWith("[") && data.EndsWith("]"))
            {
                //remove [, ], =, and spaces
                string percentageComplete = System.Text.RegularExpressions.Regex.Replace(data, @"[\[|\]|=|\s+]", "");

                statusStrip1.BeginInvoke(new MethodInvoker(delegate
                {
                    toolStripStatusLabel1.Text = $"Status: Processing... ({percentageComplete})";
                    statusStrip1.Refresh();
                }));
                
            }
            else
            {
                //append data to RichTextBox
                richTextBoxOutput.BeginInvoke(new MethodInvoker(delegate
                {
                    richTextBoxOutput.AppendText(data + Environment.NewLine);
                }));
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //set value
            toolStripStatusLabel1.Text = "Status: Processing...";

            //clear existing data
            richTextBoxOutput.Clear();

            if (!String.IsNullOrEmpty(comboBoxDismCommand.Text))
            {
                //execute dism command
                if (!_backgroundWorker1.IsBusy)
                {
                    //set value
                    string arguments = comboBoxDismCommand.Text;

                    //set value
                    _helperDism.Arguments = arguments;

                    //set value
                    richTextBoxOutput.Text = $"Command: dism {arguments}{Environment.NewLine}";

                    //run
                    _backgroundWorker1.RunWorkerAsync(_helperDism);
                }
            }
        }

        private void btnWimMount_Click(object sender, EventArgs e)
        {
            //clear existing data
            richTextBoxOutput.Clear();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "WIM File (*.wim)|*.wim";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //execute dism command
                    if (!_backgroundWorker1.IsBusy)
                    {
                        if (!Directory.Exists(_mountDir))
                            Directory.CreateDirectory(_mountDir);

                        string arguments = $"/Mount-Image /ImageFile:\"{ofd.FileName}\" /Index:1 /MountDir:\"{_mountDir}\" /readonly";

                        //set value
                        _helperDism.Arguments = arguments;

                        //set value
                        richTextBoxOutput.Text = $"Command: dism {arguments}{Environment.NewLine}";

                        //run
                        _backgroundWorker1.RunWorkerAsync(_helperDism);
                    }
                }
            }
        }

        private void btnWimDismount_Click(object sender, EventArgs e)
        {
            //clear existing data
            richTextBoxOutput.Clear();

            //execute dism command
            if (!_backgroundWorker1.IsBusy)
            {
                if (!Directory.Exists(_mountDir))
                    return;

                //set value
                string arguments = $"/Unmount-Image /MountDir:\"{_mountDir}\" /Discard";

                //set value
                _helperDism.Arguments = arguments;

                //set value
                richTextBoxOutput.Text = $"Command: dism {arguments}{Environment.NewLine}";

                //run
                _backgroundWorker1.RunWorkerAsync(_helperDism);
            }
        }

        private void btnWimRemount_Click(object sender, EventArgs e)
        {
            //clear existing data
            richTextBoxOutput.Clear();

            //execute dism command
            if (!_backgroundWorker1.IsBusy)
            {
                //set value
                string arguments = $"/Remount-Image /MountDir:\"{_mountDir}\"";

                //set value
                richTextBoxOutput.Text = $"Command: dism {arguments}{Environment.NewLine}";

                if (!Directory.Exists(_mountDir))
                {
                    richTextBoxOutput.AppendText($"MountDir '{_mountDir}' doesn't exist. Skipping.");
                    return;
                }   
                else if (Directory.GetDirectories(_mountDir).Length < 1 && Directory.GetFiles(_mountDir).Length < 1)
                {
                    richTextBoxOutput.AppendText($"MountDir '{_mountDir}' doesn't contain any files/folders. Skipping.");
                    return;
                }

                //set value
                _helperDism.Arguments = arguments;

                //run
                _backgroundWorker1.RunWorkerAsync(_helperDism);
            }
        }
    }
}
