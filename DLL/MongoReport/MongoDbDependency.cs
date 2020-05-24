using DLL.MongoReport.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.MongoReport
{
    public class MongoDbDependency

    {
        public static void ALLDependency(IServiceCollection services)
        {
            services.AddSingleton(typeof(MongoDbContex));
            services.AddTransient<IDepartmentStudentMongoRepository, DepartmentStudentMongoRepository>();
        }
    }
}
