namespace HelloWorld
{


    public class Program
    {

        public static async Task Main(string[] args)
        {
            Task task = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Task 1");
            });

            task.Start();

            Task secondTask = ConsoleAfterDelayAsync("Task 2", 150);

            Task thirdTask = ConsoleAfterDelayAsync("Task 3", 50);

            Console.WriteLine("After task 1");

            await task;
            await secondTask;
            await thirdTask;
        }

        static void ConsoleAfterDelay(string text, int delayTime)
        {
            Thread.Sleep(delayTime);
            Console.WriteLine(text);
        }

        static async Task ConsoleAfterDelayAsync(string text, int delayTime)
        {
            await Task.Delay(delayTime);
            Console.WriteLine(text);
        }
    }
}
