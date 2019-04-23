/*
 * Created by SharpDevelop.
 * User: student
 * Date: 2019-04-17
 * Time: 12:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using FastColoredTextBoxNS;

namespace turtle2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		List<bool> saved = new List<bool>();
		
		Style bluebold = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
		Style greennorm = new TextStyle(Brushes.Green, null, FontStyle.Regular);
		void y_TextChanged(object sender, TextChangedEventArgs e)
		{
			e.ChangedRange.ClearFoldingMarkers();
		    //set folding markers
		    e.ChangedRange.SetFoldingMarkers(":", ";");
		    e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");
		    
			e.ChangedRange.ClearStyle(bluebold);
			e.ChangedRange.SetStyle(bluebold, "^\\?void|^\\?class|^$");
			e.ChangedRange.SetStyle(bluebold, "^string|^int");
			
			e.ChangedRange.ClearStyle(greennorm);
			e.ChangedRange.SetStyle(greennorm, "^//.+");
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			TabPage f = new TabPage();
			f.Text = "untitled.tur";
			f.Tag = "u§,null";
			
			FastColoredTextBox y = new FastColoredTextBox();
			y.AutoIndent = true;
			y.AutoCompleteBrackets = true;
			y.TextChanged += y_TextChanged;
			y.Dock = DockStyle.Fill;
			f.Controls.Add(y);
			
			tabControl1.TabPages.Add(f);
				
		}
		
		void AddFileTab(string filename)
		{
			
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			Language.Tokenizer r = new turtle2.Language.Tokenizer();
			string codesel = ((FastColoredTextBox)tabControl1.SelectedTab.Controls[0]).Text;
			MessageBox.Show(codesel);
			List<Language.DslToken> m = r.Tokenize(((FastColoredTextBox)tabControl1.SelectedTab.Controls[0]).Text);
			string y = "";
			foreach(Language.DslToken v in m){
				y += v.TokenType.ToString() + '\n';
			}
			
			MessageBox.Show(y);
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			
		}
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			TabPage curtab = tabControl1.SelectedTab;
			string[] tag = curtab.Tag.ToString().Split(',');
			
			if(tag[0] == "u§")
			{
				SaveFileDialog sdlg = new SaveFileDialog();
				sdlg.Filter = ("Turtle source code (*.tur)|*.tur|Text file (*.txt)|*.txt");
				
				if(sdlg.ShowDialog() == DialogResult.OK)
				{
					string doctext = ((FastColoredTextBox)curtab.Controls[0]).Text;
					File.WriteAllText(sdlg.FileName, doctext);
				}
			}
			else
			{
				string doctext = ((FastColoredTextBox)curtab.Controls[0]).Text;
				File.WriteAllText(tag[1], doctext);
			}
		}
	}
}
