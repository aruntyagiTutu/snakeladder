namespace SnakeLadder
{
using System.Collections.Generic;

// Builder pattern to create game instance 
public class GameBuilder
{
    protected Game game = new Game();


    public Game Build()
    {
        game.dice = new Dice();
        game.board = new Board();
        return game;
    }

    public GameBuilder AddPlayers(List<Player> players)
    {
        foreach (var player in players)
        {
            game.players.Enqueue(player);
        }
        return this;
    }


}

public class BoardBuilder: GameBuilder
{

}

public class Game
{
    public Board board;
    public Queue<Player> players;
    public Dice dice;
    public Game()
    {
    }

    public void AddPlayer(Player player)
    {
        players.Enqueue(player);
    }


    public void start()
    {
        while(players.Count()>1)
        {
            var currentPlayer = players.Peek();
            var diceV = dice.Roll();
            var newPosition = NewPosition(currentPlayer.Position, diceV);
            currentPlayer.Position = newPosition;
            if (currentPlayer.Position == board.winningState)
            {
                Console.WriteLine($"{currentPlayer.Name} reached end");
            }
            else{
                players.Dequeue();
                players.Enqueue(currentPlayer);
                Console.WriteLine($"{currentPlayer.Name} moved to {currentPlayer.Position}.");
            }
        }
    } 

    int NewPosition(int val, int currentPosition)
    {
        if (currentPosition + val > board.winningState)
        {
            return currentPosition;
        }
        else if(currentPosition == 0){
            return currentPosition;
        }
        else
        {
            var newVal = currentPosition + val;
            // check snake
            if(board.snakes.ContainsKey(newVal))
            {
                return board.snakes[newVal].tail;
            }
            // ladder
            if(board.ladders.ContainsKey(newVal))
            {
                return board.ladders[newVal].top;
            }
            return newVal;
        }
    }
}
}