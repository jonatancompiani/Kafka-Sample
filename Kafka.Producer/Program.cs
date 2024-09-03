// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;

Console.WriteLine("Starting Producer");


var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

string inputText;
do
{
    inputText = Console.ReadLine();
    if (!string.IsNullOrEmpty(inputText))
    {
        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            string topicName = "messages";

            //producer.Produce(topicName, new() { Value = "my message"});

            var result = await producer.ProduceAsync(topicName, new() { Value = inputText });

            Console.WriteLine($"Added on Offset {result.Offset}");
        }
    }
} while (!string.IsNullOrEmpty(inputText));



