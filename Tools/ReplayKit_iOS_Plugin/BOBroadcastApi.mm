//
//  BOBroadcastApi.m
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#import "BOBroadcastApi.h"
#import "BOBroadcastWrapper.h"

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
    return [[[BOBroadcastWrapper Instance] BroadcastURL] UTF8String];
}

const char *BOBroadcastServiceBundleID()
{
    return [[[BOBroadcastWrapper Instance] BroadcastServiceBundleID] UTF8String];
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
