using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace FileDB
{
	class MainClass
	{
		private static TcpListener listener;
        private static int LIMIT = 50;
        private static int port = 8000;
		public static void Main (string[] args)
		{
			IPAddress ip;
            ip = Dns.GetHostEntry("localhost").AddressList[1];
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("FileDB");
            Console.WriteLine("Server mounted, listening on " + ip + ":" + port);

            for (int i = 0; i < LIMIT; i++)
            {
                Thread t = new Thread(new ThreadStart(Service));
                t.Start();
            }
		}
		       public static void Service()
        {
            string COL_DOM = "";
            while (true)
            {
                Socket soc = listener.AcceptSocket();
                try
                {
                    bool ip = false;
                    Console.WriteLine("Opened connection.");
                    Stream s = new NetworkStream(soc);
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true;
					string uniquePackageIdentifier = sr.ReadLine ();
					sw.WriteLine ("Recieved");
					Console.WriteLine ("Client requested " + uniquePackageIdentifier);										
                    //to be continued
					soc.Close();
                    Console.WriteLine("Closed connection");
                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: " + e.ToString());
                    Console.WriteLine("PARAMETERS: " + COL_DOM);
                }
                finally
                {
                    soc.Close();
                }
            }
	}
}
