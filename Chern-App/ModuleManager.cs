using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chern_App
{
    public static class ModuleManager
    {
        public delegate void SideBarAddButtonHandler(Button button);
        public static event SideBarAddButtonHandler AddButtonRequested;

        public delegate void ShowPageHandler(Page page);
        public static event ShowPageHandler ShowPageRequested;

        public static void AddButtonRequest(Button button)
        {
            AddButtonRequested?.Invoke(button);
        }

        public static void ShowPageRequest(Page page)
        {
            ShowPageRequested?.Invoke(page);
        }
    }
}
