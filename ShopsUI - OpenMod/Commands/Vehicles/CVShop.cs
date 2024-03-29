﻿using Cysharp.Threading.Tasks;
using OpenMod.API;
using OpenMod.API.Prioritization;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using ShopsUI.UI.Vehicles;
using SilK.Unturned.Extras.UI;
using System;

namespace ShopsUI.Commands.Vehicles
{
    [Command("vshop", Priority = Priority.High)]
    [CommandAlias("vshops")]
    [CommandAlias("vehicleshop")]
    [CommandAlias("vehicleshops")]
    [CommandDescription("Opens the vehicle shop UI.")]
    public class CVShop : UnturnedCommand
    {
        private readonly IUIManager _uiManager;
        private readonly IOpenModComponent _openModComponent;

        public CVShop(IUIManager uiManager,
            IOpenModComponent openModComponent,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _uiManager = uiManager;
            _openModComponent = openModComponent;
        }

        protected override async UniTask OnExecuteAsync()
        {
            await UniTask.SwitchToMainThread();

            if (Context.Actor is not UnturnedUser user)
            {
                throw new CommandWrongUsageException(Context);
            }

            await _uiManager.StartSession<VehicleShopsUISession>(user, lifetimeScope: _openModComponent.LifetimeScope);
        }
    }
}
