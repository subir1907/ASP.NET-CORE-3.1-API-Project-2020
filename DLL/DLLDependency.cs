﻿using DLL.MongoReport;
using DLL.Repository;
using DLL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public class DLLDependency
    {
        public static void ALLDependency(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

            MongoDbDependency.ALLDependency(services);
            // services.AddTransient<IStudentRepository,StudentRepository>();
            // services.AddTransient<IDepartmentRepository,DepartmentRepository>();
        }
    }
}