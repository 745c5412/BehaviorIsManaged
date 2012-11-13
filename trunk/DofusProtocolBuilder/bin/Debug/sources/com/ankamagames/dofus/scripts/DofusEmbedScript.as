﻿package com.ankamagames.dofus.scripts
{
    import com.ankamagames.jerakine.script.*;
    import flash.utils.*;

    public class DofusEmbedScript extends Object
    {
        private static const SCRIPT_1_DATA:Class = DofusEmbedScript_SCRIPT_1_DATA;
        private static const SCRIPT_1_URI:String = "spellScripts/1.dx";
        private static const SCRIPT_2_DATA:Class = DofusEmbedScript_SCRIPT_2_DATA;
        private static const SCRIPT_2_URI:String = "spellScripts/2.dx";
        private static const SCRIPT_3_DATA:Class = DofusEmbedScript_SCRIPT_3_DATA;
        private static const SCRIPT_3_URI:String = "spellScripts/3.dx";
        private static const SCRIPT_5_DATA:Class = DofusEmbedScript_SCRIPT_5_DATA;
        private static const SCRIPT_5_URI:String = "spellScripts/5.dx";
        private static const SCRIPT_6_DATA:Class = DofusEmbedScript_SCRIPT_6_DATA;
        private static const SCRIPT_6_URI:String = "spellScripts/6.dx";
        private static const SCRIPT_7_DATA:Class = DofusEmbedScript_SCRIPT_7_DATA;
        private static const SCRIPT_7_URI:String = "spellScripts/7.dx";
        private static const _cache:Dictionary = new Dictionary();

        public function DofusEmbedScript()
        {
            return;
        }// end function

        public static function getScript(param1:uint) : BinaryScript
        {
            if (!_cache[param1])
            {
                _cache[param1] = new BinaryScript(new ["SCRIPT_" + param1 + "_DATA"], ["SCRIPT_" + param1 + "_URI"]);
            }
            return _cache[param1];
        }// end function

    }
}
