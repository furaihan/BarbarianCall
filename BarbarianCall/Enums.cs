﻿using System;

namespace BarbarianCall
{
    public enum MissionType
    {
		None = 0,
		Cruise = 1,
		Ram = 2,
		Block = 3,
		GoTo = 4,
		Stop = 5,
		Attack = 6,
		Follow = 7,
		Flee = 8,
		Circle = 9,
		Escort = 12,
		FollowRecording = 15,
		PoliceBehaviour = 16,
		Land = 19,
		Land2 = 20,
		Crash = 21,
		PullOver = 22,
		HeliProtect = 23
	}
	public enum EscortVehicleMode : int
	{
		Behind = -1,
		Ahead,
		Left,
		Right,
		BackLeft,
		BackRight
	}
	public enum MilitarySupportType
	{
		Buzzard,
		Sparrow,
		Annihilator,
		Hunter,
	}
	[Flags]
	internal enum NodeFlags :uint
	{
		None = 0,
		IsDisabled = 1,
		UnknownBit2 = 2,
		SlowNormalRoad = 4,
		MinorRoad = 8,
		TunnelOrUndergroundParking = 16,
		UnknownBit32 = 32,
		Freeway = 64,
		Junction = 128,
		StopNode = 256,
		SpecialStopNode = 512,
		Unk1024 = 1024,
		Unk2048 = 2048,
		Unk4096 = 4096,
		Unk8192 = 8192,
		Unk16384 = 16384,
		Unk32768 = 32768,
		Unk65536 = 65536,
		Unk131072 = 131072,
		Unk262144 = 262144,
		Unk524288 = 524288,
		Unk1048576 = 1048576,
		Unk2097152 = 2097152,
		Unk4194304 = 4194304,
		Unk8388608 = 8388608,
		Unk16777216 = 16777216,
		Unk33554432 = 33554432,
		Unk67108864 = 67108864,
		Unk134217728 = 134217728,
		Unk268435456 = 268435456,
		Unk536870912 = 536870912,
		Unk1073741824 = 1073741824,
		Unk2147483648 = 2147483648,
		Unk6542 = 6542,
		Restricted = 19,
	}
	internal enum BoneMask
    {
		BONEMASK_HEAD_NECK_AND_R_ARM,
		BONEMASK_HEADONLY,
		BONEMASK_HEAD_NECK_AND_L_ARM,
		FORCED_BONEMASK_HEADONLY,
		BONEMASK_HEAD_NECK_AND_ARMS,
		BONEMASK_ARMONLY_R,
		BONEMASK_UPPERONLY,
	}
    internal enum NotificationIcon
    {
        ChatBox = 1,
        Email,
        AddFriendRequest,
        Nothing,
        RightJumpingArrow = 7,
        RPIcon,
        DollarSign
    }
    public enum CheckpointIcon
    {
        CylinderSingleArrow,
        CylinderDoubleArrow,
        CylinderTripleArrow,
        CylinderCycleArrow,
        CylinderCheckerboard,
        CylinderSingleArrow2,
        CylinderDoubleArrow2,
        CylinderTripleArrow2,
        CylinderCycleArrow2,
        CylinderCheckerboard2,
        RingSingleArrow,
        RingDoubleArrow,
        RingTripleArrow,
        RingCycleArrow,
        RingCheckerboard,
        SingleArrow,
        DoubleArrow,
        TripleArrow,
        CycleArrow,
        Checkerboard,
        CylinderSingleArrow3,
        CylinderDoubleArrow3,
        CylinderTripleArrow3,
        CylinderCycleArrow3,
        CylinderCheckerboard3,
        CylinderSingleArrow4,
        CylinderDoubleArrow4,
        CylinderTripleArrow4,
        CylinderCycleArrow4,
        CylinderCheckerboard4,
        CylinderSingleArrow5,
        CylinderDoubleArrow5,
        CylinderTripleArrow5,
        CylinderCycleArrow5,
        CylinderCheckerboard5,
        RingPlaneUp,
        RingPlaneLeft,
        RingPlaneRight,
        RingPlaneDown,
        Empty,
        Ring,
        Empty2,
        Cylinder = 47,
        Cylinder2,
        Cylinder3,
    }
    public enum PedScenario
    {
        Standing,
        WORLD_HUMAN_AA_COFFEE,
        WORLD_HUMAN_AA_SMOKE,
        WORLD_HUMAN_BINOCULARS,
        WORLD_HUMAN_BUM_FREEWAY,
        WORLD_HUMAN_BUM_SLUMPED,
        WORLD_HUMAN_BUM_STANDING,
        WORLD_HUMAN_BUM_WASH,
        WORLD_HUMAN_CAR_PARK_ATTENDANT,
        WORLD_HUMAN_CHEERING,
        WORLD_HUMAN_CLIPBOARD,
        WORLD_HUMAN_CLIPBOARD_FACILITY,
        WORLD_HUMAN_CONST_DRILL,
        WORLD_HUMAN_COP_IDLES,
        WORLD_HUMAN_DRINKING,
        WORLD_HUMAN_DRINKING_FACILITY,
        WORLD_HUMAN_DRINKING_CASINO_TERRACE,
        WORLD_HUMAN_DRUG_DEALER,
        WORLD_HUMAN_DRUG_DEALER_HARD,
        WORLD_HUMAN_DRUG_FIELD_WORKERS_RAKE,
        WORLD_HUMAN_DRUG_FIELD_WORKERS_WEEDING,
        WORLD_HUMAN_DRUG_PROCESSORS_COKE,
        WORLD_HUMAN_DRUG_PROCESSORS_WEED,
        WORLD_HUMAN_MOBILE_FILM_SHOCKING,
        WORLD_HUMAN_GARDENER_LEAF_BLOWER,
        WORLD_HUMAN_GARDENER_PLANT,
        WORLD_HUMAN_GOLF_PLAYER,
        WORLD_HUMAN_GUARD_PATROL,
        WORLD_HUMAN_GUARD_STAND,
        WORLD_HUMAN_GUARD_STAND_CASINO,
        WORLD_HUMAN_GUARD_STAND_CLUBHOUSE,
        WORLD_HUMAN_GUARD_STAND_FACILITY,
        WORLD_HUMAN_GUARD_STAND_ARMY,
        WORLD_HUMAN_HAMMERING,
        WORLD_HUMAN_HANG_OUT_STREET,
        WORLD_HUMAN_HANG_OUT_STREET_CLUBHOUSE,
        WORLD_HUMAN_HIKER,
        WORLD_HUMAN_HIKER_STANDING,
        WORLD_HUMAN_HUMAN_STATUE,
        WORLD_HUMAN_INSPECT_CROUCH,
        WORLD_HUMAN_INSPECT_STAND,
        WORLD_HUMAN_JANITOR,
        WORLD_HUMAN_JOG,
        WORLD_HUMAN_JOG_STANDING,
        WORLD_HUMAN_LEANING,
        WORLD_HUMAN_LEANING_CASINO_TERRACE,
        WORLD_HUMAN_MAID_CLEAN,
        WORLD_HUMAN_MUSCLE_FLEX,
        WORLD_HUMAN_MUSCLE_FREE_WEIGHTS,
        WORLD_HUMAN_MUSICIAN,
        WORLD_HUMAN_PAPARAZZI,
        WORLD_HUMAN_PARTYING,
        WORLD_HUMAN_PICNIC,
        WORLD_HUMAN_POWER_WALKER,
        WORLD_HUMAN_PROSTITUTE_HIGH_CLASS,
        WORLD_HUMAN_PROSTITUTE_LOW_CLASS,
        WORLD_HUMAN_PUSH_UPS,
        WORLD_HUMAN_SEAT_LEDGE,
        WORLD_HUMAN_SEAT_LEDGE_EATING,
        WORLD_HUMAN_SEAT_STEPS,
        WORLD_HUMAN_SEAT_WALL,
        WORLD_HUMAN_SEAT_WALL_EATING,
        WORLD_HUMAN_SEAT_WALL_TABLET,
        WORLD_HUMAN_SECURITY_SHINE_TORCH,
        WORLD_HUMAN_SIT_UPS,
        WORLD_HUMAN_SMOKING,
        WORLD_HUMAN_SMOKING_CLUBHOUSE,
        WORLD_HUMAN_SMOKING_POT,
        WORLD_HUMAN_SMOKING_POT_CLUBHOUSE,
        WORLD_HUMAN_STAND_FIRE,
        WORLD_HUMAN_STAND_FISHING,
        WORLD_HUMAN_STAND_IMPATIENT,
        WORLD_HUMAN_STAND_IMPATIENT_CLUBHOUSE,
        WORLD_HUMAN_STAND_IMPATIENT_FACILITY,
        WORLD_HUMAN_STAND_IMPATIENT_UPRIGHT,
        WORLD_HUMAN_STAND_IMPATIENT_UPRIGHT_FACILITY,
        WORLD_HUMAN_STAND_MOBILE,
        WORLD_HUMAN_STAND_MOBILE_CLUBHOUSE,
        WORLD_HUMAN_STAND_MOBILE_FACILITY,
        WORLD_HUMAN_STAND_MOBILE_UPRIGHT,
        WORLD_HUMAN_STAND_MOBILE_UPRIGHT_CLUBHOUSE,
        WORLD_HUMAN_STRIP_WATCH_STAND,
        WORLD_HUMAN_STUPOR,
        WORLD_HUMAN_STUPOR_CLUBHOUSE,
        WORLD_HUMAN_SUNBATHE,
        WORLD_HUMAN_SUNBATHE_BACK,
        WORLD_HUMAN_SUPERHERO,
        WORLD_HUMAN_SWIMMING,
        WORLD_HUMAN_TENNIS_PLAYER,
        WORLD_HUMAN_TOURIST_MAP,
        WORLD_HUMAN_TOURIST_MOBILE,
        WORLD_HUMAN_VALET,
        WORLD_HUMAN_VEHICLE_MECHANIC,
        WORLD_HUMAN_WELDING,
        WORLD_HUMAN_WINDOW_SHOP_BROWSE,
        WORLD_HUMAN_YOGA,
        Walk,
        Walk_Facility,
        WORLD_BOAR_GRAZING,
        WORLD_CAT_SLEEPING_GROUND,
        WORLD_CAT_SLEEPING_LEDGE,
        WORLD_COW_GRAZING,
        WORLD_COYOTE_HOWL,
        WORLD_COYOTE_REST,
        WORLD_COYOTE_WANDER,
        WORLD_COYOTE_WALK,
        WORLD_CHICKENHAWK_FEEDING,
        WORLD_CHICKENHAWK_STANDING,
        WORLD_CORMORANT_STANDING,
        WORLD_CROW_FEEDING,
        WORLD_CROW_STANDING,
        WORLD_DEER_GRAZING,
        WORLD_DOG_BARKING_ROTTWEILER,
        WORLD_DOG_BARKING_RETRIEVER,
        WORLD_DOG_BARKING_SHEPHERD,
        WORLD_DOG_SITTING_ROTTWEILER,
        WORLD_DOG_SITTING_RETRIEVER,
        WORLD_DOG_SITTING_SHEPHERD,
        WORLD_DOG_BARKING_SMALL,
        WORLD_DOG_SITTING_SMALL,
        WORLD_DOLPHIN_SWIM,
        WORLD_FISH_FLEE,
        WORLD_FISH_IDLE,
        WORLD_GULL_FEEDING,
        WORLD_GULL_STANDING,
        WORLD_HEN_FLEE,
        WORLD_HEN_PECKING,
        WORLD_HEN_STANDING,
        WORLD_MOUNTAIN_LION_REST,
        WORLD_MOUNTAIN_LION_WANDER,
        WORLD_ORCA_SWIM,
        WORLD_PIG_GRAZING,
        WORLD_PIGEON_FEEDING,
        WORLD_PIGEON_STANDING,
        WORLD_RABBIT_EATING,
        WORLD_RABBIT_FLEE,
        WORLD_RATS_EATING,
        WORLD_RATS_FLEEING,
        WORLD_SHARK_SWIM,
        WORLD_SHARK_HAMMERHEAD_SWIM,
        WORLD_STINGRAY_SWIM,
        WORLD_WHALE_SWIM,
        DRIVE,
        WORLD_VEHICLE_ATTRACTOR,
        PARK_VEHICLE,
        WORLD_VEHICLE_AMBULANCE,
        WORLD_VEHICLE_BICYCLE_BMX,
        WORLD_VEHICLE_BICYCLE_BMX_BALLAS,
        WORLD_VEHICLE_BICYCLE_BMX_FAMILY,
        WORLD_VEHICLE_BICYCLE_BMX_HARMONY,
        WORLD_VEHICLE_BICYCLE_BMX_VAGOS,
        WORLD_VEHICLE_BICYCLE_MOUNTAIN,
        WORLD_VEHICLE_BICYCLE_ROAD,
        WORLD_VEHICLE_BIKE_OFF_ROAD_RACE,
        WORLD_VEHICLE_BIKER,
        WORLD_VEHICLE_BOAT_IDLE,
        WORLD_VEHICLE_BOAT_IDLE_ALAMO,
        WORLD_VEHICLE_BOAT_IDLE_MARQUIS,
        WORLD_VEHICLE_BROKEN_DOWN,
        WORLD_VEHICLE_BUSINESSMEN,
        WORLD_VEHICLE_HELI_LIFEGUARD,
        WORLD_VEHICLE_CLUCKIN_BELL_TRAILER,
        WORLD_VEHICLE_CONSTRUCTION_SOLO,
        WORLD_VEHICLE_CONSTRUCTION_PASSENGERS,
        WORLD_VEHICLE_DRIVE_PASSENGERS,
        WORLD_VEHICLE_DRIVE_PASSENGERS_LIMITED,
        WORLD_VEHICLE_DRIVE_SOLO,
        WORLD_VEHICLE_FARM_WORKER,
        WORLD_VEHICLE_FIRE_TRUCK,
        WORLD_VEHICLE_EMPTY,
        WORLD_VEHICLE_MARIACHI,
        WORLD_VEHICLE_MECHANIC,
        WORLD_VEHICLE_MILITARY_PLANES_BIG,
        WORLD_VEHICLE_MILITARY_PLANES_SMALL,
        WORLD_VEHICLE_PARK_PARALLEL,
        WORLD_VEHICLE_PARK_PERPENDICULAR_NOSE_IN,
        WORLD_VEHICLE_PASSENGER_EXIT,
        WORLD_VEHICLE_POLICE_BIKE,
        WORLD_VEHICLE_POLICE_CAR,
        WORLD_VEHICLE_POLICE_NEXT_TO_CAR,
        WORLD_VEHICLE_QUARRY,
        WORLD_VEHICLE_SALTON,
        WORLD_VEHICLE_SALTON_DIRT_BIKE,
        WORLD_VEHICLE_SECURITY_CAR,
        WORLD_VEHICLE_STREETRACE,
        WORLD_VEHICLE_TOURBUS,
        WORLD_VEHICLE_TOURIST,
        WORLD_VEHICLE_TANDL,
        WORLD_VEHICLE_TRACTOR,
        WORLD_VEHICLE_TRACTOR_BEACH,
        WORLD_VEHICLE_TRUCK_LOGS,
        WORLD_VEHICLE_TRUCKS_TRAILERS,
        PROP_BIRD_IN_TREE,
        WORLD_VEHICLE_DISTANT_EMPTY_GROUND,
        PROP_BIRD_TELEGRAPH_POLE,
        PROP_HUMAN_ATM,
        PROP_HUMAN_BBQ,
        PROP_HUMAN_BUM_BIN,
        PROP_HUMAN_BUM_SHOPPING_CART,
        PROP_HUMAN_MUSCLE_CHIN_UPS,
        PROP_HUMAN_MUSCLE_CHIN_UPS_ARMY,
        PROP_HUMAN_MUSCLE_CHIN_UPS_PRISON,
        PROP_HUMAN_PARKING_METER,
        PROP_HUMAN_SEAT_ARMCHAIR,
        PROP_HUMAN_SEAT_BAR,
        PROP_HUMAN_SEAT_BENCH,
        PROP_HUMAN_SEAT_BENCH_FACILITY,
        PROP_HUMAN_SEAT_BENCH_DRINK,
        PROP_HUMAN_SEAT_BENCH_DRINK_FACILITY,
        PROP_HUMAN_SEAT_BENCH_DRINK_BEER,
        PROP_HUMAN_SEAT_BENCH_FOOD,
        PROP_HUMAN_SEAT_BENCH_FOOD_FACILITY,
        PROP_HUMAN_SEAT_BUS_STOP_WAIT,
        PROP_HUMAN_SEAT_CHAIR,
        PROP_HUMAN_SEAT_CHAIR_DRINK,
        PROP_HUMAN_SEAT_CHAIR_DRINK_BEER,
        PROP_HUMAN_SEAT_CHAIR_FOOD,
        PROP_HUMAN_SEAT_CHAIR_UPRIGHT,
        PROP_HUMAN_SEAT_CHAIR_MP_PLAYER,
        PROP_HUMAN_SEAT_COMPUTER,
        PROP_HUMAN_SEAT_COMPUTER_LOW,
        PROP_HUMAN_SEAT_DECKCHAIR,
        PROP_HUMAN_SEAT_DECKCHAIR_DRINK,
        PROP_HUMAN_SEAT_MUSCLE_BENCH_PRESS,
        PROP_HUMAN_SEAT_MUSCLE_BENCH_PRESS_PRISON,
        PROP_HUMAN_SEAT_SEWING,
        PROP_HUMAN_SEAT_STRIP_WATCH,
        PROP_HUMAN_SEAT_SUNLOUNGER,
        PROP_HUMAN_STAND_IMPATIENT,
        CODE_HUMAN_COWER,
        CODE_HUMAN_CROSS_ROAD_WAIT,
        CODE_HUMAN_PARK_CAR,
        PROP_HUMAN_MOVIE_BULB,
        PROP_HUMAN_MOVIE_STUDIO_LIGHT,
        CODE_HUMAN_MEDIC_KNEEL,
        CODE_HUMAN_MEDIC_TEND_TO_DEAD,
        CODE_HUMAN_MEDIC_TIME_OF_DEATH,
        CODE_HUMAN_POLICE_CROWD_CONTROL,
        CODE_HUMAN_POLICE_INVESTIGATE,
        CHAINING_ENTRY,
        CHAINING_EXIT,
        CODE_HUMAN_STAND_COWER,
        EAR_TO_TEXT,
        EAR_TO_TEXT_FAT,
        WORLD_LOOKAT_POINT
    }
	public enum PedTask
	{
		HandsUp = 0,
		ClimbLadder = 1,
		ExitVehicle = 2,
		CombatRoll = 3,
		AimGunOnFoot = 4,
		MovePlayer = 5,
		PlayerOnFoot = 6,
		Weapon = 8,
		PlayerWeapon = 9,
		PlayerIdles = 10,
		AimGun = 12,
		Complex = 12,
		FSMClone = 12,
		MotionBase = 12,
		Move = 12,
		MoveBase = 12,
		NMBehaviour = 12,
		NavBase = 12,
		Scenario = 12,
		SearchBase = 12,
		SearchInVehicleBase = 12,
		ShockingEvent = 12,
		TrainBase = 12,
		VehicleFSM = 12,
		VehicleGoTo = 12,
		VehicleMissionBase = 12,
		VehicleTempAction = 12,
		Pause = 14,
		DoNothing = 15,
		GetUp = 16,
		GetUpAndStandStill = 17,
		FallOver = 18,
		FallAndGetUp = 19,
		Crawl = 20,
		ComplexOnFire = 25,
		DamageElectric = 26,
		TriggerLookAt = 28,
		ClearLookAt = 29,
		SetCharDecisionMaker = 30,
		SetPedDefensiveArea = 31,
		UseSequence = 32,
		MoveStandStill = 34,
		ComplexControlMovement = 35,
		MoveSequence = 36,
		AmbientClips = 38,
		MoveInAir = 39,
		NetworkClone = 40,
		UseClimbOnRoute = 41,
		UseDropDownOnRoute = 42,
		UseLadderOnRoute = 43,
		SetBlockingOfNonTemporaryEvents = 44,
		ForceMotionState = 45,
		SlopeScramble = 46,
		GoToAndClimbLadder = 47,
		ClimbLadderFully = 48,
		Rappel = 49,
		Vault = 50,
		DropDown = 51,
		AffectSecondaryBehaviour = 52,
		AmbientLookAtEvent = 53,
		OpenDoor = 54,
		ShovePed = 55,
		SwapWeapon = 56,
		GeneralSweep = 57,
		Police = 58,
		PoliceOrderResponse = 59,
		PursueCriminal = 60,
		ArrestPed = 62,
		ArrestPed2 = 63,
		Busted = 64,
		FirePatrol = 65,
		HeliOrderResponse = 66,
		HeliPassengerRappel = 67,
		AmbulancePatrol = 68,
		PoliceWantedResponse = 69,
		Swat = 70,
		SwatWantedResponse = 72,
		SwatOrderResponse = 73,
		SwatGoToStagingArea = 74,
		SwatFollowInLine = 75,
		Witness = 76,
		GangPatrol = 77,
		Army = 78,
		ShockingEventWatch = 80,
		ShockingEventGoto = 82,
		ShockingEventHurryAway = 83,
		ShockingEventReactToAircraft = 84,
		ShockingEventReact = 85,
		ShockingEventBackAway = 86,
		ShockingPoliceInvestigate = 87,
		ShockingEventStopAndStare = 88,
		ShockingNiceCarPicture = 89,
		ShockingEventThreatResponse = 90,
		TakeOffHelmet = 92,
		CarReactToVehicleCollision = 93,
		CarReactToVehicleCollisionGetOut = 95,
		DyingDead = 97,
		WanderingScenario = 100,
		WanderingInRadiusScenario = 101,
		MoveBetweenPointsScenario = 103,
		ChatScenario = 104,
		CowerScenario = 106,
		DeadBodyScenario = 107,
		SayAudio = 114,
		WaitForSteppingOut = 116,
		CoupleScenario = 117,
		UseScenario = 118,
		UseVehicleScenario = 119,
		Unalerted = 120,
		StealVehicle = 121,
		ReactToPursuit = 122,
		HitWall = 125,
		Cower = 126,
		Crouch = 127,
		Melee = 128,
		MoveMeleeMovement = 129,
		MeleeActionResult = 130,
		MeleeUpperbodyAnims = 131,
		MoVEScripted = 133,
		ScriptedAnimation = 134,
		SynchronizedScene = 135,
		ComplexEvasiveStep = 137,
		WalkRoundCarWhileWandering = 138,
		ComplexStuckInAir = 140,
		WalkRoundEntity = 141,
		MoveWalkRoundVehicle = 142,
		ReactToGunAimedAt = 144,
		DuckAndCover = 146,
		AggressiveRubberneck = 147,
		InVehicleBasic = 150,
		CarDriveWander = 151,
		LeaveAnyCar = 152,
		ComplexGetOffBoat = 153,
		CarSetTempAction = 155,
		BringVehicleToHalt = 156,
		CarDrive = 157,
		PlayerDrive = 159,
		EnterVehicle = 160,
		EnterVehicleAlign = 161,
		OpenVehicleDoorFromOutside = 162,
		EnterVehicleSeat = 163,
		CloseVehicleDoorFromInside = 164,
		InVehicleSeatShuffle = 165,
		ExitVehicleSeat = 167,
		CloseVehicleDoorFromOutside = 168,
		ControlVehicle = 169,
		MotionInAutomobile = 170,
		MotionOnBicycle = 171,
		MotionOnBicycleController = 172,
		MotionInVehicle = 173,
		MotionInTurret = 174,
		ReactToBeingJacked = 175,
		ReactToBeingAskedToLeaveVehicle = 176,
		TryToGrabVehicleDoor = 177,
		GetOnTrain = 178,
		GetOffTrain = 179,
		RideTrain = 180,
		MountThrowProjectile = 190,
		GoToCarDoorAndStandStill = 195,
		MoveGoToVehicleDoor = 196,
		SetPedInVehicle = 197,
		SetPedOutOfVehicle = 198,
		VehicleMountedWeapon = 199,
		VehicleGun = 200,
		VehicleProjectile = 201,
		SmashCarWindow = 204,
		MoveGoToPoint = 205,
		MoveAchieveHeading = 206,
		MoveFaceTarget = 207,
		ComplexGoToPointAndStandStillTimed = 208,
		MoveGoToPointAndStandStill = 208,
		MoveFollowPointRoute = 209,
		MoveSeekEntity_CEntitySeekPosCalculatorStandard = 210,
		MoveSeekEntity_CEntitySeekPosCalculatorLastNavMeshIntersection = 211,
		MoveSeekEntity_CEntitySeekPosCalculatorLastNavMeshIntersection2 = 212,
		MoveSeekEntity_CEntitySeekPosCalculatorXYOffsetFixed = 213,
		MoveSeekEntity_CEntitySeekPosCalculatorXYOffsetFixed2 = 214,
		ExhaustedFlee = 215,
		GrowlAndFlee = 216,
		ScenarioFlee = 217,
		SmartFlee = 218,
		FlyAway = 219,
		WalkAway = 220,
		Wander = 221,
		WanderInArea = 222,
		FollowLeaderInFormation = 223,
		GoToPointAnyMeans = 224,
		TurnToFaceEntityOrCoord = 225,
		FollowLeaderAnyMeans = 226,
		FlyToPoint = 228,
		FlyingWander = 229,
		GoToPointAiming = 230,
		GoToScenario = 231,
		SeekEntityAiming = 233,
		SlideToCoord = 234,
		SwimmingWander = 235,
		MoveTrackingEntity = 237,
		MoveFollowNavMesh = 238,
		MoveGoToPointOnRoute = 239,
		EscapeBlast = 240,
		MoveWander = 241,
		MoveBeInFormation = 242,
		MoveCrowdAroundLocation = 243,
		MoveCrossRoadAtTrafficLights = 244,
		MoveWaitForTraffic = 245,
		MoveGoToPointStandStillAchieveHeading = 246,
		MoveGetOntoMainNavMesh = 251,
		MoveSlideToCoord = 252,
		MoveGoToPointRelativeToEntityAndStandStill = 253,
		HelicopterStrafe = 254,
		GetOutOfWater = 256,
		MoveFollowEntityOffset = 259,
		FollowWaypointRecording = 261,
		MotionPed = 264,
		MotionPedLowLod = 265,
		HumanLocomotion = 268,
		MotionBasicLocomotionLowLod = 269,
		MotionStrafing = 270,
		MotionTennis = 271,
		MotionAiming = 272,
		BirdLocomotion = 273,
		FlightlessBirdLocomotion = 274,
		FishLocomotion = 278,
		QuadLocomotion = 279,
		MotionDiving = 280,
		MotionSwimming = 281,
		MotionParachuting = 282,
		MotionDrunk = 283,
		RepositionMove = 284,
		MotionAimingTransition = 285,
		ThrowProjectile = 286,
		Cover = 287,
		MotionInCover = 288,
		AimAndThrowProjectile = 289,
		Gun = 290,
		AimFromGround = 291,
		AimGunVehicleDriveBy = 295,
		AimGunScripted = 296,
		ReloadGun = 298,
		WeaponBlocked = 299,
		EnterCover = 300,
		ExitCover = 301,
		AimGunFromCoverIntro = 302,
		AimGunFromCoverOutro = 303,
		AimGunBlindFire = 304,
		CombatClosestTargetInArea = 307,
		CombatAdditionalTask = 308,
		InCover = 309,
		AimSweep = 313,
		SharkCircle = 319,
		SharkAttack = 320,
		Agitated = 321,
		AgitatedAction = 322,
		Confront = 323,
		Intimidate = 324,
		Shove = 325,
		Shoved = 326,
		CrouchToggle = 328,
		Revive = 329,
		Parachute = 335,
		ParachuteObject = 336,
		TakeOffPedVariation = 337,
		CombatSeekCover = 340,
		CombatFlank = 342,
		Combat = 343,
		CombatMounted = 344,
		MoveCircle = 345,
		MoveCombatMounted = 346,
		Search = 347,
		SearchOnFoot = 348,
		SearchInAutomobile = 349,
		SearchInBoat = 350,
		SearchInHeli = 351,
		ThreatResponse = 352,
		Investigate = 353,
		StandGuardFSM = 354,
		Patrol = 355,
		ShootAtTarget = 356,
		SetAndGuardArea = 357,
		StandGuard = 358,
		Separate = 359,
		StayInCover = 360,
		VehicleCombat = 361,
		VehiclePersuit = 362,
		VehicleChase = 363,
		DraggingToSafety = 364,
		DraggedToSafety = 365,
		VariedAimPose = 366,
		MoveWithinAttackWindow = 367,
		MoveWithinDefensiveArea = 368,
		ShootOutTire = 369,
		ShellShocked = 370,
		BoatChase = 371,
		BoatCombat = 372,
		BoatStrafe = 373,
		HeliChase = 374,
		HeliCombat = 375,
		SubmarineCombat = 376,
		SubmarineChase = 377,
		PlaneChase = 378,
		TargetUnreachable = 379,
		TargetUnreachableInInterior = 380,
		TargetUnreachableInExterior = 381,
		StealthKill = 382,
		Writhe = 383,
		Advance = 384,
		Charge = 385,
		MoveToTacticalPoint = 386,
		ToHurtTransit = 387,
		AnimatedHitByExplosion = 388,
		NMRelax = 389,
		NMPose = 391,
		NMBrace = 392,
		NMBuoyancy = 393,
		NMInjuredOnGround = 394,
		NMShot = 395,
		NMHighFall = 396,
		NMBalance = 397,
		NMElectrocute = 398,
		NMPrototype = 399,
		NMExplosion = 400,
		NMOnFire = 401,
		NMScriptControl = 402,
		NMJumpRollFromRoadVehicle = 403,
		NMFlinch = 404,
		NMSit = 405,
		NMFallDown = 406,
		BlendFromNM = 407,
		NMControl = 408,
		NMDangle = 409,
		NMGenericAttach = 412,
		NMDraggingToSafety = 414,
		NMThroughWindscreen = 415,
		NMRiverRapids = 416,
		NMSimple = 417,
		RageRagdoll = 418,
		JumpVault = 421,
		Jump = 422,
		Fall = 423,
		ReactAimWeapon = 425,
		Chat = 426,
		MobilePhone = 427,
		ReactToDeadPed = 428,
		SearchForUnknownThreat = 430,
		Bomb = 432,
		Detonator = 433,
		AnimatedAttach = 435,
		CutScene = 441,
		ReactToExplosion = 442,
		ReactToImminentExplosion = 443,
		DiveToGround = 444,
		ReactAndFlee = 445,
		Sidestep = 446,
		CallPolice = 447,
		ReactInDirection = 448,
		ReactToBuddyShot = 449,
		VehicleGoToAutomobileNew = 454,
		VehicleGoToPlane = 455,
		VehicleGoToHelicopter = 456,
		VehicleGoToSubmarine = 457,
		VehicleGoToBoat = 458,
		VehicleGoToPointAutomobile = 459,
		VehicleGoToPointWithAvoidanceAutomobile = 460,
		VehiclePursue = 461,
		VehicleRam = 462,
		VehicleSpinOut = 463,
		VehicleApproach = 464,
		VehicleThreePointTurn = 465,
		VehicleDeadDriver = 466,
		VehicleCruiseNew = 467,
		VehicleCruiseBoat = 468,
		VehicleStop = 469,
		VehiclePullOver = 470,
		VehiclePassengerExit = 471,
		VehicleFlee = 472,
		VehicleFleeAirborne = 473,
		VehicleFleeBoat = 474,
		VehicleFollowRecording = 475,
		VehicleFollow = 476,
		VehicleBlock = 477,
		VehicleBlockCruiseInFront = 478,
		VehicleBlockBrakeInFront = 479,
		VehicleBlockBackAndForth = 478,
		VehicleCrash = 481,
		VehicleLand = 482,
		VehicleLandPlane = 483,
		VehicleHover = 484,
		VehicleAttack = 485,
		VehicleAttackTank = 486,
		VehicleCircle = 487,
		VehiclePoliceBehaviour = 488,
		VehiclePoliceBehaviourHelicopter = 489,
		VehiclePoliceBehaviourBoat = 490,
		VehicleEscort = 491,
		VehicleHeliProtect = 492,
		VehiclePlayerDriveAutomobile = 494,
		VehiclePlayerDriveBike = 495,
		VehiclePlayerDriveBoat = 496,
		VehiclePlayerDriveSubmarine = 497,
		VehiclePlayerDriveSubmarineCar = 498,
		VehiclePlayerDriveAmphibiousAutomobile = 499,
		VehiclePlayerDrivePlane = 500,
		VehiclePlayerDriveHeli = 501,
		VehiclePlayerDriveAutogyro = 502,
		VehiclePlayerDriveDiggerArm = 503,
		VehiclePlayerDriveTrain = 504,
		VehiclePlaneChase = 505,
		VehicleNoDriver = 506,
		VehicleAnimation = 507,
		VehicleConvertibleRoof = 508,
		VehicleParkNew = 509,
		VehicleFollowWaypointRecording = 510,
		VehicleGoToNavmesh = 511,
		VehicleReactToCopSiren = 512,
		VehicleGotoLongRange = 513,
		VehicleWait = 514,
		VehicleReverse = 515,
		VehicleBrake = 516,
		VehicleHandBrake = 517,
		VehicleTurn = 518,
		VehicleGoForward = 519,
		VehicleSwerve = 520,
		VehicleFlyDirection = 521,
		VehicleHeadonCollision = 522,
		VehicleBoostUseSteeringAngle = 523,
		VehicleShotTire = 524,
		VehicleBurnout = 525,
		VehicleRevEngine = 526,
		VehicleSurfaceInSubmarine = 527,
		VehiclePullAlongside = 528,
		VehicleTransformToSubmarine = 529,
		AnimatedFallback = 530
	};

}
