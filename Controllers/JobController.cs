using GuitarShop.Models;
using GuitarShop.Models.DTOs;
using GuitarShop.Models.Enums;
using GuitarShop.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs()
        {
            var jobs = (await _unitOfWork.Jobs.GetAll()).Select(job => new JobDTO(job)).ToList();
            return jobs;
        }

        //api/Jobs/jobType
        [HttpGet("{jobType}")]
        public async Task<ActionResult<JobDTO>> GetJobByType(string jobType)
        {
            if (Enum.TryParse<JobType>(jobType, true, out var parsedJobType))
            {
                var job = await _unitOfWork.Jobs.GetJobByType(parsedJobType);
                if (job == null)
                {
                    return NotFound("Job of this type does not exist");
                }
                return new JobDTO(job);
            }
            else
                return BadRequest("Invalid Job Type");
        }

        //PUT api/Jobs/jobType
        [HttpPut("{jobType}")]
        public async Task<IActionResult> PutJob(string jobType, JobDTO job)
        {
            if (Enum.TryParse<JobType>(jobType, true, out var parsedJobType))
            {
                var jobInDb = await _unitOfWork.Jobs.GetJobByType(parsedJobType);
                if (jobInDb == null)
                {
                    return NotFound("Job of this type does not exist");
                }

                jobInDb.JobType = job.JobType;
                jobInDb.Salary = job.Salary;

                await _unitOfWork.Jobs.Update(jobInDb);
                _unitOfWork.Save();

                return Ok();
            }
            else
                return BadRequest("Invalid Job Type");
        }

        //POST api/Jobs
        [HttpPost]
        public async Task<ActionResult<JobDTO>> PostJob(JobDTO job)
        {
            var jobToAdd = new Job(job);
            await _unitOfWork.Jobs.Create(jobToAdd);
            _unitOfWork.Save();
            return Ok();
        }

        //DELETE api/Jobs/jobType
        [HttpDelete("{jobType}")]
        public async Task<IActionResult> DeleteJob(string jobType)
        {
            if (Enum.TryParse<JobType>(jobType, true, out var parsedJobType))
            {
                var jobInDb = await _unitOfWork.Jobs.GetJobByType(parsedJobType);
                if (jobInDb == null)
                {
                    return NotFound("Job of this type does not exist");
                }
                await _unitOfWork.Jobs.Delete(jobInDb);
                _unitOfWork.Save();
                return Ok();

            }
            else
                return BadRequest("Invalid Job Type");
        }

    }
}
