using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HisapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double sonuc = 0;
        string Sayı = "0";
        string islem = "";
        Guna2CircleButton but;
        string Ek = " ";
        List<string> Ekler = new List<string>();
        List<string> Sonuçlar = new List<string>();
        private void btnNumralar_Click(object sender, EventArgs e)
        {
            but = (Guna2CircleButton)sender;
            if (islem != "" || sonuc == 0)
                Ek += but.Text;
            if (!Exp)
            {
                lblSonuc.Text = lblSonuc.Text.Remove(lblSonuc.Text.Length - 1, 1) + but.Text;
                Sayı = (sonuc * Math.Pow(10, Convert.ToDouble(but.Text))).ToString();
                sonuc = Convert.ToDouble(Sayı);
                Exp = true;
                return;
            }

            if (Sayı == "0")
            {
                Sayı = but.Text;
            }
            else
            {
                Sayı += but.Text;
            }
            lblSonuc.Text = Sayı;
            btnCE2.Text = "CE";
            if (islem == "xʸ")
            {
                lblEkSonuc.Text = sonuc + "^";
            }
            else
            {
                lblEkSonuc.Text = sonuc + islem;
            }
        }
        void Numaralar(string but)
        {
            if (!Exp)
            {
                lblSonuc.Text = lblSonuc.Text.Remove(lblSonuc.Text.Length - 1, 1) + but;
                Sayı = (sonuc * Math.Pow(10, Convert.ToDouble(but))).ToString();
                sonuc = Convert.ToDouble(Sayı);
                Exp = true;
                return;
            }

            if (Sayı == "0")
            {
                Sayı = but;
            }
            else
            {
                Sayı += but;
            }
            lblSonuc.Text = Sayı;
            btnCE2.Text = "CE";
            if (islem == "xʸ")
            {
                lblEkSonuc.Text = sonuc + "^";
            }
            else
            {
                lblEkSonuc.Text = sonuc + islem;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(321, 548);
            guna2Panel2.Location = guna2Panel1.Location;
            flowLayoutPanel1.Location = new Point(7, 222);

            if (TemaDB.Default.TemaBool)
            {
                this.BackColor = Color.FromArgb(20, 20, 20);
                foreach (Guna2CircleButton n in guna2Panel1.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(10, 10, 10);
                    }
                }
                foreach (Guna2CircleButton n in guna2Panel2.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(10, 10, 10);
                    }
                }
                lblSonuc.ForeColor = Color.White;
                btnSayısal.Image = Properties.Resources.pngegg2;
                btnTema.Image = Properties.Resources.BeyazTema;
                btnKayıt.Image = Properties.Resources.BeyazKayıt;
            }
            else
            {
                this.BackColor = Color.FromArgb(200, 200, 200);
                foreach (Guna2CircleButton n in guna2Panel1.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(100, 100, 100);
                    }
                }
                foreach (Guna2CircleButton n in guna2Panel2.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(100, 100, 100);
                    }
                }
                lblSonuc.ForeColor = Color.Black;
                btnSayısal.Image = Properties.Resources.pngegg;
                btnTema.Image = Properties.Resources.SiyahTema;
                btnKayıt.Image = Properties.Resources.GriKayıt;
            }

        }
        private void btnİslem_Click(object sender, EventArgs e)
        {
            Guna2CircleButton butislem = (Guna2CircleButton)sender;
            lblEkSonuc.Visible = true;
            // aşağıdaki if kodu düzeltilmesi gerek
            char[] Aktarma = new char[Ek.Length];
            if (Ek.Length > 1)
            {
                if (Ek[Ek.Length - 2] == '+' || Ek[Ek.Length - 2] == '-'
                                || Ek[Ek.Length - 2] == 'x' || Ek[Ek.Length - 2] == '÷'
                                || Ek[Ek.Length - 2] == '%')
                {
                    int sayac = 0;
                    foreach (char n in Ek)
                    {
                        char m = n;
                        if (sayac == Ek.Length - 2)
                        {
                            m = Convert.ToChar(butislem.Text);
                        }
                        Aktarma[sayac] += m;
                        sayac++;
                    }
                    Ek = " ";
                    foreach (char n in Aktarma)
                    {
                        Ek += n;
                    }
                }
                else
                {
                    Ek += " " + butislem.Text + " ";"
                }
            }
            else
            {
                Ek += " " + butislem.Text + " ";
            }
            if (islem == "+")
            {
                Sayı = (Convert.ToDouble(sonuc) + Convert.ToDouble(Sayı)).ToString();
            }
            else if (islem == "-")
            {
                Sayı = (Convert.ToDouble(sonuc) - Convert.ToDouble(Sayı)).ToString();
            }
            else if (islem == "x")
            {
                Sayı = (Convert.ToDouble(sonuc) * Convert.ToDouble(Sayı)).ToString();
            }
            else if (islem == "÷")
            {
                Sayı = (Convert.ToDouble(sonuc) / Convert.ToDouble(Sayı)).ToString();
            }
            else if (islem == "%" || islem == "mod")
            {
                Sayı = (Convert.ToDouble(sonuc) % Convert.ToDouble(Sayı)).ToString();
            }
            else if (islem == "xʸ")
            {
                Sayı = (Math.Pow(sonuc, Convert.ToDouble(Sayı))).ToString();
            }
            //buraya exp,(x üzeri y) taşıabiliriz çünkü gelecek sayı na göre işlem yapabiliriz
            islem = butislem.Text;

            if (islem == "=")
            {
                lblSonuc.Text = Sayı;
                lblEkSonuc.Visible = false;
                Ekler.Add(Ek);
                Sonuçlar.Add(lblSonuc.Text);
                Ek = lblSonuc.Text;
            }
            if (islem == "π")
            {
                Sayı = ((3.14159265358979) * Convert.ToDouble(Sayı)).ToString();
                sonuc = Convert.ToDouble(Sayı);
                islem = "=";
            }
            if (islem == "e")
            {
                Sayı = ((2.71828182845904) * Convert.ToDouble(Sayı)).ToString();
                sonuc = Convert.ToDouble(Sayı);
                islem = "=";
            }
            sonuc = Convert.ToDouble(Sayı);
            if (islem == "xʸ")
            {
                lblEkSonuc.Text = sonuc + "^";
            }
            else
            {
                lblEkSonuc.Text = sonuc + islem;
            }
            if (islem != "=")
            {


                lblSonuc.Text = "0";
                Sayı = "0";
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Sayı.Length != 1)
                Sayı = Sayı.Remove(1, 1);
            else
                Sayı = "0";
            lblSonuc.Text = Sayı;
        }
        private void SayıDüzeltme(object sender, EventArgs e)
        {
            Guna2CircleButton but = (Guna2CircleButton)sender;
            if (but.Text == "x²")
            {
                lblEkSonuc.Visible = true;
                if (sonuc == 0)
                    lblEkSonuc.Text = $"sqr({Sayı})";
                else
                    lblEkSonuc.Text += $" sqr({Sayı})";
                Sayı = (Convert.ToDouble(Sayı) * Convert.ToDouble(Sayı)).ToString();
            }
            else if (but.Text == "²√x")
            {
                lblEkSonuc.Visible = true;
                if (sonuc == 0)
                    lblEkSonuc.Text = $"1√({Sayı})";
                else
                    lblEkSonuc.Text += $" 1√({Sayı})";
                Sayı = (Math.Sqrt(Convert.ToDouble(Sayı))).ToString();
            }
            else if (but.Text == "1/x")
            {
                lblEkSonuc.Visible = true;
                if (sonuc == 0)
                    lblEkSonuc.Text = $"1/({Sayı})";
                else
                    lblEkSonuc.Text += $" 1/({Sayı})";
                Sayı = (1 / Convert.ToDouble(Sayı)).ToString();
            }
            else if (but.Text == "CE")
            {
                Sayı = "0";
                if (btnCE2.Text == "C")
                    btnCE2.Text = "CE";
                else
                    btnCE2.Text = "C";
            }
            else if (but.Text == "C")
            {
                sonuc = 0;
                Sayı = "0";
                islem = "";
                lblSonuc.Text = "0";
                lblEkSonuc.Visible = false;
            }
            else if (but.Text == "+/-")
            {
                Sayı = (Convert.ToDouble(Sayı) * (-1)).ToString();
            }
            else if (but.Text == ",")
            {
                if (!Sayı.Contains(","))
                    Sayı = Sayı + ",";
            }
            else if (but.Text == "x³")
            {
                lblEkSonuc.Visible = true;
                if (sonuc == 0)
                    lblEkSonuc.Text = $"cube({Sayı})";
                else
                    lblEkSonuc.Text += $" cube({Sayı})";
                Sayı = (Convert.ToDouble(Sayı) * Convert.ToDouble(Sayı) * Convert.ToDouble(Sayı)).ToString();
            }
            else if (but.Text == "n!")
            {
                lblEkSonuc.Visible = true;
                lblEkSonuc.Text = $"foct({Sayı})";
                if (Sayı == "0")
                {
                    Sayı = "1";
                }
                else if (Convert.ToDouble(Sayı) < 0)
                {
                    Sayı = "0";
                }
                else
                {
                    double Sabit = Convert.ToDouble(Sayı);
                    for (int i = 1; i < Sabit; i++)
                    {
                        Sayı = (Convert.ToDouble(Sayı) * i).ToString();
                    }
                }
            }
            else if (but.Text == "log")
            {
                Sayı = (Math.Log10(Convert.ToDouble(Sayı))).ToString();
            }
            else if (but.Text == "10ˣ")
            {
                Sayı = (Math.Pow(10, Convert.ToDouble(Sayı))).ToString();
            }
            else if (but.Text == "|x|")
            {
                Sayı = (Math.Abs(Convert.ToDouble(Sayı))).ToString();
            }
            else if (but.Text == "1/x²")
            {
                Sayı = (Convert.ToDouble(Sayı) * Convert.ToDouble(Sayı)).ToString();
                lblEkSonuc.Visible = true;
                if (sonuc == 0)
                    lblEkSonuc.Text = $"1/({Sayı})";
                else
                    lblEkSonuc.Text += $" 1/({Sayı})";
                Sayı = (1 / Convert.ToDouble(Sayı)).ToString();
            }
            else if (but.Text == "sin")
            {
                Sayı = ((Math.Sin(Convert.ToDouble(Sayı)))).ToString();
                btnSin.Visible = false;
                btnCos.Visible = false;
                btnTan.Visible = false;
                btnCot.Visible = false;
            }
            else if (but.Text == "cos")
            {
                Sayı = ((Math.Cos(Convert.ToDouble(Sayı)))).ToString();
                btnSin.Visible = false;
                btnCos.Visible = false;
                btnTan.Visible = false;
                btnCot.Visible = false;
            }
            else if (but.Text == "tan")
            {
                Sayı = ((Math.Tan(Convert.ToDouble(Sayı)))).ToString();
                btnSin.Visible = false;
                btnCos.Visible = false;
                btnTan.Visible = false;
                btnCot.Visible = false;
            }
            else if (but.Text == "cot")
            {
                Sayı = (1 / (Math.Tan(Convert.ToDouble(Sayı)))).ToString();
                btnSin.Visible = false;
                btnCos.Visible = false;
                btnTan.Visible = false;
                btnCot.Visible = false;
            }
            else if (but.Text == "In")
            {
                Sayı = ((Math.Log(Convert.ToDouble(Sayı)))).ToString();
            }
            lblSonuc.Text = Sayı;

        }

        private void btnTema_Click(object sender, EventArgs e)
        {
            TemaDB.Default.TemaBool = !TemaDB.Default.TemaBool;
            TemaDB.Default.Save();
            if (this.BackColor == Color.FromArgb(200, 200, 200))
            {
                this.BackColor = Color.FromArgb(20, 20, 20);
                foreach (Guna2CircleButton n in guna2Panel1.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(10, 10, 10);
                    }
                }
                foreach (Guna2CircleButton n in guna2Panel2.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(10, 10, 10);
                    }
                }
                lblSonuc.ForeColor = Color.White;
                btnSayısal.Image = Properties.Resources.pngegg2;
                btnTema.Image = Properties.Resources.BeyazTema;
                btnKayıt.Image = Properties.Resources.BeyazKayıt;
            }
            else
            {
                this.BackColor = Color.FromArgb(200, 200, 200);
                foreach (Guna2CircleButton n in guna2Panel1.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(100, 100, 100);
                    }
                }
                foreach (Guna2CircleButton n in guna2Panel2.Controls)
                {
                    if (n.Tag == "btnRakam")
                    {
                        n.FillColor = Color.FromArgb(100, 100, 100);
                    }
                }
                lblSonuc.ForeColor = Color.Black;
                btnSayısal.Image = Properties.Resources.pngegg;
                btnTema.Image = Properties.Resources.SiyahTema;
                btnKayıt.Image = Properties.Resources.GriKayıt;
            }
        }
        bool SayısalMı = false;
        private void btnSayısal_Click(object sender, EventArgs e)
        {
            if (SayısalMı)
            {
                guna2Panel1.Visible = true;
                guna2Panel2.Visible = false;
                SayısalMı = false;
            }
            else
            {
                btnSin.Location = new Point(45, 49);
                btnCos.Location = new Point(104, 49);
                btnTan.Location = new Point(164, 49);
                btnCot.Location = new Point(224, 49);
                btnCE2.Text = "CE";
                guna2Panel1.Visible = false;
                guna2Panel2.Visible = true;
                SayısalMı = true;
            }
        }
        bool Exp = true;
        private void btnexp_Click(object sender, EventArgs e)
        {
            if (Exp)
            {
                Exp = false;
                sonuc = Convert.ToDouble(Sayı);
                lblSonuc.Text = $"{Sayı}e+0";
                Sayı = "0";
            }
        }

        private void btnTrigonometri_Click(object sender, EventArgs e)
        {
            if (!btnSin.Visible)
            {
                btnSin.Visible = true;
                btnCos.Visible = true;
                btnTan.Visible = true;
                btnCot.Visible = true;
            }
            else
            {
                btnSin.Visible = false;
                btnCos.Visible = false;
                btnTan.Visible = false;
                btnCot.Visible = false;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnSıfır.FillColor = Color.FromArgb(31, 31, 31);
                    btnZero.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnZero.FillColor = Color.FromArgb(86, 86, 86);
                    btnSıfır.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("0");

            }
            if (e.KeyCode == Keys.D1)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnOne.FillColor = Color.FromArgb(31, 31, 31);
                    btnBir.FillColor = Color.FromArgb(31, 31, 31);

                }
                else
                {
                    btnOne.FillColor = Color.FromArgb(86, 86, 86);
                    btnBir.FillColor = Color.FromArgb(86, 86, 86);

                }
                Numaralar("1");
            }
            if (e.KeyCode == Keys.D2)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnTow.FillColor = Color.FromArgb(31, 31, 31);
                    btnİki.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnTow.FillColor = Color.FromArgb(86, 86, 86);
                    btnİki.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("2");
            }
            if (e.KeyCode == Keys.D3)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnThree.FillColor = Color.FromArgb(31, 31, 31);
                    btnUc.FillColor = Color.FromArgb(31, 31, 31);

                }
                else
                {
                    btnThree.FillColor = Color.FromArgb(86, 86, 86);
                    btnUc.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("3");

            }
            if (e.KeyCode == Keys.D4)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnFour.FillColor = Color.FromArgb(31, 31, 31);
                    btnDort.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnFour.FillColor = Color.FromArgb(86, 86, 86);
                    btnDort.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("4");
            }
            if (e.KeyCode == Keys.D5)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnFive.FillColor = Color.FromArgb(31, 31, 31);
                    btnBes.FillColor = Color.FromArgb(31, 31, 31);

                }
                else
                {
                    btnFive.FillColor = Color.FromArgb(86, 86, 86);
                    btnBes.FillColor = Color.FromArgb(86, 86, 86);

                }
                Numaralar("5");
            }
            if (e.KeyCode == Keys.D6)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnSix.FillColor = Color.FromArgb(31, 31, 31);
                    btnAlti.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnSix.FillColor = Color.FromArgb(86, 86, 86);
                    btnAlti.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("6");
            }
            if (e.KeyCode == Keys.D7)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnSeven.FillColor = Color.FromArgb(31, 31, 31);
                    btnYedi.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnSeven.FillColor = Color.FromArgb(86, 86, 86);
                    btnYedi.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("7");
            }
            if (e.KeyCode == Keys.D8)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnEight.FillColor = Color.FromArgb(31, 31, 31);
                    btnSekiz.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnEight.FillColor = Color.FromArgb(86, 86, 86);
                    btnSekiz.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("8");
            }
            if (e.KeyCode == Keys.D9)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnNine.FillColor = Color.FromArgb(31, 31, 31);
                    btnDokuz.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnNine.FillColor = Color.FromArgb(86, 86, 86);
                    btnDokuz.FillColor = Color.FromArgb(86, 86, 86);
                }
                Numaralar("9");
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (TemaDB.Default.TemaBool)
                {
                    btnDelete.FillColor = Color.FromArgb(31, 31, 31);
                    btnSil.FillColor = Color.FromArgb(31, 31, 31);
                }
                else
                {
                    btnDelete.FillColor = Color.FromArgb(86, 86, 86);
                    btnSil.FillColor = Color.FromArgb(86, 86, 86);
                }
                if (Sayı.Length != 1)
                    Sayı = Sayı.Remove(1, 1);
                else
                    Sayı = "0";
                lblSonuc.Text = Sayı;
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TemaDB.Default.TemaBool)
            {

                if (SayısalMı)
                {
                    btnZero.FillColor = Color.FromArgb(10, 10, 10);
                    btnOne.FillColor = Color.FromArgb(10, 10, 10);
                    btnTow.FillColor = Color.FromArgb(10, 10, 10);
                    btnThree.FillColor = Color.FromArgb(10, 10, 10);
                    btnFour.FillColor = Color.FromArgb(10, 10, 10);
                    btnFive.FillColor = Color.FromArgb(10, 10, 10);
                    btnSix.FillColor = Color.FromArgb(10, 10, 10);
                    btnSeven.FillColor = Color.FromArgb(10, 10, 10);
                    btnEight.FillColor = Color.FromArgb(10, 10, 10);
                    btnNine.FillColor = Color.FromArgb(10, 10, 10);
                    btnDelete.FillColor = Color.FromArgb(10, 10, 10);
                }
                else
                {
                    btnSıfır.FillColor = Color.FromArgb(10, 10, 10);
                    btnBir.FillColor = Color.FromArgb(10, 10, 10);
                    btnİki.FillColor = Color.FromArgb(10, 10, 10);
                    btnUc.FillColor = Color.FromArgb(10, 10, 10);
                    btnDort.FillColor = Color.FromArgb(10, 10, 10);
                    btnBes.FillColor = Color.FromArgb(10, 10, 10);
                    btnAlti.FillColor = Color.FromArgb(10, 10, 10);
                    btnYedi.FillColor = Color.FromArgb(10, 10, 10);
                    btnSekiz.FillColor = Color.FromArgb(10, 10, 10);
                    btnDokuz.FillColor = Color.FromArgb(10, 10, 10);
                    btnSil.FillColor = Color.FromArgb(10, 10, 10);
                }
            }
            else
            {
                if (SayısalMı)
                {
                    btnZero.FillColor = Color.FromArgb(100, 100, 100);
                    btnOne.FillColor = Color.FromArgb(100, 100, 100);
                    btnTow.FillColor = Color.FromArgb(100, 100, 100);
                    btnThree.FillColor = Color.FromArgb(100, 100, 100);
                    btnFour.FillColor = Color.FromArgb(100, 100, 100);
                    btnFive.FillColor = Color.FromArgb(100, 100, 100);
                    btnSix.FillColor = Color.FromArgb(100, 100, 100);
                    btnSeven.FillColor = Color.FromArgb(100, 100, 100);
                    btnEight.FillColor = Color.FromArgb(100, 100, 100);
                    btnNine.FillColor = Color.FromArgb(100, 100, 100);
                    btnDelete.FillColor = Color.FromArgb(100, 100, 100);
                }
                else
                {
                    btnSıfır.FillColor = Color.FromArgb(100, 100, 100);
                    btnBir.FillColor = Color.FromArgb(100, 100, 100);
                    btnİki.FillColor = Color.FromArgb(100, 100, 100);
                    btnUc.FillColor = Color.FromArgb(100, 100, 100);
                    btnDort.FillColor = Color.FromArgb(100, 100, 100);
                    btnBes.FillColor = Color.FromArgb(100, 100, 100);
                    btnAlti.FillColor = Color.FromArgb(100, 100, 100);
                    btnYedi.FillColor = Color.FromArgb(100, 100, 100);
                    btnSekiz.FillColor = Color.FromArgb(100, 100, 100);
                    btnDokuz.FillColor = Color.FromArgb(100, 100, 100);
                    btnSil.FillColor = Color.FromArgb(100, 100, 100);
                }
            }
        }

        
        bool kayıtGosterildi = false;
        private void btnKayıt_Click(object sender, EventArgs e)
        {
            //guna2Panel1.Visible = false;
            //guna2Panel2.Visible = false;
            //flowLayoutPanel1.Visible = true;
            kayıtGosterildi = !kayıtGosterildi;
            if (kayıtGosterildi)
            {
                guna2Transition1.ShowSync(flowLayoutPanel1);
                for (int i = Ekler.Count -1; i >= 0; i--)
                {
                    Label lblEkKayıt = new Label();
                    lblEkKayıt.ForeColor = lblEkSonuc.ForeColor;
                    lblEkKayıt.Size = lblSonuc.Size;
                    lblEkKayıt.Font = new Font("Segoe UI", 20);
                    lblEkKayıt.BackColor = lblEkSonuc.BackColor;
                    lblEkKayıt.TextAlign = ContentAlignment.TopRight;
                    lblEkKayıt.Text = Ekler[i];
                    flowLayoutPanel1.Controls.Add(lblEkKayıt);
                    Label lbl = new Label();
                    lbl.ForeColor = lblSonuc.ForeColor;
                    lbl.Text = Sonuçlar[i];
                    lbl.TextAlign = ContentAlignment.TopRight;
                    lbl.Font = lblSonuc.Font;
                    lbl.Size = lblSonuc.Size;
                    flowLayoutPanel1.Controls.Add(lbl);
                }
            }
            else
            {
                guna2Transition1.HideSync(flowLayoutPanel1);
                flowLayoutPanel1.Controls.Clear();
            }
        }
    }
}
