using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }

        /******************** DESK OBJ PROPERTIES ********************/
        [Required]
        [Range(24, 96,
            ErrorMessage = "Must be between 24 and 96.")]
        [Display(Name = "Width")]
        public int Width { get; set; } = 24;

        [Required]
        [Range(12, 48,
            ErrorMessage = "Must be between 12 and 48.")]
        [Display(Name = "Depth")]
        public int Depth { get; set; } = 12;

        [Required]
        [Range(0, 7,
            ErrorMessage = "Must be between 0 and 7.")]
        [Display(Name = "Drawer Count")]
        public int DrawerCount { get; set; } = 0;


        [Required]
        [EnumDataType(typeof(DesktopMaterial),
            ErrorMessage = "Please enter a valid Desktop Material option.")]
        [Display(Name = "Desktop Material")]
        public DesktopMaterial DesktopMaterial { get; set; } = DesktopMaterial.Pine;

        // RegExp for "is one of 3, 5, 7, or 14"
        [Required]
        [RegularExpression(@"\b(3|5|7|14){1}\b",
            ErrorMessage = "Must be 3, 5, 7, or 14.")]
        [Display(Name = "Production Days")]
        public int ProductionDays { get; set; } = 14;

        /******************** QUOTE OBJ PROPERTIES ********************/
        [Required]
        [StringLength(30, MinimumLength = 1,
            ErrorMessage = "First name must not be empty!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(30, MinimumLength = 1,
            ErrorMessage = "Last name must not be empty!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Editable(false, AllowInitialValue = false)]
        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; } = DateTime.Now;
        
        [Range(0, double.MaxValue)]
        [Editable(false, AllowInitialValue = false)]
        public decimal Value { get; set; } // set, use CalculateQuote() to set this.Value
    }

    public enum DesktopMaterial
    {
        Pine,
        Laminate,
        Veneer,
        Oak,
        Rosewood
    }
}
