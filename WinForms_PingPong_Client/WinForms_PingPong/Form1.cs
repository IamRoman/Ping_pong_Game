using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;

using System.Net;
using System.Net.Sockets;

namespace WinForms_PingPong
{
    public partial class Form_PingPong_Client : Form
    {
        SettingsForm2 form2 = null;

        Socket sck;
        EndPoint epLocal, epRemote;
        internal string Form1_IPClient_1 = null, Form1_IPClient_2 = null;
        internal string Form1_PortClient_1 = null, Form1_PortClient_2 = null;

        bool flagGame = false;
        bool flagCreateConnect = false;
        bool flagSendReady = false;

        public Form_PingPong_Client()
        {
            InitializeComponent();

            //Cursor.Hide();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Bounds = Screen.PrimaryScreen.Bounds;

            int w = (int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width / 1.5); // ширина окна            
            int h = (int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height / 1.5); // высота окна
            this.Size = new System.Drawing.Size(w, h);

            allocationOfElements();
            
        }

        private void InitializeSocket()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            Form1_PortClient_1 = (Convert.ToInt32(Form1_PortClient_1) + 10).ToString();
            Form1_PortClient_2 = (Convert.ToInt32(Form1_PortClient_2) + 10).ToString();

            Connect(); //Подключение приложения!!!!!!!!!!!!!!!
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

                    string[] parse;
                    parse = receivedMessage.Split('/');

                    if (parse[0] == "ball")
                    {
                        ball.Top = Convert.ToInt32(parse[1]);
                        ball.Left = Convert.ToInt32(parse[2]);
                    }

                    if (parse[0] == "winPlayer1")
                    {
                        GameOver.Text = "      Выиграл  " + Player1.Text;
                        GameOver.Text += "\r\nеще играем? Y - да N - нет";
                        Information_lbl.Visible = true;
                        flagGame = false;
                    }

                    if (parse[0] == "winPlayer2")
                    {
                        GameOver.Text = "      Выиграл  " + Player2.Text;
                        GameOver.Text += "\r\nеще играем? Y - да N - нет";
                        Information_lbl.Visible = true;
                        flagGame = false;
                    }

                    if (parse[0] == "point")
                    {
                        pointPlayer1_lbl.Text = parse[1].ToString();
                        pointPlayer2_lbl.Text = parse[2].ToString();
                    }

