namespace RealClient_Exe
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
         this.lb_ConnetAddress = new System.Windows.Forms.Label();
         this.lb_floatData = new System.Windows.Forms.Label();
         this.lb_intData = new System.Windows.Forms.Label();
         this.lb_strData = new System.Windows.Forms.Label();
         this.btn_ConnectAddress = new System.Windows.Forms.Button();
         this.tb_Address = new System.Windows.Forms.TextBox();
         this.tb_strData = new System.Windows.Forms.TextBox();
         this.tb_floatData = new System.Windows.Forms.TextBox();
         this.tb_intData = new System.Windows.Forms.TextBox();
         this.btn_SendAndReceive = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lb_ConnetAddress
         // 
         this.lb_ConnetAddress.AutoSize = true;
         this.lb_ConnetAddress.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.lb_ConnetAddress.Location = new System.Drawing.Point(22, 19);
         this.lb_ConnetAddress.Name = "lb_ConnetAddress";
         this.lb_ConnetAddress.Size = new System.Drawing.Size(139, 16);
         this.lb_ConnetAddress.TabIndex = 0;
         this.lb_ConnetAddress.Text = "접속할 서버 주소";
         // 
         // lb_floatData
         // 
         this.lb_floatData.AutoSize = true;
         this.lb_floatData.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.lb_floatData.Location = new System.Drawing.Point(22, 95);
         this.lb_floatData.Name = "lb_floatData";
         this.lb_floatData.Size = new System.Drawing.Size(119, 16);
         this.lb_floatData.TabIndex = 1;
         this.lb_floatData.Text = "float형 데이터";
         // 
         // lb_intData
         // 
         this.lb_intData.AutoSize = true;
         this.lb_intData.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.lb_intData.Location = new System.Drawing.Point(22, 57);
         this.lb_intData.Name = "lb_intData";
         this.lb_intData.Size = new System.Drawing.Size(102, 16);
         this.lb_intData.TabIndex = 2;
         this.lb_intData.Text = "int형 데이터";
         // 
         // lb_strData
         // 
         this.lb_strData.AutoSize = true;
         this.lb_strData.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.lb_strData.Location = new System.Drawing.Point(22, 131);
         this.lb_strData.Name = "lb_strData";
         this.lb_strData.Size = new System.Drawing.Size(116, 16);
         this.lb_strData.TabIndex = 3;
         this.lb_strData.Text = "문자열 데이터";
         // 
         // btn_ConnectAddress
         // 
         this.btn_ConnectAddress.Location = new System.Drawing.Point(373, 12);
         this.btn_ConnectAddress.Name = "btn_ConnectAddress";
         this.btn_ConnectAddress.Size = new System.Drawing.Size(75, 23);
         this.btn_ConnectAddress.TabIndex = 4;
         this.btn_ConnectAddress.Text = "접속";
         this.btn_ConnectAddress.UseVisualStyleBackColor = true;
         this.btn_ConnectAddress.Click += new System.EventHandler(this.btn_ConnectAddress_Click);
         // 
         // tb_Address
         // 
         this.tb_Address.Font = new System.Drawing.Font("Gulim", 12F);
         this.tb_Address.Location = new System.Drawing.Point(170, 14);
         this.tb_Address.Name = "tb_Address";
         this.tb_Address.Size = new System.Drawing.Size(171, 26);
         this.tb_Address.TabIndex = 5;
         // 
         // tb_strData
         // 
         this.tb_strData.Font = new System.Drawing.Font("Gulim", 12F);
         this.tb_strData.Location = new System.Drawing.Point(170, 126);
         this.tb_strData.Name = "tb_strData";
         this.tb_strData.Size = new System.Drawing.Size(171, 26);
         this.tb_strData.TabIndex = 6;
         // 
         // tb_floatData
         // 
         this.tb_floatData.Font = new System.Drawing.Font("Gulim", 12F);
         this.tb_floatData.Location = new System.Drawing.Point(170, 90);
         this.tb_floatData.Name = "tb_floatData";
         this.tb_floatData.Size = new System.Drawing.Size(171, 26);
         this.tb_floatData.TabIndex = 7;
         // 
         // tb_intData
         // 
         this.tb_intData.Font = new System.Drawing.Font("Gulim", 12F);
         this.tb_intData.Location = new System.Drawing.Point(170, 52);
         this.tb_intData.Name = "tb_intData";
         this.tb_intData.Size = new System.Drawing.Size(171, 26);
         this.tb_intData.TabIndex = 8;
         // 
         // btn_SendAndReceive
         // 
         this.btn_SendAndReceive.Location = new System.Drawing.Point(373, 131);
         this.btn_SendAndReceive.Name = "btn_SendAndReceive";
         this.btn_SendAndReceive.Size = new System.Drawing.Size(107, 23);
         this.btn_SendAndReceive.TabIndex = 9;
         this.btn_SendAndReceive.Text = "송신 및 수신";
         this.btn_SendAndReceive.UseVisualStyleBackColor = true;
         this.btn_SendAndReceive.Click += new System.EventHandler(this.btn_SendAndReceive_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(497, 176);
         this.Controls.Add(this.btn_SendAndReceive);
         this.Controls.Add(this.tb_intData);
         this.Controls.Add(this.tb_floatData);
         this.Controls.Add(this.tb_strData);
         this.Controls.Add(this.tb_Address);
         this.Controls.Add(this.btn_ConnectAddress);
         this.Controls.Add(this.lb_strData);
         this.Controls.Add(this.lb_intData);
         this.Controls.Add(this.lb_floatData);
         this.Controls.Add(this.lb_ConnetAddress);
         this.Name = "Form1";
         this.Text = "Form1";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lb_ConnetAddress;
      private System.Windows.Forms.Label lb_floatData;
      private System.Windows.Forms.Label lb_intData;
      private System.Windows.Forms.Label lb_strData;
      private System.Windows.Forms.Button btn_ConnectAddress;
      private System.Windows.Forms.TextBox tb_Address;
      private System.Windows.Forms.TextBox tb_strData;
      private System.Windows.Forms.TextBox tb_floatData;
      private System.Windows.Forms.TextBox tb_intData;
      private System.Windows.Forms.Button btn_SendAndReceive;
   }
}

