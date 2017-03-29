//
//  BOBroadcastWrapper.h
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#ifndef BOBroadcastWrapper_h
#define BOBroadcastWrapper_h

#import <Foundation/Foundation.h>
#import "RPBroadcastObserver.h"

@interface BOBroadcastWrapper : NSObject

+ (BOBroadcastWrapper*)Instance;

@property (strong, nonatomic) RPBroadcastObserver *m_broadcastObserver;

-(bool)SelectService;

-(bool)BroadcastAvailable;
-(bool)Broadcasting;
-(bool)BroadcastStreaming;
-(NSString *)BroadcastURL;
-(NSString *)ServiceBundleID;
-(bool)BroadcastStart;
-(bool)BroadcastPause;
-(bool)BroadcastResume;
-(bool)BroadcastFinish;
-(bool)GetUseCam;
-(bool)SetUseCam:(bool)useCam;
-(bool)GetUseMic;
-(bool)SetUseMic:(bool)useMic;

@end

#endif /* BOBroadcastWrapper_h */

