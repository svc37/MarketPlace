using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public class ProjectViewModel
    {
        [Required]
        public int Id { get; set; }

        public int CompanyId { get; set; }

        [DataType(DataType.Text)]
        public string FileName { get; set; }

        [Display(Name = "File")]
        public HttpPostedFileBase CadFile { get; set; }

        [Display(Name = "Accepted Bidder")]
        public int? SupplierId { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        [DataType(DataType.Text)]
        public string CreatedBy { get; set; }

        [Display(Name = "Edited Date")]
        public DateTime? EditedDate { get; set; }

        [Display(Name = "Edited By")]
        [DataType(DataType.Text)]
        public string EditedBy { get; set; }

        [Display(Name = "Accepted By")]
        [DataType(DataType.Text)]
        public string AcceptedBy { get; set; }

        [Display(Name = "Accepted Date")]
        public DateTime? AcceptedDate { get; set; }

        [Required(ErrorMessage = "Please select a machine type")]
        [DataType(DataType.Text)]
        [Display(Name = "Machine Type")]
        public MachineType MachineType { get; set; }

        [Required(ErrorMessage ="Please enter a quantity")]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Material")]
        public string Material { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Dimensions")]
        public string Dimensions { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Tolerance")]
        public string Tolerance { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Volume")]
        public string Volume { get; set; }

    }
}