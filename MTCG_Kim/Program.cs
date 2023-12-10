using MTCG_Kim.Controllers;

namespace MTCG_Kim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:10001/";
            UserController userController = new UserController(url);
            userController.Start();
        }
    }
}