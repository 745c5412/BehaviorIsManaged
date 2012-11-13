﻿package com.ankamagames.dofus.network.messages.game.actions.fight
{
    import com.ankamagames.dofus.network.messages.game.actions.*;
    import flash.utils.*;

    public class GameActionFightDropCharacterMessage extends AbstractGameActionMessage implements INetworkMessage
    {
        private var _isInitialized:Boolean = false;
        public var targetId:int = 0;
        public var cellId:int = 0;
        public static const protocolId:uint = 5826;

        public function GameActionFightDropCharacterMessage()
        {
            return;
        }// end function

        override public function get isInitialized() : Boolean
        {
            return super.isInitialized && this._isInitialized;
        }// end function

        override public function getMessageId() : uint
        {
            return 5826;
        }// end function

        public function initGameActionFightDropCharacterMessage(param1:uint = 0, param2:int = 0, param3:int = 0, param4:int = 0) : GameActionFightDropCharacterMessage
        {
            super.initAbstractGameActionMessage(param1, param2);
            this.targetId = param3;
            this.cellId = param4;
            this._isInitialized = true;
            return this;
        }// end function

        override public function reset() : void
        {
            super.reset();
            this.targetId = 0;
            this.cellId = 0;
            this._isInitialized = false;
            return;
        }// end function

        override public function pack(param1:IDataOutput) : void
        {
            var _loc_2:* = new ByteArray();
            this.serialize(_loc_2);
            writePacket(param1, this.getMessageId(), _loc_2);
            return;
        }// end function

        override public function unpack(param1:IDataInput, param2:uint) : void
        {
            this.deserialize(param1);
            return;
        }// end function

        override public function serialize(param1:IDataOutput) : void
        {
            this.serializeAs_GameActionFightDropCharacterMessage(param1);
            return;
        }// end function

        public function serializeAs_GameActionFightDropCharacterMessage(param1:IDataOutput) : void
        {
            super.serializeAs_AbstractGameActionMessage(param1);
            param1.writeInt(this.targetId);
            if (this.cellId < -1 || this.cellId > 559)
            {
                throw new Error("Forbidden value (" + this.cellId + ") on element cellId.");
            }
            param1.writeShort(this.cellId);
            return;
        }// end function

        override public function deserialize(param1:IDataInput) : void
        {
            this.deserializeAs_GameActionFightDropCharacterMessage(param1);
            return;
        }// end function

        public function deserializeAs_GameActionFightDropCharacterMessage(param1:IDataInput) : void
        {
            super.deserialize(param1);
            this.targetId = param1.readInt();
            this.cellId = param1.readShort();
            if (this.cellId < -1 || this.cellId > 559)
            {
                throw new Error("Forbidden value (" + this.cellId + ") on element of GameActionFightDropCharacterMessage.cellId.");
            }
            return;
        }// end function

    }
}
