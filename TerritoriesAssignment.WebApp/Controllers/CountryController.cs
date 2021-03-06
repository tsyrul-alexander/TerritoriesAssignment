﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TerritoriesAssignment.Core;
using TerritoriesAssignment.Database;
using TerritoriesAssignment.WebApp.Models;
using TerritoriesAssignment.WebApp.Utilities;

namespace TerritoriesAssignment.WebApp.Controllers {
	[Route("api/country")]
	[ApiController]
	public class CountryController : Controller {
		public IDataStorage Storage { get; }

		public CountryController(IDataStorage storage) {
			Storage = storage;
		}
		[HttpGet("getItems")]
		public IEnumerable<BaseLookupViewItem> Get() {
			return Storage.GetCountries().ToView();
		}
		[HttpPost("managersDistribution")]
		public ManagerResponseView[] ManagersDistribution(Guid countryId, [FromBody]ManagerView[] managers) {
			ManagerHelper helper = new ManagerHelper(Storage);
			return helper.ManagersDistribution(countryId, managers);
		}
		[HttpGet]
		public CountryView Get(Guid id) {
			return Storage.GetCountry(id).ToView();
		}
		[HttpPost("add")]
		public void Post([FromBody]CountryView item) {
			Storage.AddCountry(item.Cast());
		}
		[HttpPost("update")]
		public void Put([FromBody]CountryView item) {
			Storage.UpdateCountry(item?.Cast());
		}
		[HttpDelete("{id}")]
		public void Delete(Guid id) {
			Storage.DeleteCountry(id);
		}
	}
}