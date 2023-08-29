namespace SnakeLadder
{
using System;
using System.Collections.Generic;

public class Board
{
    public Dictionary<int, Snake> snakes;
    public Dictionary<int, Ladder> ladders;
    public int winningState;
    public void Init()
    {
        winningState = 100;
        // add snakes
        snakes = new Dictionary<int, Snake>();
        snakes.Add(26, 
            new Snake(){
            face = 26,
            tail = 5
        });

        // add ladders 
        ladders = new Dictionary<int, Ladder>();
        ladders.Add(7, new Ladder(){
            top = 27,
            bottom = 7
        });
    }
}
}