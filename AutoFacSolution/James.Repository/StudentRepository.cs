using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using James.Entity;
using James.IRepository;
namespace James.Repository
{
   public class StudentRepository:IStudentRepository
    {
        public IEnumerable<Student> GetStudents()
        {
            return new[]
                      {
                           new Student {Id = 1, Name = "Sam", Age = 14},
                            new Student {Id = 2, Name = "JamesHu", Age = 15}
                       };
        }
    }
}
