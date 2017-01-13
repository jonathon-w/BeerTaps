using System;
using System.Collections.Generic;
using System.Linq;
using BeerTaps.Domain.Models;

namespace BeerTaps.Domain.Services
{
	public interface IReplaceKegService : IBeerTapsService
	{
		ReplaceKegDto Add(ReplaceKegDto beerTap);
		ReplaceKegDto Get(int kegId);
		void Delete(int kegId);
		IEnumerable<ReplaceKegDto> GetAll();
		ReplaceKegDto Update(ReplaceKegDto beerTap);
	}

	public class ReplaceKegService : IReplaceKegService
	{
		readonly IDictionary<int, ReplaceKegDto> _availableKegs;

		public ReplaceKegService()
		{
			_availableKegs = new Dictionary<int, ReplaceKegDto>();

			Initialize();
		}

		private void Initialize()
		{
			IList<ReplaceKegDto> availableKegs = new List<ReplaceKegDto>()
			{
				new ReplaceKegDto() { Id = 1,	BeerName = "Devil's Elbow IPA", TotalVolume = 5000, CurrentVolume = 5000},
				new ReplaceKegDto() { Id = 2,	BeerName = "Ambleside Amber Ale", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 3,	BeerName = "Main Street Pilsner", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 4,	BeerName = "Rebellion Golden Ale", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 5,	BeerName = "Steamworks Heroica Red Ale", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 6,	BeerName = "33 Acres of Darkness", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 7,	BeerName = "Affligem Blonde", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 8,	BeerName = "Pirate Life Brewing Double India Pale Ale", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 9,	BeerName = "Fat Pauly's Desert Rose", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 10,	BeerName = "Xavierbier's Message in a Bottle Black IPA", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 11,	BeerName = "Nectarous Dry-Hopper Sour", TotalVolume = 5000, CurrentVolume = 5000 },
				new ReplaceKegDto() { Id = 12,	BeerName = "Stonecutter Scotch Ale", TotalVolume = 5000, CurrentVolume = 5000 }
			};

			foreach (var keg in availableKegs)
			{
				Add(keg);
			}
		}

		public ReplaceKegDto Add(ReplaceKegDto keg)
		{
			_availableKegs.Add(keg.Id, keg);
			return keg;
		}

		public ReplaceKegDto Get(int kegId)
		{
			return _availableKegs.FirstOrDefault(x => x.Key == kegId).Value;
		}

		public void Delete(int kegId)
		{
			_availableKegs.Remove(_availableKegs.FirstOrDefault(x => x.Key == kegId));
		}

		public IEnumerable<ReplaceKegDto> GetAll()
		{
			return _availableKegs.Values;
		}

		public ReplaceKegDto Update(ReplaceKegDto keg)
		{
			_availableKegs[keg.Id] = keg;
			return keg;
		}
	}
}