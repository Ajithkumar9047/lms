using System;
namespace lms.config.Models
{
    public class ServerResponse<T>
    {
        public string? Message { get; set; }
        public T? Response { get; set; }
        public int status { get; set; }
    }
}

