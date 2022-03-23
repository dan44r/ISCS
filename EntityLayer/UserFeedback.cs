using System;

namespace EntityLayer
{
    public class UserFeedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool IsPriority { get; set; }
        public string CommentType { get; set; }
        public string CommentOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CommentDate { get; set; }
        public string Comment { get; set; }
    }
}
