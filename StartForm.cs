using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient; // required for MySQL connection after addition of MySQL References

namespace RoughSetProject2
{
    public partial class StartForm : Form
    {
        public static List<int> noboundarylists = new List<int>();
        public static double accuracy = 0.0;
        public static double dependency = 0.0;
        public static decimal acc;
        public static decimal dep;
        public static String ac;
        public static String de;
        public static String ss;
        public static String stt = "";
        public static List<int> samelist = new List<int>();

        public Boolean status;
        public static string SetValueForText1 = "";
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
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(@"D:\\myheart.txt");
                String line;
                List<Patient> patientlists = new List<Patient>();
                List<Patient> nolists = new List<Patient>();
                List<Patient> yeslists = new List<Patient>();
                int id=0;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(new[] { ',' }, 14);
                    String ageStr = data[0].Trim();
                    int ageInt = int.Parse(ageStr);
                    String sex = data[1].Trim();
                    String cpStr = data[2].Trim();
                    String trestbpsStr = data[3].Trim();
                    int trestbpsInt = int.Parse(trestbpsStr);
                    String cholStr = data[4].Trim();
                    int cholInt = int.Parse(cholStr);
                    String fbsStr = data[5].Trim();
                    String restecg = data[6].Trim();
                    String thalachStr = data[7].Trim();
                    int thalachInt = int.Parse(thalachStr);
                    String exang = data[8].Trim();
                    String opStr = data[9].Trim();
                    float opFloat = float.Parse(opStr);
                    String slope = data[10].Trim();
                    String caStr = data[11].Trim();
                    String thal = data[12].Trim();
                    String tdStr = data[13].Trim();
                    if (ageStr == "?" || sex == "?" || cpStr == "?" || trestbpsStr == "?" || cholStr == "?" || fbsStr == "?" || restecg == "?" || thalachStr == "?" || exang == "?" || opStr == "?" || slope == "?" || caStr == "?" || thal == "?" || tdStr == "?")
                    {
                        //do nothing
                    }
                    else
                    {
                        int ca = int.Parse(caStr);
                        String age = "";
                        if (ageInt < 30)
                        {
                            age = "young";
                        }
                        else if (ageInt >= 30 && ageInt <= 45)
                        {
                            age = "mild";
                        }
                        else if (ageInt > 45)
                        {
                            age = "old";
                        }
                        String trestbps = "";
                        if (trestbpsInt < 120)
                        {
                            trestbps = "low";
                        }
                        else if (trestbpsInt >= 120 && trestbpsInt < 150)
                        {
                            trestbps = "medium";
                        }
                        else if (trestbpsInt >= 150)
                        {
                            trestbps = "high";
                        }

                        String chol = "";
                        if (cholInt < 160)
                        {
                            chol = "low";
                        }
                        else if (cholInt >= 160 && cholInt < 190)
                        {
                            chol = "medium";
                        }
                        else if (cholInt >= 190 && cholInt <= 250)
                        {
                            chol = "high";
                        }
                        else if (cholInt > 250)
                        {
                            chol = "very high";
                        }

                        String fbs = "";
                        if (fbsStr == "t")
                        {
                            fbs = "true";
                        }
                        else if (fbsStr == "f")
                        {
                            fbs = "false";
                        }
                        String thalach = "";
                        if (thalachInt <= 120)
                        {
                            thalach = "low";
                        }
                        else if (thalachInt > 120 && thalachInt < 150)
                        {
                            thalach = "medium";
                        }
                        else if (thalachInt >= 150)
                        {
                            thalach = "high";
                        }
                        String op = "";
                        if (opFloat < 1.5)
                        {
                            op = "low";
                        }
                        else if (opFloat >= 1.5 && opFloat <= 4.5)
                        {
                            op = "risk";
                        }
                        else if (opFloat > 4.5)
                        {
                            op = "terrible";
                        }

                        String td = "";
                        if (tdStr == "'<50'")
                        {
                            td = "0";
                        }
                        else if (tdStr == "'>50_1'")
                        {
                            td = "1";
                        }
                       StoreRecord(age, sex, cpStr, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);
                        int idd = getLastId();
                        //id = id + 1;
                        Patient patient = new Patient();
                        patient.setId(idd);
                        patient.setAge(age);
                        patient.setSex(sex);
                        patient.setCp(cpStr);
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
                        patient.setTypeOfDisease(td);
                        patientlists.Add(patient);//AllPatientLists

                        if (td == "0")
                        {
                            nolists.Add(patient);//DecisionLists that are no
                        }
                        else {
                            yeslists.Add(patient);//DecisionLists that are yes
                        }
                        
                    }

                }
                MessageBox.Show("The file could be completely read:");
                //here complete read from txt file into database;;;

