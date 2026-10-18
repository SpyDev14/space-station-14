using System;
using System.Collections.Generic;
using System.Text;
using Content.Shared.Construction;
using Content.Shared.Construction.Prototypes;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client.Construction.UI.Controls;

public sealed class ConstructionGuideView : Control
{
    public ConstructionGuide? CurrentGuide { get; private set; }

    public ConstructionGuideView()
    {
        var rootBox = new VBox();
        AddChild(rootBox);
    }

    public void SetGuide(ConstructionGuide guide)
    {
        CurrentGuide = guide;
    }
}
