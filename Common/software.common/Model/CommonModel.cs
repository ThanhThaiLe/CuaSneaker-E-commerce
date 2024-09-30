using System.Collections.Generic;

namespace software.common.Model
{
    public class CommonModel
    {
    }
    public class cell
    {

        public string value { get; set; }
    }
    public class row
    {
        public row()
        {
            list_cell = new List<cell>();
        }


        public string key { get; set; }
        public List<cell> list_cell { get; set; }
    }
}
