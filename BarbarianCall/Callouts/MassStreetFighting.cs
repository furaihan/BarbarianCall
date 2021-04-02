﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Rage;
using LSPD_First_Response.Mod.Callouts;
using LSPDFR = LSPD_First_Response.Mod.API.Functions;
using BarbarianCall.Extensions;
using BarbarianCall.Types;

namespace BarbarianCall.Callouts
{
    [CalloutInfo("Mass Street Fighting", CalloutProbability.High)]
    class MassStreetFighting : CalloutBase
    {
        private List<Ped> Participant;
        private List<Ped> Gang1;
        private List<Ped> Gang2;
        private bool CanEnd = false;
        private List<Model> Gang1Model;
        private List<Model> Gang2Model;
        private Dictionary<Ped, ESuspectStates> SuspectCondition;
        int gangMemberCount;
        private int deadCount = 0;
        private int arrestedCount = 0;
        private int escapedCount = 0;
        private static readonly uint[] meleeWeapon = { 0x92A27487, 0x958A4A8F, 0xF9E6AA4B, 0x84BD7BFD, 0x4E875F73, 0xF9DCBF2D, 0xD8DF3C3C, 0x99B507EA, 0xDD5DF8D9, 0xDFE37640, 0x19044EE0, 0xCD274149, 0x3813FC08, 
            0x24B17070/*MOLOTOV*/ };
        private RelationshipGroup gang1Relationship;
        private RelationshipGroup gang2Relationship;
        public override bool OnBeforeCalloutDisplayed()
        {
            CalloutRunning = false;
            PursuitCreated = false;
            deadCount = 0;
            arrestedCount = 0;
            escapedCount = 0;
            Participant = new List<Ped>();
            SuspectCondition = new Dictionary<Ped, ESuspectStates>();
            Gang1 = new List<Ped>();
            Gang2 = new List<Ped>();
            gang1Relationship = new RelationshipGroup("SIJI");
            gang2Relationship = new RelationshipGroup("LORO");
            Spawn = SpawnManager.GetVehicleSpawnPoint(PlayerPed, 425, 725, true);
            if (Spawn == Spawnpoint.Zero) Spawn = SpawnManager.GetVehicleSpawnPoint(PlayerPed, 350, 850);
            if (Spawn == Spawnpoint.Zero)
            {
                Spawn.Position = World.GetNextPositionOnStreet(PlayerPed.Position.Around2D(425, 725));
                Spawn.Heading = SpawnManager.GetRoadHeading(Spawn.Position);
            }
            SpawnPoint = Spawn;
            SpawnHeading = Spawn;
            Gang1Model = CommonVariables.GangPedModels.Values.ToList().GetRandomElement();
            Gang2Model = CommonVariables.GangPedModels.Values.ToList().GetRandomElement(m=> m != Gang1Model);
            Gang1Model.ForEach(m => m.LoadAndWait());
            Gang2Model.ForEach(m => m.LoadAndWait());
            CalloutPosition = Spawn;
            gangMemberCount = Peralatan.Random.Next(3, 9);
            CalloutAdvisory = string.Format("Total number of suspects is {0}", gangMemberCount * 2);
            ShowCalloutAreaBlipBeforeAccepting(Spawn, 80f);
            PlayScannerWithCallsign("WE_HAVE BAR_CRIME_GANG_RELATED IN_OR_ON_POSITION", Spawn);
            return base.OnBeforeCalloutDisplayed();
        }
        public override bool OnCalloutAccepted()
        {            
            for (int i = 0; i < gangMemberCount; i++)
            {
                Ped gangMember = new Ped(Gang1Model.GetRandomElement(), SpawnPoint.Around2D(10f).ToGround(), Peralatan.Random.Next() % 2 == 0 ? SpawnHeading : SpawnPoint.GetHeadingTowards(PlayerPed));
                gangMember.MakeMissionPed();
                Participant.Add(gangMember);
                CalloutEntities.Add(gangMember);
                Gang1.Add(gangMember);
                gangMember.Inventory.GiveNewWeapon(meleeWeapon.GetRandomElement(), -1, true);
                gangMember.RelationshipGroup = gang1Relationship;
                gangMember.Metadata.BAR_Entity = true;
                SuspectCondition.Add(gangMember, ESuspectStates.InAction);
            }
            Vector3 sp2 = SpawnManager.GetVehicleSpawnPoint(Spawn.Position, 30, 50);
            if (sp2 == Vector3.Zero) sp2 = World.GetNextPositionOnStreet(sp2.Around(30, 50));
            for (int i = 0; i < gangMemberCount; i++)
            {
                Ped gangMember = new Ped(Gang2Model.GetRandomElement(), sp2.Around2D(10f).ToGround(), Peralatan.Random.Next() % 2 == 0 ? SpawnHeading : sp2.GetHeadingTowards(PlayerPed));
                gangMember.MakeMissionPed();
                Participant.Add(gangMember);
                CalloutEntities.Add(gangMember);
                Gang2.Add(gangMember);
                gangMember.Inventory.GiveNewWeapon(meleeWeapon.GetRandomElement(), -1, true);
                gangMember.RelationshipGroup = gang2Relationship;
                gangMember.Metadata.BAR_Entity = true;
                SuspectCondition.Add(gangMember, ESuspectStates.InAction);
            }
            Participant.ForEach(p => p.SetPedAsWanted());
            gang1Relationship.SetRelationshipWith(gang2Relationship, Relationship.Hate);
            gang1Relationship.SetRelationshipWith(RelationshipGroup.Cop, Relationship.Hate);
            gang1Relationship.SetRelationshipWith(RelationshipGroup.Player, Relationship.Hate);
            gang2Relationship.SetRelationshipWith(gang1Relationship, Relationship.Hate);
            gang2Relationship.SetRelationshipWith(RelationshipGroup.Cop, Relationship.Hate);
            gang2Relationship.SetRelationshipWith(RelationshipGroup.Player, Relationship.Hate);
            Blip = new Blip(Spawn, 50f);
            Blip.Color = Yellow;
            Blip.EnableRoute(Yellow);
            SituationTawuran();
            CalloutMainFiber.Start();
            return base.OnCalloutAccepted();
        }
        public override void Process()
        {
            if (CalloutRunning)
            {
                if (!Participant.All(e => CalloutEntities.Contains(e)))
                {
                    Participant.ForEach(e =>
                    {
                        if (e)
                        {
                            if (!CalloutEntities.Contains(e)) CalloutEntities.Add(e);
                        }
                    });
                }
                SuspectCondition.Keys.ToList().ForEach(p =>
                {
                    if (SuspectCondition.ContainsKey(p))
                    {
                        if (SuspectCondition[p] == ESuspectStates.InAction && p && p.IsDead)
                        {
                            SuspectCondition[p] = ESuspectStates.Dead;
                            Blip blip = p ? p.GetAttachedBlips().Where(b => CalloutBlips.Contains(b)).FirstOrDefault() : null;
                            if (blip) blip.Delete();
                            deadCount++;
                        }
                        else if (SuspectCondition[p] == ESuspectStates.InAction && p && LSPDFR.IsPedArrested(p))
                        {
                            SuspectCondition[p] = ESuspectStates.Arrested;
                            Blip blip = p ? p.GetAttachedBlips().Where(b => CalloutBlips.Contains(b)).FirstOrDefault() : null;
                            if (blip) blip.Delete();
                            arrestedCount++;
                        }
                        else if (SuspectCondition[p] == ESuspectStates.InAction && !p)
                        {
                            SuspectCondition[p] = ESuspectStates.Escaped;
                            Blip blip = p ? p.GetAttachedBlips().Where(b => CalloutBlips.Contains(b)).FirstOrDefault() : null;
                            if (blip) blip.Delete();
                            escapedCount++;
                        }
                    }
                    else if (p) Peralatan.ToLog(string.Format("Dictionary Key doesn't exist: {0} - {1} - {2}", SuspectCondition.Count, (uint)p.Handle, p.Model.Name));
                    else Peralatan.ToLog("SOMETHING WENT WRONG, SEND YOUR LOG PLS!!");
                });
                if (SuspectCondition.Values.All(x => x != ESuspectStates.InAction)) CanEnd = true;
                if (CanEnd) End();
            }
            base.Process();
        }
        public override void End()
        {
            Participant.ForEach(p =>
            {
                if (p)
                {
                    if (p.IsAlive && p.IsEntityAPed()) p.Inventory.GiveNewWeapon("WEAPON_UNARMED", -1, true);
                    if (p) p.Dismiss();
                }
            });
            Extension.DeleteRelationshipGroup(gang1Relationship);
            Extension.DeleteRelationshipGroup(gang2Relationship);
            base.End();
        }
        private void GetClose()
        {
            while (CalloutRunning)
            {
                if (Participant.Any(p => (p && (p.IsOnScreen || p.CanSee(PlayerPed) || PlayerPed.CanSee(p))) || PlayerPed.DistanceTo(SpawnPoint) < 100f))
                {
#if DEBUG
                    string[] log =
                    {
                        $"Distance: {PlayerPed.DistanceTo(SpawnPoint)}",
                        $"Player see suspect: {Participant.Any(p=> PlayerPed.CanSee(p))}",
                        $"Suspect see player: {Participant.Any(p=> p.CanSee(PlayerPed))}",
                        $"Suspect is on screen: {Participant.Any(predicate => predicate.IsOnScreen)}"
                    };
                    log.ToList().ForEach(Peralatan.ToLog);
#endif
                    break;
                }
                Ped ran = Participant.GetRandomElement();
                if (ran) ran.Tasks.AchieveHeading(ran.GetHeadingTowards(PlayerPed));
                GameFiber.Yield();
            }
            if (Blip) Blip.Delete();
            foreach (Ped part in Participant)
            {
                if (part)
                {
                    Blip gangblp = part.AttachBlip();
                    gangblp.Color = Color.Red;
                    gangblp.Scale = 0.754585f;
                    CalloutBlips.Add(gangblp);
                }
            }
        }
        private void SituationTawuran()
        {
            CalloutMainFiber = new GameFiber(() =>
            {
                GetClose();
                if (CalloutRunning)
                {
                    Participant.ForEach(p => p.CombatAgainstHatedTargetAroundPed(250f));
                    while (CalloutRunning)
                    {
                        if (CanEnd) break;
                        if (Participant.Any(p=> p && p.IsAlive && !LSPDFR.IsPedArrested(p) && p.Tasks.CurrentTaskStatus != TaskStatus.InProgress))
                        {
                            Participant.Where(p => p && p.IsAlive && !LSPDFR.IsPedArrested(p) && p.Tasks.CurrentTaskStatus != TaskStatus.InProgress).FirstOrDefault().CombatAgainstHatedTargetAroundPed(250f);
                        }
                        GameFiber.Yield();
                    }
                }
            });          
        }
    }
}
