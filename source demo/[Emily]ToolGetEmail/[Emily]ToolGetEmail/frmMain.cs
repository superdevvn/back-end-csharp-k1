using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _Emily_ToolGetEmail
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void loadTrangVang()
        {
            string url = txtUrl.Text;
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                readStream = new StreamReader(receiveStream, Encoding.UTF8);

                html = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            var contactInfos = document.DocumentNode.Descendants("div")
                .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("listing_box"))
                .Select(element => new ContactInfo
                {
                    Name = element.Descendants("h2").First(ele => ele.Attributes.Contains("class") && ele.Attributes["class"].Value.Contains("company_name")).InnerText.Trim(),
                    Email = element.Descendants("p").First(ele => ele.Attributes.Contains("class") && ele.Attributes["class"].Value.Contains("listing_email")).InnerText.Trim(),
                    PhoneNumber = element.Descendants("p").First(ele => ele.Attributes.Contains("class") && ele.Attributes["class"].Value.Contains("listing_tel")).InnerText.Trim(),
                    Address = element.Descendants("p").First(ele => ele.Attributes.Contains("class") && ele.Attributes["class"].Value.Contains("listing_diachi")).InnerText.Trim(),
                }).ToList();
            contactInfos.ForEach((contactInfo) =>
            {
                contactInfo.STT = bindingSource1.Count + 1;
                bindingSource1.Add(contactInfo);
            });
        }

        private void ExportToExcel()
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Email";
            // storing header part in Excel  
            for (int i = 1; i < gridResult.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = gridResult.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < gridResult.Rows.Count - 1; i++)
            {
                for (int j = 0; j < gridResult.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = gridResult.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                loadTrangVang();
                lblSumary.Text = bindingSource1.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            lblSumary.Text = bindingSource1.Count.ToString();

            frmLogin login = new frmLogin();
            login.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.Clear();
                lblSumary.Text = bindingSource1.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class ContactInfo
    {
        public int STT { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
