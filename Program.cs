using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program
{
    public class Game
    {
        public string winnerName;
        public string looserName;

        public int rating;
        public int index;

        public Game(string winnerName, string looserName,int rating,int index){
            this.winnerName = winnerName;
            this.looserName = looserName;
            this.rating = rating;
            this.index = index;
        }
    }

    public class GameAccount
    {
        
        public string UserName;
        public int CurrentRating;
        public int GamesCount;

        public List<Game> stats = new List<Game>();

        public GameAccount(string UserName){
            this.UserName = UserName;
            this.CurrentRating = 10;
            this.GamesCount = 0;
        }

        public void WinGame(string opponentName, int Rating){
            this.CurrentRating+=Rating;
            this.GamesCount++;

            Game gm = new Game(this.UserName, opponentName, Rating, this.GamesCount-1);
            stats.Add(gm);
        }

        public void LoseGame(string opponentName, int Rating){
            if(this.CurrentRating>Rating){
                this.CurrentRating-=Rating;
            }
            else{
                this.CurrentRating = 1;
            }
            this.GamesCount++;

            Game gm = new Game(opponentName, this.UserName, Rating, this.GamesCount-1);
            stats.Add(gm);
        }

        public void GetStats(){
             for (int i = 0; i < this.stats.Count; i++){
                Console.WriteLine("\nUSERNAME - " + this.UserName);
                Console.WriteLine("Game "+stats[i].index+"(rating "+stats[i].rating+
                "):");
                Console.WriteLine("Win - "+stats[i].winnerName+"; Lose - "+stats[i].looserName);
             }
        }
    }

    class Program
    {

        public static void playGame(GameAccount user1,GameAccount user2, int rating){
            if(rating>=0){
                Random rnd = new Random();
                int value1 = rnd.Next(0, 10);

                if(value1<5){
                    user1.WinGame(user2.UserName,rating);
                    user2.LoseGame(user1.UserName,rating);
                }
                else{
                    user2.WinGame(user1.UserName,rating);
                    user1.LoseGame(user2.UserName,rating);
                }
                
            }
            else{
                 Console.WriteLine("Error: negative rating!");
            }
        }
        public static void Main(string[] args)
        {
            GameAccount user1 = new GameAccount("Grysha");
            GameAccount user2 = new GameAccount("Mysha");

            playGame(user1,user2,-2);
            playGame(user1,user2,6);    
            playGame(user1,user2,8);

            user1.GetStats();
            user2.GetStats();

            Console.WriteLine("\nCurrenr rating: user1 - " + user1.CurrentRating+"; user2 - " + user2.CurrentRating);
        }
    }
}