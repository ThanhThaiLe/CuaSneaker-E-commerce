﻿public interface IBaseCommon
{
    public string note { get; set; }
    public string create_by { get; set; }
    public DateTime? create_date { get; set; }
    public string update_by { get; set; }
    public DateTime? update_date { get; set; }
    public int? status_del { get; set; }
}