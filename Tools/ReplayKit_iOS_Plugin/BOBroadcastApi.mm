//
//  BOBroadcastApi.mm
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#import "BOBroadcastApi.h"
#import "BOBroadcastWrapper.h"
#import "BOBroadcastUtility.h"

void BOBroadcastClearError()
{
    [BOBroadcastUtility SetError:nil];
}

const char *BOBroadcastGetError()
{
    return [BOBroadcastUtility NSErrorToJson:[BOBroadcastUtility GetError]];
}

bool BOBroadcastAvailable()
{
    return [[BOBroadcastWrapper Instance] BroadcastAvailable];
}

bool BOBroadcasting()
{
    return [[BOBroadcastWrapper Instance] Broadcasting];
}

bool BOBroadcastStreaming()
{
    return [[BOBroadcastWrapper Instance] BroadcastStreaming];
}

const char *BOBroadcastURL()
{
    return [BOBroadcastUtility NSStringToChars:[[BOBroadcastWrapper Instance] BroadcastURL]];
}

const char *BOBroadcastServiceBundleID()
{
    return [BOBroadcastUtility NSStringToChars:[[BOBroadcastWrapper Instance] ServiceBundleID]];
}

bool BOBroadcastSelectService()
{
    return [[BOBroadcastWrapper Instance] SelectService];
}

bool BOBroadcastStart()
{
    return [[BOBroadcastWrapper Instance] BroadcastStart];
}

bool BOBroadcastFinish()
{
    return [[BOBroadcastWrapper Instance] BroadcastFinish];
}

bool BOBroadcastPause()
{
    return [[BOBroadcastWrapper Instance] BroadcastPause];
}

bool BOBroadcastResume()
{
    return [[BOBroadcastWrapper Instance] BroadcastResume];
}

void BOBroadcastSetUseCam(bool useCam)
{
    [[BOBroadcastWrapper Instance] SetUseCam:useCam];
}

bool BOBroadcastGetUseCam()
{
    return [[BOBroadcastWrapper Instance] GetUseCam];
}

void BOBroadcastSetUseMic(bool useMic)
{
    [[BOBroadcastWrapper Instance] SetUseMic:useMic];
}

bool BOBroadcastGetUseMic()
{
    return [[BOBroadcastWrapper Instance] GetUseMic];
}


