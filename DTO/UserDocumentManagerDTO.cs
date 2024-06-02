using Microsoft.CodeAnalysis;
using System.Reflection.Metadata;
using WatchMNS.Models;
using Document = WatchMNS.Models.Document;


namespace WatchMNS.DTO
{
    public class UserDocumentManagerDTO
    {
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public IFormFile File { get; set; }
    }
}
