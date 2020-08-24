﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    //public int moves;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckMatch(ShapeScript[] shapes, bool canCheck) // Can Tidy up but dont need to rush
    {
        if (!canCheck)
            return false;

        bool Checkings = false;

        foreach (ShapeScript shape in shapes)
        {
            bool[] Check = new bool[4];
            bool[] yCheck = new bool[2];
            bool[] xCheck = new bool[2];
            //print("shape name = " + shape.name);
            for (int i = 0; i < shape.adjacentShapeColliders.Length; i++)
            {
                //print("sshape.adjacentShapeColliders[i].shape.name = " + shape.adjacentShapeColliders[i].shape.name);
                if (shape.adjacentShapeColliders[i].shape == null) { continue; }
                if (shape.adjacentShapeColliders[i].shape.name != shape.name) { continue; }   // can change to check for ID instead but i not sure if needed rn

                Check[i] = true;

            }


            if (Check[0] && Check[1]) { Destroy(shape.gameObject); Destroy(shape.adjacentShapeColliders[0].shape); Destroy(shape.adjacentShapeColliders[1].shape); Checkings = true; }
            if (Check[2] && Check[3]) { Destroy(shape.gameObject); Destroy(shape.adjacentShapeColliders[2].shape); Destroy(shape.adjacentShapeColliders[3].shape); Checkings = true; }

            for(int i =0; i< Check.Length; i++)
            {
                if (shape.adjacentShapeColliders[i].shape == null) { break; }
                if (!Check[i]) { continue; }
                if (shape.adjacentShapeColliders[i].shape.GetComponent<ShapeScript>().adjacentShapeColliders[i].shape == null) { break; }
                if (shape.adjacentShapeColliders[i].shape.GetComponent<ShapeScript>().adjacentShapeColliders[i].shape.name == shape.name)
                {
                    Destroy(shape.gameObject);
                    Destroy(shape.adjacentShapeColliders[i].shape);
                    Destroy(shape.adjacentShapeColliders[i].shape.GetComponent<ShapeScript>().adjacentShapeColliders[i].shape);
                    Checkings = true;
                }
            }
            /*
            if (xCheck[0]) 
            {
                if (shape.adjacentShapeColliders[0].shape == null) { break; }
                if (shape.adjacentShapeColliders[0].shape.GetComponent<ShapeScript>().adjacentShapeColliders[0].shape == null) { break; } 
                if (shape.adjacentShapeColliders[0].shape.GetComponent<ShapeScript>().adjacentShapeColliders[0].shape.name == shape.name) { return true; } 
            }
            if (xCheck[1])
            {
                if (shape.adjacentShapeColliders[1].shape == null) { break; }
                if (shape.adjacentShapeColliders[1].shape.GetComponent<ShapeScript>().adjacentShapeColliders[1].shape == null) { break; }
                if (shape.adjacentShapeColliders[1].shape.GetComponent<ShapeScript>().adjacentShapeColliders[1].shape.name == shape.name) { return true; }
            }
            if (yCheck[0])
            {
                if (shape.adjacentShapeColliders[2].shape == null) { break; }
                if (shape.adjacentShapeColliders[2].shape.GetComponent<ShapeScript>().adjacentShapeColliders[2].shape == null) { break; }
                if (shape.adjacentShapeColliders[2].shape.GetComponent<ShapeScript>().adjacentShapeColliders[2].shape.name == shape.name) { return true; }
            }
            if (yCheck[1])
            {
                if (shape.adjacentShapeColliders[3].shape == null) { break; }
                if (shape.adjacentShapeColliders[3].shape.GetComponent<ShapeScript>().adjacentShapeColliders[3].shape == null) { break; }
                if (shape.adjacentShapeColliders[3].shape.GetComponent<ShapeScript>().adjacentShapeColliders[3].shape.name == shape.name) { return true; }
            }


            */
        }
        return Checkings;
    }

    public void GainScore(int plusScore)
    {
        score += plusScore;
        scoreText.text = "Score : " + score;
    }
}
