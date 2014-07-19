using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace downloader
{
	class MainClass
	{
		public string ServerIP = "127.0.0.1";
		public int ServerPort = 8000;
		public static void Main (string[] args)
		{
			if(args.Length == 0){
				Console.WriteLine ("Invalid arguments.");	
			}else{
				string uniquePackageIdentifier = args[1];
                TcpClient tcp = new TcpClient(ServerIP, ServerPort);
                Stream z = tcp.GetStream();
                StreamReader zr = new StreamReader(z);
                StreamWriter zw = new StreamWriter(z);
                zw.AutoFlush = true;
				zw.WriteLine (uniquePackageIdentifier);
				string wait = zr.ReadLine (); // waiting for a response from the file db
				//to be continued
				zw.Close ();
				zr.Close ();
				tcp.Close ();
			}
		}
	}
}
