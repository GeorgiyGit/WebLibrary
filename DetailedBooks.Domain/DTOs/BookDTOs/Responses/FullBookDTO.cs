using DetailedBooks.Domain.DTOs.AuthorDTOs.Responses;
using DetailedBooks.Domain.DTOs.ImageDTOs;
using DetailedBooks.Domain.DTOs.StatusDTOs.Responses;
using DetailedBooks.Domain.DTOs.TagDTOs.Responses;
using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Entities.Categories;
using DetailedBooks.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.DTOs.BookDTOs.Responses
{
    public class FullBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ImageDTO Image { get; set; }


        public int MaxChaptersCount { get; set; }
        public int TotalChaptersCount { get; set; }

        public int ChapterCollectionsCount { get; set; }

        public AuthorDTO Author { get; set; }

        public string OwnerId { get; set; }
        public ICollection<TagDTO> Tags { get; set; } = new List<TagDTO>();

        public int? ChatId { get; set; }

        public int RatingsCount { get; set; }
        public double TotalRating { get; set; }
        public bool IsRatingClosed { get; set; }


        public VisibilityStatusDTO VisibilityStatus { get; set; }
        public ChaptersCreatingStatusDTO ChaptersCreationStatus { get; set; }
        public ChaptersAccessibilityDTO ChaptersAccessibility { get; set; }
    }
}
