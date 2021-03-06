﻿using System;
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
					string requestCode = sr.ReadLine ();
					switch(requestCode)
					{
					case "MDSM" || "0001" || "1": // Requesting Package MD5 sum
						break;
					case "PURL" || "0010" || "2": // Requesting Package download URL
						break;
					case "APKG" || "0011" || "3": // Requesting Package author
						break;
					case "AURL" || "0100" || "4": // Requesting Package author's website
						break;
					case "CLOG" || "0101" || "5": // Requesting Package changelog
						break;
					case "DPEN" || "0110" || "6": // Requesting Package dependencies
						break;
					case "SRCH" || "0111" || "7": // Perform a search for a package
						break;
					// These are now the RCs for the PackageManagment utility
					case "PUSH" || "1000" || "8": // Request a package push
						break;
					case "PMOD" || "1001" || "9": // Request a package modification
						break;
					case "PDEL" || "1010" || "A": // Request a package deletion
						break;
					default:
						// error
						sw.WriteLine ("NULL");
						break;
					}
					Console.WriteLine ("Client requested " + uniquePackageIdentifier);										
                    
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
}