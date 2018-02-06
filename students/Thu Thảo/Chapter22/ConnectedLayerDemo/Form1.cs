using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ConnectedLayerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(local);Initial Catalog=FUH_COMPANY;Integrated Security=True");
     
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Loaddata();
                MessageBox.Show("The connection is successful!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("The connection failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loaddata()
        {
            conn.Open();

          

            SqlCommand com = new SqlCommand("Select tblEmployee.empSSN ,empName , depNum, empSalary, tblDependent.depName , depRelationship From tblEmployee JOIN tblDependent ON tblDependent.empSSN = tblEmployee.empSSN", conn);
            SqlDataReader dr = com.ExecuteReader();
           
            int i = 0;
            while (dr.Read())
            {
                LivDemo.Items.Add(dr["empSSN"].ToString());
                LivDemo.Items[i].SubItems.Add(dr["empName"].ToString());
                LivDemo.Items[i].SubItems.Add(dr["depNum"].ToString());
                LivDemo.Items[i].SubItems.Add(dr["empSalary"].ToString());
                LivDemo.Items[i].SubItems.Add(dr["depName"].ToString());
                LivDemo.Items[i].SubItems.Add(dr["depRelationship"].ToString());
                i++;
            }
            conn.Close();
        }

        private void LivDemo_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem list in LivDemo.SelectedItems)
            {
                txtEmpSSN.Text = list.SubItems[0].Text;
                txtEmpName.Text = list.SubItems[1].Text;
                txtDepNum.Text = list.SubItems[2].Text;
                txtEmpSalary.Text = list.SubItems[3].Text;
                txtDepName.Text = list.SubItems[4].Text;
                txtDepRelationship.Text = list.SubItems[5].Text;

            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String empSSN = txtEmpSSN.Text;
                String empName = txtEmpName.Text;
                String depNum = txtDepNum.Text;
                String salary = txtEmpSalary.Text;
                String depName = txtDepName.Text;
                String depRelationship = txtDepRelationship.Text;
                SqlCommand com = new SqlCommand("Insert into tblEmployee (empSSN, empName, depNum, empSalary) values ('" + empSSN + "', '" + empName + "', '" + depNum + "', '" + salary + "')", conn);
                com.ExecuteNonQuery();
                SqlCommand com1 = new SqlCommand("Select tblEmployee.empSSN", conn);
                int com1.ExecuteNonQuery();
                SqlCommand com2 = new SqlCommand("Insert into tblDependent (depName, empSSN, depRelationship) values ('" + depName + "', '" + com1 + "', '" + depRelationship + "')", conn);
                com2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Insert data successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LivDemo.Items.Clear();
                Loaddata();
            }
            catch
            {
                MessageBox.Show("Insert data failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String empSSN = txtEmpSSN.Text;
                String empName = txtEmpName.Text;
                String depNum = txtDepNum.Text;
                String salary = txtEmpSalary.Text;
                String depName = txtDepName.Text;
                String depRelationship = txtDepRelationship.Text;
                SqlCommand com = new SqlCommand("Update tblDependent Set depRelationship = '" + depRelationship + "'Where empSSN = '" + empSSN + "' and depName = '" + depName + "'", conn);
                SqlCommand com1 = new SqlCommand("Update tblEmployee Set empName = '" + empName + "', depNum = '" + depNum + "', empSalary = '" + salary + "'Where empSSN = '" + empSSN + "'", conn);
                com.ExecuteNonQuery();
                com1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update data successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LivDemo.Items.Clear();
                Loaddata();
            }
            catch
            {
                MessageBox.Show("Update data failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String empSSN = txtEmpSSN.Text;
                String depName = txtDepName.Text;
                SqlCommand com = new SqlCommand("Delete From tblDependent Where empSSN = '" + empSSN + "' and depName = '" + depName + "'", conn);
                SqlCommand comm = new SqlCommand("Delete From tblEmployee Where empSSN = '" + empSSN + "'", conn);
                com.ExecuteNonQuery();
                comm.ExecuteNonQuery();
                conn.Close();
                txtEmpSSN.Text = "";
                txtEmpName.Text = "";
                txtDepNum.Text = "";
                txtEmpSalary.Text = "";
                txtDepName.Text = "";
                txtDepRelationship.Text = "";
                MessageBox.Show("Delete data successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LivDemo.Items.Clear();
                Loaddata();
            }
            catch
            {
                MessageBox.Show("Delete data failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
