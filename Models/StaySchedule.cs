using hoteldb.DTOs;

namespace hoteldb.Models;

public record StaySchedule
{
    public long StayScheduleId { get; set; }
    public long RoomId { get; set; }
    public long GuestId { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }

 public StayScheduleDTO asDTO => new StayScheduleDTO
    {
       StayScheduleId =StayScheduleId,
       RoomId =RoomId,
       GuestId =GuestId,
       CheckIn =CheckIn,
       CheckOut =CheckOut,
    };
}