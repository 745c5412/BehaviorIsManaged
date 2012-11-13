

// Generated on 10/25/2012 10:42:36
using System;
using System.Collections.Generic;
using System.Linq;
using BiM.Protocol.Types;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
    public class ChatClientPrivateMessage : ChatAbstractClientMessage
    {
        public const uint Id = 851;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string receiver;
        
        public ChatClientPrivateMessage()
        {
        }
        
        public ChatClientPrivateMessage(string content, string receiver)
         : base(content)
        {
            this.receiver = receiver;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(receiver);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            receiver = reader.ReadUTF();
        }
        
    }
    
}