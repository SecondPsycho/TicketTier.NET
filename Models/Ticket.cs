using System.ComponentModel.DataAnnotations;

namespace TicketTier.Models;

public class Ticket {
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }

}