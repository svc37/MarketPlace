using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public class BidViewModel
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Display(Name = "Bidder Id")]
        public int SupplierId { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Time")]
        public string Time { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        [DataType(DataType.Text)]
        public string CreatedBy { get; set; }

        [Display(Name = "Accepted By")]
        [DataType(DataType.Text)]
        public string AcceptedBy { get; set; }

        [Display(Name = "Accepted Date")]
        public DateTime? AcceptedDate { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "DeclineReason")]
        public string DeclineReason { get; set; }

        public bool Declined { get; set; }



    }
}