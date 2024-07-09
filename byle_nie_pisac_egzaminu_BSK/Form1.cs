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
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;

namespace byle_nie_pisac_egzaminu_BSK
{
    public partial class Form1 : Form
    {
        private TcpClient klient;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string TextToSend;


        private System.Security.Cryptography.Aes aes = null;
        private ECDiffieHellmanCng diffieHellman = null;
        private byte[] publicKey;

        private byte[] anotherKey;

        public Form1()
        {
            InitializeComponent();

            aes = new AesCryptoServiceProvider();
            aes.KeySize = 256;
            diffieHellman = new ECDiffieHellmanCng
            {
                KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                HashAlgorithm = CngAlgorithm.Sha256
            };
            diffieHellman.KeySize = 256;

            publicKey = diffieHellman.PublicKey.ToByteArray();
            //Debug.WriteLine(aes.IV.Length);


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

            Thread.Sleep(200);
            STW.WriteLine("$key=" + Convert.ToBase64String(publicKey));
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

                Thread.Sleep(200);
                STW.WriteLine("$key=" + Convert.ToBase64String(publicKey));
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
                    if (receive.Substring(0,5) == "$key=")
                    {
                        receive = receive.Substring(5);
                        
                        anotherKey = Convert.FromBase64String(receive);

                        this.MESSAGEBOX.Invoke(new MethodInvoker(delegate ()
                        {
                            MESSAGEBOX.AppendText("Otrzymany klucz: " + receive + "\n");
                            MESSAGEBOX.AppendText("Mój klucz: " + Convert.ToBase64String(publicKey) + "\n");
                        }));

                        receive = "";
                    }
                    else
                    {
                        byte[] iv = Convert.FromBase64String(receive.Substring(0, 24));
                        byte[] msg = Convert.FromBase64String(receive.Substring(24));
                        string decoded = Security.Decrypt(aes, diffieHellman, anotherKey, msg, iv);
                        this.MESSAGEBOX.Invoke(new MethodInvoker(delegate ()
                        {
                            MESSAGEBOX.AppendText("Byt: " + decoded + "\n");
                        }));
                        receive = "";
                    }
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
                byte[] encrypted = Security.Encrypt(aes, diffieHellman, anotherKey, TextToSend);
                string ivtext = Convert.ToBase64String(aes.IV);
                string tosend = Convert.ToBase64String(encrypted);
                STW.WriteLine(ivtext + tosend);


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
