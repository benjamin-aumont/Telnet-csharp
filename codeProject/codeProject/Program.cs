using System;
using System.IO;
using System.Net.Sockets;

namespace codeProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            // create server SMTP with port 25
            TcpClient SmtpServ = new TcpClient("mx", 25);
            string Data;
            byte[] szData;
            string CRLF = "\r\n";
            //LogList.Items.Clear();

            try
            {
                // initialization
                NetworkStream NetStrm = SmtpServ.GetStream();
                StreamReader RdStrm = new StreamReader(SmtpServ.GetStream());
                //LogList.Items.Add(RdStrm.ReadLine());
                Console.WriteLine(RdStrm.ReadLine());

                // say hello to server and send response into log report
                Data = "helo server" + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                NetStrm.Write(szData, 0, szData.Length);
                //LogList.Items.Add(RdStrm.ReadLine());
                Console.WriteLine(RdStrm.ReadLine());

                // send sender data
                Data = "MAIL FROM: <charles.berthier@gmail.com>" + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                NetStrm.Write(szData, 0, szData.Length);
                //LogList.Items.Add(RdStrm.ReadLine());
                Console.WriteLine(RdStrm.ReadLine());

                // send receiver data
                Data = "RCPT TO:<monique.berthier@gmail.com>" + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                NetStrm.Write(szData, 0, szData.Length);
                //LogList.Items.Add(RdStrm.ReadLine());
                Console.WriteLine(RdStrm.ReadLine());


                // quit from server SMTP
                Data = "QUIT " + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                NetStrm.Write(szData, 0, szData.Length);
                //LogList.Items.Add(RdStrm.ReadLine());
                Console.WriteLine(RdStrm.ReadLine());

                // close connection
                NetStrm.Close();
                RdStrm.Close();
                //LogList.Items.Add("Close connection");
                //LogList.Items.Add("Send mail successly..");
                Console.WriteLine("close connexion");
                Console.WriteLine("send mail successly");




            }
            catch (InvalidOperationException err)
            {
                //LogList.Items.Add("Error: " + err.ToString());
                Console.WriteLine("Error: " + err.ToString());
            }
        }
    }
}
