using DLL.MongoReport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.MongoReport.Repositories
{
    public interface IDepartmentStudentMongoRepository
    {
        Task<DepartmentStudentReportMongo> Create(DepartmentStudentReportMongo departmentStudentMongo);
        Task<List<DepartmentStudentReportMongo>> GetAll();
    }

    public class DepartmentStudentMongoRepository : IDepartmentStudentMongoRepository
    {
        private readonly MongoDbContex _contex;

        public DepartmentStudentMongoRepository(MongoDbContex contex)
        {
            _contex = contex;
        }
        public async Task<DepartmentStudentReportMongo> Create(DepartmentStudentReportMongo departmentStudentMongo)
        {
            await _contex.DepartmentStudentReport.InsertOneAsync(departmentStudentMongo);
            return departmentStudentMongo;
        }

        public async Task<List<DepartmentStudentReportMongo>> GetAll()
        {
            var filterBuilder = Builders<DepartmentStudentReportMongo>.Filter;
            var filter = filterBuilder.Empty;
            var sort = Builders<DepartmentStudentReportMongo>.Sort.Descending(field: "_id");
            return await _contex.DepartmentStudentReport.Find(filter).Sort(sort).ToListAsync();
        }
    }
}
