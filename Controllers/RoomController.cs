using hoteldb.DTOs;
using hoteldb.Models;
using hoteldb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hotel.Controllers;


[ApiController]
[Route("Controller")]

public class RoomController : ControllerBase
{
    private readonly ILogger<RoomController> _logger;
    private readonly IRoomRepository _room;
    private readonly IRoomServiceStaffRepository _roomservicestaff;


    public RoomController(ILogger<RoomController> logger, IRoomRepository room, IRoomServiceStaffRepository roomservicestaff)
    {
        _logger = logger;
        _room = room;
        _roomservicestaff = roomservicestaff;
    }
    [HttpGet]
    public async Task<ActionResult<List<RoomDTO>>> GetAllUsers()
    {
        var usersList = await _room.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpPost]
    public async Task<ActionResult<RoomDTO>> CreateRoom([FromBody] RoomCreateDTO Data)
    {
        var roomservicestaff = await _roomservicestaff.GetById(Data.StaffId);
        if (roomservicestaff is null)
            return NotFound("No user found with given staff id");
        var toCreateRoom = new Room
        {
            RoomId = Data.RoomId,
            RoomType = Data.RoomType,
            RoomNo = Data.RoomNumber,
            StaffId = Data.StaffId,
            RoomRate = Data.RoomRate,
        };
        var createdRoom = await _room.Create(toCreateRoom);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpGet("{room_id}")]
    public async Task<ActionResult<RoomDTO>> GetRoomById([FromRoute] long room_id)
    {
        var room = await _room.GetById(room_id);

        if (room is null)
            return NotFound("No user found with given room id");
        var dto = room.asDTO;
        dto.RoomServiceStaff = await _room.GetAllForRoom(room.RoomId);
        return Ok(dto);
     }
     [HttpPut("{room_id}")]
      public async Task<ActionResult> UpdateUser([FromRoute] long room_id,
       [FromBody] RoomUpdateDTO Data)
     {
        var existing = await _room.GetById(room_id);
        if (existing is null)
            return NotFound("No user found with given room id");

        var toUpdateRoom = existing with
        {
            RoomType = Data.RoomType,
            RoomNo = Data.RoomNo

        };

        var didUpdate = await _room.Update(toUpdateRoom);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }

    [HttpDelete("{room_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long room_id)
    {
        var existing = await _room.GetById(room_id);
        if (existing is null)
            return NotFound("No user found with given room id");

        var didDelete = await _room.Delete(room_id);

        return NoContent();
    }
}
