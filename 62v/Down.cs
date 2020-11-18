using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;
using System.IO;
//
using System.Diagnostics;
// 버전 문제로 폐기 처분 -> 처리되지 않은 'YoutubeExtractor.VideoNotAvailableException' 형식의 예외가 YoutubeExtractor.dll에서 발생했습니다.
namespace _62view_v3
{
    public partial class Down : Form
    {
        List<IdInfo> list = new List<IdInfo>();
        List<IdInfo> i = new List<IdInfo>();
        MainForm m = null;
        string Title;

        public Down(MainForm main_form, ref List<IdInfo> id_info, string Title)
        {
            InitializeComponent();
            CenterToParent(); // 부모 중앙 위치
            m = main_form;
            i = id_info;
            this.Title = Title;
            //
            cboResolution.SelectedIndex = 0;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog() { Description = "저장할 폴더를 선택하세요." })
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = f.SelectedPath;
                }
                else
                {
                    MessageBox.Show("파일 경로를 선택하세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
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
            }

            Debug.WriteLine("youtubeurl: " + youtubeurl);
            //http://youtube.com/watch?v=D1PvIWdJ8xo
            //IEnumerable<VideoInfo> videos = DownloadUrlResolver.GetDownloadUrls("http://youtube.com/v/=D1PvIWdJ8xo");
            IEnumerable<VideoInfo> videos = DownloadUrlResolver.GetDownloadUrls(youtubeurl);
            VideoInfo video = videos.First(p => p.VideoType == VideoType.Mp4 && p.Resolution == Convert.ToInt32(cboResolution.Text));
            if(video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }
            VideoDownloader Downloader = new VideoDownloader(video, Path.Combine(txtPath.Text + "\\", video.Title + video.VideoExtension));
            Downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
            Thread th = new Thread(() => { Downloader.Execute(); }) { IsBackground = true };
            th.Start();
        }

        private void Downloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            //throw new NotImplementedException();
            Invoke(new MethodInvoker(delegate ()
            {
                progressBar1.Value = (int)e.ProgressPercentage;
                lblProgress.Text = string.Format("{0:0.##}", e.ProgressPercentage) + " %";
                progressBar1.Update();
            }
            ));
        }
    }
}
