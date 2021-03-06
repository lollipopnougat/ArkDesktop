﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */
using Chromium;
using System.Threading;
using Chromium.Event;

namespace ArkDesktopCfx
{
    partial class ArkDesktopBrowserControl
    {
        void LoadHandler_OnLoadError(object sender, CfxOnLoadErrorEventArgs e)
        {
            if (e.ErrorCode == CfxErrorCode.Aborted)
            {
                // this seems to happen when calling LoadUrl and the browser is not yet ready
                var url = e.FailedUrl;
                var frame = e.Frame;
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(200);
                    frame.LoadUrl(url);
                });
            }
        }
        private void LoadHandler_OnLoadEnd(object sender, Chromium.Event.CfxOnLoadEndEventArgs e)
        {
            //Manager.control.Zoom = Manager.control.Zoom;
        }

    }
}
