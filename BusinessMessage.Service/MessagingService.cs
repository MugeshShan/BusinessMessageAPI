using BusinessMessage.Client;
using BusinessMessage.Domain;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BusinessMessage.Service
{
    public class MessagingService : IMessageService
    {
        private readonly IFirebaseClient firebaseClient;
        private MessageClient businessMessageClient;
        public MessagingService()
        {
            IFirebaseConfig firebaseConfig = new FirebaseConfig
            {
                AuthSecret = "4doN7335eFSjG2qyj1BLNqxmAq56yciFLhZhd5Zx",
                BasePath = "https://titanium-acumen-349104-default-rtdb.firebaseio.com/"
            };

            firebaseClient = new FirebaseClient(firebaseConfig);

            var messageHttpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://businessmessages.googleapis.com")
            };
            businessMessageClient = new MessageClient(messageHttpClient);
        }

        public Dictionary<string, dynamic> Verification(dynamic jsonElement)
        {
            var dict1 = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(jsonElement);
            //var propertyInfo = jsonElement.GetType().GetProperties();
            //var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonElement);

             return dict1;
            //return null;
        }
        //public Task<string> GetMessageOrEvent(JsonElement jsonElement)
        //{
        //    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonElement);
        //    var messageModel = new MessageModel();
        //    if (dict != null && dict.ContainsKey("clientToken"))
        //    {
        //        messageModel.ClientToken = dict["clientToken"];
        //    }
        //    if (dict != null && dict.ContainsKey("secret"))
        //    {
        //        messageModel.Secret = dict["secret"];
        //    }
        //    var conversationId = dict["conversationId"];
        //    var eventId = Guid.NewGuid().ToString();

        //    if (dict != null && !dict.ContainsKey("messageText"))
        //    { 
        //        businessMessageClient.CreateEventAsync(conversationId, eventId, new BusinessMessagesEvent() { EventType = BusinessMessagesEventEventType.TYPING_STOPPED });
        //    }

        //    var msgId = Guid.NewGuid().ToString();

            

        //    if (dict != null && dict.ContainsKey("messageText"))
        //    {
        //        //var conversationId = dict["conversationId"];
        //        //var eventId = Guid.NewGuid().ToString();
        //        businessMessageClient.CreateMessageAsync("erre", false, new BusinessMessagesMessage()
        //        {
        //            MessageId = msgId,
        //            Text = "Hello customer"

        //        });
        //    }

        //    return Task.FromResult(messageModel.Secret);
        //}
        
        public object GetUser()
        {
            //var user = firebaseClient.GetAsync("@users")
            return null;
        }
    }
}
