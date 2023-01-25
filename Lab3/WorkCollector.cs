using Lab3;
using System.Threading.Channels;

internal static class WorkCollector
{
    public static async Task TokenWorkInTasks(int thisTaskNumb, Channel<Token, Token> readFrom, Channel<Token> writeTo)
    {
        await readFrom.Reader.WaitToReadAsync();
        var token = await readFrom.Reader.ReadAsync();
        token.TimeOfLife--;
        if (token.Recipient == thisTaskNumb && token.TimeOfLife > 0)
        {
            Console.WriteLine($"I'm {thisTaskNumb} and I've got message: {token.Data}");
        }
        else
        {
            if (token.TimeOfLife <= 0)
            {
                Console.WriteLine($"Time is over, time of life = {token.TimeOfLife}");
                return;
            }
            Console.WriteLine($"I'm {thisTaskNumb}, not my time of life = {token.TimeOfLife}");
            await writeTo.Writer.WriteAsync(token);
        }
    }
}