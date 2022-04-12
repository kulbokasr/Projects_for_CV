using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Dtos;
using SchoolWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebApp.Services
{
    public class StudentService
    {
        private readonly DataContext _dataContext;

        public StudentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = await _dataContext.Students.ToListAsync();
            return students;
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            Student student = await _dataContext.Students.FindAsync(id);
            if (student == null)
            {
                throw new ArgumentException("Student with such Id does not exist");
            }
            return student;
        }

        public async Task RemoveStudentAsync(int id)
        {
            Student student = await GetStudentByIdAsync(id);
            _dataContext.Students.Remove(student);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Student> CreateStudentAsync(CreateStudent createStudent)
        {
            bool doesSchoolExist = await _dataContext.Schools.AnyAsync(x => x.Id == createStudent.SchoolId);
            if (!doesSchoolExist)
            {
                throw new ArgumentException("School with such Id does not exist");
            }
            Student student = new Student()
            {
                Name = createStudent.Name,
                SchoolId = createStudent.SchoolId
            };
            _dataContext.Students.Add(student);
            await _dataContext.SaveChangesAsync();
            return student;
        }

        public async Task UpdateStudentAsync(int id, CreateStudent updateStudent)
        {
            Student student = await GetStudentByIdAsync(id);
            bool doesSchoolExist = await _dataContext.Schools.AnyAsync(x => x.Id == updateStudent.SchoolId);
            if (!doesSchoolExist)
            {
                throw new ArgumentException("School with such Id does not exist");
            }
            student.Name = updateStudent.Name;
            student.SchoolId = updateStudent.SchoolId;
            await _dataContext.SaveChangesAsync();
        }
    }
}
