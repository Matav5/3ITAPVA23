using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITALode
{
    public partial class Menu : Form
    {
        TcpListener host;
        public Menu()
        {
            InitializeComponent();
        }

        private void offlineBtn_Click(object sender, EventArgs e)
        {
            //Spustím hru se jmény hráčů
        }

        private async void onlineBtn_Click(object sender, EventArgs e)
        {
            if (hostCheckBox.Checked)
            {
                //Spustit hru jako Host
                await Server();
            }
            else
            {
                //Spustit hru jako Klient
                await Klient();
            }

        }

        private async Task Server()
        {
            host = new TcpListener(10666);
            host.Start();
            //Budu čekat na připojení
            TcpClient client = await host.AcceptTcpClientAsync();


            NetworkStream stream = client.GetStream();
            //Zapíšu do spojení Název hráče pro klienta (Oponent získá moje jméno)
            StreamWriter streamWriter = new StreamWriter(stream) { AutoFlush = true };
            streamWriter.WriteLine(textBox1.Text);

            //Čekám a snažím se získat jméno od klienta (Já získávám oponentovo jméno)
            StreamReader streamReader = new StreamReader(stream);

            string oponentovoJmeno = await streamReader.ReadLineAsync();

            //Čtení zpráv
            MessageBox.Show(oponentovoJmeno, "Jméno přijato!");

            //Odesílání simulace kliků
            Form1 hra = new Form1(textBox1.Text, oponentovoJmeno, stream);
            this.Hide();
            hra.ShowDialog();
            this.Show();
        }

        private async Task Klient()
        {
            //Zkusím připojit na hosta za pomocí IP adresy => localhost
            TcpClient tcpClient = new TcpClient(textBox3.Text, 10666);
            NetworkStream stream = tcpClient.GetStream();


            StreamReader streamReader = new StreamReader(stream);
            StreamWriter streamWriter = new StreamWriter(stream) { AutoFlush = true };

            while (true)
            {

                //Čekám na zprávu
                string zprava = await streamReader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(zprava))
                    continue;
                //Jakmile zpráva přijde jméno výpíšu
                MessageBox.Show(zprava, "Jméno přijato!");

                //Pošlu svoje jméno oponentovi
                await streamWriter.WriteLineAsync(textBox1.Text);

                //Spustím hru
                Form1 hra = new Form1(textBox1.Text, zprava, stream);
                this.Hide();
                hra.ShowDialog();
                this.Show();
            }
        }

        private void hostCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
