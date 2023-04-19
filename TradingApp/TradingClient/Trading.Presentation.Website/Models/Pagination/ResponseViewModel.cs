namespace Trading.Presentation.Website.Models.Pagination
{
    public class ResponseViewModel <T>
    {
        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public string? Message { get; set; }
        public ResponseViewModel()
        {
        }
        public ResponseViewModel(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
    }
}
