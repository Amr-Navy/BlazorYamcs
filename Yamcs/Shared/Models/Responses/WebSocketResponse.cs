namespace Yamcs.Shared.Models
{
    public class WebSocketResponse
    {

        public string Type { get; set; }
        public int Seq { get; set; }
        public int Call { get; set; }
        // public T data { set; get; }

    }
    public class WebSocketResponse<T>
    {

        public string Type { get; set; }
        public int Seq { get; set; }
        public int Call { get; set; }
        public T Data { set; get; }

    }
}
