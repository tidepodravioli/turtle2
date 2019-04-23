/*
 * Created by SharpDevelop.
 * User: student
 * Date: 2019-04-23
 * Time: 10:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace turtle2
{
	partial class console
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.RichTextBox display;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.display = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.display.Dock = System.Windows.Forms.DockStyle.Fill;
			this.display.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.display.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.display.Location = new System.Drawing.Point(5, 5);
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(808, 531);
			this.display.TabIndex = 0;
			this.display.Text = "";
			// 
			// console
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 541);
			this.Controls.Add(this.display);
			this.Name = "console";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "Console";
			this.ResumeLayout(false);

		}
	}
}
