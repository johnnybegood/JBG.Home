using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JBG.Home.Server.Resources
{
    public class IRSender : IDisposable, IIRSender
    {
        private readonly TcpClient _client;
        private readonly StreamWriter _writer;
        private readonly NetworkStream _stream;
        private readonly StreamReader _reader;

        public IRSender (string host, int port = 4998)
        {
            _client = new TcpClient(host, port);

            _stream = _client.GetStream();
            _writer = new StreamWriter(_stream, Encoding.ASCII);
            _reader = new StreamReader(_stream, Encoding.ASCII);

            _writer.AutoFlush = true;
        }

        public async Task SendAsync(string command, int channel)
        {
            if (!_client.Connected)
            {
                throw new InvalidOperationException("Not connected");
            }

            if (!_stream.CanWrite)
            {
                throw new InvalidOperationException("Stream not writable");
            }

            await _writer.WriteLineAsync($"senddir,1:{command}");

            //Small delay in answer
            await Task.Delay(100);

            while (_stream.DataAvailable)
            {
                var buffer = new byte[_client.ReceiveBufferSize];
                await _stream.ReadAsync(buffer, 0, _client.ReceiveBufferSize);

                var response = Encoding.ASCII.GetString(buffer);
                Trace.WriteLine(response);
            }
        }

        public void Dispose()
        {
            _writer?.Dispose();
            _reader?.Dispose();
            _client?.Dispose();
        }
    }
}