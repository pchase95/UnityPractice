using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    public GameObject hoverPrefab;

    public static BoardManager Instance { get; set; }

    public bool isWhiteTurn = true;
    private bool[,] allowedMoves;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public ChessMan[,] ChessMans { get; set; }
    private ChessMan selectedChessman;

    public List<GameObject> chessmanPrefabs;
    private List<GameObject> activeChessman;

    private void DrawChessboard() {
        if (selectionX >= 0 && selectionY >= 0) {
            if (!GameObject.Find(hoverPrefab.name)) {
                hoverPrefab = Instantiate(
                    hoverPrefab, new Vector3(selectionX + TILE_OFFSET, 0.01f, selectionY + TILE_OFFSET), transform.rotation
                );
            } else {
                hoverPrefab.transform.position = new Vector3(selectionX + TILE_OFFSET, 0.01f, selectionY + TILE_OFFSET);
                if (!hoverPrefab.GetComponent<Renderer>().enabled)
                    hoverPrefab.GetComponent<Renderer>().enabled = true;
            }
        } else
            if (GameObject.Find(hoverPrefab.name))
                hoverPrefab.GetComponent<Renderer>().enabled = false;
        
    }

    private void UpdateSelection() {
        if (!Camera.main)
            return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
        out hit, 25.0f, LayerMask.GetMask("ChessPlane"))) {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        } else {
            selectionX = selectionY = -1;
        }
    }
    
    private Vector3 GetTileCenter(int x, int y) {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }

    private void SpawnChessman(int index, int x, int y) {
        GameObject go = Instantiate(chessmanPrefabs[index], GetTileCenter(x, y), transform.rotation) as GameObject;
        go.transform.SetParent(this.transform);
        ChessMans[x, y] = go.GetComponent<ChessMan>();
        ChessMans[x, y].SetPosition(x, y);
        activeChessman.Add(go);
    }

    private void spawnAllChessmans() {
        activeChessman = new List<GameObject>();
        ChessMans = new ChessMan[8,8];
        // White Team
        SpawnChessman(0, 4, 0); // King
        SpawnChessman(1, 3, 0); // Queen
        SpawnChessman(2, 0, 0); // Rook
        SpawnChessman(2, 7, 0); // Rook
        SpawnChessman(3, 2, 0); // Bishop
        SpawnChessman(3, 5, 0); // Bishop
        SpawnChessman(4, 1, 0); // Knight
        SpawnChessman(4, 6, 0); // Knight
        for (int i = 0; i <= 7; i++) // Spawn Pawns
            SpawnChessman(5, i, 1);

        // Black Team
        SpawnChessman(6, 4, 7); // King
        SpawnChessman(7, 3, 7); // Queen
        SpawnChessman(8, 0, 7); // Rook
        SpawnChessman(8, 7, 7); // Rook
        SpawnChessman(9, 2, 7); // Bishop
        SpawnChessman(9, 5, 7); // Bishop
        SpawnChessman(10, 1, 7); // Knight
        SpawnChessman(10, 6, 7); // Knight
        for (int i = 0; i <= 7; i++) // Spawn Pawns
            SpawnChessman(11, i, 6);
    }

    private void SelectChessman(int x, int y) {
        if (ChessMans[x, y] == null)
            return;

        if (ChessMans[x, y].IsWhite != isWhiteTurn)
            return;

        allowedMoves = ChessMans[x, y].PossibleMove();
        bool atLeastOneMove = false;
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                if (allowedMoves[i, j]) {
                    atLeastOneMove = true;
                    break;
                }

        if (!atLeastOneMove)
            return;

        selectedChessman = ChessMans[x, y];
        BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
    }

    private void MoveChessman(int x, int y) {
        if (allowedMoves[x, y]) {
            ChessMan c = ChessMans[x, y];
            if (c != null) {
                c.Moved = false;
                if (c.IsWhite != isWhiteTurn) {
                    // Kill piece
                    activeChessman.Remove(c.gameObject);
                    Destroy(c.gameObject);

                    // If killed pience is King
                    if (c.GetType() == typeof(King)) {
                        EndGame();
                        return;
                    }
                } else {
                    if (c.GetType() == typeof(Rook))
                        c.transform.position = GetTileCenter(selectedChessman.CurrentX, selectedChessman.CurrentY);
                }
            }
            ChessMans[selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
            selectedChessman.transform.position = GetTileCenter(x, y);
            selectedChessman.SetPosition(x, y);
            ChessMans[x, y] = selectedChessman;
            rotateCamera();
            isWhiteTurn = !isWhiteTurn;   
        }
        BoardHighlights.Instance.HideHighlights();
        selectedChessman = null;
    }

    private void rotateCamera() {
        Vector3 currentPosition = Camera.main.transform.position;
        float camRotX = Camera.main.transform.rotation.x;
        if (isWhiteTurn) {
            Camera.main.transform.position = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 10);
            Camera.main.transform.Rotate(new Vector3(camRotX, 180, 0), Space.World);
        } else {
            Camera.main.transform.position = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - 10);
            Camera.main.transform.Rotate(new Vector3(camRotX, -180, 0), Space.World);
        }
    }

    private void EndGame() {
        if (isWhiteTurn)
            Debug.Log("White Team Wins");
        else
            Debug.Log("Black Team Wins");

        foreach (GameObject go in activeChessman)
            Destroy(go);

        isWhiteTurn = true;
        BoardHighlights.Instance.HideHighlights();
        spawnAllChessmans();
    }

    // Update is called once per frame
    void Update() {
        UpdateSelection();
        DrawChessboard();

        if (Input.GetMouseButtonDown(0)) {
            if (selectionX >= 0 && selectionY >= 0) {
                if (selectedChessman == null) {
                    // Select Chessman
                    SelectChessman(selectionX, selectionY);
                } else {
                    // Move the Chessman
                    MoveChessman(selectionX, selectionY);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        Instance = this;
        spawnAllChessmans();
	}
}
