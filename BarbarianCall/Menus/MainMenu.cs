﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAGENativeUI;
using RAGENativeUI.Elements;

namespace BarbarianCall.Menus
{
    internal class MainMenu
    {
        internal static UIMenu BarbarianCallMenu;
        internal static UIMenuItem setting;
        internal static UIMenuListScrollerItem<string> mechanic;
        internal static UIMenuItem insurance;
        internal static MenuPool Pool;
        internal static void CreateMenu()
        {
            Pool = new MenuPool();
            TextStyle title = new TextStyle(TextFont.ChaletComprimeCologne, Color.Ivory, 1.125f, TextJustification.Center);
            BarbarianCallMenu = new UIMenu("BarbarianCall", "")
            {
                TitleStyle = title,
                AllowCameraMovement = true,
                MouseControlsEnabled = false,
                WidthOffset = 160,
                DescriptionSeparatorColor = HudColor.NetPlayer23.GetColor(),
            };
            Sprite des = new Sprite("hei_dlc_orntbankb_txd", "gz_v_bkwood1", Point.Empty, Size.Empty);
            BarbarianCallMenu.SetBannerType(des);
            Pool.Add(BarbarianCallMenu);
            setting = new UIMenuItem("Settings", "Open BarbarianCall Pause Menu Setting");
            mechanic = new UIMenuListScrollerItem<string>("Call Mechanic", "Call mechanic to repair ~y~My Vehicle", new[] { "My Vehicle", "Nearby Vehicle" });
            mechanic.IndexChanged += (a, i, u) => mechanic.Description = $"Call mechanic to repair ~y~{mechanic.SelectedItem}~s~";
            insurance = new UIMenuItem("Call Insurance Company", "Call Insurance company to pickup nearest vehicle");
            BarbarianCallMenu.OnItemSelect += MenuHandler.ItemSelectHandler;
            BarbarianCallMenu.AddItems(mechanic, insurance, setting);
        }
    }
}
