using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using System.Data;
using testing.Data;
using testing.Models;

namespace testing.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestingController : ControllerBase
    {
        private readonly AddDbContext _addDbContext;
        public TestingController(AddDbContext addDbContext)
        {
            _addDbContext = addDbContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemoTest>>> GetDemoTests()
        {

            // Lấy tất cả các bản ghi từ bảng DemoTest
            var demoTests = await _addDbContext.DemoTest.ToListAsync();

            // Trả về một ActionResult chứa danh sách demoTests
            return Ok(new { Success = 200, data = demoTests });
        }
        [HttpGet("GetById/{id}",Name ="getById")]
        public async Task<ActionResult<IEnumerable<DemoTest>>> GetDemoTestsById(int id)
        {

            // Lấy tất cả các bản ghi từ bảng DemoTest
            var demoTests = await _addDbContext.DemoTest.SingleOrDefaultAsync(item => item.maDemo == id);

            // Trả về một ActionResult chứa danh sách demoTests
            return Ok(new { Success = 200, data = demoTests });
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<DemoTest>>> AddDemoTests(string Ten)
        {

            // Lấy tất cả các bản ghi từ bảng DemoTest
            var demoTests = new DemoTest();
            demoTests.tenDemo = Ten;
            _addDbContext.Add(demoTests);
            _addDbContext.SaveChanges();

            // Trả về một ActionResult chứa danh sách demoTests
            return Ok(new { Success = 200, data = demoTests });
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<DemoTest>>> DeleteTest(int id)
        {
           
            // Lấy tất cả các bản ghi từ bảng DemoTest
            var demoTests = await _addDbContext.DemoTest.SingleOrDefaultAsync(item => item.maDemo == id);
            if (demoTests == null)
            {
                return NotFound();
            }
            _addDbContext.Remove(demoTests);
            _addDbContext.SaveChanges();

            // Trả về một ActionResult chứa danh sách demoTests
            return Ok(new {Success=200,data= demoTests }) ;
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<DemoTest>>> EditDemo(int id,string Ten)
        {

            // Lấy tất cả các bản ghi từ bảng DemoTest
            var demoTests = await _addDbContext.DemoTest.SingleOrDefaultAsync(item => item.maDemo == id);
            if (demoTests == null)
            {
                return NotFound();
            }
            demoTests.tenDemo = Ten;
            _addDbContext.Update(demoTests);
            _addDbContext.SaveChanges();

            // Trả về một ActionResult chứa danh sách demoTests
            return Ok(new { Success = 200, data = demoTests });
        }
    }
}

