﻿using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintBrowser
{
    internal class MenuHandler : IContextMenuHandler
    {
        private const int ShowDevTools = 26501;
        private const int CloseDevTools = 26502;
        private const int ReloadNoCache = 103;

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //To disable the menu then call clear
            // model.Clear();

            //Removing existing menu item
            //bool removed = model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option

            //Add new custom menu items
            model.Clear();
            model.AddItem((CefMenuCommand)ReloadNoCache, "Refresh");
            model.AddItem((CefMenuCommand)ShowDevTools, "Show DevTools");
            model.AddItem((CefMenuCommand)CloseDevTools, "Close DevTools");
        }

        bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if ((int)commandId == ShowDevTools)
            {
                browser.ShowDevTools();
            }
            if ((int)commandId == CloseDevTools)
            {
                browser.CloseDevTools();
            }
            return false;
        }

        void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