                float totalcount = patientlists.Count;
                //indiscernibility Lists here
                List<List<Patient>> indis = new List<List<Patient>>();
                for (int i = 0; i < patientlists.Count; i++)
                {
                    Patient p1 = new Patient();
                    p1 = patientlists[i];
                    List<Patient> temp = new List<Patient>();
                    temp.Add(p1);
                    for (int j = 0; j < patientlists.Count; j++)//no. of patients
                    {
                        if (i == j)
                        {
                            //continue;
                        }
                        else
                        {
                            Patient p2 = new Patient();
                            p2 = patientlists[j];
                            if (p1.getAge() == p2.getAge() && p1.getSex() == p2.getSex() && p1.getCp() == p2.getCp() && p1.getTrestbps() == p2.getTrestbps() && p1.getChol() == p2.getChol() && p1.getFbs() == p2.getFbs() && p1.getRestecg() == p2.getRestecg() && p1.getThalach() == p2.getThalach() && p1.getExang() == p2.getExang() && p1.getOp() == p2.getOp() && p1.getSlope() == p2.getSlope() && p1.getCa() == p2.getCa() && p1.getThal() == p2.getThal())
                            {
                                temp.Add(p2);
                                patientlists.Remove(p2);//to remove object from all object list if it is same with object i
                            }
                        }
                    }
                    indis.Add(temp);
                }
                ss = "{";
                for (int j = 0; j < indis.Count; j++) {
                    String s = "{";
                    for (int k = 0; k < indis[j].Count; k++) {
                        s = s+indis[j][k].getId()+",";
                        
                    }
                    s = s+"}";
                    ss = ss + s;
                }
                ss = ss+"}";
                //here to get Boundary region for inconsistent objects
                List<int> nolower = new List<int>();
                List<int> noupper = new List<int>();
                
                List<int> yeslower = new List<int>();
                List<int> yesupper = new List<int>();
                List<int> yesboundarylists = new List<int>();

                for (int i = 0; i < indis.Count; i++)//no. of patients
                {
                    List<Boolean> nobooleanlists = new List<Boolean>();
                    List<Boolean> yesbooleanlists = new List<Boolean>();
                    List<Patient> patients = new List<Patient>();
                    patients = indis[i];
                    for (int j = 0; j < patients.Count; j++)//no. of patients
                    {
                        for (int k = 0; k < nolists.Count; k++)
                        {
                            if (patients[j].getId() == nolists[k].getId())
                            {
                                nobooleanlists.Add(true);
                            }
                            else
                            {

                            }
                        }
                        for (int x = 0; x < yeslists.Count; x++)
                        {
                            if (patients[j].getId() == yeslists[x].getId())
                            {
                                yesbooleanlists.Add(true);
                            }
                            else { }
                        }

                    }
                    if (nobooleanlists.Count > 0 && nobooleanlists.Count == indis[i].Count)
                    {
                        for (int l = 0; l < indis[i].Count; l++)
                        {
                            nolower.Add(indis[i][l].getId());
                            noupper.Add(indis[i][l].getId());
                        }
                    }
                    else if (nobooleanlists.Count > 0 && nobooleanlists.Count < indis[i].Count)
                    {
                        for (int l = 0; l < indis[i].Count; l++)
                        {
                            noupper.Add(indis[i][l].getId());
                            noboundarylists.Add(indis[i][l].getId());
                        }
                    }
                    if (yesbooleanlists.Count > 0 && yesbooleanlists.Count == indis[i].Count)
                    {
                        for (int l = 0; l < indis[i].Count; l++)
                        {
                            yeslower.Add(indis[i][l].getId());
                            yesupper.Add(indis[i][l].getId());
                        }
                    }
                    else if (yesbooleanlists.Count > 0 && yesbooleanlists.Count < indis[i].Count)
                    {
                        for (int l = 0; l < indis[i].Count; l++)
                        {
                            yesupper.Add(indis[i][l].getId());
                            yesboundarylists.Add(indis[i][l].getId());
                        }
                    }
                }
                
