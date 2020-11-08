using System;

namespace ChatApp.Contracts.Domain
{
   public class Message
   {
      public DateTime TimeSent { get; set; }

      public string FromUserId { get; set; }

      public string ToUserId { get; set; }

      public string MessageSent { get; set; }
   }
}