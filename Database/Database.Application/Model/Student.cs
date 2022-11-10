using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Application.Model
{
    public class Student
    {
        public int ID { get; init; }
        required public string LastName { get; init; }
        required public string FirstMidName { get; init; }
        required public DateTime EnrollmentDate { get; init; }

        public override string ToString()
        {
            return $"{ID}, {FirstMidName} {LastName} {EnrollmentDate}";
        }
    }
}
