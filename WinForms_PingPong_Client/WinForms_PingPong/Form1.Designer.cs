namespace WinForms_PingPong
{
    partial class Form_PingPong_Client
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.playGraund = new System.Windows.Forms.Panel();
            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.GameOver = new System.Windows.Forms.Label();
            this.Information_lbl = new System.Windows.Forms.Label();
            this.racketPlayer1 = new System.Windows.Forms.PictureBox();
            this.pointPlayer2_lbl = new System.Windows.Forms.Label();
            this.pointPlayer1_lbl = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.racketPlayer2 = new System.Windows.Forms.PictureBox();
            this.playGraund.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.racketPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racketPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // playGraund
            // 
            this.playGraund.BackColor = System.Drawing.Color.LimeGreen;
            this.playGraund.Controls.Add(this.Player1);
            this.playGraund.Controls.Add(this.Player2);
            this.playGraund.Controls.Add(this.GameOver);
            this.playGraund.Controls.Add(this.Information_lbl);
            this.playGraund.Controls.Add(this.racketPlayer1);
            this.playGraund.Controls.Add(this.pointPlayer2_lbl);
            this.playGraund.Controls.Add(this.pointPlayer1_lbl);
            this.playGraund.Controls.Add(this.ball);
            this.playGraund.Controls.Add(this.racketPlayer2);
            this.playGraund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playGraund.Location = new System.Drawing.Point(0, 0);
            this.playGraund.Name = "playGraund";
            this.playGraund.Size = new System.Drawing.Size(596, 372);
            this.playGraund.TabIndex = 0;
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player1.Location = new System.Drawing.Point(4, 4);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(57, 16);
            this.Player1.TabIndex = 8;
            this.Player1.Text = "Player 1";
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player2.Location = new System.Drawing.Point(507, 4);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(57, 16);
            this.Player2.TabIndex = 7;
            this.Player2.Text = "Player 2";
            // 
            // GameOver
            // 
            this.GameOver.AutoSize = true;
            this.GameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameOver.Location = new System.Drawing.Point(191, 284);
            this.GameOver.Name = "GameOver";
            this.GameOver.Size = new System.Drawing.Size(0, 24);
            this.GameOver.TabIndex = 6;
            // 
            // Information_lbl
            // 
            this.Information_lbl.AutoSize = true;
            this.Information_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Information_lbl.Location = new System.Drawing.Point(193, 87);
            this.Information_lbl.Name = "Information_lbl";
            this.Information_lbl.Size = new System.Drawing.Size(229, 126);
            this.Information_lbl.TabIndex = 5;
            this.Information_lbl.Text = "              Game Ping Pong\r\n(управление: кнопки  <A>,  <Z>)\r\n\r\nF1   - Старт\r\nF2" +
    "   - Подключится к игре\r\nF5   - Чат\r\nEsc - Выход";
            this.Information_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // racketPlayer1
            // 
            this.racketPlayer1.BackColor = System.Drawing.Color.Blue;
            this.racketPlayer1.Location = new System.Drawing.Point(12, 87);
            this.racketPlayer1.Name = "racketPlayer1";
            this.racketPlayer1.Size = new System.Drawing.Size(20, 200);
            this.racketPlayer1.TabIndex = 4;
            this.racketPlayer1.TabStop = false;
            // 
            // pointPlayer2_lbl
            // 
            this.pointPlayer2_lbl.AutoSize = true;
            this.pointPlayer2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointPlayer2_lbl.Location = new System.Drawing.Point(311, 9);
            this.pointPlayer2_lbl.Name = "pointPlayer2_lbl";
            this.pointPlayer2_lbl.Size = new System.Drawing.Size(51, 55);
            this.pointPlayer2_lbl.TabIndex = 3;
            this.pointPlayer2_lbl.Text = "0";
            // 
            // pointPlayer1_lbl
            // 
            this.pointPlayer1_lbl.AutoSize = true;
            this.pointPlayer1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointPlayer1_lbl.Location = new System.Drawing.Point(237, 9);
            this.pointPlayer1_lbl.Name = "pointPlayer1_lbl";
            this.pointPlayer1_lbl.Size = new System.Drawing.Size(51, 55);
            this.pointPlayer1_lbl.TabIndex = 2;
            this.pointPlayer1_lbl.Text = "0";
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Red;
            this.ball.Location = new System.Drawing.Point(64, 87);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(25, 25);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // racketPlayer2
            // 
            this.racketPlayer2.BackColor = System.Drawing.Color.Blue;
            this.racketPlayer2.Location = new System.Drawing.Point(564, 87);
            this.racketPlayer2.Name = "racketPlayer2";
            this.racketPlayer2.Size = new System.Drawing.Size(20, 200);
            this.racketPlayer2.TabIndex = 0;
            this.racketPlayer2.TabStop = false;
            // 
            // Form_PingPong_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 372);
            this.Controls.Add(this.playGraund);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_PingPong_Client";
            this.Text = "PingPong_Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_PingPong_Client_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form_PingPong_Client_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_PingPong_KeyDown);
            this.playGraund.ResumeLayout(false);
            this.playGraund.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.racketPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racketPlayer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel playGraund;
        private System.Windows.Forms.Label pointPlayer2_lbl;
        private System.Windows.Forms.Label pointPlayer1_lbl;
        private System.Windows.Forms.Label Information_lbl;
        internal System.Windows.Forms.PictureBox ball;
        internal System.Windows.Forms.PictureBox racketPlayer1;
        internal System.Windows.Forms.PictureBox racketPlayer2;
        internal System.Windows.Forms.Label GameOver;
        internal System.Windows.Forms.Label Player1;
        internal System.Windows.Forms.Label Player2;
    }
}

