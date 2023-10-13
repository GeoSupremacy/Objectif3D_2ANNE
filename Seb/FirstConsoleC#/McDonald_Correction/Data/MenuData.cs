using System;

namespace McDonald_Correction
{
    internal class MenuData
    {
        
        public string Label { get; private set; } = string.Empty;
        public Action MenuAction { get; private set; } 
        public MenuData(string _label, Action _menuAction)
        {
            Label = _label;
            MenuAction = _menuAction;
        }
    }
}
