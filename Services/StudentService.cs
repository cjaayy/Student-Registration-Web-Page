using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new();
        private readonly object _lock = new();
        private int _sequenceNumber = 100;

        public StudentService()
        {
            SeedInitialData();
        }

        private void SeedInitialData()
        {
            var seedList = new List<Student>
            {
                new Student
                {
                    StudentNumber = "2026-00101-BN-0",
                    FirstName = "Maria Clara",
                    MiddleInitial = "L",
                    LastName = "Santos",
                    Email = "mcsantos@iskolarngbayan.pup.edu.ph",
                    ContactNumber = "0917-123-4567",
                    CompleteAddress = "Brgy. Malaking Bato, Mariveles, Bataan",
                    Sex = "Feminine",
                    Birthday = "04/15/2004",
                    Program = "BSIT",
                    YearLevel = "4th Year",
                    Status = "Enrolled",
                    RegistrationDate = DateTime.Now.AddDays(-12),
                    EmergencyContactName = "Clara Santos (Mother)",
                    EmergencyContactNumber = "0918-987-6543"
                },
                new Student
                {
                    StudentNumber = "2026-00102-BN-0",
                    FirstName = "Juan",
                    MiddleInitial = "P",
                    LastName = "Dela Cruz",
                    Email = "jdelacruz@iskolarngbayan.pup.edu.ph",
                    ContactNumber = "0920-555-7890",
                    CompleteAddress = "Poblacion, Balanga City, Bataan",
                    Sex = "Masculine",
                    Birthday = "08/21/2005",
                    Program = "BSIE",
                    YearLevel = "3rd Year",
                    Status = "Enrolled",
                    RegistrationDate = DateTime.Now.AddDays(-8),
                    EmergencyContactName = "Pedro Dela Cruz (Father)",
                    EmergencyContactNumber = "0921-222-3344"
                },
                new Student
                {
                    StudentNumber = "2026-00103-BN-0",
                    FirstName = "Alyssa",
                    MiddleInitial = "M",
                    LastName = "Valdez",
                    Email = "amvaldez@iskolarngbayan.pup.edu.ph",
                    ContactNumber = "0919-444-1234",
                    CompleteAddress = "Alas-asin, Mariveles, Bataan",
                    Sex = "Feminine",
                    Birthday = "01/10/2005",
                    Program = "BSA",
                    YearLevel = "2nd Year",
                    Status = "Enrolled",
                    RegistrationDate = DateTime.Now.AddDays(-5),
                    EmergencyContactName = "Elena Valdez (Mother)",
                    EmergencyContactNumber = "0919-888-9900"
                },
                new Student
                {
                    StudentNumber = "2026-00104-BN-0",
                    FirstName = "Christian Jay",
                    MiddleInitial = "D",
                    LastName = "Reyes",
                    Email = "cjreyes@iskolarngbayan.pup.edu.ph",
                    ContactNumber = "0928-888-2345",
                    CompleteAddress = "Townsite, Limay, Bataan",
                    Sex = "Masculine",
                    Birthday = "11/03/2003",
                    Program = "BSIT",
                    YearLevel = "4th Year",
                    Status = "Enrolled",
                    RegistrationDate = DateTime.Now.AddDays(-2),
                    EmergencyContactName = "Divina Reyes (Mother)",
                    EmergencyContactNumber = "0928-111-2233"
                },
                new Student
                {
                    StudentNumber = "2026-00105-BN-0",
                    FirstName = "Kathryn",
                    MiddleInitial = "B",
                    LastName = "Bernardo",
                    Email = "kbernardo@iskolarngbayan.pup.edu.ph",
                    ContactNumber = "0915-777-3456",
                    CompleteAddress = "Lamao, Limay, Bataan",
                    Sex = "Feminine",
                    Birthday = "03/26/2006",
                    Program = "BSBA",
                    YearLevel = "1st Year",
                    Status = "Enrolled",
                    RegistrationDate = DateTime.Now.AddHours(-18),
                    EmergencyContactName = "Min Bernardo (Mother)",
                    EmergencyContactNumber = "0915-444-5566"
                },
                new Student
                {
                    StudentNumber = "2026-00106-BN-0",
                    FirstName = "Mark Joshua",
                    MiddleInitial = "H",
                    LastName = "Cruz",
                    Email = "mjcruz@iskolarngbayan.pup.edu.ph",
                    ContactNumber = "0916-999-8811",
                    CompleteAddress = "Kitang 1, Limay, Bataan",
                    Sex = "Masculine",
                    Birthday = "06/18/2004",
                    Program = "BEED",
                    YearLevel = "3rd Year",
                    Status = "Enrolled",
                    RegistrationDate = DateTime.Now.AddHours(-6),
                    EmergencyContactName = "Rosa Cruz (Mother)",
                    EmergencyContactNumber = "0916-222-1100"
                }
            };

            lock (_lock)
            {
                _students.AddRange(seedList);
                _sequenceNumber = 106;
            }
        }

        public IReadOnlyList<Student> GetAll()
        {
            lock (_lock)
            {
                return _students.OrderByDescending(s => s.RegistrationDate).ToList();
            }
        }

        public Student? GetByStudentNumber(string studentNumber)
        {
            if (string.IsNullOrWhiteSpace(studentNumber)) return null;

            lock (_lock)
            {
                return _students.FirstOrDefault(s =>
                    string.Equals(s.StudentNumber, studentNumber.Trim(), StringComparison.OrdinalIgnoreCase));
            }
        }

        public Student Add(Student student)
        {
            lock (_lock)
            {
                _sequenceNumber++;
                // PUP Bataan Student Number format: YYYY-XXXXX-BN-0
                student.StudentNumber = $"{DateTime.Now.Year}-{_sequenceNumber:D5}-BN-0";
                student.RegistrationDate = DateTime.Now;
                student.Status = "Enrolled";
                _students.Insert(0, student);
                return student;
            }
        }

        public bool Update(Student student)
        {
            lock (_lock)
            {
                var existing = _students.FirstOrDefault(s => s.StudentNumber == student.StudentNumber);
                if (existing == null) return false;

                existing.FirstName = student.FirstName;
                existing.MiddleInitial = student.MiddleInitial;
                existing.LastName = student.LastName;
                existing.Email = student.Email;
                existing.ContactNumber = student.ContactNumber;
                existing.CompleteAddress = student.CompleteAddress;
                existing.Sex = student.Sex;
                existing.Birthday = student.Birthday;
                existing.Program = student.Program;
                existing.YearLevel = student.YearLevel;
                existing.EmergencyContactName = student.EmergencyContactName;
                existing.EmergencyContactNumber = student.EmergencyContactNumber;
                return true;
            }
        }

        public bool Delete(string studentNumber)
        {
            lock (_lock)
            {
                var item = _students.FirstOrDefault(s =>
                    string.Equals(s.StudentNumber, studentNumber.Trim(), StringComparison.OrdinalIgnoreCase));
                if (item != null)
                {
                    _students.Remove(item);
                    return true;
                }
                return false;
            }
        }

        public IReadOnlyList<Student> Search(string? query, string? program, string? yearLevel)
        {
            lock (_lock)
            {
                IEnumerable<Student> filtered = _students;

                if (!string.IsNullOrWhiteSpace(query))
                {
                    var q = query.Trim().ToLowerInvariant();
                    filtered = filtered.Where(s =>
                        s.FullName.ToLowerInvariant().Contains(q) ||
                        s.StudentNumber.ToLowerInvariant().Contains(q) ||
                        s.Email.ToLowerInvariant().Contains(q) ||
                        s.CompleteAddress.ToLowerInvariant().Contains(q));
                }

                if (!string.IsNullOrWhiteSpace(program) && program != "All")
                {
                    filtered = filtered.Where(s =>
                        string.Equals(s.Program, program, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(yearLevel) && yearLevel != "All")
                {
                    filtered = filtered.Where(s =>
                        string.Equals(s.YearLevel, yearLevel, StringComparison.OrdinalIgnoreCase));
                }

                return filtered.OrderByDescending(s => s.RegistrationDate).ToList();
            }
        }

        public DashboardStats GetStats()
        {
            lock (_lock)
            {
                var stats = new DashboardStats
                {
                    TotalStudents = _students.Count,
                    TotalPrograms = _students.Select(s => s.Program).Distinct().Count(),
                    EnrolledToday = _students.Count(s => s.RegistrationDate.Date == DateTime.Today)
                };

                // Program distribution
                stats.ProgramDistribution = _students
                    .GroupBy(s => s.Program)
                    .OrderByDescending(g => g.Count())
                    .ToDictionary(g => g.Key, g => g.Count());

                stats.TopProgram = stats.ProgramDistribution.FirstOrDefault().Key ?? "N/A";

                // Gender distribution
                stats.GenderDistribution = _students
                    .GroupBy(s => s.Sex)
                    .ToDictionary(g => g.Key, g => g.Count());

                // Year Level distribution
                stats.YearLevelDistribution = _students
                    .GroupBy(s => s.YearLevel)
                    .ToDictionary(g => g.Key, g => g.Count());

                return stats;
            }
        }
    }
}
