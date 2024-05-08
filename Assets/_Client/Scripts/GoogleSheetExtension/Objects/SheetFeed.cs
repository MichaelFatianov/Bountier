using System;

namespace _Client_.Scripts.GoogleSheetExtension.Objects
{
    [Serializable]
    public class SheetFeed
    {
        public string range;
        public string majorDimension;
        public string[][] values;
    }
}