namespace unilevel.Web.Models
{
    public class MailContent
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; } 
        
        public MailContent() { }

        public MailContent(string to, string sub, string body) { 
            this.to = to;
            this.subject = sub;
            this.body = body;
        }
    }
}
