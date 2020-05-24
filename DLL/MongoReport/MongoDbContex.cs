using DLL.MongoReport.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.MongoReport
{
    public class MongoDbContex
    {
        private readonly IMongoDatabase _database;

        public MongoDbContex(IConfiguration configuration)
        {
            var client = new MongoClient( connectionString: configuration.GetValue<string>(key: "MongoConnection:ConnectionString"));
            _database = client.GetDatabase(name: configuration.GetValue<string>(key: "MongoConnection:DatabaseName"));
        }

        public IMongoCollection<DepartmentStudentReportMongo> DepartmentStudentReport =>
            _database.GetCollection<DepartmentStudentReportMongo>(name: "DepartmentStudent");

    }
}
