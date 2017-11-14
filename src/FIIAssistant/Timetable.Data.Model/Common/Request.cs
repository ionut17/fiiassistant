using Timetable.Data.Model.Interfaces;

namespace Timetable.Data.Model.Common
{
    public abstract class Request : Entity, IRequest
    {

        public string BaseAddress { get; set; }

        public abstract string GetAddress();
    }
}