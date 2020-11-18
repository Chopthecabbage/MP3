namespace _62view_v3
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnReference = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnTrash = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHide = new System.Windows.Forms.Button();
            this.Spanel = new System.Windows.Forms.Panel();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnConstant = new System.Windows.Forms.Button();
            this.btnSequential = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnFastForward = new System.Windows.Forms.Button();
            this.btnFastReverse = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lstMediPlayer = new System.Windows.Forms.ListBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnTable = new System.Windows.Forms.Button();
            this.lblDownload = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Spanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReference
            // 
            this.btnReference.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReference.BackgroundImage")));
            this.btnReference.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReference.Image = ((System.Drawing.Image)(resources.GetObject("btnReference.Image")));
            this.btnReference.Location = new System.Drawing.Point(13, 12);
            this.btnReference.Name = "btnReference";
            this.btnReference.Size = new System.Drawing.Size(57, 34);
            this.btnReference.TabIndex = 0;
            this.btnReference.UseVisualStyleBackColor = true;
            this.btnReference.Click += new System.EventHandler(this.btnReference_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(13, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(342, 400);
            this.listBox1.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(361, 52);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(547, 399);
            this.webBrowser1.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShow.BackgroundImage")));
            this.btnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShow.Location = new System.Drawing.Point(76, 12);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(57, 34);
            this.btnShow.TabIndex = 3;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnTrash
            // 
            this.btnTrash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTrash.BackgroundImage")));
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrash.Location = new System.Drawing.Point(139, 12);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(57, 34);
            this.btnTrash.TabIndex = 4;
            this.btnTrash.UseVisualStyleBackColor = true;
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDown.BackgroundImage")));
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDown.Location = new System.Drawing.Point(806, 1);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(48, 45);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.btnHide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(930, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 461);
            this.panel1.TabIndex = 6;
            // 
            // btnHide
            // 
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHide.Location = new System.Drawing.Point(0, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(34, 85);
            this.btnHide.TabIndex = 0;
            this.btnHide.Text = "숨\r\n기\r\n기";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // Spanel
            // 
            this.Spanel.BackColor = System.Drawing.Color.Pink;
            this.Spanel.Controls.Add(this.btnInitialize);
            this.Spanel.Controls.Add(this.btnLoop);
            this.Spanel.Controls.Add(this.lblPath);
            this.Spanel.Controls.Add(this.btnConstant);
            this.Spanel.Controls.Add(this.btnSequential);
            this.Spanel.Controls.Add(this.btnRandom);
            this.Spanel.Controls.Add(this.btnFastForward);
            this.Spanel.Controls.Add(this.btnFastReverse);
            this.Spanel.Controls.Add(this.btnPlus);
            this.Spanel.Controls.Add(this.btnMinus);
            this.Spanel.Controls.Add(this.btnNext);
            this.Spanel.Controls.Add(this.btnBack);
            this.Spanel.Controls.Add(this.btnPop);
            this.Spanel.Controls.Add(this.btnPause);
            this.Spanel.Controls.Add(this.btnStop);
            this.Spanel.Controls.Add(this.btnOpen);
            this.Spanel.Controls.Add(this.lstMediPlayer);
            this.Spanel.Controls.Add(this.axWindowsMediaPlayer1);
            this.Spanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Spanel.Location = new System.Drawing.Point(13, 0);
            this.Spanel.Name = "Spanel";
            this.Spanel.Size = new System.Drawing.Size(917, 461);
            this.Spanel.TabIndex = 7;
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(336, 436);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(75, 23);
            this.btnInitialize.TabIndex = 17;
            this.btnInitialize.Text = "초기화";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(787, 331);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(99, 23);
            this.btnLoop.TabIndex = 16;
            this.btnLoop.Text = "구간 반복 설정";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(489, 377);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(397, 23);
            this.lblPath.TabIndex = 15;
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConstant
            // 
            this.btnConstant.Location = new System.Drawing.Point(653, 331);
            this.btnConstant.Name = "btnConstant";
            this.btnConstant.Size = new System.Drawing.Size(75, 23);
            this.btnConstant.TabIndex = 14;
            this.btnConstant.Text = "한 곡 반복";
            this.btnConstant.UseVisualStyleBackColor = true;
            this.btnConstant.Click += new System.EventHandler(this.btnConstant_Click);
            // 
            // btnSequential
            // 
            this.btnSequential.Location = new System.Drawing.Point(572, 331);
            this.btnSequential.Name = "btnSequential";
            this.btnSequential.Size = new System.Drawing.Size(75, 23);
            this.btnSequential.TabIndex = 13;
            this.btnSequential.Text = "순차 재생";
            this.btnSequential.UseVisualStyleBackColor = true;
            this.btnSequential.Click += new System.EventHandler(this.btnSequential_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(491, 331);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(75, 23);
            this.btnRandom.TabIndex = 12;
            this.btnRandom.Text = "랜덤 재생";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnFastForward
            // 
            this.btnFastForward.Location = new System.Drawing.Point(255, 436);
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Size = new System.Drawing.Size(75, 23);
            this.btnFastForward.TabIndex = 11;
            this.btnFastForward.Text = ">>";
            this.btnFastForward.UseVisualStyleBackColor = true;
            // 
            // btnFastReverse
            // 
            this.btnFastReverse.Location = new System.Drawing.Point(174, 435);
            this.btnFastReverse.Name = "btnFastReverse";
            this.btnFastReverse.Size = new System.Drawing.Size(75, 23);
            this.btnFastReverse.TabIndex = 10;
            this.btnFastReverse.Text = "<<";
            this.btnFastReverse.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(93, 436);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(75, 23);
            this.btnPlus.TabIndex = 9;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(12, 435);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(75, 23);
            this.btnMinus.TabIndex = 8;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(417, 407);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "다음 곡";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(336, 406);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "이전 곡";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPop
            // 
            this.btnPop.Location = new System.Drawing.Point(255, 407);
            this.btnPop.Name = "btnPop";
            this.btnPop.Size = new System.Drawing.Size(75, 23);
            this.btnPop.TabIndex = 5;
            this.btnPop.Text = "지우기";
            this.btnPop.UseVisualStyleBackColor = true;
            this.btnPop.Click += new System.EventHandler(this.btnPop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(174, 407);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "일시정지";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 407);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "정지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 407);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "열기";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lstMediPlayer
            // 
            this.lstMediPlayer.FormattingEnabled = true;
            this.lstMediPlayer.ItemHeight = 12;
            this.lstMediPlayer.Location = new System.Drawing.Point(491, 12);
            this.lstMediPlayer.Name = "lstMediPlayer";
            this.lstMediPlayer.Size = new System.Drawing.Size(395, 304);
            this.lstMediPlayer.TabIndex = 1;
            this.lstMediPlayer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMediPlayer_MouseDoubleClick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(460, 388);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnTable
            // 
            this.btnTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTable.BackgroundImage")));
            this.btnTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTable.Location = new System.Drawing.Point(860, 1);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(48, 45);
            this.btnTable.TabIndex = 8;
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // lblDownload
            // 
            this.lblDownload.Font = new System.Drawing.Font("휴먼엑스포", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDownload.Location = new System.Drawing.Point(444, 1);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(356, 45);
            this.lblDownload.TabIndex = 9;
            this.lblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 461);
            this.Controls.Add(this.Spanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnTrash);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnReference);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.lblDownload);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.Spanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReference;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Panel Spanel;
        private System.Windows.Forms.Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ListBox lstMediPlayer;
        private System.Windows.Forms.Button btnConstant;
        private System.Windows.Forms.Button btnSequential;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnFastForward;
        private System.Windows.Forms.Button btnFastReverse;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Label lblDownload;
    }
}

