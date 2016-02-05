namespace Blog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Web.Mvc;


    [Table("Post")]
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public DateTime PostCreationDate { get; set; }

        [Required]
        [StringLength(500)]
        public string PostTitle { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(5000)]
        public string PostContent { get; set; }

        [Required]
        public string MediaUrl { get; set; }

        public bool Published { get; set; }

        public int AuthorId { get; set; }

        public DateTime PostUpdateDate { get; set; }

        [StringLength(500)]
        public string PostUpdateReason { get; set; }

        public int EditorId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
