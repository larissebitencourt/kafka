using Confluent.Kafka;
using Kafka.Consumer;
using Kafka.Producer;

class Program
{
    static void Main()
    {
        string topic = "topic-hello-kafka";
        string message = "Hello, Kafka Consumer";

        var delivery = ProducerService.ProducerMessage(topic, message);

        if (delivery.Status == PersistenceStatus.NotPersisted)
        {
            Console.WriteLine($"Message {delivery.Message.Value} - {delivery.Status}");
            Console.WriteLine($"Application finished!");
            return;
        }

        Console.Write($"Message {delivery.Message.Value} {delivery.Status}." +
            $"\nTopic: {delivery.Topic}" +
            $"\nPartition: {delivery.Partition}" +
            $"\nOffset {delivery.Offset}\n");

        ConsumerService.ConsumerMessage(topic);

        Console.WriteLine();
    }
}
