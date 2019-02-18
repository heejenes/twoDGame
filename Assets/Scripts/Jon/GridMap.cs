/*
using system.collections;
using system.collections.generic;
using unityengine;

public class gridmap : monobehaviour {
   
    public vector2 gridworldsize;
    public float tilesize = 10f;
    public tile[,] tiles;

    public int lateralmovecost = 10;
    public int diagonalmovecost = 14;

    public layermask unwalkable;
    int gridsizex, gridsizey;

    void start() {
        debug.log("creating gridmap...");
        tiles = creategridmap();
        debug.log("finished creating gridmap");
    }

    void ondrawgizmos()
    {
        vector2 gizmostilesize = new vector2(tilesize - 1f, tilesize - 1f);

        gizmos.color = color.red;
        gizmos.drawwirecube(transform.position, gridworldsize + vector2.one * 5);

        if (tiles != null)
        {
            foreach (Tile t in tiles)
            {
                Gizmos.color = Color.blue;
                if (t.walkable == false)
                {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawWireCube(t.worldPos, gizmosTileSize);
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Tile t1 = GetTileFromWorldCoords(mousePos);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(t1.worldPos, gizmosTileSize);

            Gizmos.color = Color.green;
            foreach (Tile n in t1.neighbours)
            {
                Gizmos.DrawWireCube(n.worldPos, gizmosTileSize);
            }
        }
    }

    public Tile GetTileFromWorldCoords (Vector2 coords) {
        float percentX = (coords.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (coords.y + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return tiles[x, y];
    }

    public int GetDistance (Tile from, Tile to) {
        int distanceX = Mathf.Abs(from.gridPos.x - to.gridPos.x);
        int distanceY = Mathf.Abs(from.gridPos.y - to.gridPos.y);

        if (distanceX > distanceY)
            return diagonalMoveCost * distanceY + lateralMoveCost * (distanceX - distanceY);
        return diagonalMoveCost * distanceX + lateralMoveCost * (distanceY - distanceX);
    }

    Tile[,] CreateGridMap()
    {
        gridSizeX = Mathf.FloorToInt(gridWorldSize.x / tileSize);
        gridSizeY = Mathf.FloorToInt(gridWorldSize.y / tileSize);
        tiles = new Tile[gridSizeX, gridSizeY];

        // get the bottom left origin world coordinate of the grid, then go iterate through by the tileSize and create grids with the corresponding grid positions
        Vector2 position2d = transform.position;
        Vector2 gridOrigin = (position2d - (-1 * Vector2.left * gridWorldSize.x / 2f)) - (-1 * Vector2.down * gridWorldSize.y / 2f) + (Vector2.one * tileSize / 2);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                //create new Tile object
                Vector2 worldPoint = gridOrigin + (Vector2.right * (x * tileSize)) + (Vector2.up * (y * tileSize));

                bool walkable = !(Physics2D.OverlapCircle(worldPoint, tileSize / 2, unwalkable));

                tiles[x, y] = new Tile(new Vector2Int(x, y), worldPoint, walkable);
            }
        }

        // go through the gridmap and assign neighbours to nodes
        foreach (Tile tile in tiles) {
            int x = tile.gridPos.x;
            int y = tile.gridPos.y;
            Tile t = tiles[x,y];
            if (!t.walkable)
                continue;

            List<Tile> neighbours = new List<Tile>();

            for (int relX = -1; relX <= 1; relX ++) {
                for (int relY = -1; relY <= 1; relY++)
                {
                    if (relX == 0 && relY == 0)
                        continue;
                    int checkX = x + relX;
                    int checkY = y + relY;
                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
                        Tile checkTile = tiles[checkX, checkY];
                        if (checkTile.walkable == true)
                        {
                            neighbours.Add(checkTile);
                        }
                    }
                }
            }

            tile.neighbours = neighbours.ToArray();
        }

        return tiles;
    }

}
*/