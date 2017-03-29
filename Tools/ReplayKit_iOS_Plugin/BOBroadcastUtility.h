//
//  BOBroadcastUtility.h
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/28.
//
//

#ifndef BOBroadcastUtility_h
#define BOBroadcastUtility_h

#import <Foundation/Foundation.h>

@interface  BOBroadcastUtility : NSObject

+(const char *)NSStringToChars:(NSString *)nsString;
+(const NSString *)GetUnitySendMessageGameObjectName;
+(void)SetError:(NSError *)error;
+(NSError *)GetError;
+(const char *)NSErrorToJson:(NSError *)error;

@end

#endif /* BOBroadcastUtility_h */
