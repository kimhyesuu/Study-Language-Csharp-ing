namespace Server_Exe
{
   partial class Form1
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
         this.btn_StartServer = new System.Windows.Forms.Button();
         this.tb_server = new System.Windows.Forms.TextBox();
         this.ltb_clientList = new System.Windows.Forms.ListBox();
         this.lb_Clientlist = new System.Windows.Forms.Label();
         this.lb_server = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // btn_StartServer
         // 
         this.btn_StartServer.Location = new System.Drawing.Point(320, 18);
         this.btn_StartServer.Name = "btn_StartServer";
         this.btn_StartServer.Size = new System.Drawing.Size(75, 23);
         this.btn_StartServer.TabIndex = 9;
         this.btn_StartServer.Text = "서버 시작";
         this.btn_StartServer.UseVisualStyleBackColor = true;
         this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
         // 
         // tb_server
         // 
         this.tb_server.Font = new System.Drawing.Font("Gulim", 12F);
         this.tb_server.Location = new System.Drawing.Point(75, 16);
         this.tb_server.Name = "tb_server";
         this.tb_server.Size = new System.Drawing.Size(226, 26);
         this.tb_server.TabIndex = 8;
         // 
         // ltb_clientList
         // 
         this.ltb_clientList.FormattingEnabled = true;
         this.ltb_clientList.ItemHeight = 12;
         this.ltb_clientList.Location = new System.Drawing.Point(20, 79);
         this.ltb_clientList.Name = "ltb_clientList";
         this.ltb_clientList.Size = new System.Drawing.Size(372, 196);
         this.ltb_clientList.TabIndex = 7;
         // 
         // lb_Clientlist
         // 
         this.lb_Clientlist.AutoSize = true;
         this.lb_Clientlist.Font = new System.Drawing.Font("Gulim", 9F);
         this.lb_Clientlist.Location = new System.Drawing.Point(20, 51);
         this.lb_Clientlist.Name = "lb_Clientlist";
         this.lb_Clientlist.Size = new System.Drawing.Size(147, 12);
         this.lb_Clientlist.TabIndex = 6;
         this.lb_Clientlist.Text = "연결 클라이언트 ip 리스트";
         // 
         // lb_server
         // 
         this.lb_server.AutoSize = true;
         this.lb_server.Font = new System.Drawing.Font("Gulim", 9F);
         this.lb_server.Location = new System.Drawing.Point(20, 23);
         this.lb_server.Name = "lb_server";
         this.lb_server.Size = new System.Drawing.Size(29, 12);
         this.lb_server.TabIndex = 5;
         this.lb_server.Text = "서버";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(416, 296);
         this.Controls.Add(this.btn_StartServer);
         this.Controls.Add(this.tb_server);
         this.Controls.Add(this.ltb_clientList);
         this.Controls.Add(this.lb_Clientlist);
         this.Controls.Add(this.lb_server);
         this.Name = "Form1";
         this.Text = "Form1";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btn_StartServer;
      private System.Windows.Forms.TextBox tb_server;
      private System.Windows.Forms.ListBox ltb_clientList;
      private System.Windows.Forms.Label lb_Clientlist;
      private System.Windows.Forms.Label lb_server;
   }
}

