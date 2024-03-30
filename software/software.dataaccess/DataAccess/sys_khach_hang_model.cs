using System.Collections.Generic;

namespace software.repo.DataAccess
{
    public class sys_khach_hang_model
    {
        public sys_khach_hang_model()
        {
            tags = new List<string>();
        }
        public string id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string background { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string notes { get; set; }
        public List<string> tags { get; set; }
    }
}
