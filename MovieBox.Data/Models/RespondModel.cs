namespace MovieBox.Data.Models
{
    public class RespondModel<T> where T : class
    {
        public bool Success { get; set; }
        public T Object { get; set; }
    }
}
