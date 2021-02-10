namespace Iys.SDK.Models
{
    public class ResponseToken
    {
        public string Message { get; set; }

        public int Status { get; set; }

        public ResponseTokenItem Result { get; set; }
    }
}