using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TerritoriesAssignment.Core.Entities.Map {
	public class BaseMapLookup : BaseLookup {
		public string MapPoint { get; set; }
		public MapPoint[] GetPoints() {
			return ParseCoordinateList()?.ToArray();
		}

		protected virtual IEnumerable<MapPoint> ParseCoordinateList() {
			return MapPoint?.Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ParseCoordinate);
		}

		protected virtual MapPoint ParseCoordinate(string coordinateStr) {
			var coordinate = coordinateStr.Split(':');
			if (coordinate.Length != 2) {
				throw new FormatException();
			}
			var x = double.Parse(coordinate[0], CultureInfo.InvariantCulture);
			var y = double.Parse(coordinate[1], CultureInfo.InvariantCulture);
			return new MapPoint {
				X = x,
				Y = y
			};
		}
	}
}