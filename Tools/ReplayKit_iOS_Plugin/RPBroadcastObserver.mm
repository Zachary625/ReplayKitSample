//
//  RPBroadcastObserver.mm
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#import <Foundation/Foundation.h>
#import "RPBroadcastObserver.h"
#import "BOBroadcastUtility.h"

@implementation RPBroadcastObserver
-(void)broadcastActivityViewController:(RPBroadcastActivityViewController *)broadcastActivityViewController didFinishWithBroadcastController:(RPBroadcastController *)broadcastController error:(NSError *)error
{
    NSLog(@" @ RPBroadcastObserver.didFinishWithBroadcastController");
    [BOBroadcastUtility SetError:error];
    self.m_broadcastController = broadcastController;
    
    [broadcastActivityViewController dismissViewControllerAnimated:YES completion:^{
        UnitySendMessage("GameClient", "BOBroadcast_OnServiceSelected", "");
    }];
}

-(void)broadcastController:(RPBroadcastController *)broadcastController didUpdateServiceInfo:(NSDictionary<NSString *,NSObject<NSCoding> *> *)serviceInfo
{
    NSLog(@" @ RPBroadcastObserver.didUpdateServiceInfo()");
}

-(void)broadcastController:(RPBroadcastController *)broadcastController didFinishWithError:(NSError *)error
{
    NSLog(@" @ RPBroadcastObserver.didFinishWithError");
    [BOBroadcastUtility SetError:error];
    self.m_broadcastController = nil;
    UnitySendMessage("GameClient", "BOBroadcast_OnBroadcastFinished", "");
}
@end
