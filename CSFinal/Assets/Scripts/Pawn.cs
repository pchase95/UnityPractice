using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessMan {
    public override bool[,] PossibleMove() {
        bool[,] r = new bool[8, 8];
        ChessMan c, c2;
        
        // White moves
        if (IsWhite) {
            // Diagonal Left
            if (CurrentX != 0 && CurrentY != 7) {
                c = BoardManager.Instance.ChessMans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.IsWhite) {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
            }

            // Diagonal Right
            if (CurrentX != 7 && CurrentY != 7) {
                c = BoardManager.Instance.ChessMans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.IsWhite)
                    r[CurrentX + 1, CurrentY + 1] = true;
            }

            // Middle
            if (CurrentY != 7) {
                c = BoardManager.Instance.ChessMans[CurrentX, CurrentY + 1];
                if (c == null)
                    r[CurrentX, CurrentY + 1] = true;
            }

            // Middle on first move
            if (CurrentY == 1) {
                c = BoardManager.Instance.ChessMans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.ChessMans[CurrentX, CurrentY + 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY + 2] = true;
            }
        } else {
            // Diagonal Left
            if (CurrentX != 0 && CurrentY != 0) {
                c = BoardManager.Instance.ChessMans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.IsWhite) {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }
            }

            // Diagonal Right
            if (CurrentX != 7 && CurrentY != 0) {
                c = BoardManager.Instance.ChessMans[CurrentX + 1, CurrentY - 1];
                if (c != null && c.IsWhite)
                    r[CurrentX + 1, CurrentY - 1] = true;
            }

            // Middle
            if (CurrentY != 0) {
                c = BoardManager.Instance.ChessMans[CurrentX, CurrentY - 1];
                if (c == null)
                    r[CurrentX, CurrentY - 1] = true;
            }

            // Middle on first move
            if (CurrentY == 6) {
                c = BoardManager.Instance.ChessMans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.ChessMans[CurrentX, CurrentY - 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY - 2] = true;
            }
        }

        return r;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
