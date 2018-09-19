using System;

namespace ElectionSystem.Models
{
    public class BaseModel
    {
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public User ModifiedBy { get; set; }
    }
}
