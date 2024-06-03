using WatchMNS.Models;

namespace WatchMNS.ViewModel
{
    public class AdminDocumentManagerViewModel
    {
        public Client User { get; set; }
        public List<Document> Documents { get; set; }
        public Dictionary<Document,string> DocumentsWithExtensions { get; set; }
    }
}
