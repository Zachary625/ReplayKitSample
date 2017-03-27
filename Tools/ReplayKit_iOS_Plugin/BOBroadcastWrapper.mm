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
    return false;
}

-(bool)BroadcastStreaming
{
    return false;
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

-(NSString *)BroadcastServiceBundleID
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
        if(nil != error) {
            NSLog(@" @ BOBroadcastWrapper.BOBroadcastStart: RPBroadcastActivityViewContrller.loadBroadcastActivityViewControllerWithHandler with error %@", error.domain);
            return;
        }
        
        broadcastActivityViewController.delegate = _m_broadcastObserver;
        [UnityGetGLViewController() presentViewController:broadcastActivityViewController animated:YES completion:^{
        }];
    }];
}

-(bool)BroadcastStart
{
    [[_m_broadcastObserver m_broadcastController] startBroadcastWithHandler:^(NSError * _Nullable error) {
    }];
    
    return true;
}

-(bool)BroadcastPause
{
    [[_m_broadcastObserver m_broadcastController] finishBroadcastWithHandler:^(NSError * _Nullable error) {
    }];
    return true;
}

-(bool)BroadcastResume
{
    [[_m_broadcastObserver m_broadcastController] resumeBroadcast];
    return true;
}

-(bool)BroadcastFinish
{
    [[_m_broadcastObserver m_broadcastController] pauseBroadcast];
    return true;
}

-(bool)GetUseCam
{
    return false;
}

-(bool)SetUseCam:(bool)useCam
{
    return false;
}

-(bool)GetUseMic
{
    return false;
}

-(bool)SetUseMic:(bool)useMic
{
    return false;
}


@end
