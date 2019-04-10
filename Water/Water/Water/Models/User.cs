using System;

namespace Water.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WaterBalance { set; get; }
        public string Consultation { set; get; }
    }
}