using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DövizUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(today);

            string dolaralis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolarA.Text = dolaralis;

            string dolarsatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarS.Text = dolarsatis;

            string euroalis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroA.Text = euroalis;

            string eurosatis = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroS.Text = eurosatis;
        }

        private void BtnDolarA_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarA.Text;
        }

        private void BtnDolarS_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarS.Text;
        }

        private void BtnEuroA_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroA.Text;
        }

        private void BtnEuroS_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroS.Text;
        }

        private void BtnSatış_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(TxtKur.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = kur * miktar;
            TxtTutar.Text = tutar.ToString();
        }

        private void TxtKur_TextChanged(object sender, EventArgs e)
        {
            TxtKur.Text = TxtKur.Text.Replace(".", ",");
        }

        private void BtnS2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(TxtKur.Text);
            int miktar = Convert.ToInt32(TxtMiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            TxtTutar.Text = tutar.ToString();
            int kalan;
            kalan = miktar % tutar;
            TxtKalan.Text = kalan.ToString();
        }
    }
}
