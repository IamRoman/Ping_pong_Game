namespace WinForms_PingPong
{
    partial class SettingsForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm2));
            this.label6 = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.Сondition = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NameClient_2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PortClient_2 = new System.Windows.Forms.TextBox();
            this.IPClient_2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.PortClient_1 = new System.Windows.Forms.TextBox();
            this.IPClient_1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NameClient_1 = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Поле для ввода сообщения:";
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.Color.Aquamarine;
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMessage.Location = new System.Drawing.Point(8, 30);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessage.Size = new System.Drawing.Size(412, 148);
            this.tbMessage.TabIndex = 0;
            // 
            // Сondition
            // 
            this.Сondition.AutoSize = true;
            this.Сondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Сondition.Location = new System.Drawing.Point(104, 288);
            this.Сondition.Name = "Сondition";
            this.Сondition.Size = new System.Drawing.Size(81, 15);
            this.Сondition.TabIndex = 4;
            this.Сondition.Text = "Отключено";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Состояние:";
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.Color.YellowGreen;
            this.Connect.Location = new System.Drawing.Point(310, 285);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(86, 23);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "Подключится";
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NameClient_2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.PortClient_2);
            this.groupBox2.Controls.Add(this.IPClient_2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(21, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Клиент_2";
            // 
            // NameClient_2
            // 
            this.NameClient_2.Location = new System.Drawing.Point(208, 54);
            this.NameClient_2.Name = "NameClient_2";
            this.NameClient_2.Size = new System.Drawing.Size(136, 20);
            this.NameClient_2.TabIndex = 7;
            this.NameClient_2.Text = "Петя";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Имя Вашего противника";
            // 
            // PortClient_2
            // 
            this.PortClient_2.Location = new System.Drawing.Point(42, 54);
            this.PortClient_2.Name = "PortClient_2";
            this.PortClient_2.Size = new System.Drawing.Size(142, 20);
            this.PortClient_2.TabIndex = 3;
            this.PortClient_2.Text = "8081";
            this.PortClient_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortClient_2_KeyPress);
            // 
            // IPClient_2
            // 
            this.IPClient_2.Location = new System.Drawing.Point(42, 25);
            this.IPClient_2.Name = "IPClient_2";
            this.IPClient_2.Size = new System.Drawing.Size(142, 20);
            this.IPClient_2.TabIndex = 2;
            this.IPClient_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPClient_2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Поле для чтения сообщения:";
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.Color.YellowGreen;
            this.Send.Location = new System.Drawing.Point(325, 249);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 3;
            this.Send.Text = "Отправить";
            this.Send.UseVisualStyleBackColor = false;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.Send);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbSend);
            this.tabPage2.Controls.Add(this.tbMessage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(415, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Чат";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbSend
            // 
            this.tbSend.BackColor = System.Drawing.Color.Aquamarine;
            this.tbSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSend.Location = new System.Drawing.Point(8, 217);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(293, 55);
            this.tbSend.TabIndex = 1;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(205, 27);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(57, 13);
            this.lbl7.TabIndex = 4;
            this.lbl7.Text = "Ваше имя";
            // 
            // PortClient_1
            // 
            this.PortClient_1.Location = new System.Drawing.Point(42, 49);
            this.PortClient_1.Name = "PortClient_1";
            this.PortClient_1.Size = new System.Drawing.Size(142, 20);
            this.PortClient_1.TabIndex = 3;
            this.PortClient_1.Text = "8080";
            this.PortClient_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortClient_1_KeyPress);
            // 
            // IPClient_1
            // 
            this.IPClient_1.Location = new System.Drawing.Point(42, 20);
            this.IPClient_1.Name = "IPClient_1";
            this.IPClient_1.Size = new System.Drawing.Size(142, 20);
            this.IPClient_1.TabIndex = 2;
            this.IPClient_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPClient_1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NameClient_1);
            this.groupBox1.Controls.Add(this.lbl7);
            this.groupBox1.Controls.Add(this.PortClient_1);
            this.groupBox1.Controls.Add(this.IPClient_1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Клиент_1";
            // 
            // NameClient_1
            // 
            this.NameClient_1.Location = new System.Drawing.Point(208, 49);
            this.NameClient_1.Name = "NameClient_1";
            this.NameClient_1.Size = new System.Drawing.Size(136, 20);
            this.NameClient_1.TabIndex = 5;
            this.NameClient_1.Text = "Вася";
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.Controls.Add(this.Сondition);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.Connect);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(415, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPage1);
            this.tabControlSettings.Controls.Add(this.tabPage2);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(423, 343);
            this.tabControlSettings.TabIndex = 1;
            // 
            // SettingsForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 343);
            this.Controls.Add(this.tabControlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm2";
            this.Text = "Настройки/Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm2_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControlSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label Сondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox NameClient_2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PortClient_2;
        private System.Windows.Forms.TextBox IPClient_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.TextBox PortClient_1;
        private System.Windows.Forms.TextBox IPClient_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NameClient_1;
        internal System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.TabControl tabControlSettings;
    }
}