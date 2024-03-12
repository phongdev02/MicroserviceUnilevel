using Microsoft.AspNetCore.Routing.Constraints;

namespace ReadFile.Models.Dto
{
    public class FileDto
    {
        public Stream? Stream { get; set; }
        public string contentType { get; set; }
        public string? fileName { get; set; }

        public FileDto(Stream _stream , string _contentType, string _fileName, string typeFile) { 
            Stream = _stream;
            contentType = _contentType;
            fileName = _fileName.ToString().Trim() + "." + typeFile.ToString().Trim();
        }
    }
} 
