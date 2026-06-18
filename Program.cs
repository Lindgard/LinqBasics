using be_linqBasics.Controllers;
namespace be_linqBasics;

class Program
{
    static void Main(string[] args)
    {
        var controller = new UfoController();
        controller.Run();
    }
}
