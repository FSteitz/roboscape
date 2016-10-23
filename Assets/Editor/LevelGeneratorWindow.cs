using UnityEngine;
using UnityEditor;

using System;
using System.Collections.Generic;

public class LevelGeneratorWindow : EditorWindow {

    private const string GRID_GAME_OBJECT_NAME = "Grid";

    private int gridWith = 10; // 10 * 16x16 tile
    private int gridHeight = 10; // 10 * 16x16 tile


    private int tilesToGenerate = 10;
    private float tilePosition = 0;
    private float tileOffset = 0.5f;

    private GameObject grid;
    private GameObject tile;

    private GameObject[,] tileGrid;

	[MenuItem("Window/Level Generator Window")]
	public static void showWindow() {
		EditorWindow.GetWindow(typeof(LevelGeneratorWindow));
	}

    [ExecuteInEditMode]
    public void OnEnable() {
        grid = GameObject.Find(GRID_GAME_OBJECT_NAME);
        Debug.Log(grid);
    }

	public void OnGUI() {
        GUILayout.Label("Grid Settings", EditorStyles.boldLabel);

        gridWith = EditorGUILayout.IntField ("Grid Width", gridWith);
        gridHeight = EditorGUILayout.IntField ("Grid Height", gridHeight);

        tile = (GameObject) EditorGUILayout.ObjectField("Tile", tile, typeof(GameObject));

        if (GUILayout.Button("Build grid")){
            BuildGrid();
        }

        if (GUILayout.Button("Reset")){
            Reset();
        }
    }

    private void BuildGrid() {
        float xOffset = 0.15f;
        float yOffset = 0.15f;

        tileGrid = new GameObject[gridHeight,gridWith];

        for(int x = 0; x < gridWith; x++) {
            for(int y = 0; y < gridHeight; y++) {
                Vector2 position = new Vector2(x * xOffset, y * yOffset);
                GameObject newTile = (GameObject) Instantiate(tile, position, Quaternion.identity);

                Debug.Log("Generated tile at position" + tilePosition);

                newTile.transform.parent = grid.transform;
                tileGrid[y,x] = tile;
            }
        }
    }

    private void Reset(){
        foreach(Transform tile in grid.transform) {
            DestroyImmediate(tile.gameObject);
        }

        tilePosition = 0;
        Array.Clear(tileGrid, 0, tileGrid.Length);
    }
}
