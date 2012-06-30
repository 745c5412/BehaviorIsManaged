// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'GameActionFightTackledMessage.xml' the '27/06/2012 15:54:57'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;

namespace BiM.Protocol.Messages
{
	public class GameActionFightTackledMessage : AbstractGameActionMessage
	{
		public const uint Id = 1004;
		public override uint MessageId
		{
			get
			{
				return 1004;
			}
		}
		
		public IEnumerable<int> tacklersIds;
		
		public GameActionFightTackledMessage()
		{
		}
		
		public GameActionFightTackledMessage(short actionId, int sourceId, IEnumerable<int> tacklersIds)
			 : base(actionId, sourceId)
		{
			this.tacklersIds = tacklersIds;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUShort((ushort)tacklersIds.Count());
			foreach (var entry in tacklersIds)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			int limit = reader.ReadUShort();
			tacklersIds = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(tacklersIds as int[])[i] = reader.ReadInt();
			}
		}
	}
}