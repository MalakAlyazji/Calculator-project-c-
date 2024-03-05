using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CalculatorProjectt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum enoperation
        {
            sum,sub,mult,divv,sqrt,square2,inverse,tenx
        }
        enoperation op=enoperation.sum;
        public double result = 0;
        public double n1 = 0;
        public double n2 = 0;
        public bool isfirstnum=true;
        public bool isnewcal = false;
        int count = 0;
        void addnum(object sender,EventArgs e) 
        {
            if (txtresult.Text!="0")
            {
                txtresult.Text +=( (Button)sender).Text;
            }
            else
            {
                txtresult.Text = ((Button)sender).Text;
            }
                
        }
        void getfirstnum()
        {
            if (isfirstnum)
            {
                n1 = Convert.ToDouble(txtresult.Text);
                isfirstnum = false;
                txtresult.Clear();
                return;
            }

            switch (op)
            {
                case enoperation.sum:
                    n1 += Convert.ToDouble(txtresult.Text);
                    break;
                case enoperation.sub:
                    n1 -= Convert.ToDouble(txtresult.Text);
                    break;
                case enoperation.mult:
                    n1 *= Convert.ToDouble(txtresult.Text);
                    break;
                case enoperation.divv:
                    if (Convert.ToDouble(txtresult.Text) == 0)
                    {
                        txtresult.Text = "Math Error";
                        break;
                    }
                    else
                    {
                        n1 /= Convert.ToDouble(txtresult.Text);
                        break;
                    }
            }
            txtresult.Clear();
        }
        void delete()
        {
            txtresult.Text = "0";
            result = 0;
            n1 = 0;
            n2 = 0;
            isfirstnum = true;
            btmult.Enabled = true;
            btdiv.Enabled = true;
            btsub.Enabled = true;
            btsum.Enabled = true;
            btequal.Enabled = true;
            btsqr.Enabled = true;
            btsquare2.Enabled = true;
            bt1x.Enabled = true;
            button19.Enabled = true;
            bt8.Enabled = true;
            bt0.Enabled = true;
            bt1.Enabled = true;
            bt2.Enabled = true;
            bt3.Enabled = true;
            bt4.Enabled = true;
            bt5.Enabled = true;
            bt6.Enabled = true;
            bt7.Enabled = true;
            bt9.Enabled = true;
            button3.Enabled = true;
        }
        private void bt_Click(object sender, EventArgs e)
        {
            addnum(sender,e);
        }
        enoperation optype(string s)
        {
            if (s == "+")
            {
                return enoperation.sum;
            }
            else if (s == "-")
            {
                return enoperation.sub;
            }
            else if (s == "*")
            {
                return enoperation.mult;
            }
            else if(s == "/")
            {
                return enoperation.divv;
            }
            else if (s == "sqrt")
            {
               return enoperation.sqrt;
            }
            else if (s == "square2")
            {
                return enoperation.square2;
            }
            else if (s == "1/x")
            {
                return enoperation.inverse;
            }
            else
            {
                return enoperation.tenx;
            }

        }
        string soperation(enoperation en)
        {
            switch (en)
            {
                case enoperation.sum:
                    return "+";
                    break;
                case enoperation.sub:
                    return "-";
                    break;
                case enoperation.mult:
                    return "*";
                    break;
                case enoperation.divv:
                    return "/";
                    break;
                case enoperation.sqrt:
                    return "^.5";
                    break;
                case enoperation.square2:
                    return "^2";
                    break;
                case enoperation.inverse:
                    return "^-1";
                case enoperation.tenx:
                    return "10 ^";
                    break;
                default:
                    return "+";
            }
        }
        private void opclick(object sender, EventArgs e)
        {
            button3.Enabled = true;
            getfirstnum();
            op = optype(((Button)sender).Text);
        }
        void calculateresult()
        { 
            switch (op)
            {
                case enoperation.sum:
                    result = n1 + n2;
                    break;
                case enoperation.sub:
                    result = n1 - n2;
                    break;
                case enoperation.mult:
                    result = n1 * n2;
                    break;
                case enoperation.divv:
                    if (n2 == 0)
                    {
                        txtresult.Text = "Math Error";
                        diablebuttonerror();
                        return;
                    }

                    else
                        result = n1 / n2;
                    break;

            }
        }
        private void btequal_Click(object sender, EventArgs e)
        {
            count++;
            if(op==enoperation.sum|| op == enoperation.sub || op == enoperation.mult || op == enoperation.divv)
            {
                n2 = Convert.ToDouble(txtresult.Text);
                if (txtresult.Text == ".")
                    insertpoint();
                calculateresult();
            }
            txtresult.Text = result.ToString();
            fillviewlist();
            btequal.Enabled = false;
            bt8.Enabled = false;
            bt0.Enabled = false;
            bt1.Enabled = false;
            bt2.Enabled = false;
            bt3.Enabled = false;
            bt4.Enabled = false;
            bt5.Enabled = false;
            bt6.Enabled = false;
            bt7.Enabled = false;
            bt9.Enabled = false;
        }
        void diablebuttonerror()
        {
            if(txtresult.Text=="Math Error")
            {
                btmult.Enabled = false;
                btdiv.Enabled = false;
                btsub.Enabled = false;
                btsum.Enabled = false;
                btequal.Enabled = false;
                btsqr.Enabled = false;
                btsquare2.Enabled = false;
                bt1x.Enabled = false;
                button19.Enabled = false;
            }
        }
        private void btclear_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void btsqr_Click(object sender, EventArgs e)
        {
            getfirstnum();
            op = optype(btsqr.Text);
            if (Convert.ToDouble(n1) < 0)
            {
                txtresult.Text = "Math Error";
                diablebuttonerror();
                return;
            }
            else
            {
                result = Math.Sqrt(n1);
            }

        }

        private void btsquare2_Click(object sender, EventArgs e)
        {
            getfirstnum();
            op = optype(btsquare2.Text);
            result =Math.Pow(n1,2);
        }
        private void bt1x_Click(object sender, EventArgs e)
        {
            getfirstnum();
            op = optype(bt1x.Text);
            if (Convert.ToDouble(n1) == 0)
            {
                txtresult.Text = "Math Error";
                diablebuttonerror();
            }
            else
            {
                result =1/ Convert.ToDouble(n1);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            getfirstnum();
            op = optype(button19.Text);
            result = Math.Pow(10, Convert.ToDouble(n1));
            count++;
        }

        private void btdeletelast_Click(object sender, EventArgs e)
        {
            result = Convert.ToDouble(txtresult.Text) / 10;
            int m = (int)result;
            txtresult.Text = m.ToString();
        }
        void insertpoint()
        {
            if (txtresult.Text == "0")
            {
                txtresult.Text = "0.";
            }
            else { 
                txtresult.Text += "."; 
            }
            
            button3.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            insertpoint();
        }
        void fillviewlist()
        {
            ListViewItem item = new ListViewItem(count.ToString());
            
            if(op==enoperation.sqrt|| op == enoperation.square2|| op == enoperation.inverse)
            {
                item.SubItems.Add(n1.ToString() + soperation(op)  + "=" + result.ToString());
            }
            else if(op == enoperation.tenx)
            {
                item.SubItems.Add(soperation(op) + n1.ToString() +   "=" + result.ToString());
            }
            else
            {
                item.SubItems.Add(n1.ToString() + soperation(op) + n2.ToString() + "=" + result.ToString());
            }
            listView1.Items.Add(item);
        }
        private void bthistory_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            tabPage2.Show();
        }
        private void btback(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabPage1.Show();
            delete();
        }
        void deletehistory()
        {
            listView1.Items.Clear();
            count = 0;
        }
        private void btdeletehistory_Click(object sender, EventArgs e)
        {
            deletehistory();
        }

        private void btsign_Click(object sender, EventArgs e)
        {
            if (txtresult.Text == "0")
            {
                txtresult.Text = "-";
                return;
            }
            //if(txtresult.Text == "-")
            //{
            //    txtresult.Text = "+";
            //    return;
            //}
            //if(txtresult.Text == "+")
            //{
            //    txtresult.Text = "-";
            //    return;
            //}
          double d = Convert.ToDouble(txtresult.Text) *(-1);
         txtresult.Text = d.ToString();
        }
    }
}
