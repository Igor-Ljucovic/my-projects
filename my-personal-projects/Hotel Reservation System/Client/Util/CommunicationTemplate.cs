using Common.Communication;

namespace Client.Util
{
    internal static class CommunicationTemplate
    {
        internal static Response Execute<SerializerReadType>(object entity, Operation operation, JsonNetworkSerializer serializer)
        {
            Request req = new Request
            {
                Argument = entity,
                Operation = operation
            };
            serializer.Send(req);
            Response response = serializer.Receive<Response>();
            response.Result = serializer.ReadType<SerializerReadType>(response.Result);
            return response;
        }
    }
}
