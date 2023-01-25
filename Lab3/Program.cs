using Lab3;

Token token = new Token();
Console.WriteLine("Enter your message:");
token.Data = Convert.ToString(Console.ReadLine());
Console.WriteLine("Enter counts of stream:");
token.Recipient = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter TTL:");
token.TimeOfLife = Convert.ToInt32(Console.ReadLine());

await TaskManager.TokenRing(5, token);
