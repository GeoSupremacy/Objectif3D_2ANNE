#pragma once
#include <vector>
using namespace std;
static int indexfegersfvetzfsd = -1;
static vector<int> currenTab;
#define KEY  indexfegersfvetzfsd
#define DEFINE_KEY_SCREEN  \
KEY++;\
int _key = KEY;\
currenTab.push_back(_key);\

#define KEY_SCREEN currenTab[_key]

#define SCREEN_DEBUG( timeDisplay, color, message) DEFINE_KEY_SCREEN GEngine->AddOnScreenDebugMessage(KEY_SCREEN, timeDisplay, FColor::color, TEXT(message));
#define SCREEN_DEBUG_MESSAGE_ERROR( timeDisplay, message) DEFINE_KEY_SCREEN GEngine->AddOnScreenDebugMessage(KEY_SCREEN, timeDisplay, FColor::Red, message);
#define SCREEN_DEBUG_MESSAGE_WARNING( timeDisplay, message) DEFINE_KEY_SCREEN GEngine->AddOnScreenDebugMessage(KEY_SCREEN, timeDisplay, FColor::Yellow, message);


#define LOG_WARNING(message, ...) UE_LOG(LogTemp, Error, TEXT(message),__VA_ARGS__);
#define LOG_ERROR( message, ...) UE_LOG(LogTemp, Error, TEXT(message), __VA_ARGS__);