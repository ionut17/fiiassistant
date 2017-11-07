using Timetable.Data.Model.Interfaces;

namespace Timetable.Data.Model.Common
{
    public abstract class Timetable : Entity, ITimetable
    {
        public Timetable() { }

        public Timetable(string baseAddress)
        {
            BaseAddress = baseAddress;
        }

        public string BaseAddress { get; set; }

        public string GetAddress()
        {
            return BaseAddress;
        }
    }
}