using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public ICollection<Comment> ChildComments { get; set; }

        public Comment()
        {
            ChildComments = new List<Comment>();
        }

    }
}