namespace TradingDDD.Domain.Entities.Pagination
{
    public class PaginationFilterEntity
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilterEntity()
        {
            this.PageNumber = 1;
            this.PageSize = 100;
        }
        public PaginationFilterEntity(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 100 ? 100 : pageSize;
        }
    }
}
