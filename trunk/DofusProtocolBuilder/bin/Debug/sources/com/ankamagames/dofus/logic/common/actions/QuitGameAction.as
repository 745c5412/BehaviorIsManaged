﻿package com.ankamagames.dofus.logic.common.actions
{

    public class QuitGameAction extends Object implements Action
    {

        public function QuitGameAction()
        {
            return;
        }// end function

        public static function create() : QuitGameAction
        {
            return new QuitGameAction;
        }// end function

    }
}
