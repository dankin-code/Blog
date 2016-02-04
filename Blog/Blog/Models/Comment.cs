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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string CommentContent { get; set; }

        public DateTime CommentCreationDate { get; set; }

        public int AuthorId { get; set; }

        public int PostId { get; set; }

        public DateTime CommentUpdateDate { get; set; }

        public bool MarkForDeletion { get; set; }

        [Required]
        [StringLength(500)]
        public string CommentUpdateReason { get; set; }

        public int EditorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
