using System.Threading.Tasks;
using BLL.Services;
using DLL.MongoReport.Models;
using DLL.MongoReport.Repositories;
using Microsoft.AspNetCore.Mvc;
using Utility.Helpers;

namespace API.Controllers
{
    public class TestController :  OurApplicationController
    {
        private readonly ITestService _testService;
        private readonly TaposRSA _taposRsa;
        private readonly IDepartmentStudentMongoRepository _departmentStudentMongoRepository;

        public TestController(ITestService testService,TaposRSA taposRsa, IDepartmentStudentMongoRepository departmentStudentMongoRepository)
        {
            _testService = testService;
            _taposRsa = taposRsa;
            _departmentStudentMongoRepository = departmentStudentMongoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          //  _taposRsa.GenerateRsaKey("v1");
         // await  _testService.SaveAllData();
         await _testService.UpdateBalance();
            return Ok("hello");
        }

        [HttpGet]
        public async Task<IActionResult> DataInsert()
        {
            await _departmentStudentMongoRepository.Create(new DepartmentStudentReportMongo()
            {
                DepartmentCode = "EEE",
                DepartmentName = "Electrical and Electronic Engineering",
                StudentName = "Subir Mandal",
                StudentEmail = "subirew026@gmail.com",
                StudentRoll = "2010-1-80-026",
            });
            return Ok("Sucessfully insert");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok( await _departmentStudentMongoRepository.GetAll());
        }
    }
}