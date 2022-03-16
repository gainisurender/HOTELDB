namespace hoteldb.Models;
using hoteldb.DTOs;

public record Guest
{

    public long GuestId { get; set;}
    public String GuestName { get; set;}
    public String GuestDetails { get; set;}
    public String GuestCity { get; set;}
    public String GuestState { get; set;}

    public GuestDTO asDTO => new GuestDTO
    {
        GuestId = GuestId,
        GuestName =GuestName,
        GuestDetails =GuestDetails,
        GuestCity = GuestCity,
        GuestState = GuestState,
    };
}






    


