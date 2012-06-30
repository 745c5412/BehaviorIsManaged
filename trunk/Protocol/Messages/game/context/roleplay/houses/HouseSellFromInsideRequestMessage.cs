// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'HouseSellFromInsideRequestMessage.xml' the '27/06/2012 15:55:03'
using System;
using BiM.Core.IO;

namespace BiM.Protocol.Messages
{
	public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
	{
		public const uint Id = 5884;
		public override uint MessageId
		{
			get
			{
				return 5884;
			}
		}
		
		
		public HouseSellFromInsideRequestMessage()
		{
		}
		
		public HouseSellFromInsideRequestMessage(int amount)
			 : base(amount)
		{
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}
	}
}