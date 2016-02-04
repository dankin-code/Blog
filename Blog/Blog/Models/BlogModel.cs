namespace Blog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogModel : DbContext
    {
        public BlogModel()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasMany(e => e.Posts)
                .WithMany(e => e.Comments)
                .Map(m => m.ToTable("PostCommentJunction").MapLeftKey("CommentId").MapRightKey("PostId"));
        }
    }
}
