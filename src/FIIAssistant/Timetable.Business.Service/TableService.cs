using Timetable.Business.Repository;
using Timetable.Data.Model.Common;

namespace Timetable.Business.Service
{
    public class TableService
    {
        private readonly TimetableRepository<GroupRequest> _timetableRepository;

        public TableService(TimetableRepository<GroupRequest> timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }
    }
}