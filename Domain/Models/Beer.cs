using System;

namespace Domain.Models
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsObsolete { get; set; }
        public Brewery Brewery { get; set; }
    }
}
