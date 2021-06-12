using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace LiveStream
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public OpenFileDialog openFileDialog1 = null;
        public String[] url = {"rtmps:/live-api-s.facebook.com:443/rtmp/","rtmp://a.rtmp.youtube.com/live2/"};
        private String[] gpu = { " -c:v libx264", " -c:v h264_amf", " -c:v h264_nvenc" },
            reslution= {"1280x720","1980x1080"};
        private String Log = "";
        private Boolean isShowDialog = false;
        private System.Threading.Timer timer = null;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.cb_reslution.SelectedIndex = 0;
            this.cb_gpu.SelectedIndex = 1;
            this.cb_server.SelectedIndex = 0;
            this.txt_stream_url.Text = url[0];
        }
        private void  btn_start_Click(object sender, EventArgs e)
        {
            timer= new System.Threading.Timer(CheckDialog, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            xxxffmpeg();
        }
        public void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                String res = String.Format(e.Data);
                if (res.Contains("time") && res.Contains("fps"))
                {
                    txt_log.Text = "> " + res;
                }
                else
                {
                    Log += res + "\n";
                    if (res.ToLower().Contains("server error") && !isShowDialog)
                    {
                        string caption = "Lỗi mạng hoặc tràn bộ nhớ";
                        string message = "Reconnecting Stream....";
                        isShowDialog = true;
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);
                        /*
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            // Closes the parent form.
                            isShowDialog = false;
                        }
                        */
                    }
                }
            }
        }
        public void P_OutputErrorReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                String res = String.Format(e.Data);
                if (res.Contains("time") && res.Contains("fps"))
                {
                    txt_log.Text = "> " + res;
                }
                else
                {
                    Log += res + "\n";
                    if (res.ToLower().Contains("server error")&&!isShowDialog)
                    {
                        string caption = "Lỗi mạng hoặc tràn bộ nhớ";
                        string message = "Reconnecting Stream....";
                        isShowDialog = true;
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);
                        /*
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            // Closes the parent form.
                            isShowDialog = false;
                        }
                        */
                    }
                }
            }
        }
        private void exitStream()
        {
            btn_start.Enabled = true;
            txt_log.AppendText("> End Stream");
            if (timer != null) timer.Dispose();
            try
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), Log);
            }
            catch {
                txt_log.AppendText("Không ghi được Log");
            }
        }
        public Process ffmpeg = new Process();

        public object Properties { get; }

        private void xxxffmpeg()
        {
            String cmd = getCMD();
            Console.WriteLine(cmd);
            if (cmd == null) return;
            btn_start.Enabled = false;
            Log = "";
            ffmpeg = new Process();
            ffmpeg.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg\\bin\\ffmpeg.exe");
            
            ffmpeg.StartInfo.Arguments =cmd;
            ffmpeg.StartInfo.RedirectStandardOutput = true;
            ffmpeg.StartInfo.RedirectStandardError = true;
            ffmpeg.EnableRaisingEvents = true;
            ffmpeg.StartInfo.CreateNoWindow = true;
            ffmpeg.StartInfo.UseShellExecute = false;
            // see below for output handler
            ffmpeg.ErrorDataReceived += P_OutputErrorReceived;
            ffmpeg.OutputDataReceived += P_OutputDataReceived;

            ffmpeg.Start();

            ffmpeg.BeginErrorReadLine();
            ffmpeg.BeginOutputReadLine();
            ffmpeg.Exited += (o, e) => exitStream();
            //ffmpeg.WaitForExit();
            /*
            ffmpeg.StartInfo.CreateNoWindow = true;
            ffmpeg.StartInfo.RedirectStandardOutput = true;
            ffmpeg.StartInfo.UseShellExecute = false;
            //ffmpeg.StartInfo.RedirectStandardInput = false;
            ffmpeg.EnableRaisingEvents = true;
            ffmpeg.OutputDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffmpeg");
            ffmpeg.ErrorDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffmpeg");
            ffmpeg.Exited += (o, e) => Debug.WriteLine("Exited", "ffmpeg");
            ffmpeg.Start();

            Thread.Sleep(500); // you need to wait/check the process started, then...

            // child, new parent
            // make 'this' the parent of ffmpeg (presuming you are in scope of a Form or Control)
            SetParent(ffmpeg.MainWindowHandle, this.Handle);

            // window, x, y, width, height, repaint
            // move the ffmpeger window to the top-left corner and set the size to 320x280
           MoveWindow(ffmpeg.MainWindowHandle, txt_log.Bounds.X, txt_log.Bounds.Y, txt_log.Width, txt_log.Height, true);
            */

        }
        private String getCMD()
        {
            DataGridView dgv = listFileGrid;
            try
            {
                int totalRows = dgv.Rows.Count;
                if (totalRows == 1||txt_stream_key.TextLength<1)
                    return null;
                String loop = "";
                if (ch_loop.Checked)
                {
                    loop = "-stream_loop -1";
                }
                if (totalRows == 2) return " -re " + loop + " -i \"" + dgv.Rows[0].Cells[1].Value + "\"" + gpu[cb_gpu.SelectedIndex] + " -preset veryfast -s " + reslution[cb_reslution.SelectedIndex] + " -b:v 1500k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 128k -ac 2 -ar 44100 -f fifo -fifo_format flv -map 0:v -map 0:a -drop_pkts_on_overflow 1 -attempt_recovery 1 -recovery_wait_time 1 \"" + txt_stream_url.Text + txt_stream_key.Text + "\" ";
                String input = "";
                String filter = "";
                for(int i = 0; i < totalRows-1; i++)
                {
                    input += " "+loop+" -i \"" + dgv.Rows[i].Cells[1].Value + "\"" ;
                    filter += "["+i+":v]"+ "[" + i + ":a]";
                }
                filter += "concat=n=" + (totalRows-1) + ":v=1:a=1 [v] [a]";
                String cmd_filetr = "-filter_complex \""+filter+"\"";
                return " -re "+input+" "+cmd_filetr+ gpu[cb_gpu.SelectedIndex] + " -preset veryfast -s " + reslution[cb_reslution.SelectedIndex] + " -b:v 1500k -maxrate 3000k -bufsize 6000k -pix_fmt yuv420p -g 50 -c:a aac -b:a 128k -ac 2 -ar 44100  -f fifo -fifo_format flv -map \"[v]\" -map \"[a]\" -drop_pkts_on_overflow 1 -attempt_recovery 1 -recovery_wait_time 1  \"" + txt_stream_url.Text + txt_stream_key.Text + "\" ";

            }
            catch {
                return null;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Video Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "mp4",
                Filter = "video file (*.mp4;*.mkv;*.flv;*.ts)|*.mp4;*.mkv;*.flv;*.ts",
                FilterIndex = 2,
                RestoreDirectory = true,
                Multiselect = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String[] list =openFileDialog1.FileNames;
                for(int i=0;i<list.Length;i++){
                    int num = listFileGrid.Rows.Add();
                    listFileGrid.Rows[num].Cells[0].Value = Path.GetFileNameWithoutExtension(list[i]);
                    listFileGrid.Rows[num].Cells[1].Value = list[i];
                }

            }

        }

        private void btn_up_list_Click(object sender, EventArgs e)
        {
            DataGridView dgv = listFileGrid;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex - 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
            }
            catch { }
        }

        private void btn_down_list_Click(object sender, EventArgs e)
        {
            DataGridView dgv = listFileGrid;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex + 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch { }
        }

        private void btn_del_file_Click(object sender, EventArgs e)
        {
            DataGridView dgv = listFileGrid;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.ClearSelection();
            }
            catch { 
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            try { 
                ffmpeg.Kill();
                txt_log.Text = "> Stop Stream\n";
            }
            catch { }
            if(timer!=null) timer.Dispose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { ffmpeg.Kill(); }
            catch { }
            if (timer != null) timer.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
                "Bạn có muốn tắt LiveStream?";
            const string caption = "Close LiveStream";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                e.Cancel = true;
            }
        }
        public void CheckDialog(object state)
        {
            if (isShowDialog) isShowDialog = false;
        }

        private void cb_server_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_stream_url.Text = url[cb_server.SelectedIndex];
        }
    }
}
