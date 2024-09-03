using Confluent.Kafka;

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