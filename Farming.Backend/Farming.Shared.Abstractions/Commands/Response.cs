namespace Farming.Shared.Abstractions.Commands
{
    public class Response<T> where T : IResponse
    {
        public T Content { get; set; }

        public Response()
        {

        }

        public Response(T content)
        {
            Content = content;
        }
    }
}
