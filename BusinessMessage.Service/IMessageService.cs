using BusinessMessage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessMessage.Service
{
    public interface IMessageService
    {
        object GetUser();

        //Task<string> GetMessageOrEvent(JsonElement jsonElement);

        Dictionary<string, dynamic> Verification(dynamic jsonElement);
    }
}
