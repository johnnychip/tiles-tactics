using Characters;
using UnityEngine;

namespace Map
{
    public class Tile: MonoBehaviour
    {
        [SerializeField]
        private TerrainType terrain;
        public Character Character { get; set; }

		// node starting params
		public bool walkable;
		public int gridX;
		public int gridY;
		public float penalty;

		// calculated values while finding path
		public int gCost;
		public int hCost;
		public Tile parent;

        public float Cost
        {
            get
            {
                //TODO: Get Cost
                return 1f;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return Character != null;
            }
        }

		// create the node
		// _price - how much does it cost to pass this tile. less is better, but 0.0f is for non-walkable.
		// _gridX, _gridY - tile location in grid.
		public void SetParameters(float _price, int _gridX, int _gridY)
		{
			walkable = _price != 0.0f;
			penalty = _price;
			gridX = _gridX;
			gridY = _gridY;
		}

		public int fCost
		{
			get
			{
				return gCost + hCost;
			}
		}

    }
}