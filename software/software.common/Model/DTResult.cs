using System.Collections.Generic;

namespace software.common.Model
{
    public class DTResult<T>
    {
        public DTResult() { }
        public int draw { get; set; }
        public int start { get; set; }
        public long recordsTotal { get; set; }
        public long recordsFiltered { get; set; }
        public List<T> data { get; set; } = new List<T>();
    }
}
