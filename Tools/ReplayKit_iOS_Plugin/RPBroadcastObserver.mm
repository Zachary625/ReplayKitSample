//
//  RPBroadcastObserver.mm
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#import <Foundation/Foundation.h>
#import "RPBroadcastObserver.h"

@implementation RPBroadcastObserver
-(void)broadcastActivityViewController:(RPBroadcastActivityViewController *)broadcastActivityViewController didFinishWithBroadcastController:(RPBroadcastController *)broadcastController error:(NSError *)error
{
    if(nil != error)
    {
        NSLog(@"RPBroadcastObserver.didFinishWithBroadcastController(): error: %@", error.domain);
    }
    
    self.m_broadcastController = broadcastController;
    
    [broadcastActivityViewController dismissViewControllerAnimated:YES completion:^{
        // TODO UnitySendMessage
    }];
}

-(void)broadcastController:(RPBroadcastController *)broadcastController didUpdateServiceInfo:(NSDictionary<NSString *,NSObject<NSCoding> *> *)serviceInfo
{
}

-(void)broadcastController:(RPBroadcastController *)broadcastController didFinishWithError:(NSError *)error
{
}
@end
