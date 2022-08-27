﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace case1
{
    public partial class Form1 : Form
    {
        private string Alphabet = "ABCDEFGHĞIİJKLMOÖPRŞTUÜVYZ".ToLower();
        private bool isOnProgress = false;
        private int inputInteger=0;

        public bool stopRequested { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                inputInteger = 0;
                bool isInteger = int.TryParse(txt_Input.Text, out inputInteger);
                if (isInteger)
                {
                    lblStatus.Text = "Working";
                    stopRequested = false;
                    timer1.Interval = 3000;
                    txt_Input.Enabled = false;
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Lütfen bir rakam giriniz.");
                    
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            isOnProgress = true;
                lblStatus.Text = "Working";
               
                var randomData = "";
                var random = new Random();
                for (int i = 0; i < inputInteger; i++)
                {
                    randomData += Alphabet[random.Next(Alphabet.Length)];
                    if (i == 0)
                        randomData = randomData.ToUpper();
                }
                /*
                 Burada MsSqlServer yüklü olamdığı için veritabanına yazmamız gereken datayı sağ tarafda bir panele yazdım. Anlayışınız için teşekkür ederim. 
                 İşlemin ortasında yahut veritabanına yazma işlemi esnasında işlemin durudurulması durumunu kodumdan anlayacağınız üzere eğer işlem içerisindeyken stop istenilmişse işlemin bitişinden sonra bunu gerçekledim. --> stopRequested 
                 */
                panel1.Controls.Add(new Label() { Text=randomData,Name=Guid.NewGuid().ToString(),Location=new Point(0,panel1.Controls.Count*40) });
                isOnProgress = false;
                if (stopRequested)
                {
                    StopTimer();
                }

           
        }

        private void StopTimer()
        {
            timer1.Enabled = false;
            lblStatus.Text = "Stopped";
            txt_Input.Enabled = true;
            timer1.Stop();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "StopRequested";
            stopRequested = true;
            
        }
    }
}