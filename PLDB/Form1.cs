using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PLDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void datagridviewDrug()
        {
            DataTable dsDrug = SQLite.getDataTableDrug("[Drug]");   // 약품 테이블의 데이터테이블을 가져온다.

            dataGridView1.DataSource = null;        // 재 로드하는 경우를 위해 null 한번 줬다가
            dataGridView1.DataSource = dsDrug;
        }

        private void datagridviewPatient()
        {
            DataTable dsPatient = SQLite.getDataTablePatient("[Patient]");                 // 환자 테이블의 데이터테이블을 가져온다.

            dataGridView2.DataSource = null;        // 재 로드하는 경우를 위해 null 한번 줬다가
            dataGridView2.DataSource = dsPatient;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datagridviewDrug();
            datagridviewPatient();
        }

        private void button1_Click(object sender, EventArgs e)      // 선택한 약품 행을 삭제
        {
            string selectId = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);  // 데이터그리드뷰에서도 삭제해서 안 보이게
            SQLite.deleteRowDrug(selectId);

            MessageBox.Show("선택한 약품 데이터가 삭제되었습니다.");
        }

        private void button2_Click(object sender, EventArgs e)      // 선택한 환자 행을 삭제
        {
            string selectId = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
            dataGridView2.Rows.Remove(dataGridView2.Rows[dataGridView2.CurrentRow.Index]);  // 데이터그리드뷰에서도 삭제해서 안 보이게
            SQLite.deleteRowPatient(selectId);

            MessageBox.Show("선택한 환자 데이터가 삭제되었습니다.");
        }

        private void button4_Click(object sender, EventArgs e)      // 데이터 다시 불러오기
        {
            datagridviewDrug();
            datagridviewPatient();

            MessageBox.Show("데이터를 다시 가져왔습니다.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("[데이터 수정] 기능은 업데이트 예정입니다.\n 조금 기다려주세요. ^^;;;;");
        }

        private void button5_Click(object sender, EventArgs e)  // 종료버튼
        {
            Application.OpenForms["Form1"].Close();  // 윈도우 폼 닫기
        }
    }
}
