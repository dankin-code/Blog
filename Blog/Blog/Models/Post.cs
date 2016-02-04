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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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
        [DataType(DataType.ImageUrl)]
        public string MediaUrl { get; set; }

        [DataType(DataType.Upload)]
        HttpPostedFileBase ImageUpload { get; set; }

        public bool Published { get; set; }

        public int AuthorId { get; set; }

        public DateTime PostUpdateDate { get; set; }

        [Required]
        [StringLength(500)]
        public string PostUpdateReason { get; set; }

        public int EditorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
