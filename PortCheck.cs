using System;
using System.DirectoryServices.ActiveDirectory;
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
                if (IsIPAddress(host))
                {
                    var result = tcpClient.BeginConnect(host, port, null, null);
                    result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeout));
                    return tcpClient.Connected;
                }
                else
                {
                    try
                    {
                        IPAddress[] addresses = Dns.GetHostAddresses(host);
                        host = addresses[0].ToString();
                        var result = tcpClient.BeginConnect(host, port, null, null);
                        result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeout));
                        return tcpClient.Connected;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
        catch
        {
            // Handle exception if needed
            return false;
        }
    }


    private static bool IsIPAddress(string input)
    {
        // 尝试解析输入为IP地址
        return IPAddress.TryParse(input, out _);
    }

}

