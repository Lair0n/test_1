namespace test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reviews
    {
        public int ID { get; set; }

        public int? GuestID { get; set; }

        public string Text { get; set; }

        public int? Rating { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublishDate { get; set; }

        public virtual Guests Guests { get; set; }
    }
}
