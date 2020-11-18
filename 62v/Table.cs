using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace _62view_v3
{
    public partial class Table : Form
    {
        private string connecString;

        public Table()
        {
            InitializeComponent();
            CenterToParent();
            SQLiteConn("C:\\sqlite-tools-win32-x86-3330000\\download.db");
            RefreshDataGridView();
        }

        private void SQLiteConn(string DBFilePath) // 테이블 -> SQConn.ConnectionString 설정
        {
            connecString = "Data Source=" + DBFilePath + ";Pooling=true;FailIfMissing=false"; // true -> 예외 발생, false -> empty database is created.
            // 커넥션 풀링은 DB와 새 연결시 많은 자원을 소모하는 데, 직접 연결을 피하고,
            // 연결된 커넥션을 자원으로서 관리를 하여 성능 향상을 얻고자 하는 방법
            // Pooling = false => 풀링이 사용되지 않는다.
        }

        private void GetAllDataFromTable(string TableName, ref DataTable dt)
        {
            //SQLite 연결
            SQLiteConnection SQConn = new SQLiteConnection();
            SQConn.ConnectionString = connecString;
            SQConn.Open();
            //select 할 command 객체 생성
            SQLiteCommand sqCommend = new SQLiteCommand(SQConn);
            sqCommend.CommandType = CommandType.Text;
            //select query
            sqCommend.CommandText = "select * from " + TableName;
            //데이터를 받을 adapter 생성
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqCommend);
            //datatable 생성하고 그 테이블에 데이터를 받아온다.
            dt = new DataTable();
            adapter.Fill(dt);
            //사용헀던 객체 삭제
            adapter.Dispose();
            sqCommend.Dispose();
            SQConn.Close();
            SQConn.Dispose();
        }

        private void RefreshDataGridView()
        {
            DataTable dt = null;

            GetAllDataFromTable("download", ref dt);
            dataGridView1.DataSource = dt;

            dt.Dispose();
        }
    }
}
