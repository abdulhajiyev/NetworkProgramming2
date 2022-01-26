using System.Net;
using System.Net.Sockets;
using System.Text;

var ip = IPAddress.Loopback;
var listener = new TcpListener(ip, 45001);

listener.Start(100);
Console.WriteLine("Listening on {0}", listener.LocalEndpoint);

while (true)
{
    listener.AcceptTcpClient();
    Console.WriteLine("Client connected");

    var client = listener.AcceptTcpClient();
    var stream = client.GetStream();
    var binaryWriter = new BinaryWriter(stream);
    var binaryReader = new BinaryReader(stream);

    while (true)
    {
        var message = binaryReader.ReadString();
        Console.WriteLine(message);
        binaryWriter.Write("Hakuna Matata");
    }
}