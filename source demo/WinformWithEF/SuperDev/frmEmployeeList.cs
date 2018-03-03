using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperDev.Repositories;

namespace SuperDev
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();

            var employeeRepository = new EmployeeRepository();
            bindingSource1.DataSource = employeeRepository.GetList();
        }

        private void gridEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEmployeeDetail form = new frmEmployeeDetail(2);
            form.ShowDialog();
        }
    }
}
