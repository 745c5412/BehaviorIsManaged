﻿package com.ankamagames.jerakine.sequencer
{

    public interface ISequencer extends ISequencableListener, IEventDispatcher
    {

        public function ISequencer();

        function addStep(param1:ISequencable) : void;

        function start() : void;

        function toString() : String;

        function get length() : uint;

        function get steps() : Array;

        function clear() : void;

        function get running() : Boolean;

    }
}
