

// Generated on 04/17/2013 22:30:08
using System;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.IO;

namespace BiM.Protocol.Types
{
    public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
    {
        public const short Id = 386;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short curCompletion;
        public short maxCompletion;
        
        public QuestObjectiveInformationsWithCompletion()
        {
        }
        
        public QuestObjectiveInformationsWithCompletion(short objectiveId, bool objectiveStatus, string[] dialogParams, short curCompletion, short maxCompletion)
         : base(objectiveId, objectiveStatus, dialogParams)
        {
            this.curCompletion = curCompletion;
            this.maxCompletion = maxCompletion;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(curCompletion);
            writer.WriteShort(maxCompletion);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            curCompletion = reader.ReadShort();
            if (curCompletion < 0)
                throw new Exception("Forbidden value on curCompletion = " + curCompletion + ", it doesn't respect the following condition : curCompletion < 0");
            maxCompletion = reader.ReadShort();
            if (maxCompletion < 0)
                throw new Exception("Forbidden value on maxCompletion = " + maxCompletion + ", it doesn't respect the following condition : maxCompletion < 0");
        }
        
    }
    
}