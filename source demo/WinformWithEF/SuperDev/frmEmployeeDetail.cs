using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperDev.Models;

namespace SuperDev
{
    public partial class frmEmployeeDetail : Form
    {
        bool isCreate { get; set; }
        public frmEmployeeDetail(int id)
        {
            InitializeComponent();
            isCreate = id == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(isCreate)
            {
                Employee employee = new Employee();
            }
        }
    }
}
