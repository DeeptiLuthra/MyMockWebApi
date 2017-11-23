using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMockWebApi.Models
{
    public class EventData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string ImageUrl { get; set; }
        public int AvailableSeats { get; set; }
        public string Location { get; set; }
    }
}