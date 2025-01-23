﻿using Content.Client.UserInterface.Systems.Actions.Controls;
using Content.Shared.Input;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.UserInterface.Systems.Actions.Widgets;

[GenerateTypedNameReferences]
public sealed partial class ActionsBar : UIWidget
{
    [Dependency] private readonly IEntityManager _entity = default!;


    public ActionsBar()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

        var keys = ContentKeyFunctions.GetHotbarBoundKeys();
        for (var index = 1; index < keys.Length; index++)
            ActionsContainer.Children.Add(MakeButton(index));
        ActionsContainer.Children.Add(MakeButton(0));

        ActionButton MakeButton(int index)
        {
            var boundKey = keys[index];
            var button = new ActionButton(_entity);
            button.KeyBind = boundKey;
            button.Label.Text = index.ToString();
            return button;
        }
    }
}
