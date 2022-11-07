namespace Look.Models
{
    public class Pager
    {
        public int TotalItem { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public Pager()
        {

        }
        public Pager(int totalItem, int page, int pageSize = 3)
        {
            int totalPage = (int)Math.Ceiling(totalItem / (decimal)pageSize);
            int currentPage = page;

            int startPage = -5;
            int endPage = +4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPage)
            {
                endPage = totalPage;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItem = totalItem;
            CurrentPage = currentPage;
            TotalPage = totalPage;
            PageSize = pageSize;
            StartPage = startPage;
            EndPage = endPage;
        }
    }

}
