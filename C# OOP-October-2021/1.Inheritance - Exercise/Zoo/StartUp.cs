namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal animal = new Animal("Bear");
            Reptile reptile = new Reptile("Lizard");
            Mammal mammal = new Mammal("Monkey");

            Lizard lizard = new Lizard("Lizard");
            Snake snake = new Snake("Cobra");
            Gorilla gorilla = new Gorilla("King Kong");
            Bear bear = new Bear("Grizzly");
        }
    }
}