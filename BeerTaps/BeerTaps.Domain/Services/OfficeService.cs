using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTaps.Domain.Models;

namespace BeerTaps.Domain.Services
{
	public interface IOfficeService : IBeerTapsService
	{
		OfficeDto Add(OfficeDto office);
		OfficeDto Get(int id);
		void Delete(int id);
		IEnumerable<OfficeDto> GetAll();
		OfficeDto Update(OfficeDto office);
	}

	public class OfficeService : IOfficeService
	{
		readonly IDictionary<int, OfficeDto> _offices;

		public OfficeService()
		{
			_offices = new Dictionary<int, OfficeDto>();

			Initialize();
		}

		private void Initialize()
		{
			// Create a list of the Offices
			IList<OfficeDto> offices = new List<OfficeDto>()
			{
				new OfficeDto() { Id = 1, Location = "Vancouver, British Columbia" },
				new OfficeDto() { Id = 2, Location = "Regina, Saskatchewan" },
				new OfficeDto() { Id = 3, Location = "Winnipeg, Manitoba" },
				new OfficeDto() { Id = 4, Location = "Sydney, Australia" },
				new OfficeDto() { Id = 5, Location = "Manila, Philippines" },
				new OfficeDto() { Id = 6, Location = "Davidson, North Carolina" }
			};

			// Add each Office to the Dictionary
			foreach (var office in offices)
			{
				Add(office);
			}
		}

		public OfficeDto Add(OfficeDto office)
		{
			_offices.Add(office.Id, office);
			return office;
		}

		public OfficeDto Get(int id)
		{
			return _offices.FirstOrDefault(x => x.Key == id).Value;
		}

		public void Delete(int id)
		{
			_offices.Remove(_offices.First(x => x.Key == id));
		}

		public IEnumerable<OfficeDto> GetAll()
		{
			return _offices.Values;
		}

		public OfficeDto Update(OfficeDto office)
		{
			_offices[office.Id] = office;
			return office;
		}
	}
}
