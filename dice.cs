using System;
public class Dice
{
    public int Roll()
    {
         Random r = new Random();
         return r.Next(1, 6);
    }
}