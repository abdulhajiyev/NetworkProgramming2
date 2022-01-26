using System.Net;
using System.Net.Sockets;

var ip = IPAddress.Loopback;
var client = new TcpClient();
client.Connect(ip, 45001);
var stream = client.GetStream();
var binaryWriter = new BinaryWriter(stream);
