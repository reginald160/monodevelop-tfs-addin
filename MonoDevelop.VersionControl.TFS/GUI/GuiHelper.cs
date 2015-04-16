﻿// GuiHelper.cs
// 
// Author:
//       Ventsislav Mladenov
// 
// The MIT License (MIT)
// 
// Copyright (c) 2013-2015 Ventsislav Mladenov
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using Autofac;
using MonoDevelop.VersionControl.TFS.Infrastructure;
using MonoDevelop.VersionControl.TFS.VersionControl.Enums;
using Xwt;

namespace MonoDevelop.VersionControl.TFS.GUI
{
    public static class GuiHelper
    {
        public static ComboBox GetLockLevelComboBox(bool forceLock = false)
        {
            ComboBox lockLevelBox = new ComboBox { WidthRequest = 150 };

            if (!forceLock)
                lockLevelBox.Items.Add(LockLevel.Unchanged, "Unchanged - Keep any existing lock.");
            lockLevelBox.Items.Add(LockLevel.CheckOut, "Check Out - Prevent other users from checking out and checking in");
            lockLevelBox.Items.Add(LockLevel.Checkin, "Check In - Prevent other users from checking in but allow checking out");
            var service = DependencyInjection.Container.Resolve<TFSVersionControlService>();
            if (forceLock && service.CheckOutLockLevel == LockLevel.Unchanged)
                lockLevelBox.SelectedItem = LockLevel.CheckOut;
            else
                lockLevelBox.SelectedItem = service.CheckOutLockLevel;
            return lockLevelBox;
        }
    }
}