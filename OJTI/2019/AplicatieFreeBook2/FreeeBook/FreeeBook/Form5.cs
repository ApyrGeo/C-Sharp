using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeeBook
{
    public partial class Form5 : Form
    {
        public Form5(int i)
        {
            
            InitializeComponent();
            //string adresa = "file://"+Application.StartupPath+@"\Resurse\cartipdf\"+Convert.ToString(i)+".pdf";
            ////System.Diagnostics.Process.Start(adresa);
            //adresa = adresa.Replace('/', '\\');
            ////adresa = System.Net.WebUtility.UrlEncode(adresa);
            //webBrowser1.Url=new Uri("C:\\Users\\geose\\OneDrive\\Desktop\\Olimpiada C#\\AplicatieFreeBook2\\FreeeBook\\FreeeBook\\bin\\Debug\\Resurse\\cartipdf\\1.pdf");
        
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
