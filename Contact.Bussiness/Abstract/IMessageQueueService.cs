using Core.Utilities.Results;
using System;

namespace Contact.Bussiness.Abstract
{
    public interface IMessageQueueService
    {
        IResult SendMessage(string queueName, string message);
        void RecieveMessage(string queueName, Func<string, bool> action);
    }
}
