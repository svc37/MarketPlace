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

        [ValidateFile]
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

        [Range(1, int.MaxValue, ErrorMessage = "Select a Machine Type")]
        [Display(Name = "Machine Type")]
        public EnumHelper.MachineType MachineType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select Material")]
        [Display(Name = "Material")]
        public EnumHelper.Material Material { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Dimensions")]
        public string Dimensions { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

    }
}