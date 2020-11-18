using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.IO;
using VideoLibrary;
using MediaToolkit;
using System.Net;
//
using System.Diagnostics;
using NAudio.Wave;
//
using System.Threading;
using System.Data.SQLite;

namespace _62view_v3
{
    public partial class MainForm : Form
    {
        List<IdInfo> i = new List<IdInfo>();
        ReferenceForm r;
        // 잡다한
        int PW;
        bool Hided;
        // MP3
        string[] files, paths;
        List<string> voyage = new List<string>();
        int State = 0;
        Random rand = new Random();
        int shuffle;
        string phrase;
        bool Initialize = true;
        string point = null;
        // Thread thd;
        double[] loop = new double[2];
        bool mode = false;
        // SQLite
        private string connecString;
        Table t;

        public MainForm()
        {
            InitializeComponent();
            CenterToScreen(); // 중앙 위치

            PW = Spanel.Width;
            Hided = false;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // 크기 고정
            openFileDialog1.Multiselect = true;
        }

        // 슬라이드
        private void btnHide_Click(object sender, EventArgs e)
        {
            if (Hided) btnHide.Text = "숨\n기\n기";
            else btnHide.Text = "보\n여\n주\n기";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hided)
            {
                Spanel.Width = Spanel.Width + 20;
                if (Spanel.Width >= PW)
                {
                    timer1.Stop();
                    Hided = false;
                    this.Refresh();
                }
            }
            else
            {
                Spanel.Width = Spanel.Width - 20;
                if (Spanel.Width <= 0)
                {
                    timer1.Stop();
                    Hided = true;
                    this.Refresh();
                }
            }
        }

        // 유튜브 관련
        private void btnReference_Click(object sender, EventArgs e)
        {
            r = new ReferenceForm(this, ref i);
            r.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string Title = null;
            string ID = null;
            //
            if (listBox1.SelectedIndex != -1)
            {
                Title = listBox1.SelectedItem.ToString();
                foreach (IdInfo prime in i)
                {
                    if (prime.Title == Title)
                    {
                        ID = prime.Info;
                        break;
                    }
                }

                string youtubeurl = "http://youtube.com/watch?v=" + ID;
                Debug.WriteLine("Url: " + youtubeurl);
                webBrowser1.Navigate(youtubeurl);
            }
            else
            {
                AutoClosingMessageBox.Show("선택을 먼저해 주세요.", "알람", 1000);
            }
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            string Title;

            if (listBox1.SelectedIndex != -1)
            {
                Title = listBox1.SelectedItem.ToString();
                foreach (IdInfo prime in i)
                {
                    if (prime.Title == Title)
                    {
                        var level = new IdInfo(prime.Info, prime.Title);
                        i.Remove(level);
                        break;
                    }
                }
            }
            else
            {
                AutoClosingMessageBox.Show("선택을 먼저해 주세요.", "알람", 1000);
            }

            Refreshing();
        }

