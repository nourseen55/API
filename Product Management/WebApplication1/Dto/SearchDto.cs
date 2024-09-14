namespace WebApplication1.Dto
{
    public class SearchDto
    {
        public string keyword { get; set; }
        public string category { get; set; }
        public decimal? maxprice { get; set; }
        public decimal? minprice { get; set; }
    }
}
