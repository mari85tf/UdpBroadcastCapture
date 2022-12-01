using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpBroadcastCapture
{
    class Program
    {
        // IMPORTANT Windows firewall must be open on UDP port 7000
        // Use the network MGV-xxx to capture from local IoT devices 
        private const int Port = 7000 ;

        static void Main()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            using (UdpClient socket = new UdpClient(ipEndPoint))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                        remoteEndPoint.Address, remoteEndPoint.Port, message);
                 
                }
            }
        }

        
    }
}
