#pragma once
#include <vector>
using namespace std;
static int indexfegersfvetzfsd = -1;
static vector<int> currenTab;
#define KEY  indexfegersfvetzfsd
#define DEFINE_KEY_SCREEN(value)  currenTab.push_back(value);
#define KEY_SCREEN(key) currenTab[key]

#define SCREEN_DEBUG(key, timeDisplay, color, message) GEngine->AddOnScreenDebugMessage(key, timeDisplay, FColor::color, TEXT(message));
#define SCREEN_DEBUG_MESSAGE_ERROR(key, timeDisplay, message) GEngine->AddOnScreenDebugMessage(key, timeDisplay, FColor::Red, message);
#define SCREEN_DEBUG_MESSAGE_WARNING(key, timeDisplay, message) GEngine->AddOnScreenDebugMessage(key, timeDisplay, FColor::Yellow, TEXT(message));