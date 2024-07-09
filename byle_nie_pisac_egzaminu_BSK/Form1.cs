using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace byle_nie_pisac_egzaminu_BSK
{
    public partial class Form1 : Form
    {
        private TcpClient klient;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string TextToSend;
        public Form1()
        {
            InitializeComponent();
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress adres in localIP)
            {
                if (adres.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPSERVERBOX.Text = adres.ToString();
                }
            }
        }

        private void BUTONSTART_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(PORTSERVERBOX.Text));
            listener.Start();
            klient = listener.AcceptTcpClient();
            STR = new StreamReader(klient.GetStream());
            STW = new StreamWriter(klient.GetStream());
            STW.AutoFlush = true;
            backgroundWorker3.RunWorkerAsync();
            backgroundWorker4.WorkerSupportsCancellation = true;
        }

        private void BUTONCONNECT_Click(object sender, EventArgs e)
        {
            klient = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(IPKLIENTBOX.Text), int.Parse(PORTKLIENTBOX.Text));
            klient.Connect(IpEnd);
            try
            {
                MESSAGEBOX.AppendText("Polaczono z Serwerem" + "\n");
                STW = new StreamWriter(klient.GetStream());
                STR = new StreamReader(klient.GetStream());
                STW.AutoFlush = true;
                backgroundWorker3.RunWorkerAsync();
                backgroundWorker4.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            while (klient.Connected)
            {
                try
                {
                    receive=STR.ReadLine();
                    this.MESSAGEBOX.Invoke(new MethodInvoker(delegate ()
                    {
                        MESSAGEBOX.AppendText("Byt: " + receive + "\n");
                    }));
                    receive = "";
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            if (klient.Connected)
            {
                STW.WriteLine(TextToSend);
                this.MESSAGEBOX.Invoke(new MethodInvoker(delegate ()
                {
                    MESSAGEBOX.AppendText("Ja: " + TextToSend + "\n");
                }));
            }
            else
            {
                MessageBox.Show("Wyslanie wiadomosci nie udalo sie");
            }

            backgroundWorker4.CancelAsync();
        }

        private void BUTONSEND_Click(object sender, EventArgs e)
        {
            if (SENDBOX.Text !="")
            {
                TextToSend =SENDBOX.Text;
                backgroundWorker4.RunWorkerAsync();
            }
            SENDBOX.Text = "";
        }
    }
}
