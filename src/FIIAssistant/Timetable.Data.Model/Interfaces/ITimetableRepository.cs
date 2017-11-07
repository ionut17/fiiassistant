using System;
using System.Linq;
using Timetable.Data.Model.Common;

namespace Timetable.Data.Model.Interfaces
{
    public interface ITimetableRepository<TEntity> where TEntity : Entity
    {
        TEntity GetTimetable();

    }
}