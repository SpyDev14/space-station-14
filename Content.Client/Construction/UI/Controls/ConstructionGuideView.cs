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

    private BoxContainer _rootBox;

    public ConstructionGuideView()
    {
        AddChild(_rootBox = new VBox() { SeparationOverride = 4 });
    }

    public void SetGuide(ConstructionGuide guide)
    {
        if (guide == CurrentGuide)
            return;

        CurrentGuide = guide;
        ClearSteps();

        foreach (var entry in guide.Entries)
        {

        }
    }


    private void ClearSteps()
    {
        _rootBox.RemoveAllChildren();
    }

    private void AddStep(FormattedMessage description, string[] conditions)
    {

    }
}
