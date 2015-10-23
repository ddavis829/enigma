/*
 * Created by SharpDevelop.
 * User: AdrianClepcea
 * Date: 2/1/2005
 * Time: 10:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma
{
	/// <summary>
	/// Description of About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public About()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(About));
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(216, 184);
			this.label3.TabIndex = 2;
			this.label3.Text = @"Enigma was an encripting device invented in early 20's. It was used by the german forces in WWII. The alied forces managed to decrypt a small part of the messages sent with this deviceand some say that this led them to victory. The secret of breaking this code was not public until the 70's. Until then , the Swedish armed forces continued to use a slightly modified model of this machine. This program does not use the fromt swithching panel present in the military version of the machine.";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.label2.Location = new System.Drawing.Point(32, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(216, 40);
			this.label2.TabIndex = 1;
			this.label2.Text = "Cryptography utility using an simplified algorithm of the German Enigma machine.";
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.label4.Location = new System.Drawing.Point(32, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(208, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Realized by Adrian Roland Clepcea ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnOk
			// 
			this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOk.Location = new System.Drawing.Point(96, 312);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ok";
			this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// label1
			// 
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.Location = new System.Drawing.Point(72, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 32);
			this.label1.TabIndex = 0;
			// 
			// About
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(272, 344);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.ResumeLayout(false);
		}
		#endregion
		void BtnOkClick(object sender, System.EventArgs e)
		{
			Close();
		}
		
	}
}
