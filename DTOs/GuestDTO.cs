using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hoteldb.DTOs;

public record GuestDTO
{
    [JsonPropertyName("guest_id")]
    public long GuestId { get; set;}

    [JsonPropertyName("guest_name")]
    public String GuestName { get;set;}

    [JsonPropertyName("guest_details")]
    public String GuestDetails { get;set;}
    
    [JsonPropertyName("guest_City")]
    public String GuestCity { get;set;}
    
    [JsonPropertyName("guest_State")]
    public String GuestState { get; set; }
   
    [JsonPropertyName("stay_schedule")]

    public List<StayScheduleDTO> StaySchedule { get; internal set;}

    
    
    


}



public record GuestCreateDTO
{
    [JsonPropertyName("guest_id")]
    [Required]
    public long GuestId { get; set;}

    [JsonPropertyName("guest_name")]
    [Required]
    public String GuestName { get; set; }

    [JsonPropertyName("guest_details")]
    [Required]
    public String GuestDetails { get; set;}

    [JsonPropertyName("guest_city")]
    [Required]
    public String GuestCity { get;set;}
    
    [JsonPropertyName("guest_state")]
    [Required]
    public String GuestState { get;set;}

}
public record GuestUpdateDTO
{
    [JsonPropertyName("guest_name")]
    public String GuestName { get; set;}

    [JsonPropertyName("guest_details")]
    public String GuestDetails { get; set;}
}