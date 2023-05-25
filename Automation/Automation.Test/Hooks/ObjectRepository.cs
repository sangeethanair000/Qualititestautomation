﻿using Automation.Drivers;
using OpenQA.Selenium;

namespace Automation.Hooks
{
    /// <summary>
    /// This is used by Specflow tests as a way to share the driver between steps.
    /// </summary>
    public static class ObjectRepository
    {
        public static IWebDriver? Driver { get; set; }
    }
}
