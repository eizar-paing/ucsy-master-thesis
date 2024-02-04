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
    public partial class SuggestRuleForm : Form
    {

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

        public SuggestRuleForm()
        {
            InitializeComponent();
        }

        private void strengthGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SuggestRuleForm_Load(object sender, EventArgs e)
        {
            int maxreductiid = getReductIDwithMaxAccuracy();
            MessageBox.Show("max reductId is   "+maxreductiid);
            String maxreductstring = getReductStringWithReductId(maxreductiid);
            String maxpercentstring = getPercentStringWithReductId(maxreductiid);
            double maxaccuracy = getAccuracyWithReductId(maxreductiid);
            int random_no = getRandomnoWithReductId(maxreductiid);
            List<Rule> maxrulelists = getRuleStringWithNoZero(maxreductiid);

            maxpercentLabel.Text = maxpercentstring;
            maxreductLabel.Text = "Reduct  ::  "+maxreductstring;
            maxaccuracyLabel.Text = "Accuracy   ::  "+String.Concat(maxaccuracy)+"%";
            randomLabel.Text = "Random No  ::  "+String.Concat(random_no);

            for (int i = 0; i < maxrulelists.Count; i++) {
                String rulestring=maxrulelists[i].getRulestring();
                double strength = maxrulelists[i].getStrength();
                int ruleimportance = maxrulelists[i].getRuleimportance();
                int supportcount = maxrulelists[i].getSupportcount();
                ruleGridview.Rows.Add();
                ruleGridview.Rows[i].Cells[0].Value = rulestring;
                ruleGridview.Rows[i].Cells[1].Value = strength + "%";
                ruleGridview.Rows[i].Cells[2].Value = ruleimportance;
                ruleGridview.Rows[i].Cells[3].Value = supportcount;
            }
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

        private int getReductIDwithMaxAccuracy()
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select idreducts from reducts where reductAccuracy=(select max(reductAccuracy) from my.reducts)";
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int reductid = reader.GetInt16(reader.GetOrdinal("idreducts"));
            connect.Close();
            return reductid;
        }

        private String getReductStringWithReductId(int idreduct)
        {

            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select reductString from reducts where idreducts=@idreduct";
            cmd.Parameters.AddWithValue("@idreduct", idreduct);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();//Fatal error encountered during command execution
            reader.Read();
            String reductstring = reader.GetString(reader.GetOrdinal("reductString"));
            connect.Close();
            return reductstring;
        }

        private String getPercentStringWithReductId(int idreduct)
        {

            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select percentString from reducts, my.percentages where reducts.idpercentages=percentages.idpercentages and idreducts=@idreduct";
            cmd.Parameters.AddWithValue("@idreduct", idreduct);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            String percentstring = reader.GetString(reader.GetOrdinal("percentString"));
            connect.Close();
            return percentstring;
        }

        private double getAccuracyWithReductId(int idreduct)
        {

            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select reductAccuracy from reducts where idreducts=@idreduct";
            cmd.Parameters.AddWithValue("@idreduct", idreduct);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            double accuracy = reader.GetDouble(reader.GetOrdinal("reductAccuracy"));
            connect.Close();
            return accuracy;
        }

        private int getRandomnoWithReductId(int idreduct)
        {

            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select random_number from reducts where idreducts=@idreduct";
            cmd.Parameters.AddWithValue("@idreduct", idreduct);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int random = reader.GetInt16(reader.GetOrdinal("random_number"));
            connect.Close();
            return random;
        }

        private List<Rule> getRuleStringWithReductId(int idreduct)
        {

            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select ruleString from rules where idreducts=@idreduct";
            cmd.Parameters.AddWithValue("@idreduct", idreduct);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Rule> rulelist = new List<Rule>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Rule rule = new Rule();
                    String rulestring = reader.GetString(reader.GetOrdinal("ruleString"));
                    rule.setRulestring(rulestring);
                    rulelist.Add(rule);
                }
            }
            connect.Close();
            return rulelist;
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
            public void setRuleid(int ruleid)
            {
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

    }
}
