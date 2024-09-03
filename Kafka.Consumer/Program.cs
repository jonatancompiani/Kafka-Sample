// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Threading;

Console.WriteLine("Starting Consumer");


var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "Group01",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using(var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe(["messages"]);

    while (true)
    {
        var consumeResult = consumer.Consume();
        Console.WriteLine($"[{consumeResult.Offset}] {consumeResult.Message.Value}");
        Thread.Sleep(1000);
    }

    consumer.Close();
}