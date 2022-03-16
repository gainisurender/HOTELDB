using hoteldb.DTOs;
using hoteldb.Models;
using hoteldb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hoteldb.Controllers;


[ApiController]
[Route("api/StayScheduleController")]

public class StayScheduleController : ControllerBase
{
    private readonly ILogger<StayScheduleController> _logger;
    private readonly IStayScheduleRepository _stayschedule;

    public StayScheduleController(ILogger<StayScheduleController> logger, IStayScheduleRepository stayschedule)
    {
        _logger = logger;
        _stayschedule = stayschedule;
    }
    [HttpGet]
    public async Task<ActionResult<List<StayScheduleDTO>>> GetAllUsers()
    {
        var usersList = await _stayschedule.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpPost]
    public async Task<ActionResult<StayScheduleDTO>> CreateStaySchedule([FromBody] StayScheduleCreateDTO Data)
    {
        var toCreateStaySchedule = new StaySchedule
        {
            StayScheduleId = Data.StayScheduleId,
            RoomId = Data.RoomId,
            GuestId = Data.GuestId,
            CheckIn = Data.CheckIn,
            CheckOut = Data.CheckOut
        };
        var createdRoom = await _stayschedule.Create(toCreateStaySchedule);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpGet("{stayschedule_id}")]
    public async Task<ActionResult<StayScheduleDTO>> GetUserById([FromRoute] long stayschedule_id)
    {
        var user = await _stayschedule.GetById(stayschedule_id);

        if (user is null)
            return NotFound("No user found with given stay schedule id");

        return Ok(user.asDTO);
    }
    // [HttpPut("{stay_schedule_id}")]
    // public async Task<ActionResult> UpdateUser([FromRoute] long stay_schedule_id,
    //    [FromBody] StayScheduleUpdateDTO Data)
    // {
    //     var existing = await _stayschedule.GetById(stay_schedule_id);
    //     if (existing is null)
    //         return NotFound("No user found with given room id");

    //     var toUpdateRoom = existing with
    //     {
    //         RoomType = Data.RoomType,
    //         RoomNumber = Data.RoomNumber

    //     };

    //     var didUpdate = await _room.Update(toUpdateRoom);

    //     if (!didUpdate)
    //         return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

    //     return NoContent();
    // }

    [HttpDelete("{stayschedule_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long stayschedule_id)
    {
        var existing = await _stayschedule.GetById(stayschedule_id);
        if (existing is null)
            return NotFound("No user found with given stay schedule id");

        var didDelete = await _stayschedule.Delete(stayschedule_id);

        return NoContent();
    }
}
