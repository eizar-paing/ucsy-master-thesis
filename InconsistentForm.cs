using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RoughSetProject2
{
    public partial class InconsistentForm : Form
    {
        public static int trainRows = 0;
        public static int testRows = 0;
        public static String percentageStr = "";
        public static String tablename = "";
        public static List<int> samelist = new List<int>();
        public static List<int> boundarylists = new List<int>();
        public static List<Patient> plist = new List<Patient>();

        private string conn;
        private MySqlConnection connect;
        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=my;Uid=root;Pwd=root91;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public InconsistentForm()
        {
            InitializeComponent();
        }

        private void deleteInconsistentPatients(int id)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE myheart FROM myheart WHERE idmyheart=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();//if ExecuteReader is not written, cann't delete data from table
            MessageBox.Show("Data Deleted with id  "+id);
            connect.Close();
        }

        private Patient GetPatientWithID(int id)
        {
            Patient patient = new Patient();
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from myheart where idmyheart=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.HasRows)
            {
                while (login.Read())
                {
                    //I would also check for DB.Null here before reading the value.
                    String age = login.GetString(login.GetOrdinal("AGE"));
                    String sex = login.GetString(login.GetOrdinal("SEX"));
                    String cp = login.GetString(login.GetOrdinal("CP"));
                    String trestbps = login.GetString(login.GetOrdinal("TRESTBPS"));
                    String chol = login.GetString(login.GetOrdinal("CHOL"));
                    String fbs = login.GetString(login.GetOrdinal("FBS"));
                    String restecg = login.GetString(login.GetOrdinal("RESTECG"));
                    String thalach = login.GetString(login.GetOrdinal("THALACH"));
                    String exang = login.GetString(login.GetOrdinal("EXANG"));
                    String op = login.GetString(login.GetOrdinal("OP"));
                    String slope = login.GetString(login.GetOrdinal("SLOPE"));
                    int ca = login.GetInt16(login.GetOrdinal("CA"));
                    String thal = login.GetString(login.GetOrdinal("THAL"));
                    String typeofDisease = login.GetString(login.GetOrdinal("TD"));
                    patient.setId(id);
                    patient.setAge(age);
                    patient.setSex(sex);
                    patient.setCp(cp);
                    patient.setTrestbps(trestbps);
                    patient.setChol(chol);
                    patient.setFbs(fbs);
                    patient.setRestecg(restecg);
                    patient.setThalach(thalach);
                    patient.setExang(exang);
                    patient.setOp(op);
                    patient.setSlope(slope);
                    patient.setCa(ca);
                    patient.setThal(thal);
                    patient.setTypeOfDisease(typeofDisease);

                }
            }
            if (login.Read())
            {
                connect.Close();

                MessageBox.Show("data" + login.ToString());

                return patient;
            }
            else
            {
                connect.Close();
                return patient;
            }
        }

        private void InconsistentForm_Load(object sender, EventArgs e)
        {
            samelist = StartForm.samelist;
            
            String ss = StartForm.ss;
            String stt = StartForm.stt;
            boundarylists = StartForm.noboundarylists;
            String accuracy = StartForm.accuracy.ToString() + "%";
            String dependency = StartForm.dependency.ToString() + "%";
            String acc = StartForm.ac + "%";
            String dep = StartForm.de + "%";
            labelacc.Text = acc;
            labeldependency.Text = dep;
            //labelincon.Text = strb.ToString();
            for (int j = 0; j < boundarylists.Count; j++)
            {
                int id = boundarylists[j];
                Patient patient = new Patient();
                patient = GetPatientWithID(id);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = id.ToString();
                dataGridView1.Rows[j].Cells[1].Value = patient.getAge();
                dataGridView1.Rows[j].Cells[2].Value = patient.getSex();
                dataGridView1.Rows[j].Cells[3].Value = patient.getCp();
                dataGridView1.Rows[j].Cells[4].Value = patient.getTrestbps();
                dataGridView1.Rows[j].Cells[5].Value = patient.getChol();
                dataGridView1.Rows[j].Cells[6].Value = patient.getFbs();
                dataGridView1.Rows[j].Cells[7].Value = patient.getRestecg();
                dataGridView1.Rows[j].Cells[8].Value = patient.getThalach();
                dataGridView1.Rows[j].Cells[9].Value = patient.getExang();
                dataGridView1.Rows[j].Cells[10].Value = patient.getOp();
                dataGridView1.Rows[j].Cells[11].Value = patient.getSlope();
                dataGridView1.Rows[j].Cells[12].Value = patient.getCa();
                dataGridView1.Rows[j].Cells[13].Value = patient.getThal();
                dataGridView1.Rows[j].Cells[14].Value = patient.getTypeOfDisease();
            }

        }

        public class Patient
        {
            int id;
            public int getId() { return id; }

            public void setId(int id)
            {
                this.id = id;
            }
            String age;

            public String getAge() { return age; }

            public void setAge(String age)
            {
                this.age = age;
            }
            String sex;

            public String getSex() { return sex; }

            public void setSex(String sex)
            {
                this.sex = sex;
            }
            String cp;

            public String getCp() { return cp; }

            public void setCp(String cp)
            {
                this.cp = cp;
            }
            String trestbps;

            public String getTrestbps() { return trestbps; }

            public void setTrestbps(String trestbps)
            {
                this.trestbps = trestbps;
            }
            String chol;

            public String getChol() { return chol; }

            public void setChol(String chol)
            {
                this.chol = chol;
            }
            String fbs;

            public String getFbs() { return fbs; }

            public void setFbs(String fbs)
            {
                this.fbs = fbs;
            }
            String restecg;

            public String getRestecg() { return restecg; }

            public void setRestecg(String restecg)
            {
                this.restecg = restecg;
            }
            String thalach;

            public String getThalach() { return thalach; }

            public void setThalach(String thalach)
            {
                this.thalach = thalach;
            }
            String exang;

            public String getExang() { return exang; }

            public void setExang(String exang)
            {
                this.exang = exang;
            }
            String op;

            public String getOp() { return op; }

            public void setOp(String op)
            {
                this.op = op;
            }
            int ca;

            public int getCa() { return ca; }

            public void setCa(int ca)
            {
                this.ca = ca;
            }
            String slope;

            public String getSlope() { return slope; }

            public void setSlope(String slope)
            {
                this.slope = slope;
            }
            String thal;

            public String getThal() { return thal; }

            public void setThal(String thal)
            {
                this.thal = thal;
            }
            String typeOfDisease;

            public String getTypeOfDisease() { return typeOfDisease; }

            public void setTypeOfDisease(String typeOfDisease)
            {
                this.typeOfDisease = typeOfDisease;
            }
        }
        private List<Patient> getAllPatients()
        {
            List<Patient> patientlist = new List<Patient>();
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from myheart";
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.HasRows)
            {
                while (login.Read())
                {
                    //I would also check for DB.Null here before reading the value.
                    Patient patient = new Patient();
                    int id = login.GetInt16(login.GetOrdinal("idmyheart"));
                    String age = login.GetString(login.GetOrdinal("age"));
                    String sex = login.GetString(login.GetOrdinal("sex"));
                    String cp = login.GetString(login.GetOrdinal("cp"));
                    String trestbps = login.GetString(login.GetOrdinal("trestbps"));
                    String chol = login.GetString(login.GetOrdinal("chol"));
                    String fbs = login.GetString(login.GetOrdinal("fbs"));
                    String restecg = login.GetString(login.GetOrdinal("restecg"));
                    String thalach = login.GetString(login.GetOrdinal("thalach"));
                    String exang = login.GetString(login.GetOrdinal("exang"));
                    String op = login.GetString(login.GetOrdinal("op"));
                    String slope = login.GetString(login.GetOrdinal("slope"));
                    int ca = login.GetInt16(login.GetOrdinal("ca"));
                    String thal = login.GetString(login.GetOrdinal("thal"));
                    String typeofDisease = login.GetString(login.GetOrdinal("td"));
                    patient.setId(id);
                    patient.setAge(age);
                    patient.setSex(sex);
                    patient.setCp(cp);
                    patient.setTrestbps(trestbps);
                    patient.setChol(chol);
                    patient.setFbs(fbs);
                    patient.setRestecg(restecg);
                    patient.setThalach(thalach);
                    patient.setExang(exang);
                    patient.setOp(op);
                    patient.setSlope(slope);
                    patient.setCa(ca);
                    patient.setThal(thal);
                    patient.setTypeOfDisease(typeofDisease);

                    patientlist.Add(patient);
                }
            }
            if (login.Read())
            {
                connect.Close();

                MessageBox.Show("data" + login.ToString());

                return patientlist;
            }
            else
            {
                connect.Close();
                return patientlist;
            }
        }

        private Hashtable getHashTable(List<List<String>> allList)
        {
            Hashtable ht = new Hashtable();
            int a1Count, a2Count, a3Count, a4Count, a5Count, a6Count, a7Count, a8Count, a9Count, a10Count, a11Count, a12Count, a13Count;
            a1Count = a2Count = a3Count = a4Count = a5Count = a6Count = a7Count = a8Count = a9Count = a10Count = a11Count = a12Count = a13Count = 0;
            for (int g = 0; g < allList.Count; g++)
            {
                List<String> list1 = allList[g];
                for (int h = 0; h < list1.Count; h++)
                {
                    String listStr = list1[h];
                    if (listStr == "a1")
                    {
                        a1Count++;
                    }
                    else if (listStr == "a2")
                    {
                        a2Count++;
                    }
                    else if (listStr == "a3")
                    {
                        a3Count++;
                    }
                    else if (listStr == "a4")
                    {
                        a4Count++;
                    }
                    else if (listStr == "a5")
                    {
                        a5Count++;
                    }
                    else if (listStr == "a6")
                    {
                        a6Count++;
                    }
                    else if (listStr == "a7")
                    {
                        a7Count++;
                    }
                    else if (listStr == "a8")
                    {
                        a8Count++;
                    }
                    else if (listStr == "a9")
                    {
                        a9Count++;
                    }
                    else if (listStr == "a10")
                    {
                        a10Count++;
                    }
                    else if (listStr == "a11")
                    {
                        a11Count++;
                    }
                    else if (listStr == "a12")
                    {
                        a12Count++;
                    }
                    else if (listStr == "a13")
                    {
                        a13Count++;
                    }
                }
            }
            ht.Add("a1", a1Count);
            ht.Add("a2", a2Count);
            ht.Add("a3", a3Count);
            ht.Add("a4", a4Count);
            ht.Add("a5", a5Count);
            ht.Add("a6", a6Count);
            ht.Add("a7", a7Count);
            ht.Add("a8", a8Count);
            ht.Add("a9", a9Count);
            ht.Add("a10", a10Count);
            ht.Add("a11", a11Count);
            ht.Add("a12", a12Count);
            ht.Add("a13", a13Count);
            return ht;
        }

        private List<Patient> decisionClass(string decision)
        {
            List<Patient> DecisionLists = new List<Patient>();
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from heartdisease where TD=@decision";
            cmd.Parameters.AddWithValue("@decision", decision);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.HasRows)
            {
                while (login.Read())
                {
                    //I would also check for DB.Null here before reading the value.
                    Patient patient = new Patient();
                    int id = login.GetInt16(login.GetOrdinal("ID"));
                    String age = login.GetString(login.GetOrdinal("AGE"));
                    String sex = login.GetString(login.GetOrdinal("SEX"));
                    String cp = login.GetString(login.GetOrdinal("CP"));
                    String trestbps = login.GetString(login.GetOrdinal("TRESTBPS"));
                    String chol = login.GetString(login.GetOrdinal("CHOL"));
                    String fbs = login.GetString(login.GetOrdinal("FBS"));
                    String restecg = login.GetString(login.GetOrdinal("RESTECG"));
                    String thalach = login.GetString(login.GetOrdinal("THALACH"));
                    String exang = login.GetString(login.GetOrdinal("EXANG"));
                    String op = login.GetString(login.GetOrdinal("OP"));
                    String slope = login.GetString(login.GetOrdinal("SLOPE"));
                    int ca = login.GetInt16(login.GetOrdinal("CA"));
                    String thal = login.GetString(login.GetOrdinal("THAL"));
                    String typeofDisease = login.GetString(login.GetOrdinal("TD"));
                    patient.setId(id);
                    patient.setAge(age);
                    patient.setSex(sex);
                    patient.setCp(cp);
                    patient.setTrestbps(trestbps);
                    patient.setChol(chol);
                    patient.setFbs(fbs);
                    patient.setRestecg(restecg);
                    patient.setThalach(thalach);
                    patient.setExang(exang);
                    patient.setOp(op);
                    patient.setSlope(slope);
                    patient.setCa(ca);
                    patient.setThal(thal);
                    patient.setTypeOfDisease(typeofDisease);

                    DecisionLists.Add(patient);
                }
            }
            if (login.Read())
            {
                connect.Close();

                MessageBox.Show("data" + login.ToString());

                return DecisionLists;
            }
            else
            {
                connect.Close();
                return DecisionLists;
            }
        }

        private Boolean isAgeSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            //cmd.CommandText = "SELECT 1 AS istrue FROM heartdisease WHERE heartdisease.ID=@id1 AND heartdisease.AGE=(SELECT heartdisease.AGE FROM heartdisease WHERE heartdisease.ID=@id2)";//runtime error
            cmd.CommandText = "SELECT IF(heartdisease.AGE=(SELECT heartdisease.AGE FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isSexSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.SEX=(SELECT heartdisease.SEX FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isCpSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.CP=(SELECT heartdisease.CP FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isTrestbpsSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.TRESTBPS=(SELECT heartdisease.TRESTBPS FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isCholSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.CHOL=(SELECT heartdisease.CHOL FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isFbsSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.FBS=(SELECT heartdisease.FBS FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isRestEcgSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.RESTECG=(SELECT heartdisease.RESTECG FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isThalAchSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.THALACH=(SELECT heartdisease.THALACH FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isExangSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.EXANG=(SELECT heartdisease.EXANG FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isOpSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.OP=(SELECT heartdisease.OP FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isSlopeSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.SLOPE=(SELECT heartdisease.SLOPE FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isCaSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.CA=(SELECT heartdisease.CA FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isThalSame(int id1, int id2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(heartdisease.THAL=(SELECT heartdisease.THAL FROM heartdisease WHERE heartdisease.ID=@id2) , false , true) AS istrue FROM heartdisease WHERE heartdisease.ID=@id1";

            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }

        private void removeLists(List<String> Lists, List<List<String>> ReductLists)
        {
            for (int ii = 0; ii < ReductLists.Count; ii++)
            {
                List<Boolean> booleanLists = new List<Boolean>();
                List<String> NoLists = new List<string>();
                NoLists = ReductLists[ii];
                for (int jj = 0; jj < NoLists.Count; jj++)
                {
                    for (int kk = 0; kk < Lists.Count; kk++)
                    {
                        if (NoLists[jj] == Lists[kk])
                        {
                            booleanLists.Add(true);
                        }
                    }
                }
                if (booleanLists.Count == Lists.Count && booleanLists.Count == NoLists.Count)
                {
                    ReductLists.Remove(NoLists);
                    //ReductLists.Remove(Lists);
                }
            }
        }

        private Boolean isListsExist(List<String> List, List<List<String>> ListList)
        {
            for (int ii = 0; ii < ListList.Count; ii++)
            {
                List<Boolean> booleanLists = new List<Boolean>();
                List<String> NoLists = new List<string>();
                NoLists = ListList[ii];
                for (int jj = 0; jj < NoLists.Count; jj++)
                {
                    for (int kk = 0; kk < List.Count; kk++)
                    {
                        if (NoLists[jj] == List[kk])
                        {
                            booleanLists.Add(true);
                        }
                    }
                }
                if (booleanLists.Count == List.Count && booleanLists.Count == NoLists.Count)
                {
                    //ReductLists.Remove(NoLists);
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < boundarylists.Count; i++) {
                deleteInconsistentPatients(boundarylists[i]);
            }
            for (int j = 0; j < samelist.Count; j++) {
                deleteInconsistentPatients(samelist[j]);
            }
            
            PercentForm f2 = new PercentForm();
            f2.Show();
        }
        private List<String> getNewAttributesWithMaxCount(Hashtable htt)
        {
            int temp = 0;
            temp = (int)htt["a1"];
            List<String> attributes = new List<string>();
            attributes.Add("a1");
            int a2Ct = (int)htt["a2"];
            int a3Ct = (int)htt["a3"];
            int a4Ct = (int)htt["a4"];
            int a5Ct = (int)htt["a5"];
            int a6Ct = (int)htt["a6"];
            int a7Ct = (int)htt["a7"];
            int a8Ct = (int)htt["a8"];
            int a9Ct = (int)htt["a9"];
            int a10Ct = (int)htt["a10"];
            int a11Ct = (int)htt["a11"];
            int a12Ct = (int)htt["a12"];
            int a13Ct = (int)htt["a13"];
            if (temp < a2Ct)
            {
                temp = a2Ct;
                attributes.Clear();
                attributes.Add("a2");
            }
            else if (temp == a2Ct)
            {
                attributes.Add("a2");
            }
            if (temp < a3Ct)
            {
                attributes.Clear();
                temp = a3Ct;
                attributes.Add("a3");
            }
            else if (temp == a3Ct)
            {
                attributes.Add("a3");
            }
            if (temp < a4Ct)
            {
                attributes.Clear();
                temp = a4Ct;
                attributes.Add("a4");
            }
            else if (temp == a4Ct)
            {
                attributes.Add("a4");
            }
            if (temp < a5Ct)
            {
                attributes.Clear();
                temp = a5Ct;
                attributes.Add("a5");
            }
            else if (temp == a5Ct)
            {
                attributes.Add("a5");
            }
            if (temp < a6Ct)
            {
                attributes.Clear();
                temp = a6Ct;
                attributes.Add("a6");
            }
            else if (temp == a6Ct)
            {
                attributes.Add("a6");
            }
            if (temp < a7Ct)
            {
                attributes.Clear();
                temp = a7Ct;
                attributes.Add("a7");
            }
            else if (temp == a7Ct)
            {
                attributes.Add("a7");
            }
            if (temp < a8Ct)
            {
                attributes.Clear();
                temp = a8Ct;
                attributes.Add("a8");
            }
            else if (temp == a8Ct)
            {
                attributes.Add("a8");
            }
            if (temp < a9Ct)
            {
                attributes.Clear();
                temp = a9Ct;
                attributes.Add("a9");
            }
            else if (temp == a9Ct)
            {
                attributes.Add("a9");
            }
            if (temp < a10Ct)
            {
                attributes.Clear();
                temp = a10Ct;
                attributes.Add("a10");
            }
            else if (temp == a10Ct)
            {
                attributes.Add("a10");
            }

            if (temp < a11Ct)
            {
                attributes.Clear();
                temp = a11Ct;
                attributes.Add("a11");
            }
            else if (temp == a11Ct)
            {
                attributes.Add("a11");
            }
            if (temp < a12Ct)
            {
                attributes.Clear();
                temp = a12Ct;
                attributes.Add("a12");
            }
            else if (temp == a12Ct)
            {
                attributes.Add("a12");
            }
            if (temp < a13Ct)
            {
                attributes.Clear();
                temp = a13Ct;
                attributes.Add("a13");
            }
            else if (temp == a13Ct)
            {
                attributes.Add("a13");
            }

            return attributes;
        }
        private List<List<String>> removeListsWithMaxAttribute(String attribute, List<List<String>> ListsLists)
        {
            List<List<String>> returnLists = new List<List<string>>();
            returnLists.AddRange(ListsLists);
            for (int iii = 0; iii < ListsLists.Count; iii++)
            {
                Boolean bol = false;
                List<String> oneLists = new List<string>();
                oneLists = ListsLists[iii];
                for (int jjj = 0; jjj < oneLists.Count; jjj++)
                {
                    if (oneLists[jjj] == attribute)
                    {
                        bol = true;
                    }
                }
                if (bol == true)
                {
                    removeLists(oneLists, returnLists);

                }
            }
            return returnLists;

        }
        private List<List<String>> removeRedundancy(List<List<String>> LastReductListss)
        {
            List<List<String>> sameLists = new List<List<string>>();
            List<List<String>> ListssWithoutRedundant = new List<List<string>>();
            ListssWithoutRedundant.AddRange(LastReductListss);
            for (int aa = 0; aa < LastReductListss.Count; aa++)
            {
                List<String> l1 = LastReductListss[aa];
                for (int bb = 0; bb < LastReductListss.Count; bb++)
                {

                    if (aa == bb) { }
                    else
                    {
                        List<Boolean> istrueLists = new List<Boolean>();
                        for (int dd = 0; dd < l1.Count; dd++)
                        {
                            for (int cc = 0; cc < LastReductListss[bb].Count; cc++)
                            {

                                if (LastReductListss[bb][cc] == l1[dd])
                                {
                                    istrueLists.Add(true);

                                }
                            }
                        }


                        if (istrueLists.Count == LastReductListss[bb].Count && istrueLists.Count == l1.Count)
                        {
                            removeLists(l1, ListssWithoutRedundant);
                            if (isListsExist(l1, sameLists) == true)
                            {
                                //nothing
                            }
                            else
                            {
                                sameLists.Add(l1);
                            }

                        }
                    }

                }

            }
            for (int yyy = 0; yyy < sameLists.Count; yyy++)
            {
                ListssWithoutRedundant.Add(sameLists[yyy]);
            }
            return ListssWithoutRedundant;
        }
        private void saveReducts(List<String> reductListLists)
        {

            MessageBox.Show("in StoreRecord:");
            for (int r1 = 0; r1 < reductListLists.Count; r1++)
            {
                db_connection();
                String reduct = reductListLists[r1];
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO reducts(reductString) VALUES (@reductStr)";
                cmd.Parameters.AddWithValue("@reductStr", reduct);
                cmd.Connection = connect;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
                connect.Close();
            }


        }

        private List<List<String>> getDiscernibilityForeachObject(Patient p1, List<Patient> otherListss, List<String> reductList)
        {
            List<List<String>> returnListss = new List<List<String>>();
            for (int z = 0; z < otherListss.Count; z++)
            {
                List<String> newListss = new List<String>();
                Patient p2 = new Patient();
                p2 = otherListss[z];
                //twoPatients.Add(p2.getId());
                int p1Id = p1.getId();
                int p2Id = p2.getId();

                Boolean b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13;
                b1 = b2 = b3 = b4 = b5 = b6 = b7 = b8 = b9 = b10 = b11 = b12 = b13 = false;
                for (int i3 = 0; i3 < reductList.Count; i3++)
                {
                    String strr = reductList[i3];

                    if (strr == "a1")
                    {
                        b1 = isAgeSame(p1Id, p2Id);
                    }
                    if (strr == "a2")
                    {
                        b2 = isSexSame(p1Id, p2Id);
                    }
                    if (strr == "a3")
                    {
                        b3 = isCpSame(p1Id, p2Id);
                    }
                    if (strr == "a4")
                    {
                        b4 = isTrestbpsSame(p1Id, p2Id);
                    }
                    if (strr == "a5")
                    {
                        b5 = isCholSame(p1Id, p2Id);
                    }
                    if (strr == "a6")
                    {
                        b6 = isFbsSame(p1Id, p2Id);
                    }
                    if (strr == "a7")
                    {
                        b7 = isRestEcgSame(p1Id, p2Id);
                    }
                    if (strr == "a8")
                    {
                        b8 = isThalAchSame(p1Id, p2Id);
                    }
                    if (strr == "a9")
                    {
                        b9 = isExangSame(p1Id, p2Id);
                    }
                    if (strr == "a10")
                    {
                        b10 = isOpSame(p1Id, p2Id);
                    }
                    if (strr == "a11")
                    {
                        b11 = isSlopeSame(p1Id, p2Id);
                    }
                    if (strr == "a12")
                    {
                        b12 = isCaSame(p1Id, p2Id);
                    }
                    if (strr == "a13")
                    {
                        b13 = isThalSame(p1Id, p2Id);
                    }
                }
                if (b1 == true)
                {
                    newListss.Add("a1");
                }
                if (b2 == true)
                {
                    newListss.Add("a2");
                }
                if (b3 == true)
                {
                    newListss.Add("a3");
                }
                if (b4 == true)
                {
                    newListss.Add("a4");
                }
                if (b5 == true)
                {
                    newListss.Add("a5");
                }
                if (b6 == true)
                {
                    newListss.Add("a6");
                }
                if (b7 == true)
                {
                    newListss.Add("a7");
                }
                if (b8 == true)
                {
                    newListss.Add("a8");
                }
                if (b9 == true)
                {
                    newListss.Add("a9");
                }
                if (b10 == true)
                {
                    newListss.Add("a10");
                }
                if (b11 == true)
                {
                    newListss.Add("a11");
                }
                if (b12 == true)
                {
                    newListss.Add("a12");
                }
                if (b13 == true)
                {
                    newListss.Add("a13");
                }
                returnListss.Add(newListss);
            }
            return returnListss;
        }

        private List<List<String>> JOHNSONAlgo(List<List<String>> reductListss)
        {
            int allListssCount = 0;
            List<List<List<String>>> allListss = new List<List<List<String>>>();//for removing reductLists with attributes 
            allListss.Add(reductListss);
            List<List<List<String>>> LastallReductListss = new List<List<List<String>>>();
            List<List<String>> lastAttListss = new List<List<String>>();
            List<List<String>> lastAttLists = new List<List<String>>();
            Hashtable htt = new Hashtable();
            //for each one of reductLists from allListss to count maximum attributes
            List<List<String>> allList = new List<List<String>>();
            allList = allListss[0];
            htt = getHashTable(allList);
            List<String> attLists = new List<String>();
            attLists = getNewAttributesWithMaxCount(htt);
            /*for (int iii1 = 0; iii1 < attLists.Count; iii1++) {
                MessageBox.Show("Attribute for object 1===="+attLists[iii1]);
            }*/
            //copy reductLists to be removed according to maximum attributeLists
            List<List<List<String>>> reductLists = new List<List<List<String>>>();
            for (int j = 0; j < attLists.Count; j++)
            {
                reductLists.Add(allList);
            }

            List<String> lastAttList = new List<String>();
            if (lastAttListss.Count == 0)
            {

                for (int j = 0; j < attLists.Count; j++)
                {
                    List<String> newList = new List<String>();
                    newList.Add(attLists[j]);
                    lastAttLists.Add(newList);
                }

            }
            else
            {
                lastAttList = lastAttListss[0];// not to change


                for (int j = 0; j < attLists.Count; j++)
                {

                    List<String> newList = new List<String>();
                    newList.AddRange(lastAttList);
                    newList.Add(attLists[j]);// out of memoryException
                    lastAttLists.Add(newList);
                }
            }

            //////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            for (int yy = 0; yy < attLists.Count; yy++)  //more than one attribute
            {
                String st = attLists[yy];
                List<List<String>> reductList = new List<List<String>>();
                reductList = reductLists[yy];
                /////////////////////////////////////

                //to remove reductLists according to attributes Lists
                List<List<String>> newreductList = new List<List<String>>();
                newreductList = removeListsWithMaxAttribute(st, reductList);

                LastallReductListss.Add(newreductList);
            }

            allListssCount = allListss.Count;
            allListss.Clear();
            allListss.AddRange(LastallReductListss);
            //MessageBox.Show("Count for reductLists in Json----" + allListss.Count);

            ///////////////////////////////
            lastAttListss.Clear();
            lastAttListss.AddRange(lastAttLists);

            List<Boolean> bListss = new List<Boolean>();
            for (int i1 = 0; i1 < allListss.Count; i1++)
            {
                if (allListss[i1].Count > 0)
                {
                }
                else
                {
                    bListss.Add(true);
                }
            }
            if (bListss.Count == allListss.Count)
            {
                allListss.Clear();
            }
            if (allListss.Count > 0)
            {
                do
                {
                    //List<List<List<String>>> LastallReductListss2 = new List<List<List<String>>>();
                    //List<List<String>> lastAttLists2 = new List<List<String>>();
                    lastAttList.Clear();
                    LastallReductListss.Clear();
                    lastAttLists.Clear();
                    ///
                    Hashtable httt = new Hashtable();
                    //for each one of reductLists from allListss to count maximum attributes
                    for (int uuu = 0; uuu < allListss.Count; uuu++)
                    {



                        allList.Clear();
                        allList = allListss[uuu];
                        httt = getHashTable(allList);
                        attLists.Clear();
                        attLists = getNewAttributesWithMaxCount(httt);
                        //copy reductLists to be removed according to maximum attributeLists
                        reductLists.Clear();
                        for (int j = 0; j < attLists.Count; j++)
                        {
                            reductLists.Add(allList);
                        }
                        if (lastAttListss.Count == 0)
                        {

                            for (int j = 0; j < attLists.Count; j++)
                            {
                                List<String> newList = new List<String>();
                                newList.Add(attLists[j]);
                                lastAttLists.Add(newList);
                            }

                        }
                        else
                        {
                            lastAttList = lastAttListss[uuu];// not to change


                            for (int j = 0; j < attLists.Count; j++)
                            {

                                List<String> newList = new List<String>();
                                newList.AddRange(lastAttList);
                                newList.Add(attLists[j]);// out of memoryException
                                lastAttLists.Add(newList);
                            }
                        }
                        for (int yy = 0; yy < attLists.Count; yy++)  //more than one attribute
                        {
                            String st = attLists[yy];
                            List<List<String>> reductList = new List<List<String>>();
                            reductList = reductLists[yy];
                            /////////////////////////////////////

                            //to remove reductLists according to attributes Lists
                            List<List<String>> newreductList = new List<List<String>>();
                            newreductList = removeListsWithMaxAttribute(st, reductList);

                            LastallReductListss.Add(newreductList);
                        }
                    }

                    ///////////////////////////////
                    allListssCount = allListss.Count;
                    allListss.Clear();
                    allListss.AddRange(LastallReductListss);
                    lastAttListss.Clear();
                    lastAttListss.AddRange(lastAttLists);

                    List<Boolean> bLists = new List<Boolean>();
                    for (int i1 = 0; i1 < allListss.Count; i1++)
                    {
                        if (allListss[i1].Count > 0)
                        {
                        }
                        else
                        {
                            bLists.Add(true);
                        }
                    }
                    if (bLists.Count == allListss.Count)
                    {
                        allListss.Clear();
                    }
                } while (allListss.Count > 0);
            }
            //} while (allListssCount > 0);
            ////**************************************************************************************************************************

            List<List<String>> LastReductLastList = new List<List<string>>();
            LastReductLastList = removeRedundancy(lastAttListss);
            return LastReductLastList;
        }

    }
}
