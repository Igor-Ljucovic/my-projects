using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Communication
{
    public class JsonNetworkSerializer
    {
        private readonly Socket socket;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public JsonNetworkSerializer(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }

        public void Send(object obj)
        {
            writer.WriteLine(JsonSerializer.Serialize(obj, options));
        }

        public T Receive<T>()
        {
            string json = reader.ReadLine();
            Console.WriteLine($"Received JSON: {json}");
            if (string.IsNullOrWhiteSpace(json))
                throw new JsonException("Received empty or null JSON data.");

            return JsonSerializer.Deserialize<T>(json, options);
        }

        public T ReadType<T>(object podaci)
        {
            return JsonSerializer.Deserialize<T>((JsonElement)podaci, options);
        }

        public void Close()
        {
            stream.Close();
            reader.Close();
            writer.Close();
        }
    }
}
