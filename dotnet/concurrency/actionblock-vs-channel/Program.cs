using System.Threading.Tasks.Dataflow;

var block = new ActionBlock<int>(val =>
{
    Console.WriteLine($"受け取った: {val}");
});

block.Post(1);
block.Post(2);
block.Post(3);

block.Complete();
await block.Completion;
