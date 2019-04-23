/*
 * Created by SharpDevelop.
 * User: student
 * Date: 2019-04-23
 * Time: 10:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace turtle2
{
	/// <summary>
	/// Description of console.
	/// </summary>
	public partial class console : Form
	{
		public console()
		{
			InitializeComponent();
		}
		
		ConsoleProperties def = new ConsoleProperties(Color.White);
		
	}
	
	public class ConsoleProperties
	{
		Color b {get;set;}
		bool c {get;set;}
		
		public ConsoleProperties(Color color, bool locked = true)
		{
			b = color;
			c = locked;
		}
	}
}
