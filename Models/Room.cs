using hoteldb.DTOs;

namespace hoteldb.Models;

public record Room
{
    public long RoomId { get; set; }
    public long RoomType { get; set; }
    public long RoomNo { get; set; }
    public long StaffId { get; set; }
    public long RoomRate { get; set; }
    public RoomDTO asDTO => new RoomDTO
    {
        RoomId =RoomId,
        RoomType =RoomType,
        RoomNumber =RoomNo,
        StaffId =StaffId,
        RoomRate = RoomRate,
    };
}