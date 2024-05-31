using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class UserDocumentManagerViewModel
    {
        public Client User { get; set; }
        public List<Document> Documents { get; set; }
        public Document NewDocument { get; set; }
        public IFormFile File { get; set; }
    }
}
