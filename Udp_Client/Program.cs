using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var ip = IPAddress.Loopback;
var serverEp = new IPEndPoint(ip, 45678);

while (true)
{
    var message = Console.ReadLine();
    var data = Encoding.Default.GetBytes(message);
    client.SendTo(data, serverEp);
}