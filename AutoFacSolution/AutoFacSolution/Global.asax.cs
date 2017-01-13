using Autofac;
using Autofac.Integration.Mvc;
using James.IRepository;
using James.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutoFacSolution
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);//注册所有的Controller

            #region 类操作
            //builder.RegisterType<StudentRepository>().As<IStudentRepository>().AsImplementedInterfaces();
            #endregion

            #region dll操作
            var IRepository = Assembly.Load("James.IRepository");
            var Repository = Assembly.Load("James.Repository");
            //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            builder.RegisterAssemblyTypes(IRepository, Repository)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces();
            //开发环境下，使用Stub类
            //builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).Where(
            //    t => t.Name.EndsWith("Repository") && t.Name.StartsWith("Stub")).AsImplementedInterfaces();
            //发布环境下，使用真实的数据访问层
            //builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).Where(
            //   t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            #endregion

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public void BootStrap_Start()
        {

        }
    }
}