                MessageBox.Show("no upper count is:::" + noupper.Count.ToString());
                MessageBox.Show("no lower count is:::" + nolower.Count.ToString());
                float nolowercount = nolower.Count;
                float nouppercount = noupper.Count;
                accuracy = (nolowercount / nouppercount) * 100;
                MessageBox.Show("yeslowercount" + yeslower.Count);
                float result = (nolowercount + yeslower.Count) / totalcount;
                MessageBox.Show("totalcount" + totalcount);
                MessageBox.Show("result" + result);
                dependency = ((nolowercount + yeslower.Count) / totalcount) * 100;
                acc = (decimal)accuracy;
                dep = (decimal)dependency;
                ac = String.Format("{0:0.00}", acc);
                de = String.Format("{0:0.00}", dep);
                //String.Format("{0:0.00}", 123.4567);      // "123.46"
                //dep.ToString("#.##");
                //acc.ToString("#.##");
                MessageBox.Show("Accuracy is:::" + acc.ToString());
                //labelaccuracy.Text = accuracy.ToString() + "%";
                
                for (int y = 0; y < indis.Count; y++) {
                    for (int u = 0; u < indis[y].Count; u++) {
                        stt = stt + "a" + indis[y][u].getId();
                    }
                    stt = stt + "\n";
                    int x = 0;
                    while (indis[y].Count > 1) {
                       samelist.Add(indis[y][x].getId());
                       indis[y].Remove(indis[y][x]);
                       
                       x++;
                    }
                    
                }
                if (accuracy == 100) {
                    PercentForm pf = new PercentForm();
                    pf.Show();
                }
                InconsistentForm inconform = new InconsistentForm();
                inconform.Show();
            }

            catch (Exception ee)
            {
                // Let the user know what went wrong.
                MessageBox.Show("The file could not be read:");
                MessageBox.Show(ee.Message);
            }
        }
        private void StoreRecord(String age, String sex, String cp, String trestbps, String chol, String fbs, String restecg, String thalach, String exang, String op, String slope, int ca, String thal, String td)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            //cmd.CommandText = "DELETE heartdisease FROM heartdisease WHERE heartdisease.ID=@id";
            cmd.CommandText = "INSERT INTO myheart(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td) VALUES (@age, @sex, @cp, @trestbps, @chol, @fbs, @restecg, @thalach, @exang, @op, @slope, @ca, @thal, @td)";
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@cp", cp);
            cmd.Parameters.AddWithValue("@trestbps", trestbps);
            cmd.Parameters.AddWithValue("@chol", chol);
            cmd.Parameters.AddWithValue("@fbs", fbs);
            cmd.Parameters.AddWithValue("@restecg", restecg);
            cmd.Parameters.AddWithValue("@thalach", thalach);
            cmd.Parameters.AddWithValue("@exang", exang);
            cmd.Parameters.AddWithValue("@op", op);
            cmd.Parameters.AddWithValue("@slope", slope);
            cmd.Parameters.AddWithValue("@ca", ca);
            cmd.Parameters.AddWithValue("@thal", thal);
            cmd.Parameters.AddWithValue("@td", td);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        private int getLastId() {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select max(idmyheart) as maxId from my.myheart";
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = reader.GetInt16(reader.GetOrdinal("maxId"));
            connect.Close();
            return id;
            
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

        private List<Patient> decisionClass(string decision)
        {
            List<Patient> decisionlists = new List<Patient>();
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from myheart where td=@decision";
            cmd.Parameters.AddWithValue("@decision", decision);
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
                    decisionlists.Add(patient);
                }
            }
            if (login.Read())
            {
                connect.Close();

                MessageBox.Show("data" + login.ToString());

                return decisionlists;
            }
            else
            {
                connect.Close();
                return decisionlists;
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

        private void button2_Click(object sender, EventArgs e)
        {
            PercentForm pform = new PercentForm();
            pform.Show();
        }


    }
}

