using System;
using System.Collections.Generic;
using System.Linq;
using BeerTaps.Domain.Models;

namespace BeerTaps.Domain.Services
{
	public interface IBeerTapService : IBeerTapsService
	{
		BeerTapDto Add(BeerTapDto beerTap);
		BeerTapDto Get(int officeId, int id);
		void Delete(int officeId, int id);
		IEnumerable<BeerTapDto> GetAll();
		BeerTapDto Update(BeerTapDto beerTap);
	}

	public class BeerTapService : IBeerTapService
	{
		readonly IDictionary<Tuple<int, int>, BeerTapDto> _beerTaps;

		public BeerTapService()
		{
			_beerTaps = new Dictionary<Tuple<int, int>, BeerTapDto>();

			Initialize();
		}

		private void Initialize()
		{
			// Create a list of unique BeerTaps with associated OfficeIds
			IList<BeerTapDto> beerTaps = new List<BeerTapDto>()
			{
				new BeerTapDto() { OfficeId = 1, Id = 1, BeerName = "Devil's Elbow IPA" },
				new BeerTapDto() { OfficeId = 1, Id = 2, BeerName = "Ambleside Amber Ale" },
				new BeerTapDto() { OfficeId = 1, Id = 3, BeerName = "Main Street Pilsner" },
				new BeerTapDto() { OfficeId = 2, Id = 1, BeerName = "Rebellion Golden Ale" },
				new BeerTapDto() { OfficeId = 2, Id = 2, BeerName = "Steamworks Heroica Red Ale" },
				new BeerTapDto() { OfficeId = 3, Id = 1, BeerName = "33 Acres of Darkness" },
				new BeerTapDto() { OfficeId = 3, Id = 2, BeerName = "Affligem Blonde" },
				new BeerTapDto() { OfficeId = 4, Id = 1, BeerName = "Pirate Life Brewing Double India Pale Ale" },
				new BeerTapDto() { OfficeId = 5, Id = 1, BeerName = "Fat Pauly's Desert Rose" },
				new BeerTapDto() { OfficeId = 5, Id = 2, BeerName = "Xavierbier's Message in a Bottle Black IPA" },
				new BeerTapDto() { OfficeId = 6, Id = 1, BeerName = "Nectarous Dry-Hopper Sour" },
				new BeerTapDto() { OfficeId = 6, Id = 2, BeerName = "Stonecutter Scotch Ale" }
			};

			// Add each BeerTap to the Dictionary
			foreach (var beerTap in beerTaps)
			{
				Add(beerTap);
			}
		}

		public BeerTapDto Add(BeerTapDto beerTap)
		{
			_beerTaps.Add(Tuple.Create(beerTap.OfficeId, beerTap.Id), beerTap);
			return beerTap;
		}

		// Get needs to get based on OfficeId and Id
		public BeerTapDto Get(int officeId, int id)
		{
			return _beerTaps.FirstOrDefault(x => x.Key.Equals(Tuple.Create(officeId, id))).Value;
		}

		public void Delete(int officeId, int id)
		{
			_beerTaps.Remove(_beerTaps.First(x => x.Key.Equals(Tuple.Create(officeId, id))));
		}

		public IEnumerable<BeerTapDto> GetAll()
		{
			return _beerTaps.Values;
		}

		public BeerTapDto Update(BeerTapDto beerTap)
		{
			_beerTaps[Tuple.Create(beerTap.OfficeId, beerTap.Id)] = beerTap;
			return beerTap;
		}
	}
}