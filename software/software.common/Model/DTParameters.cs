namespace software.common.Model
{
    public class DTParameters
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DTColumn[] Columns { get; set; }
        public Order[] Orders { get; set; }
        public DTSearch Search { get; set; }
        public string SortOrder
        {
            get
            {
                return Columns != null && Orders != null && Orders.Length > 0
                        ? (Columns[Orders[0].Column].Data + (Orders[0].Dir == DTOrderDir.DESC ? " " + Orders[0].Dir : string.Empty)) : null;
            }
        }
    }
    public class DTColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DTSearch Search { get; set; }
    }
    public class Order
    {
        public int Column { get; set; }
        public DTOrderDir Dir { get; set; }
    }
    public enum DTOrderDir
    {
        ASC,
        DESC,
    }
    public class DTSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

}
