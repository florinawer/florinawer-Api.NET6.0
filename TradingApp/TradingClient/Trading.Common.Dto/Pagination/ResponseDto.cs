namespace Trading.Common.Dto.Pagination
{
    public class ResponseDto <T>
    {
        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public string? Message { get; set; }
        public ResponseDto()
        {
        }
        public ResponseDto(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
    }
}
