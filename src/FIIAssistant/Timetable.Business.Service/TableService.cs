using Timetable.Business.Repository;
using Timetable.Data.Model.Common;

namespace Timetable.Business.Service
{
    public class TableService
    {
        private readonly TimetableRepository<GroupRequest> _timetableRepository;

        public TableService()
        {
            _timetableRepository = new TimetableRepository<GroupRequest>();
        }

        public WeekTimetable GetTimetable(GroupRequest request)
        {
            return _timetableRepository.GetTimetable(request);
        }
    }
}