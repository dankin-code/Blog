namespace Blog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;


    [Table("Comment")]
    public partial class Comment
    {
        public Comment()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(5000)]
        public string CommentContent { get; set; }

        public DateTimeOffset CommentCreationDate { get; set; }

        public string AuthorId { get; set; }

        public string PostId { get; set; }

        public DateTimeOffset CommentUpdateDate { get; set; }

        public bool MarkForDeletion { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(500)]
        public string CommentUpdateReason { get; set; }

        public string EditorId { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
