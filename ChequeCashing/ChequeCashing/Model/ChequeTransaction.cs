using SQLite;
using System;

namespace ChequeCashing.Model
{
    [Table("ChequeTransaction")]
    public class ChequeTransaction : BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ChequeNumber { get; set; }
        public string Status { get; set; }
        public string From { get; set; }
        public string ToPersonName { get; set; }
        public int Amount { get; set; }
        public string To { get; set; }
        public string RemainingAmount { get; set; }
        public DateTime DateOnCheque { get; set; }
        public string DateOfSubmission { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
    }
}