        private async void btnDown_Click(object sender, EventArgs e)
        {
            string Title;

            if (listBox1.SelectedIndex != -1)
            {
                Title = listBox1.SelectedItem.ToString();
                using (FolderBrowserDialog f = new FolderBrowserDialog() { Description = "저장할 폴더를 선택하세요." })
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        lblDownload.Text = "다운로드 중입니다\n기다려 주세요";
                        //lblDownload.Text = "다운로드가 시작되었습니다.";
                        //lblDownload.ForeColor = Color.Red;
                        string ID = null;

                        foreach (IdInfo prime in i)
                        {
                            if (prime.Title == Title)
                            {
                                ID = prime.Info;
                                break;
                            }
                        }

                        string youtubeurl = null;

                        if (ID == null)
                        {
                            Debug.WriteLine("btnDown_Click -> Error");
                        }
                        else
                        {
                            youtubeurl = "http://youtube.com/watch?v=" + ID;

                            // Title
                            WebRequest GetTitle = HttpWebRequest.Create(youtubeurl);
                            var youtube = YouTube.Default;
                            try
                            {
                                var video = await youtube.GetVideoAsync(youtubeurl); // -> 제한 걸린 파일은 오류...
                                File.WriteAllBytes(f.SelectedPath + @"\" + video.Title, await video.GetBytesAsync());
                                //File.WriteAllBytes(f.SelectedPath + @"\" + video.FullName, await video.GetBytesAsync());
                                // 새 파일을 만들고 지정된 바이트 배열을 파일에 쓴 다음 파일을 닫습니다. 대상 파일이 이미 있으면 덮어씁니다.

                                var inputFile = new MediaToolkit.Model.MediaFile { Filename = f.SelectedPath + @"\" + video.Title };
                                var outputFile = new MediaToolkit.Model.MediaFile { Filename = $"{f.SelectedPath + @"\" + video.Title}.mp3" };
                                //var inputFile = new MediaToolkit.Model.MediaFile { Filename = f.SelectedPath + @"\" + video.FullName }; // -> mp4 까지 다운 가능
                                //var outputFile = new MediaToolkit.Model.MediaFile { Filename = $"{f.SelectedPath + @"\" + video.FullName}.mp3" };

                                using (var enging = new Engine())
                                {
                                    enging.GetMetadata(inputFile);
                                    enging.Convert(inputFile, outputFile);
                                }
                                /*
                                if (rbtnMP4.Checked == true)
                                {
                                    File.Delete($"{f.SelectedPath + @"\" + video.FullName}.mp3");
                                }
                                else if (rbtnMP3.Checked == true)
                                {
                                    File.Delete(f.SelectedPath + @"\" + video.FullName);
                                }
                                */
                                File.Delete(f.SelectedPath + @"\" + video.Title);
                                //File.Delete(f.SelectedPath + @"\" + video.FullName); // MP4 삭제
                                AutoClosingMessageBox.Show("다운이 완료되었습니다.", "알람", 1000);

                                lblDownload.Text = "";
                                //lblDownload.Text = "다운로드가 완료되었습니다.";
                                //lblDownload.ForeColor = Color.Green;

                                //SQLite
                                SQLiteConn("C:\\sqlite-tools-win32-x86-3330000\\download.db");
                                InsertDB("download", Title, f.SelectedPath);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("Error: " + ex);
                                AutoClosingMessageBox.Show("동영상 제한사항입니다.", "Error", 1000);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("파일 경로를 선택하세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                AutoClosingMessageBox.Show("선택을 먼저해 주세요.", "알람", 1000);
            }
        }

        // 화면 전환 함수
        private void Refreshing()
        {
            listBox1.Items.Clear();
            foreach (IdInfo prime in i)
            {
                listBox1.Items.Add(prime.Title);
            }
        }

        // MP3
        private void Music_Sel()
        {
            //axWindowsMediaPlayer1.URL = lstMediPlayer.SelectedItem.ToString();
            axWindowsMediaPlayer1.URL = voyage[lstMediPlayer.SelectedIndex];
            axWindowsMediaPlayer1.Ctlcontrols.play();
            Debug.WriteLine("lstMediPlayer.SelectedIndex => " + lstMediPlayer.SelectedIndex);
            /*
            AudioFileReader reader = new AudioFileReader(voyage[lstMediPlayer.SelectedIndex]);
            TimeSpan newTimeSpan = reader.TotalTime;
            labelTotalTime.Text = newTimeSpan.ToString(@"mm\:ss");
            */
        }

        private void lstMediPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Music_Sel(); // 범위 지정 후 Ctrl+. -> 메소드 자동 생성
            //lblPath.Text = lstMediPlayer.SelectedItem.ToString();
            lblPath.Text = voyage[lstMediPlayer.SelectedIndex];
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Initialize = true;
                axWindowsMediaPlayer1.Ctlenabled = true;

                files = openFileDialog1.SafeFileNames;
                paths = openFileDialog1.FileNames;

                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    //lstMediPlayer.Items.Add(files[i]);
                    voyage.Add(paths[i]);
                    AudioFileReader reader = new AudioFileReader(voyage[i]);
                    TimeSpan newTimeSpan = reader.TotalTime;
                    //labelTotalTime.Text = newTimeSpan.ToString(@"mm\:ss");

                    if (i < 9)
                    {
                        phrase = "0" + (i + 1) + "번  " + "[" + newTimeSpan.ToString(@"mm\:ss") + "]" + "  " + files[i];
                    }
                    else
                    {
                        phrase = (i + 1) + "번  " + "[" + newTimeSpan.ToString(@"mm\:ss") + "]" + "  " + files[i];
                    }
                    //var padded = phrase.PadLeft(30);

                    lstMediPlayer.Items.Add(phrase);
                }

                if (lstMediPlayer.Items.Count > 0)
                {
                    lstMediPlayer.SelectedIndex = 0;
                }
            }
            else
            {
                //MessageBox.Show("파일 경로를 선택하세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            if (lstMediPlayer.SelectedItem == null)
            {
                return;
            }
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            voyage.RemoveAt(lstMediPlayer.SelectedIndex);
            lstMediPlayer.Items.RemoveAt(lstMediPlayer.SelectedIndex);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lstMediPlayer.SelectedIndex == 0)
            {
                Music_Sel();
            }
            else
            {
                lstMediPlayer.SelectedIndex--;
                lblPath.Text = voyage[lstMediPlayer.SelectedIndex];
                Music_Sel();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lstMediPlayer.SelectedIndex == voyage.Count - 1)
            {
                Music_Sel();
            }
            else
            {
                lstMediPlayer.SelectedIndex++;
                lblPath.Text = voyage[lstMediPlayer.SelectedIndex];
                Music_Sel();
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            Initialize = false;
            Array.Clear(files, 0, files.Length - 1);
            Array.Clear(paths, 0, paths.Length - 1);
            voyage.Clear();
            voyage.Capacity = 0;
            lstMediPlayer.Items.Clear();
        }

        private void btnConstant_Click(object sender, EventArgs e)
        {
            /*
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.URL = voyage[lstMediPlayer.SelectedIndex];
            */
            State = 2;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.settings.setMode("shuffle", true);
            shuffle = rand.Next(0, voyage.Count);
            lstMediPlayer.SelectedIndex = shuffle;
            lblPath.Text = voyage[shuffle];

            axWindowsMediaPlayer1.URL = voyage[shuffle];
            axWindowsMediaPlayer1.Ctlcontrols.play();
            State = 1;
        }

        private void btnSequential_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.settings.setMode("autoReWind", true);
            State = 0;
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                timer2.Interval = 100;
                //                
                if (Initialize)
                    timer2.Enabled = true;
                else
                    timer2.Enabled = false;
                //
                if (!timer2.Enabled)
                    axWindowsMediaPlayer1.Ctlenabled = false;
                lblPath.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (State == 0)
            {
                if (lstMediPlayer.SelectedIndex < voyage.Count - 1)
                {
                    lstMediPlayer.SelectedIndex++;
                    lblPath.Text = voyage[lstMediPlayer.SelectedIndex];
                    timer2.Enabled = false;
                }
                else
                {
                    lstMediPlayer.SelectedIndex = 0;
                    lblPath.Text = voyage[lstMediPlayer.SelectedIndex];
                    timer2.Enabled = false;
                }
            }
            else if (State == 1)
            {
                shuffle = rand.Next(0, voyage.Count);
                lstMediPlayer.SelectedIndex = shuffle;
                lblPath.Text = voyage[shuffle];
                axWindowsMediaPlayer1.URL = voyage[shuffle];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                timer2.Enabled = false;
                return;
            }
            else if (State == 2)
            {
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                axWindowsMediaPlayer1.URL = voyage[lstMediPlayer.SelectedIndex];
                timer2.Enabled = false;
                return;
            }
            Music_Sel();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume += 5;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume -= 5;
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsPlaying)
                return;
            try
            {
                if (btnLoop.Text == "구간 반복 설정")
                {
                    point = voyage[lstMediPlayer.SelectedIndex];
                    loop[0] = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                    btnLoop.Text = "종료 구간 선택";
                    mode = false;
                }
                else if (btnLoop.Text == "종료 구간 선택")
                {
                    if (point != voyage[lstMediPlayer.SelectedIndex])
                    {
                        btnLoop.Text = "구간 반복 설정";
                        return;
                    }

                    loop[1] = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                    btnLoop.Text = "구간 반복 중";
                    mode = true;

                    Thread thd = new Thread(new ThreadStart(delegate ()
                    {
                        while (mode)
                        {
                            this.Invoke(new Action(delegate ()
                            {
                                if (axWindowsMediaPlayer1.Ctlcontrols.currentPosition > loop[1])
                                {
                                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition = loop[0];
                                }
                            }));
                        }
                    }));
                    thd.Start();
                }
                else if (btnLoop.Text == "구간 반복 중")
                {
                    mode = false;
                    btnLoop.Text = "구간 반복 설정";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
            }
        }
        // SQLite
        private void SQLiteConn(string DBFilePath) // 테이블 -> SQConn.ConnectionString 설정
        {
            connecString = "Data Source=" + DBFilePath + ";Pooling=true;FailIfMissing=false"; // true -> 예외 발생, false -> empty database is created.
            // 커넥션 풀링은 DB와 새 연결시 많은 자원을 소모하는 데, 직접 연결을 피하고,
            // 연결된 커넥션을 자원으로서 관리를 하여 성능 향상을 얻고자 하는 방법
            // Pooling = false => 풀링이 사용되지 않는다.
        }

        ///트랜잭션 이란? => 트랜잭션(Transaction 이하 트랜잭션)이란, 데이터베이스의 상태를 변화시키기 해서 수행하는 작업의 단위를 뜻한다.
        ///데이터베이스의 상태를 변화시킨다는 것은 무얼 의미하는 것일까?
        ///간단하게 말해서 아래의 질의어(SQL)를 이용하여 데이터베이스를 접근 하는 것을 의미한다.

        private void InsertDB(string TableName, string Title, string Path)
        {
            //SQLite 연결
            SQLiteConnection SQConn = new SQLiteConnection();
            SQLiteCommand cmd;
            SQConn.ConnectionString = connecString;
            SQConn.Open();

            //트랜잭션 시작
            BeginTran(SQConn);

            cmd = new SQLiteCommand("INSERT INTO " + TableName + " (download_datetime, download_title, download_path) values (datetime('now', 'localtime')" + ", '" + Title + "', '" + Path + "')", SQConn);
            cmd.ExecuteNonQuery();
            /*
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT last_insert_rowid()";
            Int64 LastRowID64 = (Int64)cmd.ExecuteScalar(); // 명령을 실행하고 수행한 결과 집합에서 1행 1열을 반환하는 ExecuteScalra 메서드를 제공하고 있습니다.
            LastRowID = (int)LastRowID64;
            */
            //트랜잭션을 완료한다.
            CommitTran(SQConn);

            SQConn.Close();
            SQConn.Dispose();
            cmd.Dispose();
        }

        ///공통으로 쓸 함수
        //트랜잭션 시작 =>
        private void BeginTran(SQLiteConnection conn) // begin, commit을 해주면 전체 행에 대한 트랜잭션이 걸리기 때문에 속도가 비약적으로 빨라진다.
        {
            SQLiteCommand command = new SQLiteCommand("Begin", conn);
            command.ExecuteNonQuery(); //ExecuteNonQuery 메서드는 명령을 수행하고 영향을 받은 행의 수를 반환하는 메서드입니다. 행 추가나 변경, 삭제 등의 명령을 수행할 때는 명령으로 영향받은 행의 수만 알면 되기 때문에 ExecuteNonQuery 메서드를 사용합니다.
            command.Dispose(); // Dispose 메서드 구현은 주로 관리되지 않는 리소스를 해제하는 데 사용
        }

        //트랜잭션 완료
        private void CommitTran(SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand("Commit", conn);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            t = new Table();
            t.Show();
        }
    }
    //
    public class IdInfo
    {
        public string Info { get; set; }
        public string Title { get; set; }

        public IdInfo() { }

        public IdInfo(string Info, string Title)
        {
            this.Info = Info;
            this.Title = Title;
        }

        public override bool Equals(object obj)
        {
            var other = obj as IdInfo;
            if (other == null)
                return false;
            return other.Info == this.Info && other.Title == this.Title;
        }

        public override int GetHashCode()
        {
            return Info.GetHashCode() ^ Title.GetHashCode();
        }
    }
}
