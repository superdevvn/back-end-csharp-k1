using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperDev
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //frmLogin form = new frmLogin();
            //form.ShowDialog();
            frmEmployee objForm = new frmEmployee();
            objForm.TopLevel = false;
            panelMain.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
    }
}
