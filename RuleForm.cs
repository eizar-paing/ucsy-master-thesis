using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RoughSetProject2
{
    public partial class RuleForm : Form
    {
        public RuleForm()
        {
            InitializeComponent();
        }

        public static List<Rule> rulelist = new List<Rule>();
        public static List<RuleItem> ruleitemlists = new List<RuleItem>();
        public static String testingtable = "";
        public static int percentid;
        public static int reductid;
        public static int random_no;

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

        private List<Rule> getRuleString(int reductid)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            MessageBox.Show("data read for rules  ");
            cmd.CommandText = "select * from rules where idreducts=@reductid";
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Rule> rulelists = new List<Rule>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Rule rule = new Rule();
                    int ruleid = reader.GetInt16(reader.GetOrdinal("idrules"));
                    String rulestring = reader.GetString(reader.GetOrdinal("ruleString"));
                    String decision = reader.GetString(reader.GetOrdinal("decision"));
                    double strength = reader.GetDouble(reader.GetOrdinal("ruleStrength"));
                    int ruleimportance = reader.GetInt16(reader.GetOrdinal("ruleImportance"));
                    int supportcount = reader.GetInt16(reader.GetOrdinal("supportCount"));
                    rule.setRuleid(ruleid);
                    rule.setRulestring(rulestring);
                    rule.setDecision(decision);
                    rule.setStrength(strength);
                    rule.setRuleimportance(ruleimportance);
                    rule.setSupportcount(supportcount);
                    rulelists.Add(rule);
                    
                }
            }
            connect.Close();
            return rulelists;

        }

        private List<Rule> getRuleStringWithNoZero(int reductid)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            MessageBox.Show("data read for rules  ");
            cmd.CommandText = "select * from rules where idreducts=@reductid and ruleStrength>0 order by ruleStrength DESC";
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Rule> rulelists = new List<Rule>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Rule rule = new Rule();
                    int ruleid = reader.GetInt16(reader.GetOrdinal("idrules"));
                    String rulestring = reader.GetString(reader.GetOrdinal("ruleString"));
                    String decision = reader.GetString(reader.GetOrdinal("decision"));
                    double strength = reader.GetDouble(reader.GetOrdinal("ruleStrength"));
                    int ruleimportance = reader.GetInt16(reader.GetOrdinal("ruleImportance"));
                    int supportcount = reader.GetInt16(reader.GetOrdinal("supportCount"));
                    rule.setRuleid(ruleid);
                    rule.setRulestring(rulestring);
                    rule.setDecision(decision);
                    rule.setStrength(strength);
                    rule.setRuleimportance(ruleimportance);
                    rule.setSupportcount(supportcount);
                    rulelists.Add(rule);

                }
            }
            connect.Close();
            return rulelists;

        }

        private void RuleForm_Load(object sender, EventArgs e)
        {
            percentid = ReductForm.percentid;
            if (percentid == 1) {
                testingtable = "10testing";
            }
            else if (percentid == 2) {
                testingtable = "20testing";
            }
            else if (percentid == 3)
            {
                testingtable = "30testing";
            }
            else
            {
                testingtable = "40testing";
            }
            String reductstr = ReductForm.reductstr;
            String percentstr = ReductForm.percentstr;
            random_no = ReductForm.random_no;
            reductid = ReductForm.reductid;
            MessageBox.Show("reductid is    " + reductid);
            percentLabel.Text = percentstr;
            randomLabel.Text = "Random No. " + random_no;
            reductLabel.Text = "Reduct : "+reductstr;
            rulelist = getRuleString(reductid);//with all zero strength
            //sorting rules with strength

            for (int j = 0; j < rulelist.Count; j++)
            {
                String rulestring = rulelist[j].getRulestring();
                double strength = rulelist[j].getStrength();
                int ruleimportance = rulelist[j].getRuleimportance();
                int supportcount = rulelist[j].getSupportcount();
                strengthGridview.Rows.Add(); 
                strengthGridview.Rows[j].Cells[0].Value = rulestring;
                strengthGridview.Rows[j].Cells[1].Value = strength+"%";
                strengthGridview.Rows[j].Cells[2].Value = ruleimportance;
                strengthGridview.Rows[j].Cells[3].Value = supportcount;
            }
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[0].Cells[0].Value = "age";
            valuedataGridView.Rows[0].Cells[1].Value = "Young(<30), Mild(30-45), Old(>45)";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[1].Cells[0].Value = "sex";
            valuedataGridView.Rows[1].Cells[1].Value = "Male, Female";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[2].Cells[0].Value = "cp";
            valuedataGridView.Rows[2].Cells[1].Value = "1(Typical angina),2(Atypical angina),3(Non-angina pain),4(Asymptomatic)";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[3].Cells[0].Value = "trestbps";
            valuedataGridView.Rows[3].Cells[1].Value = "Low(<120),Medium(120-150), High(>=150)";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[4].Cells[0].Value = "chol";
            valuedataGridView.Rows[4].Cells[1].Value = "Low(<160),Medium(160-190),High(190-250),Very high(>250)";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[5].Cells[0].Value = "fbs";
            valuedataGridView.Rows[5].Cells[1].Value = "false, true";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[6].Cells[0].Value = "restecg";
            valuedataGridView.Rows[6].Cells[1].Value = "1(Normal), 2(ST-T Abnormal), 3(Hypertrophy)";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[7].Cells[0].Value = "thalach";
            valuedataGridView.Rows[7].Cells[1].Value = "Low(<=120), Medium(120-150), High(>150)";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[8].Cells[0].Value = "exang";
            valuedataGridView.Rows[8].Cells[1].Value = "yes, no";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[9].Cells[0].Value = "oldpeak";
            valuedataGridView.Rows[9].Cells[1].Value = "Low(<1.5), Risk(1.5-4.5), Terrible(>4.5)";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[10].Cells[0].Value = "slope";
            valuedataGridView.Rows[10].Cells[1].Value = "Up sloping, Flat, Down sloping";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[11].Cells[0].Value = "ca";
            valuedataGridView.Rows[11].Cells[1].Value = "0, 1, 2, 3";
            valuedataGridView.Rows.Add();
            valuedataGridView.Rows[12].Cells[0].Value = "thal";
            valuedataGridView.Rows[12].Cells[1].Value = "Normal, Fixed defect, Reversible defect";
            
        }

        public class Rule
        {
            public int ruleid;
            public String rulestring;
            public String decision;
            public double strength;
            public int ruleimportance;
            public int supportcount;
            public int getRuleid() { return ruleid; }
            public void setRuleid(int ruleid) {
                this.ruleid = ruleid;
            }
            public String getRulestring() { return rulestring; }
            public void setRulestring(String rulestring)
            {
                this.rulestring = rulestring;
            }
            public String getDecision() { return decision; }
            public void setDecision(String decision)
            {
                this.decision = decision;
            }
            public double getStrength() { return strength; }
            public void setStrength(double strength)
            {
                this.strength = strength;
            }
            public int getRuleimportance() { return ruleimportance; }
            public void setRuleimportance(int ruleimportance)
            {
                this.ruleimportance = ruleimportance;
            }
            public int getSupportcount() { return supportcount; }
            public void setSupportcount(int supportcount)
            {
                this.supportcount = supportcount;
            }
        }

        public class RuleItem
        {
            public String item;
            public String value;
            public String getItem() { return item; }
            public void setItem(String item)
            {
                this.item = item;
            }
            public String getValue() { return value; }
            public void setValue(String value)
            {
                this.value = value;
            }
        }

        public List<RuleItem> getRuleItemWithRuleId(int ruleid) {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select item, value from my.rulesitem, my.rulesdetail, my.rules where rules.idrules=@ruleid and rules.idrules=rulesdetail.idrules and rulesitem.idrulesitem=rulesdetail.idrulesitem";
            cmd.Parameters.AddWithValue("@ruleid", ruleid);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<RuleItem> ruleitemlist = new List<RuleItem>();
            if (reader.HasRows) {
                while (reader.Read()) {
                    RuleItem ruleitem = new RuleItem();
                    String item = reader.GetString(reader.GetOrdinal("item"));
                    String value = reader.GetString(reader.GetOrdinal("value"));
                    ruleitem.setItem(item);
                    ruleitem.setValue(value);
                    ruleitemlist.Add(ruleitem);
                }
            }
            connect.Close();
            return ruleitemlist;

        }

        private int SupportcountForTestObjectsWithDecision(List<RuleItem> ruleitemlists, String decision)
        {
            StringBuilder cmdstr = new StringBuilder();
            int index = ruleitemlists.Count - 1;
            cmdstr.Append("select count(*) as count from " + testingtable + " where ");
            for (int j = 0; j < ruleitemlists.Count; j++)
            {
                cmdstr.Append(ruleitemlists[j].getItem() + "='" + ruleitemlists[j].getValue()+"'");
                if (j == index)
                {
                    //do nothing
                }
                else
                {
                    cmdstr.Append(" and ");
                }
            }
            cmdstr.Append(" and td=@decision");
            
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Concat(cmdstr);
            cmd.Parameters.AddWithValue("@decision", decision);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int supportcount = reader.GetInt16(reader.GetOrdinal("count"));
            connect.Close();
            return supportcount;
        }

        private int SupportcountForTestObjects(List<RuleItem> ruleitemlists) {
            StringBuilder cmdstr = new StringBuilder();
            int index = ruleitemlists.Count - 1;
            cmdstr.Append("select count(*) as count from "+testingtable+" where ");
            
            for (int j = 0; j < ruleitemlists.Count; j++) {
                cmdstr.Append(ruleitemlists[j].getItem()+"='"+ruleitemlists[j].getValue()+"'");
                if (j == index)
                {
                    //do nothing
                }
                else {
                    cmdstr.Append(" and ");
                }
            }
            //richTextBox1.Text = String.Concat(cmdstr);
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Concat(cmdstr);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int supportcount = reader.GetInt16(reader.GetOrdinal("count"));
            connect.Close();
            return supportcount;
        }

        private int IsMatchObjectWithRule(List<RuleItem> ruleitemlist, Patient p)
        {
            //SELECT if (item=(select item from my.rulesitem where idrulesitem=51) and value=(select value FROM `my`.`rulesitem` where idrulesitem=51) ,true, false ) as aa from my.rulesitem where idrulesitem=51
            StringBuilder sb = new StringBuilder();
            int index = ruleitemlist.Count - 1;
            sb.Append("select if( ");
            for (int k = 0; k < ruleitemlist.Count; k++)
            {
                
                sb.Append(ruleitemlist[k].getItem() + "='" + ruleitemlist[k].getValue() + "'");
                if (k == index)
                {
                    //do nothing
                }
                else
                {
                    sb.Append(" and ");
                }
            }
            sb.Append(", 1, 0) as a from " + testingtable + " where id = " +p.getidheart());
            //richTextBox1.Text = String.Concat(sb);
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Concat(sb);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            //You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near 'thal='normal' and , 1, 0) as a from 30testing where id = 90' at line 1

            reader.Read();
            int a = reader.GetInt16(reader.GetOrdinal("a"));
            connect.Close();
            return a;
        }

        private void updateStrength(int ruleid, String strength)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
           // MessageBox.Show("ruleid in updatestrength    " + ruleid);
            //MessageBox.Show("strength in updatestrength   " + strength);
            cmd.CommandText = "update rules set ruleStrength=@strength where idrules=@ruleid";
            cmd.Parameters.AddWithValue("@ruleid", ruleid);
            cmd.Parameters.AddWithValue("@strength", strength);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        private void updateAccuracy(int reductid, String accuracy)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            // MessageBox.Show("ruleid in updatestrength    " + ruleid);
            //MessageBox.Show("strength in updatestrength   " + strength);
            cmd.CommandText = "update reducts set reductAccuracy=@accuracy where idreducts=@reductid";
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Parameters.AddWithValue("@accuracy", accuracy);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        private decimal getAccuracy(int reductid)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select reductAccuracy from reducts where idreducts=@reductid";
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            decimal a = reader.GetDecimal(reader.GetOrdinal("reductAccuracy"));
            connect.Close();
            return a;
        }

        private void UpdatePredictedDecision(int patientid, String decision)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            // MessageBox.Show("ruleid in updatestrength    " + ruleid);
            //MessageBox.Show("strength in updatestrength   " + strength);
            cmd.CommandText = "update "+testingtable+" set pretd=@decision where id=@patientid";
            cmd.Parameters.AddWithValue("@patientid", patientid);
            cmd.Parameters.AddWithValue("@decision", decision);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        private float supportcount()
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) as a from "+testingtable+" where td=pretd";
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            float a = reader.GetInt16(reader.GetOrdinal("a"));
            connect.Close();
            return a;
        }
        private float allcount()
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) as b from " + testingtable;
            cmd.Connection = connect;
            MySqlDataReader readerr = cmd.ExecuteReader();
            readerr.Read();
            float b = readerr.GetInt16(readerr.GetOrdinal("b"));
            connect.Close();
            return b;
        }

        private void strengthbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rulelist.Count; i++) {
                int ruleid = rulelist[i].getRuleid();
                //MessageBox.Show("ruleid is " + ruleid);
                String decision = rulelist[i].getDecision();
                //MessageBox.Show("decision is " + decision);
                ruleitemlists = getRuleItemWithRuleId(ruleid);
                ruleitemlists = getRuleItemWithRuleId(ruleid);
                SupportcountForTestObjects(ruleitemlists);
                float support = SupportcountForTestObjects(ruleitemlists);
                float supportwithdecision = SupportcountForTestObjectsWithDecision(ruleitemlists, decision);
                double strength = 0.0;
                decimal rulestrength;
                String rulestr = "";
                if (support == 0)
                {
                    strength = 0.0;
                    rulestrength = (decimal)strength;
                    rulestr=String.Format("{0:0.00}", rulestrength);
                }
                else {
                    strength = (supportwithdecision / support) * 100;
                    rulestrength = (decimal)strength;
                    rulestr = String.Format("{0:0.00}", rulestrength);
                }
                updateStrength(ruleid, rulestr);
            }
            List<Rule> ruleslistwithstrength = new List<Rule>();
            ruleslistwithstrength = getRuleStringWithNoZero(reductid);
            strengthGridview.Rows.Clear();
            for (int j = 0; j < ruleslistwithstrength.Count; j++)
            {//ruleslistwithstrength.Count
                String rulestring = ruleslistwithstrength[j].getRulestring();
                double strength = ruleslistwithstrength[j].getStrength();
                int ruleimportance = ruleslistwithstrength[j].getRuleimportance();
                int supportcount = ruleslistwithstrength[j].getSupportcount();
                //MessageBox.Show("each rule is...........     " + rulestring + "...." + strength + "..." + ruleimportance + "...." + supportcount);
                strengthGridview.Rows.Add();
                strengthGridview.Rows[j].Cells[0].Value = rulestring;
                strengthGridview.Rows[j].Cells[1].Value = strength+"%";
                strengthGridview.Rows[j].Cells[2].Value = ruleimportance;
                strengthGridview.Rows[j].Cells[3].Value = supportcount;
            }
            MessageBox.Show("Successful complete Calculating strenghth!!!");
        }

        private void accuracybutton_Click(object sender, EventArgs e)
        {
            decimal reductacc = getAccuracy(reductid);
            if (reductacc > 0)
            {
                MessageBox.Show("not zero accuracy");
                MessageBox.Show("accuracy for reduct is   "+reductacc);
                accuracyLabel.Text = String.Concat(reductacc) + "%";
            }
            else {
                
                MessageBox.Show("accuracy for reduct is   " + reductacc);
                List<Patient> allpatients = new List<Patient>();
                allpatients = getAllPatients();
                List<Rule> ruleslistwithstrength = new List<Rule>();
                ruleslistwithstrength = getRuleStringWithNoZero(reductid);
                for (int j = 0; j < allpatients.Count; j++)
                {//allpatients.Count
                    Patient p = allpatients[j];
                    int pid = p.getidheart();
                    List<Rule> matchrulelist = new List<Rule>();
                    
                    for (int i = 0; i < ruleslistwithstrength.Count; i++)
                    {
                        Rule rule = ruleslistwithstrength[i];
                        int ruleid = rule.getRuleid();
                        List<RuleItem> ruleitemlist = new List<RuleItem>();
                        ruleitemlist = getRuleItemWithRuleId(ruleid);
                        int a = IsMatchObjectWithRule(ruleitemlist, p);
                        if (a == 1)
                        {
                            matchrulelist.Add(rule);
                        }
                    }
                    double strength = 0.0;
                    Rule rulewithmaxstrength = new Rule();
                    for (int k = 0; k < matchrulelist.Count; k++)
                    {
                        if (strength < matchrulelist[k].getStrength() && matchrulelist[k].getStrength()!=0)
                        {
                            strength = matchrulelist[k].getStrength();
                            rulewithmaxstrength = matchrulelist[k];
                        }
                    }
                    String decision = rulewithmaxstrength.getDecision();
                    UpdatePredictedDecision(pid, decision);
                }
                float support = supportcount();
                float all = allcount();
                double accuracy = (support / all) * 100;
                decimal acc = (decimal)accuracy;
                String ac = String.Format("{0:0.00}", acc);
                updateAccuracy(reductid, ac);
                accuracyLabel.Text = ac + "%";
            }


            //to show rules with maximum accuracy
            SuggestRuleForm sf = new SuggestRuleForm();
            sf.Show();

        }

        
        public class Patient
        {
            int idheart;
            public int getidheart() { return idheart; }

            public void setidheart(int idheart)
            {
                this.idheart = idheart;
            }
            String age;

            public String getage() { return age; }

            public void setage(String age)
            {
                this.age = age;
            }
            String sex;

            public String getsex() { return sex; }

            public void setsex(String sex)
            {
                this.sex = sex;
            }
            String cp;

            public String getcp() { return cp; }

            public void setcp(String cp)
            {
                this.cp = cp;
            }
            String trestbps;

            public String gettrestbps() { return trestbps; }

            public void settrestbps(String trestbps)
            {
                this.trestbps = trestbps;
            }
            String chol;

            public String getchol() { return chol; }

            public void setchol(String chol)
            {
                this.chol = chol;
            }
            String fbs;

            public String getfbs() { return fbs; }

            public void setfbs(String fbs)
            {
                this.fbs = fbs;
            }
            String restecg;

            public String getrestecg() { return restecg; }

            public void setrestecg(String restecg)
            {
                this.restecg = restecg;
            }
            String thalach;

            public String getthalach() { return thalach; }

            public void setthalach(String thalach)
            {
                this.thalach = thalach;
            }
            String exang;

            public String getexang() { return exang; }

            public void setexang(String exang)
            {
                this.exang = exang;
            }
            String op;

            public String getop() { return op; }

            public void setop(String op)
            {
                this.op = op;
            }
            int ca;

            public int getca() { return ca; }

            public void setca(int ca)
            {
                this.ca = ca;
            }
            String slope;

            public String getslope() { return slope; }

            public void setslope(String slope)
            {
                this.slope = slope;
            }
            String thal;

            public String getthal() { return thal; }

            public void setthal(String thal)
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
            cmd.CommandText = "Select * from " + testingtable;
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
                    patient.setidheart(idheart);
                    patient.setage(age);
                    patient.setsex(sex);
                    patient.setcp(cp);
                    patient.settrestbps(trestbps);
                    patient.setchol(chol);
                    patient.setfbs(fbs);
                    patient.setrestecg(restecg);
                    patient.setthalach(thalach);
                    patient.setexang(exang);
                    patient.setop(op);
                    patient.setslope(slope);
                    patient.setca(ca);
                    patient.setthal(thal);
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

        private void strengthGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void strengthGridview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void valuedataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}



