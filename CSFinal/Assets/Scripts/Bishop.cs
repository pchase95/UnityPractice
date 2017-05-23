﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessMan {
    public override bool[,] PossibleMove() {
        bool[,] r = new bool[8, 8];
        ChessMan c;
        int i, j;

        // Up Left
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

                break;
            }
        }

        // Up Right
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i++;
            j++;
            if (i >= 8 || j >= 8)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

                break;
            }
        }

        // Down Left
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i--;
            j--;
            if (i < 0 || j < 0)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

                break;
            }
        }

        // Down Right
        i = CurrentX;
        j = CurrentY;
        while (true) {
            i++;
            j--;
            if (i >= 8 || j < 0)
                break;

            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else {
                if (this.IsWhite != c.IsWhite)
                    r[i, j] = true;

                break;
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
