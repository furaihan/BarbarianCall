﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbarianCall.Types
{
    using System;

    using Rage;

    //Thanks to alexguirre for his open source plugin
    internal static unsafe class GameOffsets
    {
        public static int CVehicleModelInfo_VehicleMakeName { get; private set; }
        public static int CVehicleModelInfo_GameName { get; private set; }

        public static bool Init()
        {
            IntPtr address = Game.FindPattern("48 8D 82 ?? ?? ?? ?? 48 8D B2 ?? ?? ?? ?? 48 85 C0 74 09");
            if (AssertAddress(address, "CVehicleModelInfo_NamesOffsets"))
            {
                CVehicleModelInfo_VehicleMakeName = *(int*)(address + 3);
                CVehicleModelInfo_GameName = *(int*)(address + 10);
            }

            return !anyAssertFailed;
        }

        private static bool anyAssertFailed = false;
        private static bool AssertAddress(IntPtr address, string name)
        {
            if (address == IntPtr.Zero)
            {
                Game.LogTrivial($"Incompatible game version, couldn't find '{name}'.");
                anyAssertFailed = true;
                return false;
            }

            return true;
        }
    }
    internal unsafe struct CVehicle
    {

        public IntPtr GetMakeName()
        {
            fixed (CVehicle* v = &this)
            {
                IntPtr modelInfo = *(IntPtr*)((IntPtr)v + 0x20);
                IntPtr makeName = modelInfo + GameOffsets.CVehicleModelInfo_VehicleMakeName;
                return makeName;
            }
        }

        public IntPtr GetGameName()
        {
            fixed (CVehicle* v = &this)
            {
                IntPtr modelInfo = *(IntPtr*)((IntPtr)v + 0x20);
                IntPtr gameName = modelInfo + GameOffsets.CVehicleModelInfo_GameName;
                return gameName;
            }
        }
    }
}
