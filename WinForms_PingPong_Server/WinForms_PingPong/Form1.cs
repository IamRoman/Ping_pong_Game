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
    public partial class Form_PingPong : Form
    {
        SettingsForm2 form2 = null;

        int speedLeft = 4;
        int speedTop = 4;
        int pointPlayer1 = 0;
        int pointPlayer2 = 0;

        Socket sck;
        EndPoint epLocal, epRemote;
        internal string Form1_IPClient_1 = null, Form1_IPClient_2 = null;
        internal string Form1_PortClient_1 = null, Form1_PortClient_2 = null;

        bool flagGame = false;
        bool flagContinue = false;
        bool flagNewGamePlayer1 = false;
        bool flagNewGamePlayer2 = false;
        bool flagCreateServer = false;
        bool flagSendReady = false;

        public Form_PingPong()
        {
            InitializeComponent();

            //Cursor.Hide(); //Скрыть курсор
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //убрать рамку
            //this.Bounds = Screen.PrimaryScreen.Bounds; //форму на передний план

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

                    if (parse[0] == "ready")
                    {
                        if (!flagSendReady)
                        {
                            GameOver.Text = "";

                            Action action = () => timer1.Enabled = true;
                            if (InvokeRequired)
                                Invoke(action);
                            else
                                action();

                            flagGame = true;
                            Information_lbl.Visible = false;
                            flagContinue = true;
                            flagSendReady = true;
                        }
                    }

                    if (parse[0] == "disconnected")
                    {
                            flagGame = false;
                            MessageBox.Show("Ваш противник покинул игру\r\nВам ничего не остается как тоже выйти из игры.", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            this.Close();
                    }

                    if (parse[0] == "newGame")
                    {
                        if(parse[1] == "0")
                            GameOver.Text = "Ваш противник отказался играть";
                        else if (parse[1] == "1")
                        {
                            flagNewGamePlayer1 = true;
                            if (flagNewGamePlayer2 && flagNewGamePlayer1)
                            {
                                ball.Top = 50;
                                ball.Left = 50;
                                speedLeft = 4;
                                speedTop = 4;
                                pointPlayer1 = 0;
                                pointPlayer2 = 0;
                                pointPlayer1_lbl.Text = "0";
                                pointPlayer2_lbl.Text = "0";
                                GameOver.Text = "";

                                Action action = () => timer1.Enabled = true;
                                if (InvokeRequired)
                                    Invoke(action);
                                else
                                    action();

                                flagGame = true;
                                Information_lbl.Visible = false;
                                flagNewGamePlayer1 = false;
                                flagNewGamePlayer2 = false;
                            }
                        }

                    }

                    if (parse[0] == "chat")
                    {
                        if (!flagGame && form2 != null)
                        {
                            GameOver.Text = Player1.Text + " открыл чат";
                        }
                    }

                    if (parse[0] == "racketPlayer1")
                    {
                        racketPlayer1.Top = Convert.ToInt32(parse[1]);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //rocket.Left = Cursor.Position.X - (rocket.Width / 2);

            ball.Left += speedLeft;
            ball.Top += speedTop;

            pointPlayer1_lbl.Text = pointPlayer1.ToString();
            pointPlayer2_lbl.Text = pointPlayer2.ToString();
            Send("ball", ball.Top, ball.Left);
            Send("point", pointPlayer1, pointPlayer2);


            if (ball.Right >= racketPlayer2.Left && ball.Right <= racketPlayer2.Right && ball.Bottom <= racketPlayer2.Bottom && ball.Bottom >= racketPlayer2.Top)
            {
                speedTop += 1;
                speedLeft += 1;
                speedLeft = -speedLeft;
                pointPlayer2++;
            }

            else if (ball.Left <= racketPlayer1.Right && ball.Left >= racketPlayer1.Left && ball.Bottom <= racketPlayer1.Bottom && ball.Bottom >= racketPlayer1.Top)
            {
                //speedTop += 1;
                //speedLeft += 1;
                speedLeft = -speedLeft;
                pointPlayer1++;
            }

            if (ball.Left <= playGraund.Left)
            {
                timer1.Enabled = false;
                flagGame = false;
                Information_lbl.Visible = true;
                flagContinue = false;
                GameOver.Text = "      Выиграл  " + Player2.Text;
                GameOver.Text += "\r\nеще играем? Y - да N - нет";
                Send("winPlayer2", 0, 0);
            }

            if (ball.Right >= playGraund.Right)
            {
                timer1.Enabled = false;
                flagGame = false;
                Information_lbl.Visible = true;
                flagContinue = false;
                GameOver.Text = "      Выиграл  " + Player1.Text;
                GameOver.Text += "\r\nеще играем? Y - да N - нет";
                Send("winPlayer1", 0, 0);
            }

            if (ball.Top <= playGraund.Top)
            {
                speedTop = -speedTop;
            }

            if (ball.Bottom >= playGraund.Bottom)
            {
                speedTop = -speedTop;
            }
        }

        private void Form_PingPong_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.F1)
                {
                    if (!flagCreateServer)
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

                                ball.Top = 50;
                                ball.Left = 50;
                                speedLeft = 4;
                                speedTop = 4;
                                pointPlayer1 = 0;
                                pointPlayer2 = 0;
                                pointPlayer1_lbl.Text = "0";
                                pointPlayer2_lbl.Text = "0";
                                GameOver.Text = "Ожидаем противника...";
                            }
                        };
                        flagCreateServer = true;
                    }
                    else if (flagCreateServer)
                    {
                        MessageBox.Show("Вы уже создали сервер!\r\nОжидайте начала игры!", "", MessageBoxButtons.OK);
                    }
                }
            
            if (e.KeyCode == Keys.F2)
            {
                
            }

            if (!flagGame)
            {
                if (e.KeyCode == Keys.Y)
                {
                    flagNewGamePlayer2 = true;
                    GameOver.Text = "";
                    if (flagNewGamePlayer2 && flagNewGamePlayer1)
                    {
                        Send("newGame", 1, 1);
                        ball.Top = 50;
                        ball.Left = 50;
                        speedLeft = 4;
                        speedTop = 4;
                        pointPlayer1 = 0;
                        pointPlayer2 = 0;
                        pointPlayer1_lbl.Text = "0";
                        pointPlayer2_lbl.Text = "0";
                        GameOver.Text = "";

                        timer1.Enabled = true;
                        flagGame = true;
                        Information_lbl.Visible = false;
                        flagNewGamePlayer1 = false;
                        flagNewGamePlayer2 = false;
                    }
                }
                if (e.KeyCode == Keys.N)
                {
                    Send("newGame", 0, 0);
                }
            }

            if (e.KeyCode == Keys.F4)
            {
                Information_lbl.Visible = true;
                timer1.Enabled = false;
                flagGame = false;
            }

            if (!flagGame && form2 != null)
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
                if (e.KeyCode == Keys.Up)
                {
                    if (racketPlayer2.Top > 0)
                    {
                        racketPlayer2.Top -= 7;
                        Send("racketPlayer2", racketPlayer2.Top, racketPlayer2.Left);
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (racketPlayer2.Bottom < playGraund.Bottom)
                    {
                        racketPlayer2.Top += 7;
                        Send("racketPlayer2", racketPlayer2.Top, racketPlayer2.Left);
                    }
                }
                //--------------------------Player1----------------------//
                /*if (e.KeyCode == Keys.A)
                    racketPlayer1.Top -= 7;
                if (e.KeyCode == Keys.Z)
                    racketPlayer1.Top += 7;*/
            }
        }

        private void Form_PingPong_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send("disconnected", 0, 0);
        }

        private void Form_PingPong_SizeChanged(object sender, EventArgs e)
        {
            allocationOfElements();
        }
    }
}
