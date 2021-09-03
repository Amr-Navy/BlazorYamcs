namespace Yamcs.Shared.Models
{
    public class WebSocketRequest<T>
    {
        public string Type { get; set; }
        public int Id { get; set; }
        // public int call { get; set; }
        public T Options { set; get; }

    }

}
