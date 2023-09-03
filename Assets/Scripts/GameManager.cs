
using System;
using UnityEngine;
using UnityEngine.UI;
using Conways.Game;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Text text;

    private Cell[,] grid;
    private Conway conway;
    private Spawner spawner;
    private bool play;
    private int generation;
    
    void Start()
    {
        grid = new Cell[width, height];
        conway = new Conway(width, height);
        spawner = new Spawner(width, height);

        generation = 0;

        FillMap();
    }


    void Update()
    {
        //Advance multiple generations
        if(Input.GetKey(KeyCode.Return))
        {
            grid = conway.Start(grid);
            generation++;
        } 
        //Advance one generation
        if(Input.GetKeyDown(KeyCode.Space))
        {
            grid = conway.Start(grid);
            generation++;
        } 
        //Restards
        if(Input.GetKeyDown(KeyCode.Backspace)) Restart();

        if(Input.GetKey(KeyCode.LeftShift) &&
        Input.GetKeyDown(KeyCode.Alpha1)) SpawnHere();

        UpdateUI();
    }

    private void FillMap()
    {
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                GameObject cell = 
                    Instantiate(cellPrefab, new Vector3(x + .4f, y + .4f, 0), Quaternion.identity);
                    
                cell.transform.parent = GameObject.Find("Grid").transform;
                cell.gameObject.name = x + " " + y; 
                grid[x, y] = cell.GetComponent<Cell>();
                grid[x, y].ActivateState();
            }
        }
    }

    private void SpawnHere()
    {
        Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(cubeRay, Vector2.zero);

            if (hit)
            {
                hit.collider.gameObject.GetComponent<Cell>().OnClick();
                string[] l = hit.collider.gameObject.name.Split(' ');
                spawner.SpawnHere(grid, Convert.ToInt32(l[0]), Convert.ToInt32(l[1]));
            }
    }

    private void Restart()
    {
        FillMap();
        generation = 0;
    }

    private void UpdateUI() => text.text = "Generation -> " + generation;
}
