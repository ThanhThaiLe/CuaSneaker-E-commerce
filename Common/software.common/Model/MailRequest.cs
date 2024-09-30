using System.Collections.Generic;

namespace software.common.Model
{
    public class MailRequest
    {
        public string toEmail { get; set; }
        public string ccEmail { get; set; }
        public string subJect { get; set; }
        public string body { get; set; }
        public string Attachment { get; set; }
        public List<string> Attachments { get; set; }

    }
}
