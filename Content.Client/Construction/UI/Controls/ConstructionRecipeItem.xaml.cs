using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;


namespace Content.Client.Construction.UI.Controls;

public sealed partial class ConstructionMenuRecipeItem : Control
{
    public bool ToggleState
    {
        get;
        set;
    }

    public ConstructionMenuRecipeItem()
    {
        
    }
}
