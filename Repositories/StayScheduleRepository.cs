using Dapper;
using hoteldb.DTOs;
using hoteldb.Models;

namespace hoteldb.Repositories;

public interface IStayScheduleRepository
{
    Task<StaySchedule> Create(StaySchedule Item);

    Task<bool> Delete(long StayScheduleId);
    Task<StaySchedule> GetById(long StayScheduleId);
    Task<List<StaySchedule>> GetList();
    Task<List<StayScheduleDTO>> GetAllForGuest(long GuestId);


}
public class StayScheduleRepository : BaseRepository, IStayScheduleRepository
{
    public StayScheduleRepository(IConfiguration configuration) : base(configuration)
    {
    }
    public async Task<StaySchedule> Create(StaySchedule Item)
    {
        var query = $@"Insert Into stayschedule(stayschedule_id,room_id,guest_id,check_in,check_out)VALUES(@StayScheduleId,@RoomId,@GuestId,@CheckIn,@CheckOut) RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<StaySchedule>(query, Item);
            return res;
        }
    }

    public async Task<bool> Delete(long StayScheduleId)
    {
        var query = $@"DELETE FROM stayschedule WHERE stayschedule_id = @StayScheduleId";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, new { StayScheduleId });
            return result > 0;

        }
    }

    // public Task<bool> Delete(long StayScheduleId)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<StaySchedule> GetById(long StayScheduleId)
    {
        var query = $@"SELECT * FROM stayschedule WHERE stayschedule_id = @StayScheduleId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<StaySchedule>(query, new { StayScheduleId });
    }

    public async Task<List<StaySchedule>> GetList()
    {
        var query = $@"SELECT * FROM stayschedule";
        List<StaySchedule> result;
        using (var con = NewConnection)
            result = (await con.QueryAsync<StaySchedule>(query)).AsList();
        return result;
    }

    public async Task<List<StayScheduleDTO>> GetAllForGuest(long GuestId)
    {
        var query = $@"SELECT * FROM stayschedule WHERE guest_id = @GuestId";
        using (var con = NewConnection)
          
          return (await con.QueryAsync<StayScheduleDTO>(query, new {GuestId})).AsList();
    }

   
}

