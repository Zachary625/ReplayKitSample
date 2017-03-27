//
//  BOBroadcastApi.h
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/27.
//
//

#ifndef BOBroadcastApi_h
#define BOBroadcastApi_h

#import <Foundation/Foundation.h>

#ifdef __cplusplus
extern "C" {
#endif
    bool BOBroadcastAvailable();
    bool BOBroadcasting();
    bool BOBroadcastStreaming();
    const char *BOBroadcastURL();
    const char *BOBroadcastServiceBundleID();
    bool BOBroadcastSelectService();
    bool BOBroadcastStart();
    bool BOBroadcastFinish();
    bool BOBroadcastPause();
    bool BOBroadcastResume();
#ifdef __cplusplus
}
#endif

#endif /* BOBroadcastApi_h */
