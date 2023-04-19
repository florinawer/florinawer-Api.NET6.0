namespace TradingDDD.Domain.Entities.Pagination
{
    public class ResponseEntity <T>
    {
        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public string? Message { get; set; }
        public ResponseEntity()
        {
        }
        public ResponseEntity(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
    }
}
