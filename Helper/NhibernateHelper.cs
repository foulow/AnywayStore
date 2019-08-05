using AnywayStore.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace AnywayStore.Helper
{
    public static class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["DBSet"].ConnectionString;
            ISessionFactory sessionFactory = 
                Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection"))
                    .ShowSql()
                )
                .Mappings(m =>
                    m.FluentMappings
                    .AddFromAssemblyOf<ClassMapProducts>()
                )
                .ExposeConfiguration(cfg =>
                    new SchemaUpdate(cfg)
                    .Execute(false, true)
                )
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}