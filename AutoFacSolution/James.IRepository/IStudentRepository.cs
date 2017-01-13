using James.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace James.IRepository
{
   public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
    }
}
