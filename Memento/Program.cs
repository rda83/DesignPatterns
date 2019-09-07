/*
* GOF #18
* Memento (Хранитель - паттерн поведения объектов.)
* Не нарушая инкапсуляции, фиксирует и выносит за пределы объекта его внутреннее так,
* чтобы позднее можно было восстановить в нем объект.
* 21/08/2019
*/

using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Set("LVL-1", 10);
            Console.WriteLine(game);

            File file = new File();
            file.Data = game.Save();

            game.Set("LVL-2", 20);
            Console.WriteLine(game);

            game.Load(file.Data);
            Console.WriteLine(game);
        }
    }

    public class Game
    {
        private String level;
        private int time;

        public void Set(String level, int time)
        {
            this.level = level;
            this.time = time;
        }

        public override String ToString()
        {
            return $"Level game: {this.level}. Time game: {this.time}.";
        }

        public Save Save()
        {
            Save save = new Save(this.level, this.time);
            return save;
        }

        public void Load(Save save)
        {
            this.level = save.Level;
            this.time = save.Time;
        }
    }

    public class Save
    {
        public String Level { get; private set; }
        public int Time { get; private set; }

        public Save(String level, int time)
        {
            Level = level;
            Time = time;
        }
    }

    public class File
    {
        public Save Data { get; set; }
    }
}
