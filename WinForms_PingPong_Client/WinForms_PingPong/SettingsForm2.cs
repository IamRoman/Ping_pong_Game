using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_PingPong
{
    public partial class SettingsForm2 : Form
    {
        Form_PingPong_Client form1 = null;

        Socket sck;
        EndPoint epLocal, epRemote;

        public SettingsForm2(Form_PingPong_Client Form1)
        {
            InitializeComponent();
            form1 = Form1;

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            IPClient_1.Text = GetLocalIP();
            IPClient_2.Text = GetLocalIP();

            Send.Enabled = false;
        }

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "127.0.0.1";
        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0)
                {
                    byte[] receivedData = new byte[1464];
                    receivedData = (byte[])aResult.AsyncState;
                    UTF8Encoding eEncoding = new UTF8Encoding();
                    string receivedMessage = eEncoding.GetString(receivedData); //декодирование байтов в строку

                    tbMessage.Text += NameClient_2.Text + ": " + receivedMessage;
                    tbMessage.Text += "\r\n";
                }

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Проверте: \r\n - верно ли внесены сетевые настройки игры;\r\n - отсутствует сетевое подключение;\r\n - Ваш противник покинул игру или неуспел подключится.", "Oшибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(IPClient_1.Text), Convert.ToInt32(PortClient_1.Text));
                sck.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(IPClient_2.Text), Convert.ToInt32(PortClient_2.Text));
                sck.Connect(epRemote);

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

                Connect.Enabled = false;
                Send.Enabled = true;
                Сondition.Text = "Подключено";
                tbSend.Focus();

                form1.Form1_IPClient_1 = IPClient_1.Text; form1.Form1_IPClient_2 = IPClient_2.Text;
                form1.Form1_PortClient_1 = PortClient_1.Text; form1.Form1_PortClient_2 = PortClient_2.Text;
                form1.Player1.Text = NameClient_1.Text; form1.Player2.Text = NameClient_2.Text;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Проблема с подключением, проверте: \r\n - верно ли внесены сетевые настройки игры;\r\n - отсутствует сетевое подключение;\r\n - Ваш противник покинул игру или неуспел подключится.", "Oшибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(tbSend.Text);

                sck.Send(msg);

                tbMessage.Text += NameClient_1.Text + ": " + tbSend.Text;
                tbMessage.Text += "\r\n";

                tbSend.Clear();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Проверте: \r\n - верно ли внесены сетевые настройки игры;\r\n - отсутствует сетевое подключение;\r\n - Ваш противник покинул игру или неуспел подключится.", "Oшибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void SettingsForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void IPClient_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 46 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;   //46 - символ "."; 48-57 цифры; 8 <-- 
        }

        private void IPClient_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 46 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;   //46 - символ "."; 48-57 цифры; 8 <-- 
        }

        private void PortClient_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;   // 48-57 цифры; 8 <-- 
        }

        private void PortClient_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;   // 48-57 цифры; 8 <-- 
        }
    }
}
