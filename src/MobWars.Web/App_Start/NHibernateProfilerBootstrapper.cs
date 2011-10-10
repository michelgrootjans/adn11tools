using HibernatingRhinos.Profiler.Appender.NHibernate;

[assembly: WebActivator.PreApplicationStartMethod(typeof(MobWars.Web.App_Start.NHibernateProfilerBootstrapper), "PreStart")]
namespace MobWars.Web.App_Start
{
	public static class NHibernateProfilerBootstrapper
	{
		public static void PreStart()
		{
            NHibernateProfiler.Initialize();
		}
	}
}

