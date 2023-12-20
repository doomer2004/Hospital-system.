using HospitalSystem.Common.Enum;
using HospitalSystem.DAL;
using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Repository.Interfaces;

namespace BLL.UnitTest.Tests.Mock;

public class MockFabric
{
    private readonly List<Doctor> _doctors;
    private readonly List<Specialty> _specialties;

    public MockFabric()
    {

        _specialties = new List<Specialty>()
        {
            new Specialty()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                TypeOfSpecialty = "Allergist"

            }
        };
        _doctors = new List<Doctor>()
        {
            new Doctor()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                FullName = "Test",
                StartTime = TimeOnly.MinValue,
                EndTime = TimeOnly.MaxValue,
                Specialties = new List<Specialty>()
                {
                    _specialties.Find(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                }
            }
        };
    }

    private Mock<IRepository<T>> GetRepositoryMock<T>(List<T> entities) where T : class
    {
        var repository = new Mock<IRepository<T>>();
        var mock = entities.BuildMock();
    }
}