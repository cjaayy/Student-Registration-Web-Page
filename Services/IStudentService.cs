using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentService
    {
        IReadOnlyList<Student> GetAll();
        Student? GetByStudentNumber(string studentNumber);
        Student Add(Student student);
        bool Update(Student student);
        bool Delete(string studentNumber);
        IReadOnlyList<Student> Search(string? query, string? program, string? yearLevel);
        DashboardStats GetStats();
    }
}
