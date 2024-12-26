using System;
using System.Net;
using System.Net.Sockets;

public class PortScanner
{
    public static bool IsPortOpen(string host, int port, int timeout = 1000)
    {
        try
        {
            using (var tcpClient = new TcpClient())
            {
                var result = tcpClient.BeginConnect(host, port, null, null);
                result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeout));
                return tcpClient.Connected;
            }
        }
        catch
        {
            // Handle exception if needed
            return false;
        }
    }
}

