using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Configurations
{
    //once mapping is added here, register it in program.cs as well
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap(); //reversemap can be skipped if we don't want reverse mapping
        }
    }
}
