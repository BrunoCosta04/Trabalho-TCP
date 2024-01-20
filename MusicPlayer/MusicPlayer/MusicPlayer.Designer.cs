namespace MusicPlayer
{
    partial class MusicPlayer
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            btnGenerateMusic = new Button();
            btnUpload = new Button();
            btnDownload = new Button();
            btnPlayMusic = new Button();
            groupBox2 = new GroupBox();
            cmbOctaves = new ComboBox();
            cmbInstruments = new ComboBox();
            label6 = new Label();
            tbVolume = new TrackBar();
            label4 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel6 = new Panel();
            txtMusic = new TextBox();
            panel5 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbVolume).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(332, 441);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 58.5858574F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 41.4141426F));
            tableLayoutPanel1.Size = new Size(332, 441);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGenerateMusic);
            panel3.Controls.Add(btnUpload);
            panel3.Controls.Add(btnDownload);
            panel3.Controls.Add(btnPlayMusic);
            panel3.Controls.Add(groupBox2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 260);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(326, 179);
            panel3.TabIndex = 1;
            // 
            // btnGenerateMusic
            // 
            btnGenerateMusic.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerateMusic.Location = new Point(109, 127);
            btnGenerateMusic.Margin = new Padding(3, 2, 3, 2);
            btnGenerateMusic.Name = "btnGenerateMusic";
            btnGenerateMusic.Size = new Size(108, 22);
            btnGenerateMusic.TabIndex = 11;
            btnGenerateMusic.Text = "Generate Music!";
            btnGenerateMusic.UseVisualStyleBackColor = true;
            btnGenerateMusic.Click += btnGenerateMusic_Click;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpload.Location = new Point(6, 127);
            btnUpload.Margin = new Padding(3, 2, 3, 2);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(97, 48);
            btnUpload.TabIndex = 10;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownload.Location = new Point(221, 127);
            btnDownload.Margin = new Padding(3, 2, 3, 2);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(97, 48);
            btnDownload.TabIndex = 9;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnPlayMusic
            // 
            btnPlayMusic.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlayMusic.Location = new Point(109, 153);
            btnPlayMusic.Margin = new Padding(3, 2, 3, 2);
            btnPlayMusic.Name = "btnPlayMusic";
            btnPlayMusic.Size = new Size(108, 22);
            btnPlayMusic.TabIndex = 8;
            btnPlayMusic.Text = "Play Music!";
            btnPlayMusic.UseVisualStyleBackColor = true;
            btnPlayMusic.Click += btnTocarMusica_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(cmbOctaves);
            groupBox2.Controls.Add(cmbInstruments);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(tbVolume);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(6, 2);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(312, 121);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Setup";
            // 
            // cmbOctaves
            // 
            cmbOctaves.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOctaves.FormattingEnabled = true;
            cmbOctaves.Location = new Point(88, 45);
            cmbOctaves.Margin = new Padding(3, 2, 3, 2);
            cmbOctaves.Name = "cmbOctaves";
            cmbOctaves.Size = new Size(208, 23);
            cmbOctaves.TabIndex = 9;
            // 
            // cmbInstruments
            // 
            cmbInstruments.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstruments.FormattingEnabled = true;
            cmbInstruments.Location = new Point(88, 20);
            cmbInstruments.Margin = new Padding(3, 2, 3, 2);
            cmbInstruments.Name = "cmbInstruments";
            cmbInstruments.Size = new Size(208, 23);
            cmbInstruments.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 81);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 7;
            label6.Text = "Volume:";
            // 
            // tbVolume
            // 
            tbVolume.Location = new Point(88, 70);
            tbVolume.Margin = new Padding(3, 2, 3, 2);
            tbVolume.Maximum = 127;
            tbVolume.Minimum = 10;
            tbVolume.Name = "tbVolume";
            tbVolume.Size = new Size(207, 45);
            tbVolume.SmallChange = 127;
            tbVolume.TabIndex = 5;
            tbVolume.TickStyle = TickStyle.Both;
            tbVolume.Value = 60;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 22);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 5;
            label4.Text = "Instruments:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 47);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 6;
            label5.Text = "Octaves:";
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 2);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(326, 254);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel6, 0, 1);
            tableLayoutPanel2.Controls.Add(panel5, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(326, 254);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(txtMusic);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 28);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(320, 224);
            panel6.TabIndex = 1;
            // 
            // txtMusic
            // 
            txtMusic.Dock = DockStyle.Fill;
            txtMusic.Location = new Point(0, 0);
            txtMusic.Margin = new Padding(3, 2, 3, 2);
            txtMusic.Multiline = true;
            txtMusic.Name = "txtMusic";
            txtMusic.PlaceholderText = "Text here...";
            txtMusic.ScrollBars = ScrollBars.Vertical;
            txtMusic.Size = new Size(320, 224);
            txtMusic.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 2);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(320, 22);
            panel5.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "Text:";
            // 
            // MusicPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 441);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MusicPlayer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Player";
            Load += MusicPlayer_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbVolume).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private TrackBar tbVolume;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel5;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel6;
        private TextBox txtMusic;
        private ComboBox cmbOctaves;
        private ComboBox cmbInstruments;
        private Button btnUpload;
        private Button btnDownload;
        private Button btnPlayMusic;
        private Button btnGenerateMusic;
    }
}