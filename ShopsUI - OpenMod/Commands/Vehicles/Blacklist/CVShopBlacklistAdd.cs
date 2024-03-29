﻿using Cysharp.Threading.Tasks;
using OpenMod.API.Commands;
using OpenMod.API.Prioritization;
using OpenMod.Core.Commands;
using ShopsUI.API.Shops.Vehicles.Whitelist;
using System;

namespace ShopsUI.Commands.Vehicles.Blacklist
{
    [Command("add", Priority = Priority.High)]
    [CommandAlias("a")]
    [CommandAlias("+")]
    [CommandSyntax("<vehicle> <permission>")]
    [CommandDescription("Add a vehicle shop blacklist.")]
    [CommandParent(typeof(CVShopBlacklist))]
    public class CVShopBlacklistAdd : ShopCommand
    {
        private readonly IVehicleShopWhitelistEditor _whitelistEditor;

        public CVShopBlacklistAdd(IServiceProvider serviceProvider,
            IVehicleShopWhitelistEditor whitelistEditor) : base(serviceProvider)
        {
            _whitelistEditor = whitelistEditor;
        }

        protected override async UniTask OnExecuteAsync()
        {
            var asset = await GetVehicleAsset(0);
            var permission = await Context.Parameters.GetAsync<string>(1);

            if (await _whitelistEditor.AddBlacklist(ushort.Parse(asset.VehicleAssetId), permission))
            {
                await PrintAsync(StringLocalizer["commands:success:shop_blacklist:added:vehicle",
                    new {VehicleAsset = asset, Permission = permission}]);
            }
            else
            {
                throw new UserFriendlyException(StringLocalizer["commands:errors:shop_blacklist:added:vehicle",
                    new {VehicleAsset = asset, Permission = permission}]);
            }
        }
    }
}
