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
    public partial class ReductForm : Form
    {
        public ReductForm()
        {
            InitializeComponent();
        }

        public static int percentid;
        public static String percentstr = "";
        public static String tablename = "";
        public static int random_no = 0;
        public static String reductstr = "";
        public static int reductid;

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
        private List<String> getReductString(int percentid, int random_number) {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select reductString from reducts where idpercentages=@percentid and random_number=@random_number";
            cmd.Parameters.AddWithValue("@percentid", percentid);
            cmd.Parameters.AddWithValue("@random_number", random_number);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<String> reductlists = new List<string>();
            if (reader.HasRows) {
                while (reader.Read()) {
                    String reductstring = reader.GetString(reader.GetOrdinal("reductString"));
                    reductlists.Add(reductstring);
                }
            }
            connect.Close();
            return reductlists;
            
        }

        private int IsRulesAlreadyExist(int reductid)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) as rulecount from rules where idreducts=@reductid";
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            reader.Read();
            count = reader.GetInt16(reader.GetOrdinal("rulecount"));
            connect.Close();
            return count;

        }

        private int GetReductId(String reductstr, int percentid, int random_no) {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select idreducts from reducts where idpercentages=@percentid and reductString=@reductstr and random_number=@random_no";
            cmd.Parameters.AddWithValue("@percentid", percentid);
            cmd.Parameters.AddWithValue("@reductstr", reductstr);
            cmd.Parameters.AddWithValue("@random_no", random_no);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            int id = 0;
            reader.Read();
            id = reader.GetInt16(reader.GetOrdinal("idreducts"));
            connect.Close();
            return id;
        }

        private int SupportcountRules(List<RuleItem> ruleitemlists)
        {
            StringBuilder cmdstr = new StringBuilder();
            int index = ruleitemlists.Count - 1;
            cmdstr.Append("select count(*) as count from " + tablename + " where ");

            for (int j = 0; j < ruleitemlists.Count; j++)
            {
                cmdstr.Append(ruleitemlists[j].getItem() + "='" + ruleitemlists[j].getValue() + "'");
                if (j == index)
                {
                    //do nothing
                }
                else
                {
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

        private int SupportdecisioncountRules(List<RuleItem> ruleitemlists)
        {
           //MessageBox.Show("support distinct count start   ");
            StringBuilder cmdstr = new StringBuilder();
            int index = ruleitemlists.Count - 1;
            cmdstr.Append("select count(distinct(td)) as count from " + tablename + " where ");
            //MessageBox.Show("rulestrin supportcount1       " + cmdstr);
            //MessageBox.Show("itemlist count is    " + ruleitemlists.Count);
            for (int j = 0; j < ruleitemlists.Count; j++)
            {
                //MessageBox.Show("item is   " + ruleitemlists[j].getItem());
                //MessageBox.Show("value is   " + ruleitemlists[j].getValue());
                cmdstr.Append(ruleitemlists[j].getItem() + "='" + ruleitemlists[j].getValue() + "'");
                //MessageBox.Show("rulestrin supportcount2      " + cmdstr);
                if (j == index)
                {
                    //do nothing
                }
                else
                {
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


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("starting of button click");
            reductstr = (String)reductcomboBox.SelectedItem;
            reductid = GetReductId(reductstr, percentid, random_no);
            int rulescount = 0;
            rulescount = IsRulesAlreadyExist(reductid);
            MessageBox.Show("rulescount is " + rulescount);

            if (rulescount > 0)
            {
                RuleForm ruleform = new RuleForm();
                ruleform.Show();
            }
            else
            {
                List<String> reducts = reductstr.Split(',').Reverse().ToList<String>();
                /*for (int i = 0; i < reducts.Count; i++)
                {
                    MessageBox.Show("each reduct String   " + reducts[i]);
                }*/
                List<Patient> allpatientlists = new List<Patient>();
                allpatientlists = getAllPatients();

                string noDisease = "0";
                string yesDisease = "1";
                List<Patient> noDecisionLists = new List<Patient>();
                noDecisionLists = decisionClass(noDisease);
                
                List<Patient> yesDecisionLists = new List<Patient>();
                yesDecisionLists = decisionClass(yesDisease);

                for (int y = 0; y < allpatientlists.Count; y++)//allpatientlists.Count
                {
                    //MessageBox.Show("patient one");
                    List<List<String>> allReductLists = new List<List<string>>();
                    Patient p1 = new Patient();
                    p1 = allpatientlists[y];
                    List<Patient> otherlists = new List<Patient>();
                    if (p1.getTypeOfDisease() == "0") {
                        otherlists.AddRange(yesDecisionLists);
                    }
                    else if (p1.getTypeOfDisease() == "1") {
                        otherlists.AddRange(noDecisionLists);
                    }
                    //MessageBox.Show("id of patient one is   "+p1.getidheart());
                    
                    //MessageBox.Show("other patient count is " + yesDecisionLists.Count);
                    StringBuilder ssb = new StringBuilder();
                    for (int z = 0; z < otherlists.Count; z++)
                    {
                        List<String> yesDisLists = new List<String>();
                        Patient p2 = new Patient();
                        p2 = otherlists[z];
                        //twopatients.Add(p2.getidheart());
                        int p1idheart = p1.getidheart();
                        int p2idheart = p2.getidheart();
                        ssb.Append(p2idheart);
                        ssb.Append(",");
                        for (int i = 0; i < reducts.Count; i++)
                        {
                            //MessageBox.Show("each reduct is " + reducts[i]);
                            Boolean b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13;
                            b1 = b2 = b3 = b4 = b5 = b6 = b7 = b8 = b9 = b10 = b11 = b12 = b13 = false;
                            if (reducts[i] == "a1")
                            {
                                b1 = isageSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a2")
                            {
                                b2 = issexSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a3")
                            {
                                b3 = iscpSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a4")
                            {
                                b4 = istrestbpsSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a5")
                            {
                                b5 = ischolSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a6")
                            {
                                b6 = isfbsSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a7")
                            {
                                b7 = isrestecgSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a8")
                            {
                                b8 = isthalachSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a9")
                            {
                                b9 = isexangSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a10")
                            {
                                b10 = isopSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a11")
                            {
                                b11 = isslopeSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a12")
                            {
                                b12 = iscaSame(p1idheart, p2idheart);
                            }
                            else if (reducts[i] == "a13")
                            {
                                b13 = isthalSame(p1idheart, p2idheart);
                            }
                            /////
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
                        }
                        allReductLists.Add(yesDisLists);

                    }
                    
                    //richTextBox1.Text = String.Concat(ssb);
                    
                    
                    
                    //Boolean isincon = false;
                    for (int dd = 0; dd < allReductLists.Count; dd++)
                    {
                        if (allReductLists[dd].Count == 0) {
                            allReductLists.RemoveAt(dd);
                            //isincon = true;
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
                     * */
                    //if (isincon == false)
                    //{


                        List<String> reductList = new List<String>();

                        List<List<String>> returnListt = new List<List<string>>();
                        do
                        {
                            Hashtable htt = new Hashtable();
                            htt = getHashTable(allReductLists);
                            String maxatt = getNewAttributesWithMaxCount(htt);
                            //richTextBox1.Text = maxatt;
                            //MessageBox.Show("max atttribute " + maxatt);
                            reductList.Add(maxatt);//out of memory exception
                            returnListt = removeListsWithMaxAttribute(maxatt, allReductLists);
                            allReductLists.Clear();
                            allReductLists.AddRange(returnListt);

                        } while (allReductLists.Count > 1);

                        if (allReductLists.Count == 1)
                        {
                            //MessageBox.Show("last reduct list is one   "+allReductLists[0].Count);
                            for (int a = 0; a < allReductLists[0].Count; a++)
                            {
                                List<int> ruleitemidlist = new List<int>();
                                StringBuilder rulestr = new StringBuilder();
                                rulestr.Append("IF    ");
                                //Rule rule = new Rule();
                                int rulesitemid = 0;
                                int lastrulesitemid = 0;
                                List<String> attlist = new List<string>();
                                attlist.Add(allReductLists[0][a]);

                                for (int b = 0; b < reductList.Count; b++)
                                {
                                    attlist.Add(reductList[b]);
                                }
                                StringListsBubbleSort(attlist);
                                String item = "";
                                String value = "";
                                List<RuleItem> itemlist = new List<RuleItem>();
                                for (int c = 0; c < attlist.Count; c++)
                                {
                                    //MessageBox.Show("att List is " + attlist[c]);
                                    if (attlist[c] == "a1")
                                    {
                                        item = "age";
                                        value = p1.getage();
                                    }
                                    else if (attlist[c] == "a2")
                                    {
                                        item = "sex";
                                        value = p1.getsex();
                                    }
                                    else if (attlist[c] == "a3")
                                    {
                                        item = "cp";
                                        value = p1.getcp();
                                    }
                                    else if (attlist[c] == "a4")
                                    {
                                        item = "trestbps";
                                        value = p1.gettrestbps();
                                    }
                                    else if (attlist[c] == "a5")
                                    {
                                        item = "chol";
                                        value = p1.getchol();
                                    }
                                    else if (attlist[c] == "a6")
                                    {
                                        item = "fbs";
                                        value = p1.getfbs();
                                    }
                                    else if (attlist[c] == "a7")
                                    {
                                        item = "restecg";
                                        value = p1.getrestecg();
                                    }
                                    else if (attlist[c] == "a8")
                                    {
                                        item = "thalach";
                                        value = p1.getthalach();
                                    }
                                    else if (attlist[c] == "a9")
                                    {
                                        item = "exang";
                                        value = p1.getexang();
                                    }
                                    else if (attlist[c] == "a10")
                                    {
                                        item = "op";
                                        value = p1.getop();
                                    }
                                    else if (attlist[c] == "a11")
                                    {
                                        item = "slope";
                                        value = p1.getslope();
                                    }
                                    else if (attlist[c] == "a12")
                                    {
                                        item = "ca";
                                        value = String.Concat(p1.getca());
                                    }
                                    else if (attlist[c] == "a13")
                                    {
                                        item = "thal";
                                        value = p1.getthal();
                                    }
                                    rulestr.Append(item + " = " + value);
                                    int itemcount = 0;
                                    itemcount = IsRulesItemAlreadyExist(item, value);
                                    if (itemcount == 0)
                                    {
                                        SaveRulesItem(item, value);
                                        lastrulesitemid = GetLastRuleItemId();
                                        ruleitemidlist.Add(lastrulesitemid);
                                    }
                                    else
                                    {
                                        rulesitemid = getRulesItemId(item, value);
                                        ruleitemidlist.Add(rulesitemid);
                                    }
                                    ///////////
                                    int index = attlist.Count - 1;
                                    if (index == c)
                                    {

                                    }
                                    else
                                    {
                                        rulestr.Append(" and ");
                                    }
                                    RuleItem ritem = new RuleItem();
                                    ritem.setItem(item);
                                    ritem.setValue(value);
                                    itemlist.Add(ritem);
                                    //MessageBox.Show("**item is   " + item);
                                    //MessageBox.Show("**value is   " + value);
                                }//end of attlist that already sorting attributes
                                /*for (int i = 0; i < itemlist.Count; i++) 
                                {
                                    MessageBox.Show("**item is   " + itemlist[i].getItem());
                                    MessageBox.Show("**value is   " + itemlist[i].getValue());
                                }*/
                                //the rule is consistent or not, check before
                                int supportdistinctdecisioncount = SupportdecisioncountRules(itemlist);
                                //int supportdistinctdecisioncount = 1;
                                if (supportdistinctdecisioncount == 1) 
                                {
                                    int supportcount = SupportcountRules(itemlist);
                                    String decision = "";
                                    if (p1.getTypeOfDisease() == "0")
                                    {
                                        decision = "0";
                                        rulestr.Append(" then 'no heart disease'");
                                    }
                                    else if (p1.getTypeOfDisease() == "1")
                                    {
                                        decision = "1";
                                        rulestr.Append(" then ' heart disease'");
                                    }
                                    String rulestring = String.Concat(rulestr);
                                    //check this rulestring is already exist in rules table for the reduct that user chose
                                    int rulecount = 0;
                                    int ruleid = 0;
                                    rulecount = IsRulesAlreadyExist(rulestring, reductid);
                                    if (rulecount == 0)
                                    {
                                        int ruleimportance = 1;
                                        saveRules(rulestring, decision, reductid, ruleimportance, supportcount);
                                        ruleid = GetLastRuleId();
                                        for (int d = 0; d < ruleitemidlist.Count; d++)
                                        {
                                            //MessageBox.Show("saveruledetail time " + d);
                                            saveRulesDetail(ruleid, ruleitemidlist[d]);
                                        }
                                    }
                                    else
                                    {
                                        ruleid = getRulesId(rulestring, reductid);
                                        int ruleimportance = getruleImportance(ruleid);
                                        ruleimportance = ruleimportance + 1;
                                        updateSupport(ruleid, ruleimportance);
                                    }
                                }
                                //MessageBox.Show("ruleitemlistcount is    "+ruleitemidlist.Count);
                            }//end of only one remaining list;; allReductLists[0]
                        }//end of if
                        /////////////////////finish to update
                        else
                        {
                            //MessageBox.Show("last reduct list is nothing ");
                            StringBuilder rulestr = new StringBuilder();
                            rulestr.Append("IF    ");
                            List<int> ruleitemidlist = new List<int>();
                            int rulesitemid = 0;
                            int lastrulesitemid = 0;
                            String item = "";
                            String value = "";
                            List<RuleItem> itemlist = new List<RuleItem>();
                            StringListsBubbleSort(reductList);
                            for (int b = 0; b < reductList.Count; b++)
                            {
                                if (reductList[b] == "a1")
                                {
                                    item = "age";
                                    value = p1.getage();

                                }
                                else if (reductList[b] == "a2")
                                {
                                    item = "sex";
                                    value = p1.getsex();
                                }
                                else if (reductList[b] == "a3")
                                {
                                    item = "cp";
                                    value = p1.getcp();
                                }
                                else if (reductList[b] == "a4")
                                {
                                    item = "trestbps";
                                    value = p1.gettrestbps();
                                }
                                else if (reductList[b] == "a5")
                                {
                                    item = "chol";
                                    value = p1.getchol();
                                }
                                else if (reductList[b] == "a6")
                                {
                                    item = "fbs";
                                    value = p1.getfbs();
                                }
                                else if (reductList[b] == "a7")
                                {
                                    item = "restecg";
                                    value = p1.getrestecg();
                                }
                                else if (reductList[b] == "a8")
                                {
                                    item = "thalach";
                                    value = p1.getthalach();
                                }
                                else if (reductList[b] == "a9")
                                {
                                    item = "exang";
                                    value = p1.getexang();
                                }
                                else if (reductList[b] == "a10")
                                {
                                    item = "op";
                                    value = p1.getop();
                                }
                                else if (reductList[b] == "a11")
                                {
                                    item = "slope";
                                    value = p1.getslope();
                                }
                                else if (reductList[b] == "a12")
                                {
                                    item = "ca";
                                    value = String.Concat(p1.getca());
                                }
                                else if (reductList[b] == "a13")
                                {
                                    item = "thal";
                                    value = p1.getthal();
                                }
                                rulestr.Append(item + " = " + value);

                                int itemcount = 0;
                                itemcount = IsRulesItemAlreadyExist(item, value);
                                if (itemcount == 0)
                                {
                                    SaveRulesItem(item, value);
                                    lastrulesitemid = GetLastRuleItemId();
                                    ruleitemidlist.Add(lastrulesitemid);
                                }
                                else
                                {
                                    rulesitemid = getRulesItemId(item, value);
                                    ruleitemidlist.Add(rulesitemid);
                                }
                                ///////////

                                int index = reductList.Count - 1;
                                if (index == b)
                                {
                                }
                                else
                                {
                                    rulestr.Append(" and ");
                                }
                                RuleItem ritem = new RuleItem();
                                ritem.setItem(item);
                                ritem.setValue(value);
                                itemlist.Add(ritem);

                            }//end of sorting lists
                            //the rule is consistent or not, check before
                            int supportdistinctdecisioncount = SupportdecisioncountRules(itemlist);
                            if (supportdistinctdecisioncount == 1)
                            {
                                int supportcount = SupportcountRules(itemlist);
                                String decision = "";
                                if (p1.getTypeOfDisease() == "0")
                                {
                                    decision = "0";
                                    rulestr.Append(" then 'no heart disease'");
                                }
                                else if (p1.getTypeOfDisease() == "1")
                                {
                                    decision = "1";
                                    rulestr.Append(" then ' heart disease'");
                                }
                                String rulestring = String.Concat(rulestr);
                                //MessageBox.Show(rulestring);
                                //check this rulestring is already exist in rules table for the reduct that user chose
                                int rulecount = 0;
                                int ruleid = 0;
                                rulecount = IsRulesAlreadyExist(rulestring, reductid);
                                if (rulecount == 0)
                                {
                                    int ruleimportance = 1;
                                    //calculate support

                                    saveRules(rulestring, decision, reductid, ruleimportance, supportcount);
                                    ruleid = GetLastRuleId();
                                    for (int d = 0; d < ruleitemidlist.Count; d++)
                                    {
                                        saveRulesDetail(ruleid, ruleitemidlist[d]);
                                    }
                                }
                                else
                                {
                                    ruleid = getRulesId(rulestring, reductid);
                                    int ruleimportance = getruleImportance(ruleid);
                                    ruleimportance = ruleimportance + 1;
                                    updateSupport(ruleid, ruleimportance);
                                }
                            }    
                            
                            
                        }
                     
                    ///}
                }//outer for loop
                RuleForm ruleform = new RuleForm();
                    ruleform.Show();


                }
            }
        public static void exchange(List<String> data, int m, int n)
        {
            String temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }
        public static void StringListsBubbleSort(List<String> data)
        {
            int i, j;
            int num1 = 0;
            int num2 = 0;
            int N = data.Count;

            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (data[i] == "a1") {
                        num1 = 1;
                    }
                    else if (data[i] == "a2") {
                        num1 = 2;
                    }
                    else if (data[i] == "a3")
                    {
                        num1 = 3;
                    }
                    else if (data[i] == "a4")
                    {
                        num1 = 4;
                    }
                    else if (data[i] == "a5")
                    {
                        num1 = 5;
                    }
                    else if (data[i] == "a6")
                    {
                        num1 = 6;
                    }
                    else if (data[i] == "a7")
                    {
                        num1 = 7;
                    }
                    else if (data[i] == "a8")
                    {
                        num1 = 8;
                    }
                    else if (data[i] == "a9")
                    {
                        num1 = 9;
                    }
                    else if (data[i] == "a10")
                    {
                        num1 = 10;
                    }
                    else if (data[i] == "a11")
                    {
                        num1 = 11;
                    }
                    else if (data[i] == "a12")
                    {
                        num1 = 12;
                    }
                    else if (data[i] == "a13")
                    {
                        num1 = 13;
                    }
                    ////////////////////////////////
                    if (data[i + 1] == "a1")
                    {
                        num2 = 1;
                    }
                    else if (data[i + 1] == "a2")
                    {
                        num2 = 2;
                    }
                    else if (data[i + 1] == "a3")
                    {
                        num2 = 3;
                    }
                    else if (data[i + 1] == "a4")
                    {
                        num2 = 4;
                    }
                    else if (data[i + 1] == "a5")
                    {
                        num2 = 5;
                    }
                    else if (data[i + 1] == "a6")
                    {
                        num2 = 6;
                    }
                    else if (data[i + 1] == "a7")
                    {
                        num2 = 7;
                    }
                    else if (data[i + 1] == "a8")
                    {
                        num2 = 8;
                    }
                    else if (data[i + 1] == "a9")
                    {
                        num2 = 9;
                    }
                    else if (data[i + 1] == "a10")
                    {
                        num2 = 10;
                    }
                    else if (data[i + 1] == "a11")
                    {
                        num2 = 11;
                    }
                    else if (data[i + 1] == "a12")
                    {
                        num2 = 12;
                    }
                    else if (data[i + 1] == "a13")
                    {
                        num2 = 13;
                    }
                    if (num1 > num2)
                        exchange(data, i, i + 1);
                }
            }
        }

        private int IsRulesAlreadyExist(String rulestring, int reductid)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) as rulecount from rules where ruleString=@rulestring and idreducts=@reductid";
            cmd.Parameters.AddWithValue("@rulestring", rulestring);
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            reader.Read();
            count = reader.GetInt16(reader.GetOrdinal("rulecount"));
            connect.Close();
            return count;

        }

        private int getRulesId(String rulestring, int reductid)
        {
            int id = 0;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select idrules from rules where ruleString=@rulestring and idreducts=@reductid";
            cmd.Parameters.AddWithValue("@rulestring", rulestring);
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            login.Read();
            id = login.GetInt16(login.GetOrdinal("idrules"));
            connect.Close();
            return id;
        }

        private int getruleImportance(int ruleid) {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select ruleImportance from rules where idrules=@ruleid";
            cmd.Parameters.AddWithValue("@ruleid", ruleid);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int support = reader.GetInt16(reader.GetOrdinal("ruleImportance"));
            connect.Close();
            return support;
        }

        private void updateSupport(int ruleid, int ruleimportance) {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "update rules set ruleImportance=@ruleimportance where idrules=@ruleid";
            cmd.Parameters.AddWithValue("@ruleid",ruleid);
            cmd.Parameters.AddWithValue("@ruleimportance", ruleimportance);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        private void saveRules(String rulestring, String decision, int reductid, int importance, int supportcount)
        {
            //MessageBox.Show("in StoreRecord:");
            //for (int r1 = 0; r1 < reductListLists.Count; r1++)
            //{
            db_connection();
            //String reduct = "";
            //reduct = reductListLists[r1];
            //reduct = reductlistlists;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO rules(ruleString,decision, idreducts, ruleImportance, ruleStrength, supportCount) VALUES (@ruleStr,@decision, @reductid, @importance, 0, @supportcount)";
            cmd.Parameters.AddWithValue("@ruleStr", rulestring);
            cmd.Parameters.AddWithValue("@decision", decision);
            cmd.Parameters.AddWithValue("@reductid", reductid);
            cmd.Parameters.AddWithValue("@importance", importance);
            cmd.Parameters.AddWithValue("@supportcount", supportcount);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Data inserted");
            connect.Close();
            //}
        }

        private int GetLastRuleId() {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select idrules from rules where idrules=(select max(idrules) from rules)";
            cmd.Connection = connect;
            MySqlDataReader reader=cmd.ExecuteReader();
            reader.Read();
            int id = reader.GetInt16(reader.GetOrdinal("idrules"));
            connect.Close();
            return id;
        }

        private void SaveRulesItem(String item, String value)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO rulesitem(item, value) VALUES (@item, @value)";
            cmd.Parameters.AddWithValue("@item", item);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
            //}
        }

        private int GetLastRuleItemId()
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select idrulesitem from rulesitem where idrulesitem=(select max(idrulesitem) from rulesitem)";
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = reader.GetInt16(reader.GetOrdinal("idrulesitem"));
            connect.Close();
            return id;
        }

        private int IsRulesItemAlreadyExist(String item, String value)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) as itemcount from rulesitem where item=@item and value=@value";
            cmd.Parameters.AddWithValue("@item", item);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Connection = connect;
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            reader.Read();
            count = reader.GetInt16(reader.GetOrdinal("itemcount"));
            connect.Close();
            return count;

        }

        private int getRulesItemId(String item, String value)
        {
            int id = 0;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select idrulesitem from rulesitem where item=@item and value=@value";
            //select if (idrulesitem =(select idrulesitem from rulesitem where item=@item and value=@value), idrulesitem, 0) as id from rulesitem
            cmd.Parameters.AddWithValue("@item",item);
            cmd.Parameters.AddWithValue("@value",value);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            login.Read();
            id = login.GetInt16(login.GetOrdinal("idrulesitem"));
            /*if (login.HasRows)
            {
                while (login.Read())
                {
                    login.Read();
                    id = login.GetInt16(login.GetOrdinal("id"));
                    if (id > 0)
                        break;
                }
            }*/
            connect.Close();
            return id;
        }

        private void saveRulesDetail(int ruleid, int ruleitemid)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO rulesdetail(idrules, idrulesitem) VALUES (@ruleid, @ruleitemid)";
            cmd.Parameters.AddWithValue("@ruleid", ruleid);
            cmd.Parameters.AddWithValue("@ruleitemid", ruleitemid);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
            //}
        }

        private void ReductForm_Load(object sender, EventArgs e)
        {
            percentid = PercentForm.percentid;
            random_no = PercentForm.random_no;
            if (percentid == 1)
            {
                percentstr = "90% training and 10% testing";
                tablename = "90training";
            }
            else if (percentid == 2)
            {
                percentstr = "80% training and 20% testing";
                tablename = "80training";
            }
            else if (percentid == 3)
            {
                percentstr = "70% training and 30% testing";
                tablename = "70training";
            }
            else
            {
                percentstr = "60% training and 40% testing";
                tablename = "60training";
            }
            percentLabel.Text = percentstr;
            randomLabel.Text = "Random No::    "+random_no;
            List<String> reductlistss = new List<string>();
            reductlistss = getReductString(percentid, random_no);
            for (int i = 0; i < reductlistss.Count; i++) {
                reductcomboBox.Items.Add(reductlistss[i]);
            }
            /*DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = "a1";
            row.Cells[1].Value = "Age";
            dataGridView1.Rows.Add(row);
            */
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "a1";
            dataGridView1.Rows[0].Cells[1].Value = "age";
            dataGridView1.Rows[0].Cells[2].Value = "Age";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[1].Cells[0].Value = "a2";
            dataGridView1.Rows[1].Cells[1].Value = "sex";
            dataGridView1.Rows[1].Cells[2].Value = "Sex";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[2].Cells[0].Value = "a3";
            dataGridView1.Rows[2].Cells[1].Value = "cp";
            dataGridView1.Rows[2].Cells[2].Value = "Chest Pain Type";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[3].Cells[0].Value = "a4";
            dataGridView1.Rows[3].Cells[1].Value = "trestbps";
            dataGridView1.Rows[3].Cells[2].Value = "Resting Blood Pressure(mmHg)";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[4].Cells[0].Value = "a5";
            dataGridView1.Rows[4].Cells[1].Value = "chol";
            dataGridView1.Rows[4].Cells[2].Value = "Serum Cholestrol Rate:(mmHg)";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[5].Cells[0].Value = "a6";
            dataGridView1.Rows[5].Cells[1].Value = "fbs";
            dataGridView1.Rows[5].Cells[2].Value = "Fasting Blood Sugar over 120 mg/dl?";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[6].Cells[0].Value = "a7";
            dataGridView1.Rows[6].Cells[1].Value = "restecg";
            dataGridView1.Rows[6].Cells[2].Value = "Resting Electrocardiographic Results";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[7].Cells[0].Value = "a8";
            dataGridView1.Rows[7].Cells[1].Value = "thalach";
            dataGridView1.Rows[7].Cells[2].Value = "Maximum Heart Rate achieved";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[8].Cells[0].Value = "a9";
            dataGridView1.Rows[8].Cells[1].Value = "exang";
            dataGridView1.Rows[8].Cells[2].Value = "Exercise induced angina?";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[9].Cells[0].Value = "a10";
            dataGridView1.Rows[9].Cells[1].Value = "oldpeak";
            dataGridView1.Rows[9].Cells[2].Value = "ST depression induced by exercise relative to rest";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[10].Cells[0].Value = "a11";
            dataGridView1.Rows[10].Cells[1].Value = "slope";
            dataGridView1.Rows[10].Cells[2].Value = "The slope of the peak exercise ST segment";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[11].Cells[0].Value = "a12";
            dataGridView1.Rows[11].Cells[1].Value = "ca";
            dataGridView1.Rows[11].Cells[2].Value = "Number of major vessels colored by fluoroscopy";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[12].Cells[0].Value = "a13";
            dataGridView1.Rows[12].Cells[1].Value = "thal";
            dataGridView1.Rows[12].Cells[2].Value = "Thallium Scan";
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private String getNewAttributesWithMaxCount(Hashtable htt)
        {
            int temp = 0;
            temp = (int)htt["a1"];
            //List<String> attributes = new List<string>();
            String att = "a1";
            //attributes.Add("a1");
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
                //attributes.Clear();
                //attributes.Add("a2");
                att = "a2";
            }
            else if (temp == a2Ct)
            {
                //attributes.Add("a2");
                att = "a2";
            }
            if (temp < a3Ct)
            {
                //attributes.Clear();
                temp = a3Ct;
                //attributes.Add("a3");
                att = "a3";
            }
            else if (temp == a3Ct)
            {
                //attributes.Add("a3");
                att = "a3";
            }
            if (temp < a4Ct)
            {
                //attributes.Clear();
                temp = a4Ct;
                //attributes.Add("a4");
                att = "a4";
            }
            else if (temp == a4Ct)
            {
                //attributes.Add("a4");
                att = "a4";
            }
            if (temp < a5Ct)
            {
                //attributes.Clear();
                temp = a5Ct;
                //attributes.Add("a5");
                att = "a5";
            }
            else if (temp == a5Ct)
            {
                //attributes.Add("a5");
                att = "a5";
            }
            if (temp < a6Ct)
            {
                //attributes.Clear();
                temp = a6Ct;
                //attributes.Add("a6");
                att = "a6";
            }
            else if (temp == a6Ct)
            {
                //attributes.Add("a6");
                att = "a6";
            }
            if (temp < a7Ct)
            {
                //attributes.Clear();
                temp = a7Ct;
                //attributes.Add("a7");
                att = "a7";
            }
            else if (temp == a7Ct)
            {
                //attributes.Add("a7");
                att = "a7";
            }
            if (temp < a8Ct)
            {
                //attributes.Clear();
                temp = a8Ct;
                //attributes.Add("a8");
                att = "a8";
            }
            else if (temp == a8Ct)
            {
                //attributes.Add("a8");
                att = "a8";
            }
            if (temp < a9Ct)
            {
                //attributes.Clear();
                temp = a9Ct;
                //attributes.Add("a9");
                att = "a9";
            }
            else if (temp == a9Ct)
            {
                //attributes.Add("a9");
                att = "a9";
            }
            if (temp < a10Ct)
            {
                //attributes.Clear();
                temp = a10Ct;
                //attributes.Add("a10");
                att = "a10";
            }
            else if (temp == a10Ct)
            {
                //attributes.Add("a10");
                att = "a10";
            }

            if (temp < a11Ct)
            {
                //attributes.Clear();
                temp = a11Ct;
                //attributes.Add("a11");
                att = "a11";
            }
            else if (temp == a11Ct)
            {
                //attributes.Add("a11");
                att = "a11";
            }
            if (temp < a12Ct)
            {
                //attributes.Clear();
                temp = a12Ct;
                //attributes.Add("a12");
                att = "a12";
            }
            else if (temp == a12Ct)
            {
                //attributes.Add("a12");
                att = "a12";
            }
            if (temp < a13Ct)
            {
                //attributes.Clear();
                temp = a13Ct;
                //attributes.Add("a13");
                att = "a13";
            }
            else if (temp == a13Ct)
            {
                //attributes.Add("a13");
                att = "a13";
            }

            return att;
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

        public class Rule {
            String item;
            public String getitem() { return item; }

            public void setitem(String item)
            {
                this.item = item;
            }
            String value;
            public String getvalue() { return value; }

            public void setvalue(String value)
            {
                this.value = value;
            }
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
            cmd.CommandText = "Select * from " + tablename;
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

        private List<Patient> decisionClass(string decision)
        {
            List<Patient> DecisionLists = new List<Patient>();
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from " + tablename + " where td=@decision";
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

    }
}

