using BusinessMessage.API.Models;
using BusinessMessage.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BusinessMessage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessMessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        private string ConversationId;
        private Message Message = new Message();
        private UserStatus UserStatus = new UserStatus();
        public BusinessMessageController(IMessageService _messageService)
        {
            messageService = _messageService;
        }
        //[HttpPost]
        //[Route("callback")]
        //public async Task<ActionResult<string>> Callback([FromBody] MessageModel request)
        //{

        //    if(request.ClientToken != null)
        //    {
        //        var httpClient = new HttpClient()
        //        {
        //            BaseAddress = new Uri("http://businesscommunications.googleapis.com")
        //        };

        //        var client = new Client.Client(httpClient);

        //        //client.CreateAgentAsync
        //        return Ok("secret:" + request.Secret);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpPost]
        [Route("callback")]
        public ActionResult<string> Callback([FromBody] dynamic request)
        {

            var dict = messageService.Verification(request);
            //var d = JsonDocument.Parse(request);
            //var result = d.RootElement.EnumerateObject();
            foreach (var r in dict)
            {
                if (r.Value.ValueKind == JsonValueKind.String)
                {
                    if (r.Key == "conversationId")
                    {
                        ConversationId = System.Text.Json.JsonSerializer.Deserialize<string>(r.Value);
                    }
                }

                if(r.Value.ValueKind == JsonValueKind.Object)
                {
                    if (r.Key == "message")
                    {
                        //var messageValue = 
                        var msgDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, dynamic>>(r.Value);
                        foreach (var us in msgDict)
                        {
                            if (us.Key == "text")
                            {
                                Message.Text = System.Text.Json.JsonSerializer.Deserialize<string>(us.Value);
                            }
                            if (us.Key == "createTime")
                            {
                                Message.CreateTime = System.Text.Json.JsonSerializer.Deserialize<string>(us.Value);
                            }
                            if (us.Key == "name")
                            {
                                Message.Name = System.Text.Json.JsonSerializer.Deserialize<string>(us.Value);
                            }
                            if (us.Key == "messageId")
                            {
                                Message.MessageId = System.Text.Json.JsonSerializer.Deserialize<string>(us.Value);
                            }
                        }
                    }
                    if (r.Key == "userStatus")
                    {
                        var usDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, dynamic>>(r.Value);
                        foreach(var us in usDict)
                        {
                            if(us.Key == "isTyping")
                            {
                                UserStatus.IsTyping = System.Text.Json.JsonSerializer.Deserialize<Boolean>(us.Value) ;
                            }
                            if(us.Key == "createTime")
                            {
                                UserStatus.CreateTime = System.Text.Json.JsonSerializer.Deserialize<string>(us.Value);
                            }
                        }
                    }
                }
            }
            //var messageModel = new MessageModel();
            //if (dict != null && dict.ContainsKey("clientToken"))
            //{
            //    messageModel.ClientToken = dict["clientToken"];
            //}
            //if (dict != null && dict.ContainsKey("secret"))
            //{
            //    messageModel.Secret = dict["secret"];
            //}




            //if (messageModel.Secret == null)
            //{
            //    var message = messageService.GetMessageOrEvent(request);
            //}

            return Ok();
            //return Ok("secret:" + messageModel.Secret);
        }
    }
}
