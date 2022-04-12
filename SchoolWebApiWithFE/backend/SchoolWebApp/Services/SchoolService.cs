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
    public class SchoolService
    {
        private readonly DataContext _dataContext;

        public SchoolService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<School>> GetAllSchoolsAsync()
        {
            List<School> schools = await _dataContext.Schools.Include(s => s.Students).ToListAsync();
            return schools;
        }
        public async Task<School> GetSchoolByIdAsync(int id)
        {
            School school = await _dataContext.Schools.Include(s => s.Students).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (school == null)
            {
                throw new ArgumentException("School with such Id does not exist");
            }
            return school;
        }
        
        public async Task RemoveSchoolAsync(int id)
        {
            School school = await GetSchoolByIdAsync(id);
            _dataContext.Schools.Remove(school);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<School> CreateSchoolAsync(CreateSchool createSchool)
        {
            bool doesNameExist = await _dataContext.Schools.AnyAsync(x => x.Name == createSchool.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("School with such name already exists");
            }
            School school = new School()
            {
                Name = createSchool.Name
            };
            _dataContext.Schools.Add(school);
            await _dataContext.SaveChangesAsync();
            return school;
        }

        public async Task UpdateSchoolAsync(int id, CreateSchool updateSchool)
        {
            School school = await GetSchoolByIdAsync(id);
            bool doesNameExist = await _dataContext.Schools.AnyAsync(x => x.Name == updateSchool.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("School with such name already exists");
            }
            school.Name = updateSchool.Name;
            await _dataContext.SaveChangesAsync();
        }
    }
}
