using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lab3
{
    internal class TaskManager
    {
        public static async Task TokenRing(int tasksCount, Token token)
        {
            List<Task> tasks = new List<Task>();
            List<Channel<Token>> tokenChannels = new();
            tokenChannels.Add(Channel.CreateBounded<Token>(new BoundedChannelOptions(1)));
            await tokenChannels[0].Writer.WriteAsync(token);
            try
            {
                for (var i = 1; i < tasksCount; i++)
                {
                    var taskNumb = i;
                    tokenChannels.Add(Channel.CreateBounded<Token>(new BoundedChannelOptions(1)));
                    tasks.Add(WorkCollector.TokenWorkInTasks(taskNumb, tokenChannels[taskNumb - 1], tokenChannels[taskNumb]));
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
