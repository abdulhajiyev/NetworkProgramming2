using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();
    
    static async Task MainAsync(string[] args)
    {
        var listener = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Dgram,
            ProtocolType.Udp);

        var ip = IPAddress.Loopback;
        var listenerEp = new IPEndPoint(ip, 45678);

        listener.Bind(listenerEp);
        var buffer = new byte[ushort.MaxValue];
        var segment = new ArraySegment<byte>(buffer);

        EndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);

        while (true)
        {
            var bytesReceived = await listener.ReceiveFromAsync(segment, SocketFlags.None, remoteEp);
            var len = bytesReceived.ReceivedBytes;
            var endPoint = bytesReceived.RemoteEndPoint;
            var message = Encoding.Default.GetString(buffer, 0, len);
            Console.WriteLine($"Received: {message}");
        }
    }
}