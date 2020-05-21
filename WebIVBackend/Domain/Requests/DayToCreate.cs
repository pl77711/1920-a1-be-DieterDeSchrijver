using System;

namespace WebIVBackend.Domain.Models
{
    public class DayToCreate
    {
        public DateTime date { get; set; }
        public string menu { get; set; }
        public int maxUsers { get; set; }
    }
}