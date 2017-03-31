//
//  BOBroadcastWrapper.mm
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#import <Foundation/Foundation.h>
#import <ReplayKit/ReplayKit.h>
#import "BOBroadcastWrapper.h"
#import "BOBroadcastUtility.h"

static BOBroadcastWrapper* s_BOBroadcastWrapper = nil;

@implementation BOBroadcastWrapper

+ (BOBroadcastWrapper*)Instance
{
    if (s_BOBroadcastWrapper == nil)
    {
        s_BOBroadcastWrapper = [[BOBroadcastWrapper alloc] init];
    }
    
    return s_BOBroadcastWrapper;
}

- (id)init
{
    if(nil != self)
    {
        _m_broadcastObserver = [[RPBroadcastObserver alloc] init];
    }
    return self;
}

-(bool)BroadcastAvailable
{
    return true;
}

-(bool)Broadcasting
{
    if(nil == _m_broadcastObserver)
    {
        return false;
    }
    if(nil == [_m_broadcastObserver m_broadcastController])
    {
        return false;
    }
    return [[_m_broadcastObserver m_broadcastController] isBroadcasting];
}

-(bool)BroadcastStreaming
{
    if(nil == _m_broadcastObserver)
    {
        return false;
    }
    if(nil == [_m_broadcastObserver m_broadcastController])
    {
        return false;
    }
    return ![[_m_broadcastObserver m_broadcastController] isPaused];
}

-(NSString *)BroadcastURL
{
    if(nil != _m_broadcastObserver)
    {
        if(nil != [_m_broadcastObserver m_broadcastController])
        {
            return [[_m_broadcastObserver m_broadcastController] broadcastURL].absoluteString;
        }
    }
    return nil;
}

-(NSString *)ServiceBundleID
{
    if(nil != _m_broadcastObserver)
    {
        if(nil != [_m_broadcastObserver m_broadcastController])
        {
            return [[_m_broadcastObserver m_broadcastController] broadcastExtensionBundleID];
        }
    }
    return nil;
}

-(bool)SelectService
{
    [RPBroadcastActivityViewController loadBroadcastActivityViewControllerWithHandler:^(RPBroadcastActivityViewController * _Nullable broadcastActivityViewController, NSError * _Nullable error) {
        [BOBroadcastUtility SetError: error];
        UnitySendMessage("GameClient", "BOBroadcast_OnServicesLoaded", "");
        if(nil != error)
        {
            return;
        }
        broadcastActivityViewController.delegate = _m_broadcastObserver;
        [UnityGetGLViewController() presentViewController:broadcastActivityViewController animated:YES completion:^{
        }];
    }];
    return true;
}

-(bool)BroadcastStart
{
    if(nil == _m_broadcastObserver)
    {
        return false;
    }
    if(nil == [_m_broadcastObserver m_broadcastController])
    {
        return false;
    }

    [[_m_broadcastObserver m_broadcastController] startBroadcastWithHandler:^(NSError * _Nullable error) {
        [BOBroadcastUtility SetError: error];
        UnitySendMessage("GameClient", "BOBroadcast_OnStarted", "");
        if(nil != error)
        {
            return;
        }
        if(nil == [RPScreenRecorder sharedRecorder])
        {
            NSLog(@"[RPScreenRecorder sharedRecorder] == nil");
            return;
        }
        if(false == [[RPScreenRecorder sharedRecorder] isCameraEnabled])
        {
            NSLog(@"[[RPScreenRecorder sharedRecorder] isCameraEnabled] == false");
            return;
        }
        if(nil == [RPScreenRecorder sharedRecorder].cameraPreviewView)
        {
            NSLog(@"[RPScreenRecorder sharedRecorder].cameraPreviewView == nil");
            return;
        }
        if(CGRectIsNull(_m_CamViewRect))
        {
            NSLog(@"CGRectIsNull(_m_CamViewRect)");
            return;
        }
        [[RPScreenRecorder sharedRecorder].cameraPreviewView setFrame:_m_CamViewRect];
        [RPScreenRecorder sharedRecorder]
        
        [UnityGetGLView() addSubview:[RPScreenRecorder sharedRecorder].cameraPreviewView];
    }];
    
    return true;
}

-(bool)BroadcastFinish
{
    
    if(nil == _m_broadcastObserver)
    {
        return false;
    }
    if(nil == [_m_broadcastObserver m_broadcastController])
    {
        return false;
    }
    
    [[_m_broadcastObserver m_broadcastController] finishBroadcastWithHandler:^(NSError * _Nullable error) {
        [BOBroadcastUtility SetError: error];
        UnitySendMessage("GameClient", "BOBroadcast_OnFinished", "");
    }];
    return true;
}

-(bool)BroadcastResume
{

    if(nil == _m_broadcastObserver)
    {
        return false;
    }
    if(nil == [_m_broadcastObserver m_broadcastController])
    {
        return false;
    }
    
    [[_m_broadcastObserver m_broadcastController] resumeBroadcast];
    return true;
}

-(bool)BroadcastPause
{

    if(nil == _m_broadcastObserver)
    {
        return false;
    }
    if(nil == [_m_broadcastObserver m_broadcastController])
    {
        return false;
    }

    [[_m_broadcastObserver m_broadcastController] pauseBroadcast];
    return true;
}

-(bool)GetUseCam
{
    if(nil == [RPScreenRecorder sharedRecorder])
    {
        return false;
    }
    return [[RPScreenRecorder sharedRecorder] isCameraEnabled];
}

-(bool)SetUseCam:(bool)useCam
{
    if(nil == [RPScreenRecorder sharedRecorder])
    {
        return false;
    }
    [[RPScreenRecorder sharedRecorder] setCameraEnabled:useCam];
    return true;
}

-(bool)GetUseMic
{
    if(nil == [RPScreenRecorder sharedRecorder])
    {
        return false;
    }
    return [[RPScreenRecorder sharedRecorder] isMicrophoneEnabled];
}

-(bool)SetUseMic:(bool)useMic
{
    if(nil == [RPScreenRecorder sharedRecorder])
    {
        return false;
    }
    [[RPScreenRecorder sharedRecorder] setMicrophoneEnabled:useMic];
    return true;
}

-(bool)SetCamViewRect:(CGRect)rect
{
    _m_CamViewRect = rect;
    return true;
}

-(CGRect)GetCamViewRect
{
    return _m_CamViewRect;
}


@end
