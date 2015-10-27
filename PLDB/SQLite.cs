using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace PLDB
{
    class SQLite
    {
        public static DataTable getDataTableDrug(string table)     // DB 테이블명을 받아서 데이터테이블을 반환하는 함수(데이터그리드뷰에 넣기 위해)
        {
            String connectionString = @"Data Source=C:\Program Files\PLOCR\Data\PLOCR.db";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                String selectCommand = String.Format("SELECT Id AS ID, DrugCode AS 약품코드, DrugName AS 약품명, FDrugCode AS [오인식\n약품코드], FDrugName AS [오인식\n약품명], UseTF AS [데이터 사용\n사용1 미사용0], InsuranceTF AS [급여1 비급여0], DrugDose AS [고정\n투약량], DrugTime AS [고정\n투여횟수], DrugDay AS [고정\n투약일수], DrugDoseTF AS [투약량 고정\n사용1 미사용0], DrugTimeTF AS [투여횟수고정\n사용1 미사용0], DrugDayTF AS [투약일수고정\n사용1 미사용0] FROM {0}", table);

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectCommand, connectionString);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                                
                conn.Close();

                return dt;
            }
        }

        public static DataTable getDataTablePatient(string table)     // DB 테이블명을 받아서 데이터테이블을 반환하는 함수(데이터그리드뷰에 넣기 위해)
        {
            String connectionString = @"Data Source=C:\Program Files\PLOCR\Data\PLOCR.db";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                String selectCommand = String.Format("SELECT Id AS ID, PatientNumber AS 주민번호, PatientName AS 환자명, FPatientNumber AS [오인식\n주민번호], FPatientName AS [오인식\n환자명], UseTF AS [데이터 사용\n사용1 미사용0], InquiryTF AS [수진자조회\n사용1 미사용0] FROM {0}", table);

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectCommand, connectionString);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                conn.Close();

                return dt;
            }
        }

        public static void deleteRowDrug(string selectId)       // 선택된 row의 아이디를 받아서, Drug 테이블의 row 를 삭제한다.
        {
            String connectionString = @"Data Source=C:\Program Files\PLOCR\Data\PLOCR.db";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                String selectCommand = String.Format("DELETE FROM [Drug] WHERE [Id]='{0}'", selectId);
                SQLiteCommand cmd = new SQLiteCommand(selectCommand, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static void deleteRowPatient(string selectId)       // 선택된 row의 아이디를 받아서, Patient 테이블의 row 를 삭제한다.
        {
            String connectionString = @"Data Source=C:\Program Files\PLOCR\Data\PLOCR.db";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                String selectCommand = String.Format("DELETE FROM [Patient] WHERE [Id]='{0}'", selectId);
                SQLiteCommand cmd = new SQLiteCommand(selectCommand, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
       
    }
}
