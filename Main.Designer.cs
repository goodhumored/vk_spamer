namespace vkRaid
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.AuthExitButton = new System.Windows.Forms.Button();
            this.NickName = new System.Windows.Forms.Label();
            this.StartRaidButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LinkTextBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddAtt = new System.Windows.Forms.Button();
            this.RemoveAtt = new System.Windows.Forms.Button();
            this.AttachmentList = new System.Windows.Forms.ListView();
            this.AttLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Owner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StickerIdBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(118)))), ((int)(((byte)(168)))));
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.Header);
            this.panel1.Controls.Add(this.AuthExitButton);
            this.panel1.Controls.Add(this.NickName);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 60);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(728, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(69, 29);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(246)))));
            this.Header.Location = new System.Drawing.Point(330, 16);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(140, 29);
            this.Header.TabIndex = 3;
            this.Header.Text = "Вк рейдер";
            // 
            // AuthExitButton
            // 
            this.AuthExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AuthExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(177)))), ((int)(((byte)(198)))));
            this.AuthExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AuthExitButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.AuthExitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(246)))));
            this.AuthExitButton.Location = new System.Drawing.Point(12, 31);
            this.AuthExitButton.Name = "AuthExitButton";
            this.AuthExitButton.Size = new System.Drawing.Size(63, 21);
            this.AuthExitButton.TabIndex = 2;
            this.AuthExitButton.Text = "Войти";
            this.AuthExitButton.UseVisualStyleBackColor = false;
            this.AuthExitButton.Click += new System.EventHandler(this.AuthExitButton_Click);
            // 
            // NickName
            // 
            this.NickName.AutoSize = true;
            this.NickName.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NickName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(246)))));
            this.NickName.Location = new System.Drawing.Point(9, 9);
            this.NickName.Name = "NickName";
            this.NickName.Size = new System.Drawing.Size(98, 16);
            this.NickName.TabIndex = 1;
            this.NickName.Text = "Имя Фамилия";
            // 
            // StartRaidButton
            // 
            this.StartRaidButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(177)))), ((int)(((byte)(198)))));
            this.StartRaidButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartRaidButton.Font = new System.Drawing.Font("Tahoma", 12F);
            this.StartRaidButton.ForeColor = System.Drawing.Color.Black;
            this.StartRaidButton.Location = new System.Drawing.Point(705, 401);
            this.StartRaidButton.Name = "StartRaidButton";
            this.StartRaidButton.Size = new System.Drawing.Size(82, 37);
            this.StartRaidButton.TabIndex = 1;
            this.StartRaidButton.Text = "Рейд";
            this.StartRaidButton.UseVisualStyleBackColor = false;
            this.StartRaidButton.Click += new System.EventHandler(this.RaidButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Айди назначения:";
            // 
            // LinkTextBox
            // 
            this.LinkTextBox.FormattingEnabled = true;
            this.LinkTextBox.Location = new System.Drawing.Point(28, 92);
            this.LinkTextBox.Name = "LinkTextBox";
            this.LinkTextBox.Size = new System.Drawing.Size(145, 21);
            this.LinkTextBox.TabIndex = 4;
            this.LinkTextBox.DropDown += new System.EventHandler(this.Link_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вложения:";
            // 
            // AddAtt
            // 
            this.AddAtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(177)))), ((int)(((byte)(198)))));
            this.AddAtt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddAtt.Location = new System.Drawing.Point(329, 118);
            this.AddAtt.Name = "AddAtt";
            this.AddAtt.Size = new System.Drawing.Size(25, 25);
            this.AddAtt.TabIndex = 7;
            this.AddAtt.Text = "+";
            this.AddAtt.UseVisualStyleBackColor = false;
            this.AddAtt.Click += new System.EventHandler(this.AddAtt_Click);
            // 
            // RemoveAtt
            // 
            this.RemoveAtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(177)))), ((int)(((byte)(198)))));
            this.RemoveAtt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveAtt.Location = new System.Drawing.Point(360, 118);
            this.RemoveAtt.Name = "RemoveAtt";
            this.RemoveAtt.Size = new System.Drawing.Size(25, 25);
            this.RemoveAtt.TabIndex = 8;
            this.RemoveAtt.Text = "-";
            this.RemoveAtt.UseVisualStyleBackColor = false;
            this.RemoveAtt.Click += new System.EventHandler(this.RemoveAtt_Click);
            // 
            // AttachmentList
            // 
            this.AttachmentList.AllowDrop = true;
            this.AttachmentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttLink,
            this.AttType,
            this.Owner});
            this.AttachmentList.GridLines = true;
            this.AttachmentList.Location = new System.Drawing.Point(19, 36);
            this.AttachmentList.Name = "AttachmentList";
            this.AttachmentList.Size = new System.Drawing.Size(366, 76);
            this.AttachmentList.TabIndex = 9;
            this.AttachmentList.TileSize = new System.Drawing.Size(168, 15);
            this.AttachmentList.UseCompatibleStateImageBehavior = false;
            this.AttachmentList.View = System.Windows.Forms.View.Details;
            this.AttachmentList.DragDrop += new System.Windows.Forms.DragEventHandler(this.AttachmentList_DragDrop);
            this.AttachmentList.DragEnter += new System.Windows.Forms.DragEventHandler(this.AttachmentList_DragEnter);
            // 
            // AttLink
            // 
            this.AttLink.Text = "Ссылка";
            this.AttLink.Width = 180;
            // 
            // AttType
            // 
            this.AttType.Text = "Тип вложения";
            this.AttType.Width = 84;
            // 
            // Owner
            // 
            this.Owner.Text = "Владелец";
            this.Owner.Width = 98;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(19, 154);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(366, 146);
            this.MessageTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Сообщение:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MessageTextBox);
            this.groupBox1.Controls.Add(this.AttachmentList);
            this.groupBox1.Controls.Add(this.RemoveAtt);
            this.groupBox1.Controls.Add(this.AddAtt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 318);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обычный спам";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StickerIdBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(452, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 276);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Спам стикерами";
            // 
            // StickerIdBox
            // 
            this.StickerIdBox.Location = new System.Drawing.Point(16, 222);
            this.StickerIdBox.Name = "StickerIdBox";
            this.StickerIdBox.Size = new System.Drawing.Size(313, 21);
            this.StickerIdBox.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label8.Location = new System.Drawing.Point(13, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(318, 28);
            this.label8.TabIndex = 10;
            this.label8.Text = "4. В описании к фото дана ссылка, скопируй всё,\nчто идёт после vk.com/images/stic" +
    "kers/ и вставь сюда:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.Location = new System.Drawing.Point(13, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "3. Ищешь там нужный стикер";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(13, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "2. Ищешь там нужный стикерпак в альбомах";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(12, 16);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(14, 46);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 19);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "1. Заходишь сюда";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Id Стикера:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(485, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "Кол-во отправленных сообщений:\n0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LinkTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartRaidButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AuthExitButton;
        private System.Windows.Forms.Label NickName;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button StartRaidButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LinkTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddAtt;
        private System.Windows.Forms.Button RemoveAtt;
        private System.Windows.Forms.ListView AttachmentList;
        private System.Windows.Forms.ColumnHeader AttLink;
        private System.Windows.Forms.ColumnHeader AttType;
        private System.Windows.Forms.ColumnHeader Owner;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox StickerIdBox;
    }
}

