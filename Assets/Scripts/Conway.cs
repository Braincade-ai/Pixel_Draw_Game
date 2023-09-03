namespace Conways.Game
{
    public class Conway
    {
        private Cell[,] grid;
        private Cell[,] nextGrid;
        private int width;
        private int height;

        public Conway(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Cell[,] Start(Cell[,] grid)
        {
            this.grid = grid;
            CheckGrid();
            ActivateStates();
            return grid;
        }

        private void CheckGrid()
        {   
            for(int x = 0; x < width; x++){
                for(int y = 0; y < height; y++){
                    CheckNeighboors(x, y);
                }
            }
        }

        private void CheckNeighboors(int x, int y)
        {
            int numberOfAlive = 0;

            if(grid[x + 1 >= width ? 0 : x + 1, y].IsAlive()) numberOfAlive++;
            if(grid[x - 1 < 0 ? width - 1 : x - 1, y].IsAlive()) numberOfAlive++;
            if(grid[x, y - 1 < 0 ? height - 1 : y - 1].IsAlive()) numberOfAlive++;
            if(grid[x, y + 1 >= height ? 0 : y + 1].IsAlive()) numberOfAlive++;
            if(grid[x + 1 >= width ? 0 : x + 1, y + 1 >= height ? 0 : y + 1].IsAlive()) numberOfAlive++;
            if(grid[x + 1 >= width ? 0 : x + 1, y - 1 < 0 ? height - 1 : y - 1].IsAlive()) numberOfAlive++;
            if(grid[x - 1 < 0 ? width - 1 : x - 1, y + 1 >= height ? 0 : y + 1].IsAlive()) numberOfAlive++;
            if(grid[x - 1 < 0 ? width - 1 : x - 1, y - 1 < 0 ? height - 1 : y - 1].IsAlive()) numberOfAlive++;
            
            // Any live cell with fewer than two live neighbours dies, as if by underpopulation
            if(numberOfAlive < 2 && grid[x, y].IsAlive())
            { 
                grid[x, y].SetNextState(false);
            }

            if((numberOfAlive == 2 || numberOfAlive ==3) && grid[x, y].IsAlive()){
                grid[x, y].SetNextState(true);
            }
            
            if(numberOfAlive == 3 && !grid[x, y].IsAlive())
            { 
                grid[x, y].SetNextState(true);
            }
            //Any live cell with more than three live neighbours dies, as if by overpopulation.
            if(numberOfAlive > 3 && grid[x, y].IsAlive())
            { 
                grid[x, y].SetNextState(false);
            }
        }

        private void ActivateStates()
        {
            for(int x = 0; x < width; x++){
                for(int y = 0; y < height; y++){
                    grid[x,y].ActivateState();
                }
            }
        }
    }

}
