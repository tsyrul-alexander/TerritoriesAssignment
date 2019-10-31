﻿using System;
using System.Collections.Generic;
using TerritoriesAssignment.Core;
using TerritoriesAssignment.Core.Entities;
using TerritoriesAssignment.Core.Entities.Map;
using Attribute = TerritoriesAssignment.Core.Entities.Attribute;

namespace TerritoriesAssignment.Database
{
	public interface IDataStorage {
		Country GetCountry(Guid id);
		Area GetArea(Guid id);
		Region GetRegion(Guid id);
		Attribute GetAttribute(Guid id);
		AttributeValue GetAttributeValue(Guid attributeId, Guid regionId);
		void AddCountry(Country country);
		void AddArea(Area area);
		void AddRegion(Region region);
		void AddAttribute(Attribute attribute);
		void AddAttributeValue(AttributeValue attributeValue);
		void UpdateCountry(Country country);
		void UpdateArea(Area area);
		void UpdateRegion(Region region);
		void UpdateAttribute(Attribute attribute);
		void UpdateAttributeValue(AttributeValue attributeValue);
		IEnumerable<BaseLookup> GetCountries(string search = null);
		IEnumerable<BaseLookup> GetAreas(Guid countryId, string search = null);
		IEnumerable<BaseMapLookup> GetAreasMap(Guid countryId);
		IEnumerable<BaseLookup> GetRegions(Guid areaId, string search = null);
		IEnumerable<BaseLookup> GetAttributes(string search = null);
		IEnumerable<AttributeValue> GetAttributeValues(Guid regionId);
		IEnumerable<AttributeValue> GetAttributeValuesFromCountry(Guid countryId);
		IEnumerable<AttributeValue> GetAttributeValuesFromArea(Guid areaId);
		void DeleteCountry(Guid countryId);
		void DeleteArea(Guid areaId);
		void DeleteRegion(Guid regionId);
		void DeleteAttribute(Guid attributeId);
		void DeleteAttributeValue(Guid attributeValueId);
	}
}