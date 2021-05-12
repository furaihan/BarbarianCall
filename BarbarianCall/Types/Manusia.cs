﻿using System;
using System.Collections.Generic;
using System.Linq;
using Rage;
using System.Reflection;
using System.Drawing;

namespace BarbarianCall.Types
{
    public class Manusia
    {
        public Ped Pedestrian { get; internal set; }
        public string Fullname { get; internal set; }
        public DateTime BirthDay { get; internal set; }
        public Vector3 Location { get; internal set; }
        public bool WithVehicle { get; internal set; }
        public Vehicle Car { get; internal set; }
        public string CarColor { get; private set; }
        public static Manusia CurrentManusia { get; internal set; }
        public Manusia(Ped ped, LSPD_First_Response.Engine.Scripting.Entities.Persona persona)
        {
            Pedestrian = ped;
            Fullname = persona.FullName;
            BirthDay = persona.Birthday;
            Location = ped.Position;
            WithVehicle = false;
            Car = null;
            CurrentManusia = this;
        }
        public Manusia(Ped ped, LSPD_First_Response.Engine.Scripting.Entities.Persona persona, Vehicle vehicle)
        {
            Pedestrian = ped;
            Fullname = persona.FullName;
            BirthDay = persona.Birthday;
            Location = ped.Position;
            if (vehicle)
            {
                Car = vehicle;
                CarColor = GetCarColor();
                WithVehicle = true;
            }
            else
            {
                Car = null;
                WithVehicle = false;
            }
            CurrentManusia = this;
        }
        public void DisplayNotif()
        {
            if (CurrentManusia == null || this == null) return;
            Pedestrian.DisplayNotificationsWithPedHeadshot("Ped Database", $"~y~Name~s~: {Fullname}~n~~y~DOB~s~: {BirthDay.ToShortDateString()} ({GetAge()} Y.O)~n~~y~Last Seen~s~: {Pedestrian.GetZoneName()}, " +
                $"{World.GetStreetName(Pedestrian.Position)}");
            if (Car && WithVehicle)
            {
                GameFiber.Wait(575);
                Peralatan.DisplayNotifWithLogo($"~y~Model~s~: {Car.GetDisplayName()}~n~~y~Color~s~: {CarColor}~n~~y~License Plate~s~: {Car.LicensePlate}", "~y~Vehicle Details~s~", "mpcarhud", "transport_car_icon");
            }
        }
        private string GetCarColor()
        {
            try
            {
                PropertyInfo[] cname = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
                List<Color> colour = cname.Select(c => Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), c.Name))).ToList();
                List<int> cint = colour.Select(c => c.ToArgb()).ToList();
                if (cint.Contains(Car.PrimaryColor.ToArgb()))
                {
                    return cname[cint.IndexOf(Car.PrimaryColor.ToArgb())].Name.AddSpacesToSentence();
                }
            }
            catch (Exception e)
            {
                "Get car color error".ToLog();
                e.ToString().ToLog();
            }          
            $"{Car.GetDisplayName()} color is unknown, Argb: {Car.PrimaryColor.ToArgb()}".ToLog();
            return "Weirdly colored";
        }
        private int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDay.Year;
            if (BirthDay.Date < today.AddYears(-age)) age--;
            return age;
        }
    }
}
