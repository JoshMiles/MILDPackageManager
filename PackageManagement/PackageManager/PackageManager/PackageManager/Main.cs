using System;

namespace PackageManager
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			drawTitle (0);
			print ("This is the PackageManager for the MILDPM FilesDB.");
			drawBar ();
			wait ();
			drawTitle (1);
			print ("Please select an option below by pressing the number on your keyboard.");
			drawBar ();
			print ("1: Push a package to the FilesDB");
			print ("2: Modify a package on the FilesDB");
			print ("3: Delete a package from the FilesDB");
			print ("4: Apply for a developers key");
			drawBar ();
			ConsoleKeyInfo inp = Console.ReadKey (false);
			switch(inp.Key)
			{
			case ConsoleKey.D1:
				packagePush();
				break;
			default:
				print ("Invalid number: " +inp.KeyChar + ".");
				print ("Exiting...");
			}
		}
		private static void packagePush()
		{
			
		}
		private static void packageModify()
		{
			
		}
		private static void packageDelete()
		{
			
		}
		private static void developersKey()
		{
			print ("You are unable to apply for a developers key.");	
		}
		private static void wait()
		{
			Console.WriteLine ("Continuing in 3 seconds...");
			Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
			System.Threading.Thread.Sleep (1000);
			Console.WriteLine ("Continuing in 2 seconds...");
			Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
			System.Threading.Thread.Sleep (1000);
			Console.WriteLine ("Continuing in 1 second... ");
			Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
			System.Threading.Thread.Sleep (1000);
		}
		private static void print(string a)
		{
			Console.WriteLine (a);	
		}
		private static void drawBar()
		{
			Console.WriteLine ("===========================");
		}
		private static void drawTitle(int stepnumber)
		{
			Console.Clear ();
			drawBar ();
			Console.WriteLine ("= PACKAGE MANAGER STEP: " + stepnumber + " =");
			drawBar ();
		}
	}
}
