namespace Client_Exe
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
         this.lb_serverIp = new System.Windows.Forms.Label();
         this.lb_UserIp = new System.Windows.Forms.Label();
         this.tb_ServerIp = new System.Windows.Forms.TextBox();
         this.tb_UserIp = new System.Windows.Forms.TextBox();
         this.btn_Connect = new System.Windows.Forms.Button();
         this.btn_SendAndReceive = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lb_serverIp
         // 
         this.lb_serverIp.AutoSize = true;
         this.lb_serverIp.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold);
         this.lb_serverIp.Location = new System.Drawing.Point(21, 14);
         this.lb_serverIp.Name = "lb_serverIp";
         this.lb_serverIp.Size = new System.Drawing.Size(68, 16);
         this.lb_serverIp.TabIndex = 0;
         this.lb_serverIp.Text = "서버 ip:";
         // 
         // lb_UserIp
         // 
         this.lb_UserIp.AutoSize = true;
         this.lb_UserIp.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold);
         this.lb_UserIp.Location = new System.Drawing.Point(21, 45);
         this.lb_UserIp.Name = "lb_UserIp";
         this.lb_UserIp.Size = new System.Drawing.Size(85, 16);
         this.lb_UserIp.TabIndex = 1;
         this.lb_UserIp.Text = "접속자 ip:";
         // 
         // tb_ServerIp
         // 
         this.tb_ServerIp.Font = new System.Drawing.Font("Gulim", 12F);
         this.tb_ServerIp.Location = new System.Drawing.Point(121, 9);
         this.tb_ServerIp.Name = "tb_ServerIp";
         this.tb_ServerIp.Size = new System.Drawing.Size(183, 26);
         this.tb_ServerIp.TabIndex = 2;
         // 
         // tb_UserIp
         // 
         this.tb_UserIp.Font = new System.Drawing.Font("Gulim", 12F);
         this.tb_UserIp.Location = new System.Drawing.Point(121, 40);
         this.tb_UserIp.Name = "tb_UserIp";
         this.tb_UserIp.Size = new System.Drawing.Size(183, 26);
         this.tb_UserIp.TabIndex = 3;
         // 
         // btn_Connect
         // 
         this.btn_Connect.Location = new System.Drawing.Point(319, 12);
         this.btn_Connect.Name = "btn_Connect";
         this.btn_Connect.Size = new System.Drawing.Size(117, 23);
         this.btn_Connect.TabIndex = 4;
         this.btn_Connect.Text = "접속 시작";
         this.btn_Connect.UseVisualStyleBackColor = true;
         this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
         // 
         // btn_SendAndReceive
         // 
         this.btn_SendAndReceive.Location = new System.Drawing.Point(121, 84);
         this.btn_SendAndReceive.Name = "btn_SendAndReceive";
         this.btn_SendAndReceive.Size = new System.Drawing.Size(267, 23);
         this.btn_SendAndReceive.TabIndex = 5;
         this.btn_SendAndReceive.Text = "송수신 시작";
         this.btn_SendAndReceive.UseVisualStyleBackColor = true;
         this.btn_SendAndReceive.Click += new System.EventHandler(this.btn_SendAndReceive_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(460, 122);
         this.Controls.Add(this.btn_SendAndReceive);
         this.Controls.Add(this.btn_Connect);
         this.Controls.Add(this.tb_UserIp);
         this.Controls.Add(this.tb_ServerIp);
         this.Controls.Add(this.lb_UserIp);
         this.Controls.Add(this.lb_serverIp);
         this.Name = "Form1";
         this.Text = "Simple Server";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lb_serverIp;
      private System.Windows.Forms.Label lb_UserIp;
      private System.Windows.Forms.TextBox tb_ServerIp;
      private System.Windows.Forms.TextBox tb_UserIp;
      private System.Windows.Forms.Button btn_Connect;
      private System.Windows.Forms.Button btn_SendAndReceive;
   }
}

