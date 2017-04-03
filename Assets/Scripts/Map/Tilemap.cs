using UnityEngine;

namespace Map
{
	public class Tilemap : MonoBehaviour 
	{
		public TileRow[] tiles;
        public float tileSize = 1f;

		public Vector2 TileToWorldPosition (Vector2 position)
		{
			return position * tileSize;
		}

		public Vector2 WorldToTilePosition (Vector2 position)
		{
			return position / tileSize;
		}

		public Tile GetTileAt (Vector2 position)
		{
			return tiles[(int)position.y].tiles[(int)position.x];
		}


		public List<Tile> GetNeighbours(Tile node)
		{
			List<Tile> neighbours = new List<Tile>();

			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (x == 0 && y == 0)
						continue;

					int checkX = node.gridX + x;
					int checkY = node.gridY + y;

					if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
					{
						neighbours.Add(nodes[checkX, checkY]);
					}
				}
			}

			return neighbours;
		}

	}
}