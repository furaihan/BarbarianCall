﻿using System;
using System.Linq;
using System.Collections.Generic;
using LSPD_First_Response.Mod.API;
using Rage;
using LSPD_First_Response.Engine.Scripting.Entities;
using RAGENativeUI.Elements;
using BarbarianCall.Types;

namespace BarbarianCall.Callouts
{
    public abstract class CalloutBase : LSPD_First_Response.Mod.Callouts.Callout
    {
        #region Fields
        public enum ESuspectStates { InAction, Arrested, Dead, Escaped };
        public enum ECalloutStates { UnAccepted, EnRoute, OnScene, InPursuit, Finish };
        public static List<Blip> CalloutBlips { get; protected set; } = new List<Blip>();
        public static List<Entity> CalloutEntities { get; protected set; } = new List<Entity>();
        public ECalloutStates CalloutStates;
        public Ped Suspect;
        public Vehicle SuspectCar;
        public Manusia Manusia;
        public Model CarModel;
        public List<Model> GangModels;
        public Blip Blip;
        public bool CalloutRunning = false;
        public Vector3 SpawnPoint = Vector3.Zero;
        public float SpawnHeading = 0f;
        public Spawnpoint Spawn = Spawnpoint.Zero;
        public long Timer;
        public DateTime Time;
        public TimeSpan TimeSpan = new(0, 0, 15);
        public System.Diagnostics.Stopwatch StopWatch;
        public LHandle Pursuit;
        public LHandle PullOver;
        public bool PursuitCreated = false;
        public bool GrammarPoliceRunning => Initialization.IsLSPDFRPluginRunning("GrammarPolice", new Version(1, 4, 2, 2));
        public bool StopThePedRunning => Initialization.IsLSPDFRPluginRunning("StopThePed", new Version(4, 9, 4, 4));
        public bool UltimateBackupRunning => Initialization.IsLSPDFRPluginRunning("UltimateBackup", new Version(1, 8, 5, 4));
        public Persona SuspectPersona;
        public Ped PlayerPed => Game.LocalPlayer.Character;
        public GameFiber CalloutMainFiber;
        public readonly System.Drawing.Color Yellow = System.Drawing.Color.Yellow;
        public string FilePath;
        public static readonly uint[] WeaponHashes = { 0x1B06D571, 0xBFE256D4, 0x5EF9FEC4, 0x22D8FE39, 0x99AEEB3B, 0x2B5EF5EC, 0x78A97CD0, 0x1D073A89, 0x555AF99A, 0xBD248B55, 0x13532244, 0x624FE830 };
        protected bool Displayed = true;
        protected bool Accepted = true;
        #endregion
        private GameFiber EndHandlerFiber;

