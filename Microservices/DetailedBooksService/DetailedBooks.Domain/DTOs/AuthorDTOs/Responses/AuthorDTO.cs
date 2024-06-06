using DetailedBooks.Domain.DTOs.ImageDTOs;
using DetailedBooks.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.DTOs.AuthorDTOs.Responses
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ImageDTO? Image { get; set; }
    }
}
