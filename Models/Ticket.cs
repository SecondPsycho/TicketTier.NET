using System.ComponentModel.DataAnnotations;

namespace TicketTier.Models;

public class Ticket {
    public int ID { get; set; }
    public int Order { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }

}

//dotnet aspnet-codegenerator controller -name TicketsController -m Ticket -dc TicketTier.Data.TicketTierContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite