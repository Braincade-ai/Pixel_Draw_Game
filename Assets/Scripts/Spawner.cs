namespace Conways.Game
{
    public class Spawner
{
    private int width;
    private int height;

    public Spawner(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void SpawnHere(Cell[,] grid, int x, int y)
    {
        grid[x, y].OnClick();
        x++;
        x = x >= width ? 0 : x; 
        grid[x >= width ? width - x : x, y].OnClick();
        x++;
        x = x >= width ? 0 : x; 
        grid[x>= width ? width - x : x, y].OnClick();
        x++;
        x = x >= width ? 0 : x; 
        grid[x>= width ? width - x : x, y].OnClick();
        y--;
        y = y < 0 ? height - 1 : y;
        grid[x, y].OnClick();
        grid[x - 1 < 0 ? width - 1 : x - 1, y - 1 < 0 ? height - 1 : y - 1].OnClick();
    }

    private int CheckBoundries(int x, int max)
    {
        if(x >= width) return 0;

        return x;
    }
}
}