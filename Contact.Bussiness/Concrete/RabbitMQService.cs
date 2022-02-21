using Contact.Bussiness.Abstract;
using Core.Utilities.Results;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Contact.Bussiness.Concrete
{
    public class RabbitMQService : IMessageQueueService
    {
        private readonly string rabbitMqConnection;
        public RabbitMQService(IConfiguration configuration)
        {
            rabbitMqConnection = configuration.GetSection("RabbitMQConnection").Value;
        }
        public IResult SendMessage(string queueName, string message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(rabbitMqConnection);

            using (var connection = factory.CreateConnection())
            {
                var channel = connection.CreateModel();

                channel.QueueDeclare(queueName, true, false, false);

                var messageBody = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(string.Empty, queueName, null, messageBody);

                if (!channel.IsClosed)
                    channel.Close();
            }

            return new SuccessDataResult<object>(null);
        }

        public void RecieveMessage(string queueName, Func<string, bool> action)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(rabbitMqConnection);

            var connection = factory.CreateConnection();
           
            var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume(queueName, false, consumer);

            consumer.Received += (s, e) =>
            {
                string message = Encoding.UTF8.GetString(e.Body.ToArray());

                var result = action(message);
                if (result)
                    channel.BasicAck(e.DeliveryTag, false);

                Thread.Sleep(1500);
            };
            
        }
    }
}
