using hoteldb.DTOs;
using hoteldb.Models;
using hoteldb.Repositories;
using Microsoft.AspNetCore.Mvc;
using static hoteldb.DTOs.RoomServiceStaffDTO;

namespace hoteldb.Controllers;


[ApiController]
[Route("api/Controller")]

public class RoomServiceStaffController : ControllerBase
{
    private readonly ILogger<RoomServiceStaffController> _logger;
    private readonly IRoomServiceStaffRepository _roomservicestaff;

    public RoomServiceStaffController(ILogger<RoomServiceStaffController> logger, IRoomServiceStaffRepository roomServiceStaff)
    {
        _logger = logger;
        _roomservicestaff = roomServiceStaff;
    }
    [HttpGet]
    public async Task<ActionResult<List<RoomServiceStaffDTO>>> GetAllUsers()
    {
        var usersList = await _roomservicestaff.GetList();

        
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpPost]
    public async Task<ActionResult<RoomServiceStaffDTO>> CreateRoomServiceStaff([FromBody] RoomServiceStaffCreateDTO Data)
    {
        var toCreateRoomServiceStaff = new RoomServiceStaff
        {
            StaffId = Data.StaffId,
            StaffName = Data.StaffName,
            StaffAddress = Data.StaffAddress,
            ContactNumber = Data.ContactNumber,
            Gender = Data.Gender,
            StaffZipCode = Data.StaffZipCode
        };
        var createdRoomServiceStaff = await _roomservicestaff.Create(toCreateRoomServiceStaff);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpGet("{staff_id}")]
    public async Task<ActionResult<RoomServiceStaffDTO>> GetUserById([FromRoute] long staff_id)
    {
        var user = await _roomservicestaff.GetById(staff_id);

        if (user is null)
            return NotFound("No user found with given Staff id");

        return Ok(user.asDTO);
    }
    [HttpPut("{staff_id}")]
    public async Task<ActionResult> UpdateRoomServiceStaff([FromRoute] long staff_id,
       [FromBody] RoomServiceStaffUpdateDTO Data)
    {
        var existing = await _roomservicestaff.GetById(staff_id);
        if (existing is null)
            return NotFound("No user found with given staff id");

        var toUpdateRoomServiceStaff = existing with
        {
            StaffName = Data.StaffName,
            StaffAddress = Data.StaffAddress,

        };

        var didUpdate = await _roomservicestaff.Update(toUpdateRoomServiceStaff);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update RoomServiceStaff");

        return NoContent();
    }

    [HttpDelete("{staff_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long staff_id)
    {
        // var existing = await _roomservicestaff.Delete(staff_id);
        // if (existing is null)
        //     return NotFound("No user found with given staff id");

        var didDelete = await _roomservicestaff.Delete(staff_id);

        return NoContent();
    }
}