        public override void OnCalloutNotAccepted()
        {
            CalloutRunning = false;
            PursuitCreated = false;
            if (Suspect) Suspect.Delete();
            if (SuspectCar) SuspectCar.Delete();
            if (Blip) Blip.Delete();
            if (GrammarPoliceRunning) API.GrammarPoliceFunc.SetStatus(API.GrammarPoliceFunc.EGrammarPoliceStatusType.Available, true, false);
            CalloutBlips.ForEach(b => { if (b) b.Delete(); });
            CalloutEntities.ForEach(e =>
            {
                if (e)
                {
                    if (e is Ped ped && e.IsAlive && !Functions.IsPedArrested(ped)) e.Dismiss();
                    else if (e is Ped ped1 && e.IsAlive && Functions.IsPedArrested(ped1)) e.IsInvincible = false;
                    else if (e is Vehicle) e.Dismiss();
                    else if (e is Rage.Object) e.Delete();
                    else e.Dismiss();
                }
            });
            //CalloutMainFiber?.Abort();
            Manusia.CurrentManusia = null;
            Functions.PlayScannerAudio("BAR_AI_RESPOND");
            base.OnCalloutNotAccepted();
        }
        public override bool OnBeforeCalloutDisplayed()
        {
            GangModels = Globals.GangPedModels.Values.GetRandomElement();
            return base.OnBeforeCalloutDisplayed();
        }
        public override bool OnCalloutAccepted()
        {
            CalloutStates = ECalloutStates.EnRoute;
            CalloutRunning = true;
            if (EndHandlerFiber == null)
            {
                HandleEnd();
                EndHandlerFiber.Start();
            }
            else if (EndHandlerFiber.IsHibernating) EndHandlerFiber.Wake();
            StopWatch = new System.Diagnostics.Stopwatch();
            GameFiber.Sleep(75);
            return base.OnCalloutAccepted();
        }
        public override void OnCalloutDisplayed()
        {
            base.OnCalloutDisplayed();
        }
        public override void End()
        {
            CalloutRunning = false;
            Peralatan.Speaking = false;
            if (Displayed && Accepted)"~g~We Are CODE 4".DisplayNotifWithLogo(CalloutMessage);
            //StopWatch = null;
            if (Suspect && !Functions.IsPedArrested(Suspect)) Suspect.Dismiss();
            if (SuspectCar) SuspectCar.Dismiss();
            if (Blip) Blip.Delete();
            if (GrammarPoliceRunning && Menus.PauseMenu.autoAvailable.Checked) API.GrammarPoliceFunc.SetStatus(API.GrammarPoliceFunc.EGrammarPoliceStatusType.Available);
            if (Pursuit != null && Functions.IsPursuitStillRunning(Pursuit)) Functions.ForceEndPursuit(Pursuit);
            Manusia.CurrentManusia = null;
            CalloutBlips.ForEach(b => { if (b) b.Delete(); });
            CalloutEntities.ForEach(e =>
            {
                if (e)
                {
                    if (e.Model.IsPed && e.IsAlive && !Functions.IsPedArrested((Ped)e)) e.Dismiss();
                    else if (e.Model.IsPed && e.IsAlive && Functions.IsPedArrested((Ped)e)) e.IsInvincible = false;
                    else if (e.Model.IsVehicle) e.Dismiss();
                    else if (e.Model.IsObject) e.Delete();
                    else e.Dismiss();
                }
            });
            if (CarModel.IsLoaded) CarModel.Dismiss();
            //CalloutMainFiber?.Abort();
            base.End();
        }
        protected void HandleEnd()
        {
            EndHandlerFiber = new GameFiber(() =>
            {
                "Starting EndHandler Loop".ToLog();
                DateTime dateTime = DateTime.UtcNow;
                while (CalloutRunning)
                {
                    GameFiber.Yield();
                    if (Peralatan.CheckKey(System.Windows.Forms.Keys.None, System.Windows.Forms.Keys.End))
                    {
                        GameFiber.Sleep(300);
                        if (Game.IsKeyDownRightNow(System.Windows.Forms.Keys.End))
                        {
                            GameFiber.Sleep(1850);
                            if (Game.IsKeyDownRightNow(System.Windows.Forms.Keys.End)) End();
                        }
                        else Game.DisplayHelp($"~y~To force end the callout, press and hold down {Peralatan.FormatKeyBinding(System.Windows.Forms.Keys.None, System.Windows.Forms.Keys.End)}~y~ for 2 second");
                    }
                }
                $"Callout ended successfully, that callout took {(DateTime.UtcNow - dateTime).TotalSeconds:0.00} seconds".ToLog();
                GameFiber.Hibernate();
            }, "[BarbarianCall] Callout End Listener");
        }
        protected void DisplayGPNotif()
        {
            if (Initialization.IsLSPDFRPluginRunning("GrammarPolice"))
            {
                "If you have GrammarPolice installed, you can ask dispatch to display the suspect detail ~y~e.g. ~b~\"Dispatch requesting suspect details\"".DisplayNotifWithLogo("~y~"
                    + API.GrammarPoliceFunc.GetCallsign() + "~s~");
            }
            else "This Callout work better if ~y~GrammarPolice~s~ is installed, you can ask dispatch to display suspect details anytime with ~y~GrammarPolice".DisplayNotifWithLogo(GetType().Name);
        }
        protected void PlayScannerWithCallsign(string audio)
        {
            if (Initialization.IsLSPDFRPluginRunning("GrammarPolice", new Version(1, 4, 2, 2))) Functions.PlayScannerAudio("DISPATCH_TO " + API.GrammarPoliceFunc.GetCallsignAudio() + " " + audio);
            else Functions.PlayScannerAudio($"ATTENTION_ALL_UNITS {audio}");
        }
        protected void PlayScannerWithCallsign(string audio, Vector3 position)
        {
            if (Initialization.IsLSPDFRPluginRunning("GrammarPolice", new Version(1, 4, 2, 2)))
                Functions.PlayScannerAudioUsingPosition("DISPATCH_TO " + API.GrammarPoliceFunc.GetCallsignAudio() + " " + audio, position);
            else Functions.PlayScannerAudioUsingPosition($"ATTENTION_ALL_UNITS {audio}", position);
        }
        protected void DeclareVariable()
        {
            CalloutRunning = false;
            PursuitCreated = false;
            CalloutStates = ECalloutStates.UnAccepted;
            $"Callout Created From {CreationSource}".ToLog();
        }
        protected void PlayRadioAnimation(int duration) => Functions.PlayPlayerRadioAction(Functions.GetPlayerRadioAction(), duration);
        protected void ClearUnrelatedEntities()
        {
            World.GetEntities(CalloutPosition, 50f, GetEntitiesFlags.ConsiderGroundVehicles | GetEntitiesFlags.ConsiderHumanPeds).ToList().ForEach(ent =>
            {
                if (ent)
                {
                    if (!ent.CreatedByTheCallingPlugin && ent.GetAttachedBlips().Length == 0 && !ent.Position.IsOnScreen())
                    {
                        if (ent && Extensions.Extension.IsEntityAVehicle(ent) && (ent as Vehicle).IsEmpty) ent.Delete();
                        else if (ent && Extensions.Extension.IsEntityAPed(ent))
                        {
                            var ped = ent as Ped;
                            ped.Tasks.ClearImmediately();
                            ped.Dismiss();
                            if (ped.DistanceTo(CalloutPosition) < 20f) ped.Delete();
                        }
                    }
                }
            });
        }
        public static UIMenuItem[] CreateMenu()
        {
            "Creating callout menu tab, menu items".ToLog();
            return new UIMenuItem[]
            {
                new UIMenuNumericScrollerItem<float>("Minimum Distance", "Set the callout minimum distance", 100f, 500f, 20f),
                new UIMenuNumericScrollerItem<float>("Maximum Distance", "Set the callout maximum distance", 500f, 2000f, 50f)
            };
        }
        protected class SuspectProperty
        {
            public ESuspectStates SuspectState { get; set; }
            public string FullName { get; set; }
            public uint? MugshotHandle { get; set; }
            public string MugshotTexture { get; set; }
            public SuspectProperty(ESuspectStates suspectState, string name, uint? mugshotHandle, string mugshotTexture)
            {
                SuspectState = suspectState;
                FullName = name;
                MugshotHandle = mugshotHandle;
                MugshotTexture = mugshotTexture;
            }
        }
    }
}
