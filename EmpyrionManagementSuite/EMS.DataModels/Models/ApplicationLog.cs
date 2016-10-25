using System;

namespace EMS.DataModels.Models
{
    public class ApplicationLog
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string AdditionalInfo { get; set; }
    }
}