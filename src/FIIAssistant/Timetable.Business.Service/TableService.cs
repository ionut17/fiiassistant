using Timetable.Business.Repository;

namespace Timetable.Business.Service
{
    public class TableService
    {
        private readonly GroupTimetableRepository _groupTimetableRepository;

        public TableService(GroupTimetableRepository groupTimetableRepository)
        {
            _groupTimetableRepository = groupTimetableRepository;
        }
    }
}