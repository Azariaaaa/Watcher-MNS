namespace WatchMNS
{
    public static class MimeMapping
    {
        private static readonly Dictionary<string, string> Mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {".pdf", "application/pdf"},
        {".jpg", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".png", "image/png"},
    };

        public static string GetMimeMapping(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return extension != null && Mappings.ContainsKey(extension) ? Mappings[extension] : "application/octet-stream";
        }
    }
}
