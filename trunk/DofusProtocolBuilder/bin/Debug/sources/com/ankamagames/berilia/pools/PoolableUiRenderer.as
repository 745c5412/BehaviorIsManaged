﻿package com.ankamagames.berilia.pools
{
    import com.ankamagames.berilia.uiRender.*;

    public class PoolableUiRenderer extends UiRenderer implements Poolable
    {

        public function PoolableUiRenderer()
        {
            return;
        }// end function

        public function free() : void
        {
            _nTimeStamp = 0;
            _scUi = null;
            return;
        }// end function

    }
}
