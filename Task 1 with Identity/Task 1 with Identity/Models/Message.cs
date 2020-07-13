using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1_with_Identity.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Feedback { get; set; }
        public DateTime dateTime { get; set; }

    }
}