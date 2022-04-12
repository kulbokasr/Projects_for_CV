using Microsoft.AspNetCore.Mvc;
using SchoolWebApp.Dtos;
using SchoolWebApp.Models;
using SchoolWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        public SchoolService _schoolService;

        public SchoolController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _schoolService.GetAllSchoolsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _schoolService.GetSchoolByIdAsync(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSchool createSchool)
        {
            try
            {
                School school = await _schoolService.CreateSchoolAsync(createSchool);
                return Created("", school);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateSchool updateSchool)
        {
            try
            {
                await _schoolService.UpdateSchoolAsync(id, updateSchool);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("School Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _schoolService.RemoveSchoolAsync(id);
                return Ok("Shool and its students deleted");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
