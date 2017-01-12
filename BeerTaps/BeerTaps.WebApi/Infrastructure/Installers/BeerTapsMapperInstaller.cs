using System;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi.Services.Mapping;
using BeerTaps.Domain;

namespace BeerTaps.WebApi.Infrastructure.Installers
{
	public class BeerTapsMapperInstaller : IWindsorInstaller
	{
		readonly Assembly _beerTapsAssembly;
		public BeerTapsMapperInstaller(Assembly beerTapsAssembly)
		{
			if (beerTapsAssembly == null)
				throw new ArgumentNullException("beerTapsAssembly");
			_beerTapsAssembly = beerTapsAssembly;
		}
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			var apiMappersAssemblyDesc = Classes.FromAssembly(_beerTapsAssembly);

			container
				   .Register(apiMappersAssemblyDesc.BasedOn(typeof(IBeerTapsService)).WithServiceAllInterfaces());
		}
	}
}