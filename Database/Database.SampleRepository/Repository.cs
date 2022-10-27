using Database.Application;
using Database.SampleRepository.Models;

namespace Database.SampleRepository;

public class Repository : ISampleRepository
{
    private readonly SchoolContext _schoolContext;

    public Repository(SchoolContext schoolContext)
    {
        _schoolContext = schoolContext;
    }

    public Application.Model.Student AddSudent(Application.Model.Student student)
    {
        _schoolContext.Students.Add(new Student()
        {
            FirstMidName = student.FirstMidName,
            LastName = student.LastName,
            EnrollmentDate = student.EnrollmentDate,
        });

        _schoolContext.SaveChanges();
        
        return student;
    }

    public IReadOnlyCollection<Application.Model.Student> GetStudents()
    {
        var students = _schoolContext.Students.ToList();

        List<Application.Model.Student> result = new();

        students.ForEach(s => result.Add(new Application.Model.Student()
        {
            ID = s.ID,
            FirstMidName = s.FirstMidName,
            LastName = s.LastName,
            EnrollmentDate = s.EnrollmentDate            
        }));

        return result;
    }
}