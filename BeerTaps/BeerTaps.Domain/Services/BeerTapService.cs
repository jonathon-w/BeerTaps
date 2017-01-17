using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BeerTaps.Domain.Models;

namespace BeerTaps.Domain.Services
{
	public interface IBeerTapService : IBeerTapsService
	{
		BeerTapDto Add(BeerTapDto beerTap);
		BeerTapDto Get(int officeId, int id);
		void Delete(int officeId, int id);
		IEnumerable<BeerTapDto> GetAll();
		IEnumerable<BeerTapDto> GetAllAtOfficeId(int officeId);
		void Replace(BeerTapDto newBeerTap);
		void Pour(int officeId, int id);
		BeerTapDto Update(BeerTapDto beerTap);
	}

	public class BeerTapService : IBeerTapService
	{
		readonly IDictionary<Tuple<int, int>, BeerTapDto> _beerTaps;

		public BeerTapService()
		{
			if (_beerTaps == null)
			{
				_beerTaps = new Dictionary<Tuple<int, int>, BeerTapDto>();
				Initialize();
			}
		}

		private void Initialize()
		{
			// Create a list of unique BeerTaps with associated OfficeIds
			IList<BeerTapDto> beerTaps = new List<BeerTapDto>()
			{
				new BeerTapDto() {OfficeId = 1, Id = 1, BeerName = "Devil's Elbow IPA", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 1, Id = 2, BeerName = "Ambleside Amber Ale", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 1, Id = 3, BeerName = "Main Street Pilsner", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 2, Id = 1, BeerName = "Rebellion Golden Ale", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 2, Id = 2, BeerName = "Steamworks Heroica Red Ale", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 3, Id = 1, BeerName = "33 Acres of Darkness", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 3, Id = 2, BeerName = "Affligem Blonde", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 4, Id = 1, BeerName = "Pirate Life Brewing Double India Pale Ale", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 5, Id = 1, BeerName = "Fat Pauly's Desert Rose", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 5, Id = 2, BeerName = "Xavierbier's Message in a Bottle Black IPA", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 6, Id = 1, BeerName = "Nectarous Dry-Hopper Sour", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true},
				new BeerTapDto() {OfficeId = 6, Id = 2, BeerName = "Stonecutter Scotch Ale", TotalVolume = 5000, CurrentVolume = 5000, IsFull = true}
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

		public IEnumerable<BeerTapDto> GetAllAtOfficeId(int officeId)
		{
			return _beerTaps.Values.Where(x => x.OfficeId.Equals(officeId));
		}

		public void Replace(BeerTapDto newBeerTap)
		{
			Delete(newBeerTap.OfficeId, newBeerTap.Id);
			Add(newBeerTap);
		}

		public void Pour(int officeId, int id)
		{
			// Get the BeerTap being pointed at and create a copy to update
			var beerTap = Get(officeId, id);
			var updatedBeerTap = beerTap.Clone();

			// Subtract a pint (500ml) from the keg
			updatedBeerTap.CurrentVolume = (updatedBeerTap.CurrentVolume - 500) >= 0
				? updatedBeerTap.CurrentVolume -= 500
				: updatedBeerTap.CurrentVolume = 0;

			// Place the updated BeerTap back into the Dictionary
			Update(updatedBeerTap);
		}

		public BeerTapDto Update(BeerTapDto beerTap)
		{
			_beerTaps[Tuple.Create(beerTap.OfficeId, beerTap.Id)] = beerTap;
			return beerTap;
		}
	}
}