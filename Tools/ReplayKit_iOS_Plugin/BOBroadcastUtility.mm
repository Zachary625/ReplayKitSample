//
//  BOBroadcastUtility.mm
//  Unity-iPhone
//
//  Created by zhang.chi on 17/3/28.
//
//

#import "BOBroadcastUtility.h"
#import <string>
static NSError * s_BOBroadcastError;

@implementation BOBroadcastUtility

+(const char *)NSStringToChars:(NSString *)nsString
{
    if(nil == nsString)
    {
        return nil;
    }
    std::string stdString = [nsString UTF8String];
    if(stdString.size() <= 0)
    {
        return nil;
    }
    
    char *chars = new char[stdString.size() + 1];
    memset(chars, 0, stdString.size() + 1);
    memcpy(chars, stdString.data(), stdString.size());
    return chars;
}


+(const NSString *)GetUnitySendMessageGameObjectName
{
    return @"GameClient";
}

+(void)SetError:(NSError *)error
{
    s_BOBroadcastError = error;
}

+(NSError *)GetError
{
    return s_BOBroadcastError;
}

+(const char *)NSErrorToJson:(NSError *)error
{
    if(nil == error)
    {
        return nil;
    }
    NSMutableDictionary *errorJsonData = [NSMutableDictionary dictionary];
    errorJsonData[@"code"] = @(error.code);
    errorJsonData[@"description"] = error.description;
    errorJsonData[@"localizedDescription"] = error.localizedDescription;
    errorJsonData[@"localizedFailureReason"] = error.localizedFailureReason;
    errorJsonData[@"localizedRecoverySuggestion"] = error.localizedRecoverySuggestion;
    errorJsonData[@"localizedRecoveryOptions"] = error.localizedRecoveryOptions;
    errorJsonData[@"helpAnchor"] = error.helpAnchor;
    
    NSData *data = [NSJSONSerialization dataWithJSONObject:errorJsonData options:NSJSONWritingPrettyPrinted error:nil];
    NSString *strJson = [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
    return [BOBroadcastUtility NSStringToChars:strJson];
}

@end

