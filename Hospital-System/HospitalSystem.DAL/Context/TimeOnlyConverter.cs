using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalSystem.DAL.Context;

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(), 
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    { }
}