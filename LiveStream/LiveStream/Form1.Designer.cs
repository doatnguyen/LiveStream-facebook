using System.Windows.Forms;

namespace LiveStream
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                Application.Exit();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_stream_key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.cb_reslution = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_gpu = new System.Windows.Forms.ComboBox();
            this.listFileGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_del_file = new System.Windows.Forms.Button();
            this.btn_up_list = new System.Windows.Forms.Button();
            this.btn_down_list = new System.Windows.Forms.Button();
            this.ch_loop = new System.Windows.Forms.CheckBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.txt_warning = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_server = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_stream_url = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listFileGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_stream_key
            // 
            this.txt_stream_key.Location = new System.Drawing.Point(111, 38);
            this.txt_stream_key.Name = "txt_stream_key";
            this.txt_stream_key.Size = new System.Drawing.Size(604, 20);
            this.txt_stream_key.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stream Key";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(16, 368);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_log.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_log.Location = new System.Drawing.Point(-2, 407);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(727, 71);
            this.txt_log.TabIndex = 4;
            this.txt_log.Text = "";
            // 
            // cb_reslution
            // 
            this.cb_reslution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_reslution.Items.AddRange(new object[] {
            "1280x720",
            "1980x1080"});
            this.cb_reslution.Location = new System.Drawing.Point(272, 308);
            this.cb_reslution.Name = "cb_reslution";
            this.cb_reslution.Size = new System.Drawing.Size(121, 21);
            this.cb_reslution.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Độ phân giải";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "GPU";
            // 
            // cb_gpu
            // 
            this.cb_gpu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_gpu.FormattingEnabled = true;
            this.cb_gpu.Items.AddRange(new object[] {
            "CPU",
            "AMD",
            "NVIA"});
            this.cb_gpu.Location = new System.Drawing.Point(49, 308);
            this.cb_gpu.Name = "cb_gpu";
            this.cb_gpu.Size = new System.Drawing.Size(121, 21);
            this.cb_gpu.TabIndex = 9;
            // 
            // listFileGrid
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listFileGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.listFileGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listFileGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listFileGrid.DefaultCellStyle = dataGridViewCellStyle14;
            this.listFileGrid.Location = new System.Drawing.Point(16, 131);
            this.listFileGrid.Name = "listFileGrid";
            this.listFileGrid.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listFileGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.listFileGrid.Size = new System.Drawing.Size(618, 150);
            this.listFileGrid.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Tên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Vị Trí";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btn_add
            // 
            this.btn_add.Image = global::LiveStream.Properties.Resources.icons8_add_image_16;
            this.btn_add.Location = new System.Drawing.Point(640, 131);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 11;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_del_file
            // 
            this.btn_del_file.Image = global::LiveStream.Properties.Resources.icons8_delete_16;
            this.btn_del_file.Location = new System.Drawing.Point(640, 161);
            this.btn_del_file.Name = "btn_del_file";
            this.btn_del_file.Size = new System.Drawing.Size(75, 23);
            this.btn_del_file.TabIndex = 12;
            this.btn_del_file.UseVisualStyleBackColor = true;
            this.btn_del_file.Click += new System.EventHandler(this.btn_del_file_Click);
            // 
            // btn_up_list
            // 
            this.btn_up_list.Image = global::LiveStream.Properties.Resources.icons8_collapse_arrow_16;
            this.btn_up_list.Location = new System.Drawing.Point(640, 191);
            this.btn_up_list.Name = "btn_up_list";
            this.btn_up_list.Size = new System.Drawing.Size(75, 23);
            this.btn_up_list.TabIndex = 13;
            this.btn_up_list.UseVisualStyleBackColor = true;
            this.btn_up_list.Click += new System.EventHandler(this.btn_up_list_Click);
            // 
            // btn_down_list
            // 
            this.btn_down_list.Image = global::LiveStream.Properties.Resources.icons8_expand_arrow_16;
            this.btn_down_list.Location = new System.Drawing.Point(640, 221);
            this.btn_down_list.Name = "btn_down_list";
            this.btn_down_list.Size = new System.Drawing.Size(75, 23);
            this.btn_down_list.TabIndex = 14;
            this.btn_down_list.UseVisualStyleBackColor = true;
            this.btn_down_list.Click += new System.EventHandler(this.btn_down_list_Click);
            // 
            // ch_loop
            // 
            this.ch_loop.AutoSize = true;
            this.ch_loop.Checked = true;
            this.ch_loop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_loop.Location = new System.Drawing.Point(432, 311);
            this.ch_loop.Name = "ch_loop";
            this.ch_loop.Size = new System.Drawing.Size(57, 17);
            this.ch_loop.TabIndex = 15;
            this.ch_loop.Text = "Lặp lại";
            this.ch_loop.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(111, 367);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 16;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // txt_warning
            // 
            this.txt_warning.AutoSize = true;
            this.txt_warning.ForeColor = System.Drawing.Color.Red;
            this.txt_warning.Location = new System.Drawing.Point(229, 376);
            this.txt_warning.Name = "txt_warning";
            this.txt_warning.Size = new System.Drawing.Size(0, 13);
            this.txt_warning.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Show Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Server";
            // 
            // cb_server
            // 
            this.cb_server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_server.FormattingEnabled = true;
            this.cb_server.Items.AddRange(new object[] {
            "Facebook",
            "Youtube"});
            this.cb_server.Location = new System.Drawing.Point(65, 71);
            this.cb_server.Name = "cb_server";
            this.cb_server.Size = new System.Drawing.Size(121, 21);
            this.cb_server.TabIndex = 20;
            this.cb_server.SelectedIndexChanged += new System.EventHandler(this.cb_server_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Url Server";
            // 
            // txt_stream_url
            // 
            this.txt_stream_url.Location = new System.Drawing.Point(254, 72);
            this.txt_stream_url.Name = "txt_stream_url";
            this.txt_stream_url.Size = new System.Drawing.Size(461, 20);
            this.txt_stream_url.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 478);
            this.Controls.Add(this.txt_stream_url);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_server);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_warning);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.ch_loop);
            this.Controls.Add(this.btn_down_list);
            this.Controls.Add(this.btn_up_list);
            this.Controls.Add(this.btn_del_file);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.listFileGrid);
            this.Controls.Add(this.cb_gpu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_reslution);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_stream_key);
            this.Name = "Form1";
            this.Text = "LiveStream Facebook Simple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.listFileGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_stream_key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.RichTextBox txt_log;
        private ComboBox cb_reslution;
        private Label label2;
        private Label label3;
        private ComboBox cb_gpu;
        private DataGridView listFileGrid;
        private Button btn_add;
        private Button btn_del_file;
        private Button btn_up_list;
        private Button btn_down_list;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private CheckBox ch_loop;
        private Button btn_stop;
        private Label txt_warning;
        private Button button1;
        private Label label4;
        private ComboBox cb_server;
        private Label label5;
        private TextBox txt_stream_url;
    }
}

