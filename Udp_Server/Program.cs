using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var ip = IPAddress.Loopback;
var listenerEp = new IPEndPoint(ip, 45678);

listener.Bind(listenerEp);
var buffer = new byte[ushort.MaxValue];

EndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var bytesReceived = listener.ReceiveFrom(buffer, ref remoteEp);
    var message = Encoding.Default.GetString(buffer, 0, bytesReceived);
    Console.WriteLine($"Received: {message}");
}