using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prestige_eSportsAPI.Data.Models
{
    public class Log
    {
        [Key]
        public long LogId { get; set; }
        public string RequestIpAddress { get; set; }
        public string RequestUri { get; set; }
        public string RequestPostData { get; set; }
        public DateTime? RequestTimestamp { get; set; }
        public string ResponseStatusCode { get; set; }
        public string ResponseReasonPhrase { get; set; }
        public string ResponseErrorMessage { get; set; }
        public DateTime? ResponseTimestamp { get; set; }
    }
}
