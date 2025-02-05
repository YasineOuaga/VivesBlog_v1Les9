﻿namespace VivesBlog.Dtos.Results
{
    public class ArticleResult
    {
        public int Id { get; set; }
      
        public required string Title { get; set; }

        public int? AuthorId { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }

        public DateTime PublishedDate { get; set; }
        
        public required string Description { get; set; }
      
        public required string Content { get; set; }
    }
}
