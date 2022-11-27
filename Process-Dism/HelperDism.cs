using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Process_Dism
{
    public class HelperDism
    {
        public delegate void EventHandlerDataReceived(object sender, DataReceivedEventArgs e);

        public event EventHandlerDataReceived ErrorReceived;
        public event EventHandlerDataReceived DataReceived;

        public string Arguments { get; set; }
        public System.Text.Encoding Encoding { get; set; } = null;

        public void RunDism(System.ComponentModel.BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e)
        {
            string dismFullyQualifiedFilename = Path.Combine(Environment.GetEnvironmentVariable("windir"), "system32", "Dism.exe");

            if (!System.IO.File.Exists(dismFullyQualifiedFilename))
                throw new Exception($"'{dismFullyQualifiedFilename}' doesn't exist.");

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //create new instance
            ProcessStartInfo psInfo = new ProcessStartInfo(dismFullyQualifiedFilename);

            if (!String.IsNullOrEmpty(Arguments))
                psInfo.Arguments = Arguments;

            if (Encoding != null)
            {
                //set value
                psInfo.StandardErrorEncoding = Encoding;
                psInfo.StandardOutputEncoding = Encoding;
            }

            psInfo.CreateNoWindow = true;
            psInfo.RedirectStandardError = true; //redirect standard Error
            psInfo.RedirectStandardOutput = true; //redirect standard output
            psInfo.RedirectStandardInput = false;
            psInfo.UseShellExecute = false; //if True, uses 'ShellExecute'; if false, uses 'CreateProcess'
            psInfo.Verb = "runas"; //use elevated permissions
            psInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //create new instance and set properties
            using (Process p = new Process() { EnableRaisingEvents = true, StartInfo = psInfo })
            {
                //subscribe to event and add event handler code
                p.ErrorDataReceived += (sender, e2) =>
                {
                    if (!String.IsNullOrEmpty(e2.Data))
                    {
                        //ToDo: add desired code 
                        Debug.WriteLine($"Error: {e2.Data}");

                        if (this.ErrorReceived != null)
                            //raise event
                            this.ErrorReceived(this, e2);
                    }
                };

                //subscribe to event and add event handler code
                p.OutputDataReceived += (sender, e2) =>
                {
                    if (!String.IsNullOrEmpty(e2.Data))
                    {
                        //ToDo: add desired code
                        Debug.WriteLine($"Output: '{e2.Data.Trim()}'");

                        if (this.DataReceived != null)
                            //raise event
                            this.DataReceived(this, e2);
                    }
                };

                p.Start(); //start

                p.BeginErrorReadLine(); //begin async reading for standard error
                p.BeginOutputReadLine(); //begin async reading for standard output

                //waits until the process is finished before continuing
                p.WaitForExit();
            }
        }
    }
}
