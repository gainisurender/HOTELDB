using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hoteldb.DTOs;

public record RoomDTO
{
    [JsonPropertyName("room_id")]
    public long RoomId { get; set; }
    [JsonPropertyName("room_type")]
    public long RoomType { get; set; }
    [JsonPropertyName("room_number")]
    public long RoomNumber { get; set; }
    [JsonPropertyName("staff_id")]
    public long StaffId { get; set; }
    
    [JsonPropertyName("room_rate")]
    public long RoomRate { get; set; }


     public List<RoomServiceStaffDTO> RoomServiceStaff { get; internal set; }
}
public record RoomCreateDTO
{
    [JsonPropertyName("room_id")]
    [Required]

    public long RoomId { get; set; }

    [JsonPropertyName("room_type")]
    [Required]

    public long RoomType { get; set; }

    [JsonPropertyName("room_no")]
    [Required]
    public long RoomNumber { get; set; }

    [JsonPropertyName("Staff_id")]
    [Required]
    public long StaffId { get; set; }
    [JsonPropertyName("room_rate")]
    [Required]
    public long RoomRate { get; set;}

}
public record RoomUpdateDTO
{
    [JsonPropertyName("room_no")]

    public long RoomNo { get; set; }

    [JsonPropertyName("room_type")]
    public long RoomType { get; set; }

}