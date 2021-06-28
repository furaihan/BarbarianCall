﻿using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using RAGENativeUI;
using RAGENativeUI.Elements;
using Rage;
using Rage.Native;
using BarbarianCall.Extensions;

namespace BarbarianCall.Menus
{
    internal class MainMenu
    {
        internal static UIMenu BarbarianCallMenu;
        internal static UIMenuItem setting;
        internal static UIMenuListScrollerItem<string> mechanic;
        internal static UIMenuItem insurance;
#if DEBUG
        internal static UIMenuListScrollerItem<string> spawnFreemode;
#endif
        internal static MenuPool Pool;
        internal static void CreateMenu()
        {
            Pool = new MenuPool();
            TextStyle title = new(TextFont.ChaletComprimeCologne, Color.Ivory, 1.125f, TextJustification.Center);
            BarbarianCallMenu = new UIMenu("BarbarianCall", "")
            {
                TitleStyle = title,
                AllowCameraMovement = true,
                MouseControlsEnabled = false,
                WidthOffset = 160,
                DescriptionSeparatorColor = HudColor.NetPlayer23.GetColor(),
            };
            Sprite des = new("h4_mph4_man_islandx_mansion", "am_villa_brick_1_s", Point.Empty, Size.Empty);
            BarbarianCallMenu.SetBannerType(des);
            Pool.Add(BarbarianCallMenu);
            setting = new("Settings", "Open BarbarianCall Pause Menu Setting");
            mechanic = new("Call Mechanic", "Call mechanic to repair ~y~My Vehicle", new[] { "My Vehicle", "Nearby Vehicle" });
            mechanic.IndexChanged += (a, i, u) => mechanic.Description = $"Call mechanic to repair ~y~{mechanic.SelectedItem}~s~";
            insurance = new("Call Insurance Company", "Call Insurance company to pickup nearest vehicle");
#if DEBUG
            spawnFreemode = new("[DEBUG] Spawn Freemode Ped", "", new[] { "Male", "Female" });
            UIMenuItem notif = new("[DEBUG] Display Notification");
            notif.Activated += (m, s) =>
            {
                m.Close(false);
                try
                {
                    Types.Mugshot mugshot = new(Game.LocalPlayer.Character);
                    GameFiber.Sleep(2000);
                    mugshot.DisplayNotification("Test", "Lalala", "Lilili", true);
                    mugshot.Delete();
                }
                catch (System.Exception e)
                {
                    e.ToString().ToLog();
                }
            };           
            UIMenuNumericScrollerItem<float> checkNode = new("[DEBUG] Get Nearest Vehicle Node", "The scroller is minimum distance, Max distance is min distance + 10", 10, 1000, 10)
            {
                Value = 20,
            };
            checkNode.Activated += (m, s) =>
            {
                try
                {
                    s.Enabled = false;
                    var mindis = (s as UIMenuNumericScrollerItem<float>).Value;
                    var sp = SpawnManager.GetVehicleSpawnPoint(Game.LocalPlayer.Character, mindis, mindis + 10, false);
                    if (sp == Types.Spawnpoint.Zero)
                    {
                        Game.DisplaySubtitle("Vehicle Node Is Not Found");
                        s.Enabled = true;
                        return;
                    }
                    Game.DisplaySubtitle("Found vehicle Node: " + sp.ToString());
                    GameFiber.StartNew(() =>
                    {
                        var cp = new Types.Checkpoint(CheckpointIcon.Cylinder, sp, 3, 250, Color.Gold, Color.White, true);
                        while (true)
                        {
                            GameFiber.Yield();
                            if (Peralatan.CheckKey(System.Windows.Forms.Keys.None, System.Windows.Forms.Keys.Tab))
                            {
                                break;
                            }
                        }
                        if (cp) cp.Delete();
                    });
                }
                catch (System.Exception e)
                {
                    e.ToString().ToLog();
                }
                finally
                {
                    s.Enabled = true;
                }
            };
#endif
            BarbarianCallMenu.OnItemSelect += MenuHandler.ItemSelectHandler;
            BarbarianCallMenu.AddItems(mechanic, insurance, setting);
#if DEBUG
            BarbarianCallMenu.AddItems(spawnFreemode, notif, checkNode);
            BarbarianCallMenu.AddItem(new UIMenuCheckboxItem("[DEBUG] Get Gameplay Cam Raycast", false));
            BarbarianCallMenu.AddItem(new UIMenuItem("[DEBUG] Get Solicitation SpawnPoint"));
#endif
        }
    }
}
