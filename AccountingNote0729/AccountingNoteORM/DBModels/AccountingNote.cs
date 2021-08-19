namespace AccountingNoteORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountingNote")]
    public partial class AccountingNote
    {
        public int ID { get; set; }

        public Guid UserID { get; set; }

        [StringLength(100)]
        public string Caption { get; set; }

        public int Amount { get; set; }

        public int ActType { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(500)]
        public string Body { get; set; }
    }
}
