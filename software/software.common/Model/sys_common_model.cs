﻿namespace software.common.Model
{
    public class sys_common_string_model
    {
        public string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }
    public class sys_common_number_model
    {
        public long id { get; set; }
        public string name { get; set; }
        public long? id_tinh { get; set; }
        public long? value { get; set; }
        public string code { get; set; }
        public string link { get; set; }
        public string image { get; set; }
    }
}
