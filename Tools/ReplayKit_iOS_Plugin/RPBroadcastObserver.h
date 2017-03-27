//
//  RPBroadcastObserver.h
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#ifndef RPBroadcastObserver_h
#define RPBroadcastObserver_h

#import <ReplayKit/ReplayKit.h>

@interface RPBroadcastObserver : NSObject<RPBroadcastActivityViewControllerDelegate, RPBroadcastControllerDelegate>

@property (strong, nonatomic) RPBroadcastController *m_broadcastController;

@end

#endif /* RPBroadcastObserver_h */
