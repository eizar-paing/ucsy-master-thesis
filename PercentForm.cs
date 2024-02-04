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
    public partial class PercentForm : Form
    {
        public static int trainRows = 0;
        public static int testRows = 0;
        public static int percentid = 0;
        public static String percentageStr = "";
        public static String tablename = "";
        public static int random_no = 0;
        public static String split_tablename = "";
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

        //BackGroundWorker Thread
        private BackgroundWorker myWorker = new BackgroundWorker();
        public PercentForm()
        {
            InitializeComponent();
           // myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
           // myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
           // myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
           // myWorker.WorkerReportsProgress = true;
           // myWorker.WorkerSupportsCancellation = true;

        }

        /*protected void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker =(BackgroundWorker)sender;//Capture the BackgroundWorker that fired the event
            StringBuilder sb = new StringBuilder();//Declare a new string builder to store the result.

            if (!sendingWorker.CancellationPending)//At each iteration of the loop, 
            //check if there is a cancellation request pending 
            {
                MessageBox.Show("start of no cancellaion");
                //sb.Append(string.Format("Counting number: {0}" + Environment.NewLine));
                //start of long running process


                sb.Append(string.Format("Counting number: {0}{1}",
                //HeavyOperation(), Environment.NewLine));//Append the result to the string builder

                sendingWorker.ReportProgress(0);//Report our progress to the main thread
                   
                }
                else
                {
                    e.Cancel = true;//If a cancellation request is pending, assign this flag a value of true
                   // break;// If a cancellation request is pending, break to exit the loop
                }

            e.Result = sb.ToString();// Send our result to the main thread!
        }

        protected void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled &&
            e.Error == null)//Check if the worker has been canceled or if an error occurred
            {
                string result = (string)e.Result;//Get the result from the background thread
                lblStatus.Text = "Done";
            }
            else if (e.Cancelled)
            {
                lblStatus.Text = "User Canceled";
            }
            else
            {
                lblStatus.Text = "An error has occurred";
            }
            button1.Enabled = true;//Re enable the start button
        }

        protected void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Show the progress to the user based on the input we got from the background worker
            lblStatus.Text = string.Format("Counting number: {0}...", e.ProgressPercentage);
        }
        */
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

        private String getNewAttributesWithMaxCount(Hashtable htt)
        {
            
            int temp = 0;
            temp = (int)htt["a1"];
            String att = "a1";

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
                att = "a2";
            }
            else if (temp == a2Ct)
            {
                att = "a2";
            }
            if (temp < a3Ct)
            {
                temp = a3Ct;
                att = "a3";
            }
            else if (temp == a3Ct)
            {
                att = "a3";
            }
            if (temp < a4Ct)
            {
                temp = a4Ct;
                att = "a4";
            }
            else if (temp == a4Ct)
            {
                att = "a4";
            }
            if (temp < a5Ct)
            {
                temp = a5Ct;
                att = "a5";
            }
            else if (temp == a5Ct)
            {
                att = "a5";
            }
            if (temp < a6Ct)
            {
                temp = a6Ct;
                att = "a6";
            }
            else if (temp == a6Ct)
            {
                att = "a6";
            }
            if (temp < a7Ct)
            {
                temp = a7Ct;
                att = "a7";
            }
            else if (temp == a7Ct)
            {
                att = "a7";
            }
            if (temp < a8Ct)
            {
                temp = a8Ct;
                att = "a8";
            }
            else if (temp == a8Ct)
            {
                att = "a8";
            }
            if (temp < a9Ct)
            {
                temp = a9Ct;
                att = "a9";
            }
            else if (temp == a9Ct)
            {
                att = "a9";
            }
            if (temp < a10Ct)
            {
                temp = a10Ct;
                att = "a10";
            }
            else if (temp == a10Ct)
            {
                att = "a10";
            }

            if (temp < a11Ct)
            {
                temp = a11Ct;
                att = "a11";
            }
            else if (temp == a11Ct)
            {
                att = "a11";
            }
            if (temp < a12Ct)
            {
                temp = a12Ct;
                att = "a12";
            }
            else if (temp == a12Ct)
            {
                att = "a12";
            }
            if (temp < a13Ct)
            {
                temp = a13Ct;
                att = "a13";
            }
            else if (temp == a13Ct)
            {
                att = "a13";
            }

            return att;
        }

        /*private List<String> getNewAttributesWithMaxCount(Hashtable htt)
        {
            List<String> attlist = new List<string>();
            int temp = 0;
            temp = (int)htt["a1"];
            String att = "a1";
            attlist.Add(att);

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
                att = "a2";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a2Ct)
            {
                att = "a2";
                attlist.Add(att);
            }
            if (temp < a3Ct)
            {
                temp = a3Ct;
                att = "a3";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a3Ct)
            {
                att = "a3";
                attlist.Add(att);
            }
            if (temp < a4Ct)
            {
                temp = a4Ct;
                att = "a4";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a4Ct)
            {
                att = "a4";
                attlist.Add(att);
            }
            if (temp < a5Ct)
            {
                temp = a5Ct;
                att = "a5";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a5Ct)
            {
                att = "a5";
                attlist.Add(att);
            }
            if (temp < a6Ct)
            {
                temp = a6Ct;
                att = "a6";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a6Ct)
            {
                att = "a6";
                attlist.Add(att);
            }
            if (temp < a7Ct)
            {
                temp = a7Ct;
                att = "a7";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a7Ct)
            {
                att = "a7";
                attlist.Add(att);
            }
            if (temp < a8Ct)
            {
                temp = a8Ct;
                att = "a8";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a8Ct)
            {
                att = "a8";
                attlist.Add(att);
            }
            if (temp < a9Ct)
            {
                temp = a9Ct;
                att = "a9";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a9Ct)
            {
                att = "a9";
                attlist.Add(att);
            }
            if (temp < a10Ct)
            {
                temp = a10Ct;
                att = "a10";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a10Ct)
            {
                att = "a10";
                attlist.Add(att);
            }

            if (temp < a11Ct)
            {
                temp = a11Ct;
                att = "a11";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a11Ct)
            {
                att = "a11";
                attlist.Add(att);
            }
            if (temp < a12Ct)
            {
                temp = a12Ct;
                att = "a12";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a12Ct)
            {
                att = "a12";
                attlist.Add(att);
            }
            if (temp < a13Ct)
            {
                temp = a13Ct;
                att = "a13";
                attlist.Clear();
                attlist.Add(att);
            }
            else if (temp == a13Ct)
            {
                att = "a13";
                attlist.Add(att);
            }

            return attlist;
        }*/

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
                }
            }
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
                            if (isListsexist(l1, sameLists) == true)
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

        private Boolean isListsexist(List<String> List, List<List<String>> ListList)
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
                    int idheart = login.GetInt16(login.GetOrdinal("idmyheart"));
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
                    patient.setId(idheart);
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

        private List<Patient> decisionClass(string decision)
        {
            List<Patient> DecisionLists = new List<Patient>();
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from "+tablename+" where td=@decision";
            cmd.Parameters.AddWithValue("@decision", decision);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.HasRows)
            {
                while (login.Read())
                {
                    //I would also check for DB.Null here before reading the value.
                    Patient patient = new Patient();
                    int idheart = login.GetInt16(login.GetOrdinal("id"));
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
                    patient.setId(idheart);
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

        private Boolean isageSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            //cmd.CommandText = "SELECT 1 AS istrue FROM heart WHERE heart.idheart=@idheart1 AND heart.age=(SELECT heart.age FROM heart WHERE heart.idheart=@idheart2)";//runtime error
            cmd.CommandText = "SELECT IF(age=(SELECT age FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean issexSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(sex=(SELECT sex FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean iscpSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(cp=(SELECT cp FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean istrestbpsSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(trestbps=(SELECT trestbps FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean ischolSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(chol=(SELECT chol FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isfbsSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(fbs=(SELECT fbs FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isrestecgSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(restecg=(SELECT restecg FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isthalachSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(thalach=(SELECT thalach FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isexangSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(exang=(SELECT exang FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isopSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(op=(SELECT op FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isslopeSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(slope=(SELECT slope FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean iscaSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(ca=(SELECT ca FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }
        private Boolean isthalSame(int idheart1, int idheart2)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT IF(thal=(SELECT thal FROM " + tablename + " WHERE id=@idheart2) , false , true) AS istrue FROM " + tablename + " WHERE id=@idheart1";

            cmd.Parameters.AddWithValue("@idheart1", idheart1);
            cmd.Parameters.AddWithValue("@idheart2", idheart2);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            Boolean istrue = false;
            login.Read();
            istrue = login.GetBoolean(login.GetOrdinal("istrue"));
            connect.Close();
            return istrue;
        }

        private int IsReductAlreadyExist(int percentid, int random_no)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) as redcount from reducts where idpercentages=@percentid and random_number=@random_no";
            cmd.Parameters.AddWithValue("@percentid", percentid);
            cmd.Parameters.AddWithValue("@random_no", random_no);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            reader.Read();
            count = reader.GetInt16(reader.GetOrdinal("redcount"));
            connect.Close();
            return count;

        }

        private void saveReducts(String reductlistlists, int percentid, int random_no)
        {

            MessageBox.Show("in StoreRecord:");
            //for (int r1 = 0; r1 < reductListLists.Count; r1++)
            //{
            db_connection();
            //String reduct = "";
            //reduct = reductListLists[r1];
            //reduct = reductlistlists;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO reducts(reductString, idpercentages, reductAccuracy, random_number) VALUES (@reductStr, @percentid, 0.0, @random_no)";
            cmd.Parameters.AddWithValue("@reductStr", reductlistlists);
            cmd.Parameters.AddWithValue("@percentid", percentid);
            cmd.Parameters.AddWithValue("@random_no", random_no);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data inserted");
            connect.Close();
            //}
        }

        //////////////////////////////////////////////////
        private BackgroundWorker bw = new BackgroundWorker();

        private void percentcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PercentForm_Load(object sender, EventArgs e)
        {
            percentcomboBox.Items.Add(new Item("90% training and 10% testing", 1));
            percentcomboBox.Items.Add(new Item("80% training and 20% testing", 2));
            percentcomboBox.Items.Add(new Item("70% training and 30% testing", 3));
            percentcomboBox.Items.Add(new Item("60% training and 40% testing", 4));
        }
        // Content item for the combo box
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        /*private void button1_Click_1(object sender, EventArgs e)
        {
            if (!myWorker.IsBusy)//Check if the worker is already in progress
            {
                button1.Enabled = false;//Disable the Start button
                myWorker.RunWorkerAsync();//Call the background worker
                //button1.Enabled = false;//Disable the Start button
                //myWorker.RunWorkerAsync(arrObjects);//Call the background worker
                //RunWorkAsync; start running background worker that makes start DoWork()
            }
        }*/

        private void deleteAllData() {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "delete from " + tablename + " where id!=0";
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Item itm = (Item)percentcomboBox.SelectedItem;
            String percentvalue = itm.Name;
            if (percentvalue == "90% training and 10% testing")
            {
                percentid = 1;
                tablename = "90training";
            }
            else if (percentvalue == "80% training and 20% testing")
            {
                percentid = 2;
                tablename = "80training";
            }
            else if (percentvalue == "70% training and 30% testing")
            {
                percentid = 3;
                tablename = "70training";
            }
            else
            {
                percentid = 4;
                tablename = "60training";
            }
            int isreductcount = 0;
            //int numericValue = (int)numericUpDownMax.Value;//Capture the user input
            random_no = (int) numericUpDown1.Value;
            isreductcount = IsReductAlreadyExist(percentid, random_no);
            if (isreductcount > 0)
            {
                ReductForm rform = new ReductForm();
                rform.Show();
            }
            else
            {
                //inserting data into alldata array firstly before splitting
                List<Patient> patientlists = new List<Patient>();
                patientlists = getAllPatients();
                int count = patientlists.Count;
                MessageBox.Show("index of getallpatients;;;" + count);
                String[][] alldata = new String[count][];
                for (int i = 0; i < count; i++)
                {
                    //MessageBox.Show("patient age in alldata===" + patientlists[0].getAge());
                    String age = patientlists[i].getAge();
                    String sex = patientlists[i].getSex();
                    String cp = patientlists[i].getCp();
                    String trestbps = patientlists[i].getTrestbps();
                    String chol = patientlists[i].getChol();
                    String fbs = patientlists[i].getFbs();
                    String restecg = patientlists[i].getRestecg();
                    String thalach = patientlists[i].getThalach();
                    String exang = patientlists[i].getExang();
                    String op = patientlists[i].getOp();
                    String slope = patientlists[i].getSlope();
                    String ca = patientlists[i].getCa().ToString();
                    String thal = patientlists[i].getThal();
                    String td = patientlists[i].getTypeOfDisease();
                    // alldata[i] = new String[] { age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td };
                    alldata[i] = new String[14];
                    alldata[i][0] = age;
                    alldata[i][1] = sex;
                    alldata[i][2] = cp;
                    alldata[i][3] = trestbps;
                    alldata[i][4] = chol;
                    alldata[i][5] = fbs;
                    alldata[i][6] = restecg;
                    alldata[i][7] = thalach;
                    alldata[i][8] = exang;
                    alldata[i][9] = op;
                    alldata[i][10] = slope;
                    alldata[i][11] = ca;
                    alldata[i][12] = thal;
                    alldata[i][13] = td;
                }

                if (percentid == 1) {
                    //splitting for 90% training and 10% testing
                    String[][] train90 = null;
                    String[][] test10 = null;
                    percentageStr = "90&10%";
                    MakeTrainTest(alldata, out train90, out test10, random_no);
                    tablename = "90training";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < train90.Length; x++)
                    {
                        String age = train90[x][0];//Object reference not set to an instance of an object.
                        String sex = train90[x][1];
                        String cp = train90[x][2];
                        String trestbps = train90[x][3];
                        String chol = train90[x][4];
                        String fbs = train90[x][5];
                        String restecg = train90[x][6];
                        String thalach = train90[x][7];
                        String exang = train90[x][8];
                        String op = train90[x][9];
                        String slope = train90[x][10];
                        int ca = int.Parse(train90[x][11]);//argumentNullPointerException
                        String thal = train90[x][12];
                        String td = train90[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                    tablename = "10testing";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < test10.Length; x++)
                    {
                        String age = test10[x][0];
                        String sex = test10[x][1];
                        String cp = test10[x][2];
                        String trestbps = test10[x][3];
                        String chol = test10[x][4];
                        String fbs = test10[x][5];
                        String restecg = test10[x][6];
                        String thalach = test10[x][7];
                        String exang = test10[x][8];
                        String op = test10[x][9];
                        String slope = test10[x][10];
                        int ca = int.Parse(test10[x][11]);//argumentNullPointerException
                        String thal = test10[x][12];
                        String td = test10[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                }

                else if (percentid == 2) {
                    //splitting for 80% training and 20% testing
                    String[][] train80 = null;
                    String[][] test20 = null;
                    percentageStr = "80&20%";
                    MakeTrainTest(alldata, out train80, out test20, random_no);
                    tablename = "80training";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < train80.Length; x++)
                    {
                        String age = train80[x][0];//Object reference not set to an instance of an object.
                        String sex = train80[x][1];
                        String cp = train80[x][2];
                        String trestbps = train80[x][3];
                        String chol = train80[x][4];
                        String fbs = train80[x][5];
                        String restecg = train80[x][6];
                        String thalach = train80[x][7];
                        String exang = train80[x][8];
                        String op = train80[x][9];
                        String slope = train80[x][10];
                        int ca = int.Parse(train80[x][11]);//argumentNullPointerException
                        String thal = train80[x][12];
                        String td = train80[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                    tablename = "20testing";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < test20.Length; x++)
                    {
                        String age = test20[x][0];
                        String sex = test20[x][1];
                        String cp = test20[x][2];
                        String trestbps = test20[x][3];
                        String chol = test20[x][4];
                        String fbs = test20[x][5];
                        String restecg = test20[x][6];
                        String thalach = test20[x][7];
                        String exang = test20[x][8];
                        String op = test20[x][9];
                        String slope = test20[x][10];
                        int ca = int.Parse(test20[x][11]);//argumentNullPointerException
                        String thal = test20[x][12];
                        String td = test20[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                }

                else if (percentid == 3)
                {
                    //splitting for 70% training and 30% testing
                    String[][] train70 = null;
                    String[][] test30 = null;
                    percentageStr = "70&30%";
                    MakeTrainTest(alldata, out train70, out test30, random_no);
                    tablename = "70training";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < train70.Length; x++)
                    {
                        String age = train70[x][0];//Object reference not set to an instance of an object.
                        String sex = train70[x][1];
                        String cp = train70[x][2];
                        String trestbps = train70[x][3];
                        String chol = train70[x][4];
                        String fbs = train70[x][5];
                        String restecg = train70[x][6];
                        String thalach = train70[x][7];
                        String exang = train70[x][8];
                        String op = train70[x][9];
                        String slope = train70[x][10];
                        int ca = int.Parse(train70[x][11]);//argumentNullPointerException
                        String thal = train70[x][12];
                        String td = train70[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                    tablename = "30testing";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < test30.Length; x++)
                    {
                        String age = test30[x][0];
                        String sex = test30[x][1];
                        String cp = test30[x][2];
                        String trestbps = test30[x][3];
                        String chol = test30[x][4];
                        String fbs = test30[x][5];
                        String restecg = test30[x][6];
                        String thalach = test30[x][7];
                        String exang = test30[x][8];
                        String op = test30[x][9];
                        String slope = test30[x][10];
                        int ca = int.Parse(test30[x][11]);//argumentNullPointerException
                        String thal = test30[x][12];
                        String td = test30[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                }
                else {
                    //splitting for 60% training and 40% testing
                    String[][] train60 = null;
                    String[][] test40 = null;
                    percentageStr = "60&40%";
                    MakeTrainTest(alldata, out train60, out test40, random_no);
                    tablename = "60training";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < train60.Length; x++)
                    {
                        String age = train60[x][0];//Object reference not set to an instance of an object.
                        String sex = train60[x][1];
                        String cp = train60[x][2];
                        String trestbps = train60[x][3];
                        String chol = train60[x][4];
                        String fbs = train60[x][5];
                        String restecg = train60[x][6];
                        String thalach = train60[x][7];
                        String exang = train60[x][8];
                        String op = train60[x][9];
                        String slope = train60[x][10];
                        int ca = int.Parse(train60[x][11]);//argumentNullPointerException
                        String thal = train60[x][12];
                        String td = train60[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                    tablename = "40testing";
                    //delete all record before storing new records with new random number:
                    deleteAllData();
                    for (int x = 0; x < test40.Length; x++)
                    {
                        String age = test40[x][0];
                        String sex = test40[x][1];
                        String cp = test40[x][2];
                        String trestbps = test40[x][3];
                        String chol = test40[x][4];
                        String fbs = test40[x][5];
                        String restecg = test40[x][6];
                        String thalach = test40[x][7];
                        String exang = test40[x][8];
                        String op = test40[x][9];
                        String slope = test40[x][10];
                        int ca = int.Parse(test40[x][11]);//argumentNullPointerException
                        String thal = test40[x][12];
                        String td = test40[x][13];
                        
                        StoreRecord(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td);

                    }
                }

                //start of generating rules//6-8-2015
                //repair //19/9/2015
                string noDisease = "0";
                string yesDisease = "1";
                List<Patient> noDecisionLists = new List<Patient>();
                noDecisionLists = decisionClass(noDisease);

                List<Patient> yesDecisionLists = new List<Patient>();
                yesDecisionLists = decisionClass(yesDisease);

                List<List<String>> NoDisLists = new List<List<String>>();
                List<List<String>> allReductLists = new List<List<string>>();
                for (int y = 0; y < noDecisionLists.Count; y++)
                {
                    Patient p1 = new Patient();
                    p1 = noDecisionLists[y];
                    for (int z = 0; z < yesDecisionLists.Count; z++)
                    {
                        List<String> yesDisLists = new List<String>();
                        Patient p2 = new Patient();
                        p2 = yesDecisionLists[z];
                        int p1idheart = p1.getId();
                        int p2idheart = p2.getId();
                        Boolean b1 = isageSame(p1idheart, p2idheart);
                        Boolean b2 = issexSame(p1idheart, p2idheart);
                        Boolean b3 = iscpSame(p1idheart, p2idheart);
                        Boolean b4 = istrestbpsSame(p1idheart, p2idheart);
                        Boolean b5 = ischolSame(p1idheart, p2idheart);
                        Boolean b6 = isfbsSame(p1idheart, p2idheart);
                        Boolean b7 = isrestecgSame(p1idheart, p2idheart);
                        Boolean b8 = isthalachSame(p1idheart, p2idheart);
                        Boolean b9 = isexangSame(p1idheart, p2idheart);
                        Boolean b10 = isopSame(p1idheart, p2idheart);
                        Boolean b11 = isslopeSame(p1idheart, p2idheart);
                        Boolean b12 = iscaSame(p1idheart, p2idheart);
                        Boolean b13 = isthalSame(p1idheart, p2idheart);
                        if (b1 == true)
                        {
                            yesDisLists.Add("a1");
                        }
                        if (b2 == true)
                        {
                            yesDisLists.Add("a2");
                        }
                        if (b3 == true)
                        {
                            yesDisLists.Add("a3");
                        }
                        if (b4 == true)
                        {
                            yesDisLists.Add("a4");
                        }
                        if (b5 == true)
                        {
                            yesDisLists.Add("a5");
                        }
                        if (b6 == true)
                        {
                            yesDisLists.Add("a6");
                        }
                        if (b7 == true)
                        {
                            yesDisLists.Add("a7");
                        }
                        if (b8 == true)
                        {
                            yesDisLists.Add("a8");
                        }
                        if (b9 == true)
                        {
                            yesDisLists.Add("a9");
                        }
                        if (b10 == true)
                        {
                            yesDisLists.Add("a10");
                        }
                        if (b11 == true)
                        {
                            yesDisLists.Add("a11");
                        }
                        if (b12 == true)
                        {
                            yesDisLists.Add("a12");
                        }
                        if (b13 == true)
                        {
                            yesDisLists.Add("a13");
                        }
                        NoDisLists.Add(yesDisLists);
                        allReductLists.Add(yesDisLists);
                    }

                }
                /*
                StringBuilder sb = new StringBuilder();
                for (int dd = 0; dd < allReductLists.Count; dd++)
                {
                    String sst = "{";
                    for (int cc = 0; cc < allReductLists[dd].Count; cc++)
                    {
                        sst = sst + allReductLists[dd][cc];
                        sst = sst + ",";
                    }
                    sst = sst + "}";
                    sb.Append(sst);
                }
                richTextBox1.Text = String.Concat(sb);
                */
                List<String> reductList = new List<String>();
                StringBuilder sb = new StringBuilder();
                //do
                //{
                List<List<String>> returnListt = new List<List<string>>();
                //for (int a = 0; a < 11; a++) {
                do
                {
                    Hashtable htt = new Hashtable();
                    htt = getHashTable(allReductLists);
                    String maxatt = getNewAttributesWithMaxCount(htt);
                    /*List<String> maxattlist = getNewAttributesWithMaxCount(htt);
                    //MessageBox.Show("max attribute---" + maxatt);
                    for (int x = 0; x < maxattlist.Count; x++) {
                        MessageBox.Show("max attribute---" + maxattlist[x]);
                        reductList.Add(maxattlist[x]);
                        returnListt = removeListsWithMaxAttribute(maxattlist[x], allReductLists);
                        allReductLists.Clear();
                        allReductLists.AddRange(returnListt);
                    }*/
                    reductList.Add(maxatt);
                    returnListt = removeListsWithMaxAttribute(maxatt, allReductLists);
                    allReductLists.Clear();
                    allReductLists.AddRange(returnListt);
                    MessageBox.Show("//////////////////////");
                } while (allReductLists.Count > 1);

                String reductt = "";
                if (allReductLists.Count == 1)
                {
                    MessageBox.Show("allreductLists count is 1");
                    for (int a = 0; a < allReductLists[0].Count; a++)
                    {
                        reductt = allReductLists[0][a];
                        for (int b = 0; b < reductList.Count; b++)
                        {
                            reductt = reductt + ",";
                            reductt = reductt + reductList[b];
                            MessageBox.Show("reduct each String in count 1" + reductt);
                        }
                        saveReducts(reductt, percentid, random_no);
                    }
                }
                else
                {
                    MessageBox.Show("allreductLists count is not 1");
                    for (int b = 0; b < reductList.Count; b++)
                    {
                        reductt = reductt + reductList[b];
                        int index = reductList.Count - 1;
                        if (b == index) { }
                        else
                        {
                            reductt = reductt + ",";
                        }

                        MessageBox.Show("reduct each String " + reductt);
                    }
                    saveReducts(reductt, percentid, random_no);
                }
                 
                ReductForm rform = new ReductForm();
                rform.Show();
                

            }
        }
        static void MakeTrainTest(String[][] allData, out String[][] trainData, out String[][] testData, int random_no)
        {
            // split allData into 80% trainData and 20% testData
            Random rnd = new Random(random_no);
            int totRows = allData.Length;
            MessageBox.Show("total row of all data in Maketraintest  " + totRows);
            int numCols = allData[0].Length;//Index was outside the bounds of the array.

            if (percentageStr == "90&10%")
            {
                trainRows = (int)(totRows * 0.90); // hard-coded 90-10 split
                testRows = totRows - trainRows;
            }
            else if (percentageStr == "80&20%")
            {
                trainRows = (int)(totRows * 0.80); // hard-coded 80-20 split
                testRows = totRows - trainRows;
            }
            else if (percentageStr == "70&30%")
            {
                trainRows = (int)(totRows * 0.70); // hard-coded 70-30 split
                testRows = totRows - trainRows;
            }
            else
            {
                trainRows = (int)(totRows * 0.60); // hard-coded 60-40 split
                testRows = totRows - trainRows;
            }

            trainData = new String[trainRows][];
            testData = new String[testRows][];

            int[] sequence = new int[totRows]; // create a random sequence of indexes
            for (int i = 0; i < sequence.Length; ++i)
                sequence[i] = i;

            for (int i = 0; i < sequence.Length; ++i)
            {
                int r = rnd.Next(i, sequence.Length);
                int tmp = sequence[r];
                sequence[r] = sequence[i];
                sequence[i] = tmp;
            }

            int si = 0; // index into sequence[]
            int j = 0; // index into trainData or testData

            for (; si < trainRows; ++si) // first rows to train data
            {
                trainData[j] = new String[numCols];
                int idx = sequence[si];
                Array.Copy(allData[idx], trainData[j], numCols);
                ++j;
            }

            j = 0; // reset to start of test data
            for (; si < totRows; ++si) // remainder to test data
            {
                testData[j] = new String[numCols];
                int idx = sequence[si];
                Array.Copy(allData[idx], testData[j], numCols);
                ++j;
            }
        } // MakeTrainTest


        private void StoreRecord(String age, String sex, String cp, String trestbps, String chol, String fbs, String restecg, String thalach, String exang, String op, String slope, int ca, String thal, String td)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            //cmd.CommandText = "DELETE heartdisease FROM heartdisease WHERE heartdisease.ID=@id";
            cmd.CommandText = "INSERT INTO " + tablename + "(age, sex, cp, trestbps, chol, fbs, restecg, thalach, exang, op, slope, ca, thal, td) VALUES (@age, @sex, @cp, @trestbps, @chol, @fbs, @restecg, @thalach, @exang, @op, @slope, @ca, @thal, @td)";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

