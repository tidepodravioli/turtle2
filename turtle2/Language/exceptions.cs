/*
 * Created by SharpDevelop.
 * User: student
 * Date: 2019-04-17
 * Time: 13:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace turtle2.Exceptions
{
	public class FileDoesntExist:Exception
	{
		public FileDoesntExist(){}
		public FileDoesntExist(string message): base(message){}
	}
}
