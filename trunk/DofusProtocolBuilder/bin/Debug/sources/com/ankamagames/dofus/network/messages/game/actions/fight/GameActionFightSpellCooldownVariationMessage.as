﻿package com.ankamagames.dofus.network.messages.game.actions.fight
{
    import com.ankamagames.dofus.network.messages.game.actions.*;
    import flash.utils.*;

    public class GameActionFightSpellCooldownVariationMessage extends AbstractGameActionMessage implements INetworkMessage
    {
        private var _isInitialized:Boolean = false;
        public var targetId:int = 0;
        public var spellId:uint = 0;
        public var value:int = 0;
        public static const protocolId:uint = 6219;

        public function GameActionFightSpellCooldownVariationMessage()
        {
            return;
        }// end function

        override public function get isInitialized() : Boolean
        {
            return super.isInitialized && this._isInitialized;
        }// end function

        override public function getMessageId() : uint
        {
            return 6219;
        }// end function

        public function initGameActionFightSpellCooldownVariationMessage(param1:uint = 0, param2:int = 0, param3:int = 0, param4:uint = 0, param5:int = 0) : GameActionFightSpellCooldownVariationMessage
        {
            super.initAbstractGameActionMessage(param1, param2);
            this.targetId = param3;
            this.spellId = param4;
            this.value = param5;
            this._isInitialized = true;
            return this;
        }// end function

        override public function reset() : void
        {
            super.reset();
            this.targetId = 0;
            this.spellId = 0;
            this.value = 0;
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
            this.serializeAs_GameActionFightSpellCooldownVariationMessage(param1);
            return;
        }// end function

        public function serializeAs_GameActionFightSpellCooldownVariationMessage(param1:IDataOutput) : void
        {
            super.serializeAs_AbstractGameActionMessage(param1);
            param1.writeInt(this.targetId);
            if (this.spellId < 0)
            {
                throw new Error("Forbidden value (" + this.spellId + ") on element spellId.");
            }
            param1.writeInt(this.spellId);
            param1.writeShort(this.value);
            return;
        }// end function

        override public function deserialize(param1:IDataInput) : void
        {
            this.deserializeAs_GameActionFightSpellCooldownVariationMessage(param1);
            return;
        }// end function

        public function deserializeAs_GameActionFightSpellCooldownVariationMessage(param1:IDataInput) : void
        {
            super.deserialize(param1);
            this.targetId = param1.readInt();
            this.spellId = param1.readInt();
            if (this.spellId < 0)
            {
                throw new Error("Forbidden value (" + this.spellId + ") on element of GameActionFightSpellCooldownVariationMessage.spellId.");
            }
            this.value = param1.readShort();
            return;
        }// end function

    }
}
