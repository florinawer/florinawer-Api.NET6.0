using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingDDD.Domain.Entities;

namespace TradingDDD.Application.Services.Helpers
{
    public static class EmailHelper
    {
        public static void Send(string log)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://admin:qgcjX5LAnoWjYxKCz8NmwIT1KMyjcx2p@wn3y8t.stackhero-network.com:5671")
            };

            IConnection conn = factory.CreateConnection();
            Console.WriteLine("Connected.");

            IModel model = conn.CreateModel();

            //Aqui hay que poner nuestros nombres, para no compartir los mensajes
            var exchangeName = "Email-exchange-Mel";
            var queueName = "Email-queue-Mel";
            var consoleTestRoutingKey = "Email-key-Mel";

            model.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            model.QueueDeclare(queueName, false, false, false, null);
            model.QueueBind(queueName, exchangeName, consoleTestRoutingKey, null);

            EmailEntity emailEntity = new()
            {
                Subject = "test",
                Body = log,
                SenderEmail = "serilogemails@gmail.com",
                SenderName = "test",
                RecipientEmail = "prahabroikidi-4178@yopmail.com",
                RecipientName = "test",
            };
            //Serializing objects
            var json = JsonConvert.SerializeObject(emailEntity);
            var body = Encoding.UTF8.GetBytes(json);

            model.BasicPublish(exchangeName, consoleTestRoutingKey, null, body);
            Console.WriteLine("Mensaje Enviado con éxito");
        }
    }
}
