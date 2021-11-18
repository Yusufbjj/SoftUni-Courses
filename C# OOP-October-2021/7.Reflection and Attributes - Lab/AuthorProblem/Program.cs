
namespace AuthorProblem
{
    [Author("Az")]
    [Author("ti")]
    [Author("tq")]
    public class StartUp
    {
        [Author("Gosho")]
        public static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }


}