                    if (parse[0] == "disconnected")
                    {
                        flagGame = false;
                         MessageBox.Show("Ваш противник покинул игру\r\nВам ничего не остается как тоже выйти из игры.", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                         this.Close();
                    }

                    if (parse[0] == "newGame")
                    {
                        if (parse[1] == "0")
                            GameOver.Text = "Ваш противник отказался играть";
                        if (parse[1] == "1")
                            GameOver.Text = "";
                    }

                    if (parse[0] == "chat")
                    {
                        if (!flagGame && form2 != null)
                        {
                            GameOver.Text = Player2.Text + " открыл чат";
                        }
                    }

                    if (parse[0] == "racketPlayer2")
                    {
                        racketPlayer2.Top = Convert.ToInt32(parse[1]);
                    }
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

        private void Connect()
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(Form1_IPClient_1), Convert.ToInt32(Form1_PortClient_1));
                sck.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(Form1_IPClient_2), Convert.ToInt32(Form1_PortClient_2));
                sck.Connect(epRemote);

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Проблема с подключением, проверте: \r\n - верно ли внесены сетевые настройки игры;\r\n - отсутствует сетевое подключение;\r\n - Ваш противник покинул игру или неуспел подключится.", "Oшибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void Send(string what, int Top, int Left)
        {
            try
            {
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(what + "/" + Top.ToString() + "/" + Left.ToString());

                sck.Send(msg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Проверте: \r\n - верно ли внесены сетевые настройки игры;\r\n - отсутствует сетевое подключение;\r\n - Ваш противник покинул игру или неуспел подключится.", "Oшибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void allocationOfElements()
        {
            racketPlayer2.Left = playGraund.Right - (playGraund.Right / 35); //позиция ракетки Игрока №2
            racketPlayer1.Left = 5; //позиция ракетки Игрока №1

            pointPlayer1_lbl.Left = playGraund.Width / 2 - pointPlayer1_lbl.Width * 2; //очки игрок1
            pointPlayer2_lbl.Left = playGraund.Width / 2 + pointPlayer2_lbl.Width; //очки игрок2

            Information_lbl.Top = playGraund.Height / 2; //Information menu
            Information_lbl.Left = (playGraund.Width / 2) - (Information_lbl.Width / 2);

            Player1.Left = 5; Player1.Top = 5;
            Player2.Left = playGraund.Right - (playGraund.Right / 15); Player2.Top = 5;

            GameOver.Top = playGraund.Height - GameOver.Height * 2; //Information menu
            GameOver.Left = (playGraund.Width / 2) - (Information_lbl.Width / 2);
        }

        private void Form_PingPong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) //есть глюк
            {
                    Send("ready", 0, 0);
                    if (!flagSendReady)
                    {
                        flagGame = true;
                        Information_lbl.Visible = false;
                        flagSendReady = true;
                    }
                    else if (flagSendReady)
                    {
                        MessageBox.Show("Игра запущена", "", MessageBoxButtons.OK);
                    }
            }

            if (e.KeyCode == Keys.F2)
            {
                if (!flagCreateConnect)
                {
                    form2 = new SettingsForm2(this);
                    form2.Show();
                    form2.TopMost = true;

                    form2.FormClosing += (obj, arg) =>
                    {
                        this.TopMost = true; //форму на передний план
                        if (Form1_IPClient_1 != null && Form1_IPClient_2 != null && Form1_PortClient_1 != null && Form1_PortClient_2 != null)
                        {
                            InitializeSocket();
                        }
                    };
                    flagCreateConnect = true;
                }
                else if (flagCreateConnect)
                {
                    MessageBox.Show("Вы уже дали команду на подключение к серверу", "", MessageBoxButtons.OK);
                }
            }

            if (!flagGame)
            {
                if (e.KeyCode == Keys.Y)
                {
                    Send("newGame", 1, 1);
                    GameOver.Text = "";
                    Information_lbl.Visible = false;
                    flagGame = true;
                }
                if (e.KeyCode == Keys.N)
                {
                    Send("newGame", 0, 0);
                    GameOver.Text = "";
                    Information_lbl.Visible = true;
                }
            }

            if (!flagGame && form2!=null)
            {
                if (e.KeyCode == Keys.F5)
                {
                    Send("chat", 0, 0);
                    ((Control)form2.tabPage1).Enabled = false;
                    form2.tabControlSettings.SelectedTab = form2.tabPage2;
                    form2.Show();
                    form2.TopMost = true;
                    form2.FormClosing += (obj, arg) =>
                    {
                        GameOver.Text = "\r\nеще играем? Y - да N - нет";
                    };
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Вы уверены, что хотите выйти из игры?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (flagGame)
            {
                //--------------------------Player2----------------------//
                /*if (e.KeyCode == Keys.Up)
                {
                    racketPlayer2.Top -= 7;
                    Send("racketPlayer2", racketPlayer2.Top, racketPlayer2.Left);
                }
                if (e.KeyCode == Keys.Down)
                {
                    racketPlayer2.Top += 7;
                    Send("racketPlayer2", racketPlayer2.Top, racketPlayer2.Left);
                }*/
                //--------------------------Player1----------------------//
                if (e.KeyCode == Keys.A)
                {
                    if (racketPlayer1.Top > 0)
                    {
                        racketPlayer1.Top -= 7;
                        Send("racketPlayer1", racketPlayer1.Top, racketPlayer1.Left);
                    }
                }
                if (e.KeyCode == Keys.Z)
                {
                    if (racketPlayer1.Bottom < playGraund.Bottom)
                    {
                        racketPlayer1.Top += 7;
                        Send("racketPlayer1", racketPlayer1.Top, racketPlayer1.Left);
                    }
                }
            }
        }

        private void Form_PingPong_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send("disconnected", 0, 0);
        }

        private void Form_PingPong_Client_SizeChanged(object sender, EventArgs e)
        {
            allocationOfElements();
        }
    }
}
