using System;
using System.Linq;
using Timetable.Data.Model.Common;

namespace Timetable.Data.Model.Interfaces
{
    public interface ITimetableRepository<TEntity, TTimetable> where TEntity : Entity
    {
        TTimetable GetTimetable(TEntity entity);

    }
}