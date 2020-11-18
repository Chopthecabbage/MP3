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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
//
using System.Diagnostics;

namespace _62view_v3
{
    public partial class ReferenceForm : Form
    {
        List<IdInfo> list = new List<IdInfo>();
        List<IdInfo> i = new List<IdInfo>();
        MainForm m = null;

        public ReferenceForm(MainForm main_form, ref List<IdInfo> id_info)
        {
            InitializeComponent();
            CenterToParent(); // 부모 중앙 위치
            m = main_form;
            i = id_info;
        }

        private async void txtReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Clear();
                var youtube = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyD3p9S10lfcmj32937VruN01tZbOYJYfO0",
                    //ApplicationName = "Chopthecabbage"
                });

                var request = youtube.Search.List("snippet");

                if (txtReference.Text.Length < 1)
                {
                    AutoClosingMessageBox.Show("검색어를 작성해 주세요.", "알람", 1000);
                    return;
                }
                else
                {
                    request.Q = txtReference.Text;
                    request.MaxResults = 20;

                    // Search용 Request 실행
                    var result = await request.ExecuteAsync();

                    // Search 결과를 리스트박스에 담기
                    foreach (var item in result.Items)
                    {
                        if (item.Id.Kind == "youtube#video")
                        {
                            listBox1.Items.Add(item.Snippet.Title);
                            list.Add(new IdInfo(item.Id.VideoId.ToString(), item.Snippet.Title));
                        }
                    }
                }
            }
        }

        private async void btnReference_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyD3p9S10lfcmj32937VruN01tZbOYJYfO0",
                //ApplicationName = "Chopthecabbage"
            });

            var request = youtube.Search.List("snippet");

            if (txtReference.Text.Length < 1)
            {
                AutoClosingMessageBox.Show("검색어를 작성해 주세요.", "알람", 1000);
                return;
            }
            else
            {
                request.Q = txtReference.Text;
                request.MaxResults = 10;

                // Search용 Request 실행
                var result = await request.ExecuteAsync();

                // Search 결과를 리스트박스에 담기
                foreach (var item in result.Items)
                {
                    if (item.Id.Kind == "youtube#video")
                    {
                        listBox1.Items.Add(item.Snippet.Title);
                        list.Add(new IdInfo(item.Id.VideoId.ToString(), item.Snippet.Title));
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Title = null;

            if (listBox1.SelectedIndex != -1)
            {
                Title = listBox1.SelectedItem.ToString();
                Debug.WriteLine("선택된 비디오 이름: " + Title);

                foreach (IdInfo prime in list)
                {
                    if (prime.Title == Title)
                    {
                        var level = new IdInfo(prime.Info, prime.Title);
                        Debug.WriteLine("prime.Title: " + prime.Title);
                        i.Add(level);
                        break;
                    }
                }

                m.listBox1.Items.Add(Title);
                this.Close();
            }
            else
            {
                AutoClosingMessageBox.Show("선택을 먼저해 주세요.", "알람", 1000);
            }
        }
    }
}
